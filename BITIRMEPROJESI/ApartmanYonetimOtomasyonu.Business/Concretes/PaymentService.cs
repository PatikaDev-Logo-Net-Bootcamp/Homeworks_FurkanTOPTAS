using ApartmanYonetimOtomasyonu.API.ApiDataResponse;
using ApartmanYonetimOtomasyonu.Business.Abstract;
using ApartmanYonetimOtomasyonu.Business.DTOs;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ApartmanYonetimOtomasyonu.Business.Concretes
{
    public class PaymentService : IPaymentService
    {
        private readonly HttpClient _httpClient;

        public PaymentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<ApiDataResponse<string>> PaymentCreate(PaymentCreateDto paymentCreateDto)
        {
            const string requestUrl = "https://localhost:44361/api/Payment/CreatePayment";
            string requestJson = JsonConvert.SerializeObject(paymentCreateDto);
            HttpResponseMessage httpResponse;
            using (var stringContent = new StringContent(requestJson, Encoding.UTF8, "application/json"))
            {
                httpResponse = await _httpClient.PostAsync(requestUrl, stringContent);
                var apiResponse = await httpResponse.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ApiDataResponse<string>>(apiResponse);
            }
        }
    }
}
