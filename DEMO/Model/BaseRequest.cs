using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEMO.Model
{
    public class BaseRequest
    {
        public Int64 partner_id { get; set; }
        public Int64 shopid { get; set; }
        public Int32 timestamp { get; set; }
    }
    public class IncomeRequest : BaseRequest
    {
        public string ordersn { get; set; }
    }

    public class UpdateShopInfoRQ : BaseRequest
    {
        public string shop_name { get; set; }
        public List<string> images { get; set; }
        public List<string> videos { get; set; }
        public UInt32 disable_make_offer { get; set; }
        public Boolean enable_display_unitno { get; set; }
        public string shop_description { get; set; }
    }
    public class GetOrderLogisticRQ : BaseRequest
    {
        public string forder_id { get; set; }
        public string package_number { get; set; }
        public string ordersn { get; set; }
    }
    public class GetOrder : BaseRequest
    {
        public Int32 create_time_from { get; set; }
        public Int32 create_time_to { get; set; }
        public Int32 update_time_from { get; set; }
        public Int32 update_time_to { get; set; }
        public Int32 pagination_entries_per_page { get; set; }
        public Int32 pagination_offset { get; set; }
    }
}
