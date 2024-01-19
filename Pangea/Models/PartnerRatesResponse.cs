using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static Pangea.Common.GeneralFunction;

namespace Pangea.Models
{
    public class PartnerRatesResponse
    {
        public List<PartnerRate> PartnerRates { get; set; }
    }

    public class PartnerRate
    {
        public string Currency { get; set; }
        public string PaymentMethod { get; set; }
        public string DeliveryMethod { get; set; }
        public decimal Rate { get; set; }
        public string AcquiredDate { get; set; }

    }
}