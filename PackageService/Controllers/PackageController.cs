using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PackageSearch.Model;
using PackageSearch.Services;

namespace PackageSearch.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PackageController : Controller
    {
        private readonly IPackageSearchService _packageService;

        public PackageController(IPackageSearchService packageService)
        {
            _packageService = packageService;
        }
        [HttpGet("{Search}")]
        public async Task<ActionResult<List<Package>>> Search([FromQuery] PackageSearchCriteria packageSearch)
        {
            if (ModelState.IsValid)
            {
                Console.WriteLine(">>" + packageSearch);
                return await _packageService.GetPackages(packageSearch);
            }
            else
            {
                return BadRequest("Bad Request");
            }
        }

        //[HttpPost("{Book}")]
        //public async Task<ActiionResult>
    }
}
