using Newtonsoft.Json;
using Pangea.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Web;

namespace Pangea.Common
{
    public interface IPathProvider
    {
         string GetBaseDirectory();
    }
    public class PathProvider : IPathProvider
    {
        public string GetBaseDirectory()
        {
            return AppDomain.CurrentDomain.BaseDirectory;
        }
    }
    public class GeneralFunction
    {
       


        public enum DeliveryMethods
        {
            Debit,
            Deposit,
            Cash
        }
        public enum PaymentMethods
        {
            Cash,
            Debit,
            BankAccount

        }
        public enum Country
        {
            [Description("MEX")]
            Mexico,
            [Description("IND")]
            India,
            [Description("PHL")]
            Philippines,
            [Description("GTM")]
            Guatemala

        }

        // Rates usually comes from Database. But as this is sample project I am adding it here.
        public static Rates GetPangeaRates(string countryCode, IPathProvider pathProvider)
        {

            string jsonFilePath = "JsonFiles\\PangeaRates.json";
            // Read JSON from file
            string absolutePath = Path.Combine(pathProvider.GetBaseDirectory(), jsonFilePath);
            if (File.Exists(absolutePath))
            {
                // Read JSON from file
                string jsonContent = File.ReadAllText(absolutePath);
                // Deserialize JSON to a list of entities
                List<Rates> listOfRates = JsonConvert.DeserializeObject<List<Rates>>(jsonContent);
                

                return listOfRates.FirstOrDefault(p => p.CountryCode == countryCode);
            }
            else
            {
                return null;
            }
        }


    }
}