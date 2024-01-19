using Newtonsoft.Json;
using Pangea.Models;
using Pangea.Repositories;
using Pangea.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;


namespace Pangea.Controllers
{
 
    [Route("api/exchange-rates")]
    public class ExchangeRateController : ApiController
    {
        private readonly IExchangeRateService _exchangeRateService;
        public ExchangeRateController()
        {
            // We can use Ninject or Unity or any other dependency injection
            _exchangeRateService = new ExchangeRateService();

        }
        //public ExchangeRateController(IExchangeRateService exchangeRateService)
        //{
        //    _exchangeRateService = exchangeRateService;
        //}
       [System.Web.Http.HttpGet]
        public IHttpActionResult Get(string countryCode)
        {
            try
            {
                var exchangeRates = _exchangeRateService.GetExchangeRates(countryCode);
                if (exchangeRates == null || !exchangeRates.Any())
                {
                    return NotFound();
                }

                return Ok(exchangeRates);
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
