using System.Net.Http;
using System.Text.Json.Nodes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SignalRDtoLayer.ContactDto;
using SignalRDtoLayer.MessageDto;

namespace SignalRWebUI.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DefaultController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
           // var client = _httpClientFactory.CreateClient();
           // var responseMessage = await client.GetAsync("http://localhost:5003/api/Contact");
           // var jsonData = await responseMessage.Content.ReadAsStringAsync();
           //// var values = JsonConvert.DeserializeObject<ResultContactDto>(jsonData);
           // JsonObject item=
           // ViewBag.location = jsonData[0].ToString();

            HttpClient client= new HttpClient();
            HttpResponseMessage response = await client.GetAsync("http://localhost:5003/api/Contact");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            JArray item = JArray.Parse(responseBody);
            string value = item[0]["location"].ToString();
            ViewBag.location = value;
            return View();
        }

        [HttpGet]
        public  PartialViewResult SendMessage()
        {
         
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(CreateMessageDto createMessageDto)
        {

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createMessageDto);
            StringContent stringContent = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5003/api/Message", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index","Default");
            }
            return View();
        }

    }
}
