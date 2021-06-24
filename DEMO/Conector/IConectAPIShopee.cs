using DEMO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DEMO.Conector
{
    public interface IConectAPIShopee
    {
        public APIResponse CallShopeeApi<T>(string route, BaseRequest objectRequest) where T : BaseResponse;
    }
}
