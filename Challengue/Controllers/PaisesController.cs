using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using AttributeRouting.Web.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Challengue.Controllers
{
    [ApiController]
    public class PaisesController : ControllerBase
    {
        [Microsoft.AspNetCore.Mvc.HttpGet("MyRestfulapp/Paises/{pais}")]
        public ActionResult Get(string pais)
        {
            if (string.Equals(pais.ToUpper(), "AR"))
            {
                WebClient _client = new WebClient();
                JObject _answer = JObject.Parse(_client.DownloadString("https://api.mercadolibre.com/classified_locations/countries/AR"));
                return Ok(_answer.ToString());

            }
            else
                //throw new HttpResponseException(HttpStatusCode.Unauthorized);
                return Unauthorized();
        }

    }
}
