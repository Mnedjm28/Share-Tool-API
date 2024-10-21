using Newtonsoft.Json;
using SharedToolApi.Business;
using SharedToolApi.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace ShareToolApi.Controllers
{
    public class ToolsController : ApiController
    {
        public async Task<JsonResult<List<Tool>>> GetAllTools() {
            var toolRepo = new ToolRepository();

            return Json(await toolRepo.GetAllTools());
        }
    }
}
