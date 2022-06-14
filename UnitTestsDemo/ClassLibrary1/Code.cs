using System;

namespace ClassLibrary1
{
    public class ExchangeRateService : IExchangeRateService
    {
        private ILogger logger;

        public ExchangeRateService(ILogger logger)
        {
            this.logger = logger;
        }


        public decimal CalculateAmount(decimal amount, decimal currencyRate)
        {
            if (amount < 0)
            {
                logger.LogError("Provided amount is invalid: " + amount);
                //throw new ArgumentOutOfRangeException(nameof(amount));  
            }

            return amount * currencyRate;
        }
    }

    public interface ILogger
    {
        void LogError(string v);
    }

    public interface IExchangeRateService
    {
        decimal CalculateAmount(decimal amount, decimal currencyRate);
    }
}
