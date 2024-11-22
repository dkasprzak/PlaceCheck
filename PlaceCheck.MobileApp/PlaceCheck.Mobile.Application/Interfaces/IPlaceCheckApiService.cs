using PlaceCheck.Mobile.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaceCheck.Mobile.Application.Interfaces
{
    public interface IPlaceCheckApiService
    {
        Task<IEnumerable<PlaceViewModel>> GetPlaces(string query);
    }
}
