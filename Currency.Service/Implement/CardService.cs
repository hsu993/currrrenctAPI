using AutoMapper;
using Azure;
using Currency.Model.Dtos.Condition;
using Currency.Model.Dtos.DataModel;
using Currency.Model.Implement;
using Currency.Model.Interface;
using Currency.Service.Dtos.info;
using Currency.Service.Dtos.ResultModel;
using Currency.Service.Interface;
using Currency.Service.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Currency.Service.Implement
{
    /// <summary>
    /// 卡片管理
    /// </summary>
    /// <seealso cref="ProjectN.Service.Interface.ICardService" />
    public class CardService : ICardService
    {
        private readonly IMapper _mapper;
        //private readonly ICardRepository _cardRepository;

        ///// <summary>
        ///// 建構式
        ///// </summary>
        //public CardService()
        //{
        //    this._cardRepository = new CardRepository();

        //    var config = new MapperConfiguration(cfg =>
        //        cfg.AddProfile<ServiceMappings>());

        //    this._mapper = config.CreateMapper();
        //}


        private readonly ICardRepository _cardRepository;

        /// <summary>
        /// 建構式
        /// </summary>
        public CardService(ICardRepository cardRepository)
        {
            this._cardRepository = cardRepository;

            var config = new MapperConfiguration(cfg =>
                cfg.AddProfile<ServiceMappings>());

            this._mapper = config.CreateMapper();
        }

        /// <summary>
        /// 查詢卡片列表
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public IEnumerable<CardResultModel> GetList(CardSearchInfo info)
        {
            var condition = this._mapper.Map<CardSearchInfo, CardSearchCondition>(info);
            var cards = this._cardRepository.GetList(condition);

            var result = this._mapper.Map<
                IEnumerable<CardDataModel>,
                IEnumerable<CardResultModel>>(cards);

            return result;
        }

        /// <summary>
        /// 查詢卡片
        /// </summary>
        /// <param name="id">卡片編號</param>
        /// <returns></returns>
        public CardResultModel Get(int id)
        {
            var card = this._cardRepository.Get(id);
            var result = this._mapper.Map<CardDataModel, CardResultModel>(card);
            return result;
        }

        /// <summary>
        /// 新增卡片
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public bool Insert(CardInfo info)
        {
            var condition = this._mapper.Map<CardInfo, CardCondition>(info);
            var result = this._cardRepository.Insert(condition);
            return result;
        }

        /// <summary>
        /// 更新卡片
        /// </summary>
        /// <param name="id">卡片編號</param>
        /// <param name="info"></param>
        /// <returns></returns>
        public bool Update(int id, CardInfo info)
        {
            var condition = this._mapper.Map<CardInfo, CardCondition>(info);
            var result = this._cardRepository.Update(id, condition);
            return result;
        }

        /// <summary>
        /// 刪除卡片
        /// </summary>
        /// <param name="id">卡片編號</param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            var result = this._cardRepository.Delete(id);
            return result;
        }
    }
}




///// <summary>
///// 卡片資料操作
///// </summary>
//private readonly CardRepository _cardRepository;

///// <summary>
///// 建構式
///// </summary>
//public CardController()
//{
//    this._cardRepository = new CardRepository();
//}

/////// <summary>
/////// 查詢卡片列表
/////// </summary>
/////// <returns></returns>
////[HttpGet]
////[Produces("application/json")]
////public IEnumerable<CardViewModel> GetList()
////{
////    return this._cardRepository.GetList();
////}

///// <summary>
///// 查詢卡片列表
///// </summary>
///// <returns></returns>
//[HttpGet]
//[Produces("application/json")]
//public IEnumerable<CardViewModel> GetList(
//    [FromQuery] CardSearchParameter parameter)
//{
//    // 查詢卡片的一些操作
//    return this._cardRepository.GetList();
//}

///// <summary>
///// 查詢卡片
///// </summary>
///// <remarks>附加說明</remarks>
///// <param name="id">卡片編號</param>
///// <returns></returns>
///// <response code="200">回傳對應的卡片</response>
///// <response code="404">找不到該編號的卡片</response>  
//[HttpGet]
//[Produces("application/json")]
//[ProducesResponseType(typeof(CardViewModel), 200)]
//[Route("{id}")]
//public CardViewModel Get([FromRoute] int id)
//{
//    var result = this._cardRepository.Get(id);
//    if (result is null)
//    {
//        Response.StatusCode = 404;
//        return null;
//    }
//    return result;
//}

///// <summary>
///// 新增卡片
///// </summary>
///// <param name="parameter">卡片參數</param>
///// <returns></returns>
//[HttpPost]
//public IActionResult Insert([FromBody] CardParameter parameter)
//{
//    var result = this._cardRepository.Create(parameter);
//    if (result > 0)
//    {
//        return Ok();
//    }
//    return StatusCode(500);
//}

///// <summary>
///// 更新卡片
///// </summary>
///// <param name="id">卡片編號</param>
///// <param name="parameter">卡片參數</param>
///// <returns></returns>
//[HttpPut]
//[Route("{id}")]
//public IActionResult Update(
//    [FromRoute] int id,
//    [FromBody] CardParameter parameter)
//{
//    var targetCard = this._cardRepository.Get(id);
//    if (targetCard is null)
//    {
//        return NotFound();
//    }

//    var isUpdateSuccess = this._cardRepository.Update(id, parameter);
//    if (isUpdateSuccess)
//    {
//        return Ok();
//    }
//    return StatusCode(500);
//}

///// <summary>
///// 刪除卡片
///// </summary>
///// <param name="id">卡片編號</param>
///// <returns></returns>
//[HttpDelete]
//[Route("{id}")]
//public IActionResult Delete([FromRoute] int id)
//{
//    this._cardRepository.Delete(id);
//    return Ok();
//}