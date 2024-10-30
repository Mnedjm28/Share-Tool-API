using Newtonsoft.Json;
using SharedToolApi.Business;
using SharedToolApi.Business.DTOs;
using System;
using System.Collections.Generic;
using System.IO;
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
        private ToolRepository _toolRepository { get; set; } = new ToolRepository();

        [HttpGet]
        public async Task<JsonResult<List<ToolDto>>> GetAllTools()
        {
            var toolRepo = new ToolRepository();
            return Json(await toolRepo.GetAllTools(),
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                });
        }

        [HttpPost]
        public HttpResponseMessage Create()
        {
            return Request.CreateResponse(HttpStatusCode.OK, "Created successfuly");
        }

        [HttpPut]
        public async Task<IHttpActionResult> Update(ToolDto tool)
        {
            //var imageUrl = await _toolRepository.Update(tool);            
            return Ok();
        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var imageUrl = await _toolRepository.Delete(id);
            if (imageUrl != null)
            {
                imageUrl = imageUrl.Replace("/Images/", string.Empty);
                //File.Delete(Path.Combine(Server.MapPath("~/Images"), imageUrl));
            }
            return Ok();
        }
    }
}
