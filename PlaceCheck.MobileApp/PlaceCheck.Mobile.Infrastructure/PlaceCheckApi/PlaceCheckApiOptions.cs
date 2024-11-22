using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaceCheck.Mobile.Infrastructure.PlaceCheckApi
{
    public record PlaceCheckApiOptions
    {
        public string BaseUrl { get; set; }
    }
}
