using Currency.Model.Dtos.DataModel;
using Currency.Model.Interface;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency.Model.Implement
{
    public class CurrencyRepository : ICurrencyRepository
    {
        private readonly CurrencyContext _currencyDbContext;

        // Constructor
        // Inject AppDbContext inside the constructor to make access to the AppDbContext 
        public CurrencyRepository(CurrencyContext currencyDbContext)
        {
            _currencyDbContext = currencyDbContext;
        }

        // Add new Currency
        public async Task<Dtos.DataModel.Currency> AddCurrency(Currency.Model.Dtos.DataModel.Currency currency)
        {
            if (currency is not null)
            {
                //currency.Id = Guid.NewGuid().ToString();
                await _currencyDbContext.Currencies.AddAsync(currency);
                await _currencyDbContext.SaveChangesAsync();
            }
            return currency;
        }

        // Delete a Currency based on the id
        public bool Delete(int id)
        {
            var currency = DetailsCurrency(id);
            if (currency is not null)
            {
                _currencyDbContext.Currencies.Remove(currency);
                _currencyDbContext.SaveChanges();
                return true;
            }
            return false;
        }

        // Details of a currency based on the id
        public Currency.Model.Dtos.DataModel.Currency DetailsCurrency(int id)
        {
            return _currencyDbContext.Currencies.FirstOrDefault(m => m.Id == id);
        }

        // Edit a currency
        public async Task<Currency.Model.Dtos.DataModel.Currency> EditCurrency(Currency.Model.Dtos.DataModel.Currency currency)
        {
            var currencyDetail = DetailsCurrency(currency.Id);
            if (currency is not null)
            {
                // AutoMapper or Mapster or any kind of function that 
                // could map these properties must be used
                currencyDetail.CurrencyCode = currency.CurrencyCode;
                currencyDetail.CurrencyName = currency.CurrencyName;
                currencyDetail.CurrencyLang = currency.CurrencyLang;
                currencyDetail.CurrencySymbol = currency.CurrencySymbol;
                currencyDetail.CurrencyRate = currency.CurrencyRate;
                currencyDetail.CurrencyDescription = currency.CurrencyDescription;
                currencyDetail.UpdatedAt = currency.UpdatedAt;
                await _currencyDbContext.SaveChangesAsync();
            }
            return currencyDetail;
        }

        // List of all currency
        public IEnumerable<Currency.Model.Dtos.DataModel.Currency> ListCurrency()
        {
            return _currencyDbContext.Currencies.OrderByDescending(m => m.Id).ToList();
        }
    }
}
