using Currency.Service.Interface;
using Currency.Service.Misc;
using Currency.Model.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
using Currency.Model.Dtos.DataModel;


namespace Currency.Service
{
    public class CurrencyService : ICurrencyService
    {
        //private IRepository<Categories> repository = new DataRepository<Categories>();
        private IRepository<Currency.Model.Dtos.DataModel.Currency> _repository;
        public CurrencyService(IRepository<Currency.Model.Dtos.DataModel.Currency> repository)
        {
            this._repository = repository;
        }

        public IResult Create(Currency.Model.Dtos.DataModel.Currency instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException();
            }

            IResult result = new Result(false);
            try
            {
                this._repository.Create(instance);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Exception = ex;
            }
            return result;
        }

        public IResult Update(Currency.Model.Dtos.DataModel.Currency instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException();
            }

            IResult result = new Result(false);
            try
            {
                this._repository.Update(instance);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Exception = ex;
            }
            return result;
        }

        public IResult Delete(int currencyID)
        {
            IResult result = new Result(false);

            if (!this.IsExists(currencyID))
            {
                result.Message = "找不到資料";
            }

            try
            {
                var instance = this.GetByID(currencyID);
                this._repository.Delete(instance);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Exception = ex;
            }
            return result;
        }

        public bool IsExists(int currencyID)
        {
            return this._repository.GetAll().Any(x => x.Id == currencyID);
        }

        public Currency.Model.Dtos.DataModel.Currency GetByID(int currencyID)
        {
            return this._repository.Get(x => x.Id == currencyID);
        }

        public IEnumerable<Currency.Model.Dtos.DataModel.Currency> GetAll()
        {
            return this._repository.GetAll();
        }
    }
}