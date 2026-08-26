using Library.ApplicationCore.Entities;
using Library.Infrastructure.Data;
using Microsoft.Extensions.Configuration;

namespace Library.UnitTests.Infrastructure.JsonDataTests;

public class GetPopulatedLoan
{
    [Fact(DisplayName = "JsonData.GetPopulatedLoan: Leaves missing related entities null")]
    public void GetPopulatedLoan_LeavesMissingRelatedEntitiesNull()
    {
        // Arrange
        var configuration = new ConfigurationBuilder().Build();
        var jsonData = new JsonData(configuration)
        {
            BookItems = new List<BookItem>(),
            Patrons = new List<Patron>()
        };
        var loan = new Loan
        {
            Id = 1,
            BookItemId = 9999,
            PatronId = 9999
        };

        // Act
        var populatedLoan = jsonData.GetPopulatedLoan(loan);

        // Assert
        Assert.NotNull(populatedLoan);
        Assert.Equal(loan.Id, populatedLoan.Id);
        Assert.Null(populatedLoan.BookItem);
        Assert.Null(populatedLoan.Patron);
    }
    
    
}

