using MicroRabbit.MVC.Models.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MicroRabbit.MVC.Services
{
    public class TransferService : ITransferService
    {
        private readonly HttpClient _apiClient;

        // Injecting the httpClient client (_apiClient) into the TransferService (...) constructor
        public TransferService(HttpClient apiClient)
        {
            _apiClient = apiClient;
        }


        public async Task Transfer(TransferDto transferDto)
        {
            
            var bankingServiceUri = "https://localhost:5001/api/Banking";
            var transferContent = new StringContent(JsonConvert.SerializeObject(transferDto),
                System.Text.Encoding.UTF8, "application/json");

            // !!!!! DO NOT DO THIS IN PRODUCTION> Create a Valid Certificate Instead !!!!!!!!!
            //Might want to create a valid certificate instead in production
            using (var httpClientHandler = new HttpClientHandler())
            {
                // !!!!! DO NOT DO THIS IN PRODUCTION> Create a Valid Certificate Instead !!!!!!!!!
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                using (var _apiClient = new HttpClient(httpClientHandler))
                {
                    // The presentation layer is making the http call to our Banking Microservice.
                    var response = await _apiClient.PostAsync(bankingServiceUri, transferContent);
                    response.EnsureSuccessStatusCode();
                }
            }
        }
    }
}
