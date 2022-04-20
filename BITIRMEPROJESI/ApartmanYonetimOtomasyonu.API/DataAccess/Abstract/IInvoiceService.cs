using ApartmanYonetimOtomasyonu.API.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApartmanYonetimOtomasyonu.API.DataAccess.Abstract
{
    public interface IInvoiceService
    {
        Task<List<InvoicePayment>> GetAll();
        Task<InvoicePayment> GetById(string id);
        Task Add(InvoicePayment invoicePayment);
        Task Delete(string id);
    }
}
