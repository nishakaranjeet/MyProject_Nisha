using Newtonsoft.Json;
using Pangea.Models;
using Pangea.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Pangea.Repositories
{
    public class ThirdPartyExchangeRateRepository : IThirdPartyExchangeRateRepository
    {
        //Later we will convert this to API call for now we are reading it from json file(Each third party Exchange company should implement IExchangeRateRepository)

        public List<PartnerRate> GetExchangeRate()
        {
            string jsonFilePath = "JsonFiles\\PartnerRates.json";
            // Read JSON from file
            string absolutePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, jsonFilePath);
            if (File.Exists(absolutePath))
            {
                // Read JSON from file
                string jsonContent = File.ReadAllText(absolutePath);
                // Deserialize JSON to a list of entities
                PartnerRatesResponse partnerRatesResponse = JsonConvert.DeserializeObject<PartnerRatesResponse>(jsonContent);

                return partnerRatesResponse.PartnerRates;
            }
            else
            { 
                return null; 
            }


        }
    }
}