using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency.Model.Interface
{
    public interface ICurrencyRepository
    {
        // Add Currency based on the Currency model
        Task<Currency.Model.Dtos.DataModel.Currency> AddCurrency(Currency.Model.Dtos.DataModel.Currency currency);

        // Edit Currency based on the Currency model
        Task<Currency.Model.Dtos.DataModel.Currency> EditCurrency(Currency.Model.Dtos.DataModel.Currency currency);

        // Delete a Currency based on the id
        bool Delete(int id);

        // Details of a Currency based on the id
        Currency.Model.Dtos.DataModel.Currency DetailsCurrency(int id);

        // List of all Currency
        IEnumerable<Currency.Model.Dtos.DataModel.Currency> ListCurrency();
    }
}
