using Pangea.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pangea.Repositories.Interfaces
{
    internal interface IThirdPartyExchangeRateRepository
    {
        List<PartnerRate> GetExchangeRate();
    }
}
