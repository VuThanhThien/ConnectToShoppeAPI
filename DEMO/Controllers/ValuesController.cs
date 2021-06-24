using DEMO.Conector;
using DEMO.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Newtonsoft.Json.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DEMO.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IConectAPIShopee _conectAPIShopee;

        public ValuesController(IConectAPIShopee conectAPIShopee)
        {
            _conectAPIShopee = conectAPIShopee;
        }

        /// <summary>
        /// Lấy thông tin shop
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("getinfo")]
        public BaseResponse GetInfoShop()
        {
            BaseResponse  baseResponse = new BaseResponse();
            var route = "/api/v1/shop/get";
            BaseRequest objectRequest = new BaseRequest();
            objectRequest.partner_id = 842209;
            objectRequest.shopid = 40822338;
            APIResponse response = _conectAPIShopee.CallShopeeApi<BaseResponse>(route, objectRequest);
            baseResponse.code = (int)response.code;
            baseResponse.message = response.message;
            baseResponse.data = response.data;
            return baseResponse;
        }

        [HttpGet]
        [Route("update")]
        public UpdateShopInfoResponse UpdateShopInfo()
        {
            UpdateShopInfoResponse baseResponse = new UpdateShopInfoResponse();
            var route = "/api/v1/shop/update";
            UpdateShopInfoRQ objectRequest = new UpdateShopInfoRQ();
            objectRequest.partner_id = 842209;
            objectRequest.shopid = 40822338;
            objectRequest.disable_make_offer = 0;
            objectRequest.shop_name = "AduStore";
            objectRequest.enable_display_unitno = false;
            objectRequest.shop_description = "nothing in my eyes";
            objectRequest.images = new List<string> { "https://f.shopee.com.my/file/9db9b57fe475d6f36952ec5d2c47723b"};
            objectRequest.videos = new List<string> { "https://youtu.be/abCdEfg9991" };
            APIResponse response = _conectAPIShopee.CallShopeeApi<UpdateShopInfoResponse>(route, objectRequest);
            baseResponse.code = (int)response.code;
            baseResponse.message = response.message;
            baseResponse.data = response.data;
            return baseResponse;
        }

        [HttpGet]
        [Route("GetAddress")]
        public BaseResponse GetAddress()
        {
            BaseResponse baseResponse = new BaseResponse();
            var route = "/api/v1/logistics/address/get";
            BaseRequest objectRequest = new BaseRequest();
            objectRequest.partner_id = 842209;
            objectRequest.shopid = 40822338;
            APIResponse response = _conectAPIShopee.CallShopeeApi<BaseResponse>(route, objectRequest);
            baseResponse.code = (int)response.code;
            baseResponse.message = response.message;
            baseResponse.data = response.data;
            return baseResponse;
        }

        /// <summary>
        /// lấy ordersn
        /// </summary>
        /// <returns></returns>
        //[HttpGet]
        //[Route("GetOrderBS")]
        //public BaseResponse GetOrder()
        //{
        //    BaseResponse baseResponse = new BaseResponse();
        //    var route = "/api/v1/orders/basics";
        //    GetOrder objectRequest = new GetOrder();
        //    objectRequest.shopid = 40822338;
        //    objectRequest.partner_id = 842209;
        //    objectRequest.create_time_from = 1;
        //    objectRequest.create_time_to = 1;
        //    objectRequest.pagination_offset = 0;
        //    objectRequest.pagination_entries_per_page = 10;
        //    objectRequest.update_time_from = 1;
        //    objectRequest.update_time_to = 1;
        //    APIResponse response = _conectAPIShopee.CallShopeeApi<BaseResponse>(route, objectRequest);
        //    baseResponse.code = (int)response.code;
        //    baseResponse.message = response.message;
        //    baseResponse.data = response.data;
        //    return baseResponse;
        //}

        /// <summary>
        /// Lấy thông tin vận chuyển đơn hàng
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetOrderLogistic")]
        public BaseResponse GetOrderLogistic()
        {
            BaseResponse baseResponse = new BaseResponse();
            var route = "/api/v1/logistics/order/get";
            GetOrderLogisticRQ objectRequest = new GetOrderLogisticRQ();
            objectRequest.forder_id = "";
            objectRequest.package_number = "";
            objectRequest.shopid = 40822338;
            objectRequest.partner_id = 842209;
            objectRequest.ordersn = "21052054J28DB2";
            APIResponse response = _conectAPIShopee.CallShopeeApi<BaseResponse>(route, objectRequest);
            baseResponse.code = (int)response.code;
            baseResponse.message = response.message;
            baseResponse.data = response.data;
            return baseResponse;
        }
    }
}
