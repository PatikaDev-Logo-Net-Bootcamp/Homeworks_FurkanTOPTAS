using ApartmanYonetimOtomasyonu.API.ApiDataResponse;
using ApartmanYonetimOtomasyonu.Business.DTOs;
using System.Threading.Tasks;

namespace ApartmanYonetimOtomasyonu.Business.Abstract
{
    public interface IPaymentService
    {
        Task<ApiDataResponse<string>> PaymentCreate(PaymentCreateDto paymentCreateDto);
    }
}
