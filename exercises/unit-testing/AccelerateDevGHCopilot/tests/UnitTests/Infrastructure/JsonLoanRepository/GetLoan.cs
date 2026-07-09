using System.IO;
using Microsoft.Extensions.Configuration;
using NSubstitute;
using Library.ApplicationCore;
using Library.Infrastructure.Data;
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

		_configuration = new ConfigurationBuilder()
			.SetBasePath(Directory.GetCurrentDirectory())
			.AddJsonFile("appSettings.json")
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
}
