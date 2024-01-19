using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pangea.Models
{
    public class PangeaExchangeResponse
    {
       
        public string CurrencyCode { get; set; }
        public string CountryCode { get; set; }
        public decimal PangeaRate { get; set; }
        public string PaymentMethod { get; set; }
        public string DeliveryMethod { get; set; }


    }
}