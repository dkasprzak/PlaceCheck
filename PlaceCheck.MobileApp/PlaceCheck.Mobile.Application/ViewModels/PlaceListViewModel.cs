using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaceCheck.Mobile.Application.ViewModels
{
    public record PlaceListViewModel
    {
        public string Id { get; set; }
        public DisplyName DisplayName { get; set; }
        public bool AllowsDogs { get; set; }
        public double Rating { get; set; } 
        public record DisplyName(string Text);
    }
}
