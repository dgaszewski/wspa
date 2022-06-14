using ClassLibrary1;
using Moq;
using System;
using Xunit;

namespace TestProject1
{
    public class UnitTest1
    { 
        [Fact]
        public void Test1()
        {
            // Arrange
            IExchangeRateService sut = new ExchangeRateService(null);
            decimal amount = 10;
            decimal currencyRate = 4;
            decimal expectedResult = 40;

            // Act
            decimal result = sut.CalculateAmount(amount, currencyRate);

            // Assert 
            Assert.Equal(expectedResult, result);

        }

        [Fact]
        public void Test2()
        {
            // Arrange
            var loggerMock = new Mock<ILogger>(); 
            IExchangeRateService sut = new ExchangeRateService(loggerMock.Object); 
            decimal amount = -3;
            decimal currencyRate = 4;
              
            // Act
            decimal result = sut.CalculateAmount(amount, currencyRate);

            // Assert
            loggerMock.Verify(x=>x.LogError(It.IsAny<string>()), Times.Once); 
        }
    }

    
}
