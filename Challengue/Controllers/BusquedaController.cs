using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Challengue.Controllers
{
    [ApiController]
    public class BusquedaController : ControllerBase
    {
        [HttpGet("MyRestfulapp/busqueda/{dato}")]
        public ActionResult Busqueda(string dato)
        {
            if (!string.IsNullOrEmpty(dato))
            {
                WebClient _client = new WebClient();
                JObject _answer = JObject.Parse(_client.DownloadString(string.Concat("https://api.mercadolibre.com/sites/MLA/search?q=", dato)));
                JObject _response = new JObject();
                foreach (JObject _resultado in _answer.Root["results"])
                {
                    _response.Add(_resultado["id"].ToString(), JToken.FromObject(new[] { _resultado["site_id"].ToString(), _resultado["title"].ToString(), _resultado["price"].ToString(), _resultado["seller"]["id"].ToString(), _resultado["permalink"].ToString() }));
                }
                return Ok(_response.ToString());
            }
            else
                return BadRequest();
        }
    }
}
