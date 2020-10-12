using System.Net.Http.Json;
using PackageSearch.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PackageSearch.Services
{
    public interface IHttpClientService
    {
        Task<List<Hotel>> GetHotels(HotelSearchCriteria hotelSearchCriteria);
        Task<List<Flight>> GetFlights(FlightSearchCriteria flightSearchCriteria);
    }
    public class HttpClientService : IHttpClientService
    {
        private readonly HttpClient _httpClient;

        public HttpClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Flight>> GetFlights(FlightSearchCriteria flightSearchCriteria)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"http://localhost:57502/api/flights/search" +
                $"?Adults={flightSearchCriteria.Adults}&Origin={flightSearchCriteria.Origin}&Destination={flightSearchCriteria.Destination}" +
                $"&DepartureDate={flightSearchCriteria.DepartureDate.ToString("yyyy-MM-dd")}&ArrivalDate={flightSearchCriteria.ArrivalDate.ToString("yyyy-MM-dd")}");
            request.Headers.Add("Accept", "application/vnd.github.v3+json");
            request.Headers.Add("User-Agent", "PackageSearch");
            HttpResponseMessage response = await _httpClient.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<Flight>>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                throw new Exception("No Flights Found For " + flightSearchCriteria.ToString());
            }

        }

        public async Task<List<Hotel>> GetHotels(HotelSearchCriteria hotelSearchCriteria)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"http://localhost:62564/api/hotel/search" +
                $"?Destination={hotelSearchCriteria.Destination}&Children={hotelSearchCriteria.Children}" +
                $"&Adults={hotelSearchCriteria.Adults}");
            request.Headers.Add("Accept", "application/vnd.github.v3+json");
            request.Headers.Add("User-Agent", "PackageSearch");

            HttpResponseMessage response = await _httpClient.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<Hotel>>(await response.Content.ReadAsStringAsync());
            }
            else
            {
                throw new Exception("no hotels found for " + hotelSearchCriteria.ToString());
            }
            //_httpClient.
        }
    }
}
