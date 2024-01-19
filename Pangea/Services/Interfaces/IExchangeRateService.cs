using Pangea.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pangea.Repositories.Interfaces
{
    public interface IExchangeRateService
    {
        List<PangeaExchangeResponse> GetExchangeRates(string country);
    }
}
