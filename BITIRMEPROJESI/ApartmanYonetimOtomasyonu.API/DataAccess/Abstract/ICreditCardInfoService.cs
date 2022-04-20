using ApartmanYonetimOtomasyonu.API.DTOs;
using ApartmanYonetimOtomasyonu.API.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApartmanYonetimOtomasyonu.API.DataAccess.Abstract
{
    public interface ICreditCardInfoService
    {
        Task<List<CreditCardInfo>> GetAllAsync();
        Task<CreditCardInfo> GetById(string id);
        Task<CreditCardInfo> GetByFilter(InvoicePaymentDto filter);
        Task Add(CreditCardInfo creditCardInfo);
        Task Delete(string id);
        Task Update(string id, CreditCardInfo creditCardInfo);
    }
}
