using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using static Pangea.Common.GeneralFunction;

namespace Pangea.Common
{
    public class Rates
    {
        public string Country { get; set; }

        // If we later use this as a request model to do Model Validation 
        [Required(ErrorMessage = "Currency Code is required")]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "Currency Code must be exactly 3 characters")]
        public string CurrencyCode { get; set; }

        [Required(ErrorMessage = "Country Code is required")]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "Country Code must be exactly 3 characters")]
        public string CountryCode { get; set; }
        public decimal Rate { get; set; }

    }
}