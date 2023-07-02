using Fiotec.Prova.Infra.Data.Rest.DataSus.InputModels;
using Fiotec.Prova.Infra.Data.Rest.DataSus.ViewModels;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Fiotec.Prova.Infra.Data.Rest.DataSus
{
    public class DataSusService : IDataSusService
    {
        public readonly IConfiguration _configuration;


        public DataSusService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Consulta? ObtemRegistros()
        {
            var client = new RestClient(_configuration["API_DataSUS:urlApi"]);
            var request = new RestRequest();

            request.Authenticator = new HttpBasicAuthenticator(_configuration["API_DataSUS:user"], _configuration["API_DataSUS:password"]);
            request.Method = Method.Post;
            request.AddHeader("Accept", "application/json");
            request.AddParameter("application/json", new { Size = 10000 }, ParameterType.RequestBody);

            var response = client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
               return JsonConvert.DeserializeObject<Consulta>(response.Content);                
            }

            return null;
        }
    }
}
