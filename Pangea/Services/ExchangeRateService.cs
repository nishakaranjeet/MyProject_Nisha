using Pangea.Common;
using Pangea.Models;
using Pangea.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Pangea.Repositories
{
    public class ExchangeRateService : IExchangeRateService
    {
        private readonly IThirdPartyExchangeRateRepository _thirdPartyExchangeRateRepository;
        private readonly IPathProvider _pathProvider;
        public ExchangeRateService()
        {
            _pathProvider=new PathProvider();
            _thirdPartyExchangeRateRepository=new ThirdPartyExchangeRateRepository();
        }
        public List<PangeaExchangeResponse> GetExchangeRates(string countryCode)
        {
            try
            {
                if (countryCode.Length == 3)
                {

                    List<PartnerRate> listOfPartnerRates = _thirdPartyExchangeRateRepository.GetExchangeRate();
                    Rates pangeaRates = GeneralFunction.GetPangeaRates(countryCode, _pathProvider);
                    if (pangeaRates == null)
                    {
                         return null;
                    }
                    List<PartnerRate> listOfRequestedRates = listOfPartnerRates.FindAll(p => p.Currency == pangeaRates.CurrencyCode);
                    var uniqueObjects = listOfRequestedRates
                      .GroupBy(obj => new { obj.Currency, obj.PaymentMethod, obj.DeliveryMethod })
                      .Select(group =>
                          group.OrderByDescending(obj => obj.AcquiredDate).First()
                      );
                    List<PangeaExchangeResponse> listOfResponse = uniqueObjects
        .Select(item => new PangeaExchangeResponse
        {
            CurrencyCode = item.Currency,
            PaymentMethod = item.PaymentMethod,
            DeliveryMethod = item.DeliveryMethod,
            PangeaRate = Math.Round(item.Rate + pangeaRates.Rate, 2),
            CountryCode = pangeaRates.CountryCode
        })
        .ToList();

                    return listOfResponse;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception)
            {
                return null;
            }


        }
    }
}