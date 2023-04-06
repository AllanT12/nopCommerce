using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Web.Framework.Models;

namespace Nop.Plugin.Widgets.Weather.Model
{
    public record WeatherModel: BaseNopModel
    {
        public string City { get; set; }
        public string Condition { get; set; }
        public string LinkImg { get; set; }
        public string Temp { get; set; }
    }
}
