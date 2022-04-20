using ApartmanYonetimOtomasyonu.API.DataAccess.Abstract;
using ApartmanYonetimOtomasyonu.API.DataAccess.Configurations;
using ApartmanYonetimOtomasyonu.API.Entities;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApartmanYonetimOtomasyonu.API.DataAccess.Concrete
{
    public class InvoiceService : IInvoiceService
    {
        private IMongoCollection<InvoicePayment> _invoicePaymentCollection;
        private ExpensePaymentConfiguration _config;

        public InvoiceService(IOptions<ExpensePaymentConfiguration> config)
        {
            _config = config.Value;
            MongoClient client = new MongoClient(_config.ConnectionString);
            IMongoDatabase db = client.GetDatabase(_config.DbName);
            _invoicePaymentCollection = db.GetCollection<InvoicePayment>(_config.InvoicePaymentCollection);
        }

        public async Task<List<InvoicePayment>> GetAll()
        {
            return await _invoicePaymentCollection.Find(i => true).ToListAsync();
        }

        public async Task<InvoicePayment> GetById(string id)
        {
            return await _invoicePaymentCollection.Find(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task Add(InvoicePayment invoicePayment)
        {
            await _invoicePaymentCollection.InsertOneAsync(invoicePayment);
        }

        public async Task Delete(string id)
        {
            await _invoicePaymentCollection.DeleteOneAsync(i => i.Id == id);
        }
    }
}
