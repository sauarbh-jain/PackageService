using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelSearch.Model;
using HotelSearch.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelSearch.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotelService _hotelService;

        public HotelController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        [HttpGet("{search}")]
        public async Task<ActionResult<List<Hotel>>> Search([FromQuery]Hotel hotel)
        {
            if (ModelState.IsValid)
            {
                return await (_hotelService.GetHotels(hotel));
            }
            else
            {
                return BadRequest("Hotel Not Found");
            }
        }
    }
}
