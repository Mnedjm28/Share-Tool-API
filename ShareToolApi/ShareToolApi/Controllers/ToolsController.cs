using Newtonsoft.Json;
using SharedToolApi.Business;
using SharedToolApi.Business.DTOs;
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
        public async Task<JsonResult<List<ToolDto>>> GetAllTools() {
            var toolRepo = new ToolRepository();
            return Json(await toolRepo.GetAllTools(),
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                });
        }
    }
}
