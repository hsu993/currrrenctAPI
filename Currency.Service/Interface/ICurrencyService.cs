using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Currency.Model.Models;
using Currency.Model.Models.Interface;
using Currency.Model.Models.Repository;
using Currency.Service.Interface;
using Currency.Service.Misc;

namespace Currency.Service.Interface
{
    public interface ICurrencyService
    {
        IResult Create(Currency.Model.Dtos.DataModel.Currency instance);

        IResult Update(Currency.Model.Dtos.DataModel.Currency instance);

        IResult Delete(int currencyID);

        bool IsExists(int currencyID);

        Currency.Model.Dtos.DataModel.Currency GetByID(int currencyID);

        IEnumerable<Currency.Model.Dtos.DataModel.Currency> GetAll();
    }
}
