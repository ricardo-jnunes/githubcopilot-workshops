using System.IO;
using Microsoft.Extensions.Configuration;
using NSubstitute;
using Library.ApplicationCore;
using Library.Infrastructure.Data;
using System.Collections.Generic;
using Library.ApplicationCore.Entities;
using Xunit;

namespace Library.UnitTests.Infrastructure.JsonLoanRepositoryTests;

public class GetLoan
{
	private readonly ILoanRepository _mockLoanRepository;
	private readonly JsonLoanRepository _jsonLoanRepository;
	private readonly IConfiguration _configuration;
	private readonly JsonData _jsonData;

	public GetLoan()
	{
		_mockLoanRepository = Substitute.For<ILoanRepository>();

		// Locate the repo Json folder by walking parent directories
		var current = new DirectoryInfo(Directory.GetCurrentDirectory());
		string? jsonDir = null;
		while (current != null)
		{
			var candidate = Path.Combine(current.FullName, "src", "Library.Console", "Json");
			if (Directory.Exists(candidate))
			{
				jsonDir = candidate;
				break;
			}
			current = current.Parent!;
		}
		if (jsonDir == null)
		{
			throw new DirectoryNotFoundException("Could not locate src/Library.Console/Json folder in parent paths.");
		}
		var inMemory = new Dictionary<string, string>
		{
			{"JsonPaths:Authors", Path.Combine(jsonDir, "Authors.json")},
			{"JsonPaths:Books", Path.Combine(jsonDir, "Books.json")},
			{"JsonPaths:BookItems", Path.Combine(jsonDir, "BookItems.json")},
			{"JsonPaths:Patrons", Path.Combine(jsonDir, "Patrons.json")},
			{"JsonPaths:Loans", Path.Combine(jsonDir, "Loans.json")},
		};

		_configuration = new ConfigurationBuilder()
			.AddInMemoryCollection(inMemory)
			.Build();

		_jsonData = new JsonData(_configuration);
		_jsonLoanRepository = new JsonLoanRepository(_jsonData);
	}

	[Fact(DisplayName = "JsonLoanRepository.GetLoan: Returns loan when ID exists")]
	public async Task GetLoan_ReturnsLoan_WhenIdExists()
	{
		// Arrange
		var loanId = 1; // exists in src/Library.Console/Json/Loans.json
		var expectedLoan = new Loan { Id = loanId };
		_mockLoanRepository.GetLoan(loanId).Returns(expectedLoan);

		// Act
		var actualLoan = await _jsonLoanRepository.GetLoan(loanId);

		// Assert
		Assert.NotNull(actualLoan);
		Assert.Equal(expectedLoan.Id, actualLoan!.Id);
	}

    [Fact(DisplayName = "JsonLoanRepository.GetLoan: Returns null when ID does not exist")]
    public async Task GetLoan_ReturnsNull_WhenIdDoesNotExist()
    {
        // Arrange
        var loanId = 9999; // does not exist in src/Library.Console/Json/Loans.json
        _mockLoanRepository.GetLoan(loanId).Returns((Loan?)null);

        // Act
        var actualLoan = await _jsonLoanRepository.GetLoan(loanId);

        // Assert
        Assert.Null(actualLoan);
    }
}
