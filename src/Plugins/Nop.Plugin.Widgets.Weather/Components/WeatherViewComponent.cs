using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Nop.Plugin.Widgets.Weather.Model;
using Nop.Web.Framework.Components;

namespace Nop.Plugin.Widgets.Weather.Components
{
    public class WeatherViewComponent: NopViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            //https://api.weatherapi.com/v1/current.json?key=0549fcdea1cd4434bc595346230604&q=Romania&aqi=no
            HttpClient client = new HttpClient();
            Uri uri = new Uri("https://api.weatherapi.com/v1/current.json?key=0549fcdea1cd4434bc595346230604&q=Suceava&aqi=no");
            WeatherModel model = new WeatherModel();
            HttpResponseMessage response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                JObject json = JObject.Parse(responseBody);
                model.City = json["location"]["name"].ToString();
                model.Condition = json["current"]["condition"]["text"].ToString();
                model.LinkImg =  json["current"]["condition"]["icon"].ToString();
                model.Temp = json["current"]["temp_c"].ToString();
            }
            Console.WriteLine(model.City);
            return View("~/Plugins/Widgets.Weather/Views/WeatherView.cshtml", model);
        }
    }
}
