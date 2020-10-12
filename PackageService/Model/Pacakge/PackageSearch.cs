using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PackageSearch.Model
{
    public class PackageSearchCriteria : IValidatableObject
    {
        [Required]
        [FromQuery(Name = "origin")]
        public string Origin { get; set; }
        [Required]
        [FromQuery(Name = "destination")]
        public string Destination { get; set; }
        [Required]
        [FromQuery(Name = "adults")]
        [Range(1, 10)]
        public int Adults { get; set; }
        [Required]
        [FromQuery(Name = "children")]
        [Range(0, 9)]
        public int Children { get; set; }
        [Required]
        [FromQuery(Name = "departureDate")]
        public DateTime? DepartureDate { get; set; }
        [Required]
        [FromQuery(Name = "arrivalDate")]
        public DateTime? ArrivalDate { get; set; }
      
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if ((Adults + Children)> 10)
            {
                yield return new ValidationResult("Max booking limit is 10 but requested for " + Adults + Children);
            }
        }
    }
}
