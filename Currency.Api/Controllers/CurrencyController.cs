//using Currency.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Currency.Model.Interface;

namespace Currency.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CurrencyController : ControllerBase
    {
        private readonly ILogger<CurrencyController> _logger;
        //private ICurrencyService _currencyService;

        //public CurrencyController(ILogger<CurrencyController> logger, ICurrencyService currencyService)
        //{
        //    _logger = logger;
        //    this._currencyService = currencyService;
        //} 
        private readonly ICurrencyRepository _currencyRepository;
        //private readonly IMapper _mapper;
        public CurrencyController(ILogger<CurrencyController> logger, ICurrencyRepository currencyRepository)
        {
            _logger = logger;
            this._currencyRepository = currencyRepository;
        }
        // GET: CurrencyController
        //[HttpGet(Name = "GetCurrencys")]
        //public ActionResult Get()
        //{
        //    return "1";
        //    var currencys = this._currencyService.GetAll()
        //        .OrderByDescending(x => x.Id)
        //        .ToList();

        //    //return currencys;
        //}

        [HttpGet(Name = "GetCurrencys")]
        public IEnumerable<Model.Dtos.DataModel.Currency> Get()
        {
            var result = _currencyRepository.ListCurrency();
            if (result.Any())
            {
                return result;
                //return StatusCode(StatusCodes.Status200OK, _mapper.Map<IEnumerable<MusicDTO>>(result));
            }
            return result;
            //return StatusCode(StatusCodes.Status204NoContent);


            //List <Currency.Model.Dtos.DataModel.Currency> = _currencyRepository.ListCurrency();
            //return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            //{
            //    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            //    TemperatureC = Random.Shared.Next(-20, 55),
            //    Summary = "10"
            //})
            //.ToArray();
        }

        //// GET: CurrencyController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: CurrencyController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: CurrencyController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: CurrencyController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: CurrencyController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: CurrencyController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: CurrencyController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
