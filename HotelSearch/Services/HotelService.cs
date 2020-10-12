using HotelSearch.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelSearch.Services
{
    public interface IHotelService
    {
        Task<List<Hotel>> GetHotels(Hotel hotel);
    }
    public class HotelService : IHotelService
    {
        List<Hotel> hotels = new List<Hotel>()
        { new Hotel {HotelName="Dummy1", HotelLocation="London", Price=10000 },
          new Hotel {HotelName="Dummy2", HotelLocation="Indore", Price=20000 },
          new Hotel {HotelName="Dummy3", HotelLocation="Delhi", Price=30000 }
        };
        public async Task<List<Hotel>> GetHotels(Hotel hotel)
        {
            return (hotels);
        }
    }
}
