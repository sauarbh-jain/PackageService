using PackageSearch.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;

namespace PackageSearch.Services
{
    public interface IPackageSearchService
    {
        Task<List<Package>> GetPackages(PackageSearchCriteria packageSearch);
    }


    public class PackageSearchService : IPackageSearchService
    {
        private readonly IHttpClientService _httpClientService;
        public PackageSearchService(IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        public async Task<List<Package>> GetPackages(PackageSearchCriteria packageSearch)
        {
            HotelSearchCriteria hsc = new HotelSearchCriteria() { Adults = packageSearch.Adults, Children = packageSearch.Children, Destination = packageSearch.Destination };
            FlightSearchCriteria fsc = new FlightSearchCriteria() { Origin = packageSearch.Origin, Destination = packageSearch.Destination, Adults = packageSearch.Adults, Children = packageSearch.Children, DepartureDate=packageSearch.DepartureDate.Value.Date,ArrivalDate=packageSearch.ArrivalDate.Value.Date };

            var hotels = await _httpClientService.GetHotels(hsc);
            var flights = await _httpClientService.GetFlights(fsc);

            var packages = hotels
                .SelectMany(hotel => flights, (hotel, flight) => new Package { Flight = flight, Hotel = hotel })
                .ToList();

            return packages;
        }
    }
}
