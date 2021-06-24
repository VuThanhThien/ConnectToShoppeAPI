using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEMO.Model
{
    public class BaseResponse : APIResponse
    {
    }
    public class UpdateShopInfoResponse : BaseResponse
    {
        public UInt64 shopid { get; set; }
        public string shop_name { get; set; }
        public List<string> images { get; set; }
        public List<string> videos { get; set; }
        public UInt32 disable_make_offer { get; set; }
        public Boolean enable_display_unitno { get; set; }
        public string warning { get; set; }
        public string country { get; set; }
        public string shop_description { get; set; }
        public string request_id { get; set; }

    }
}
