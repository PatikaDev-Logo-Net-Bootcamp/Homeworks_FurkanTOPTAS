namespace ApartmanYonetimOtomasyonu.API.DataAccess.Configurations
{
    public class ExpensePaymentConfiguration
    {
        public string DbName { get; set; }
        public string ConnectionString { get; set; }
        public string InvoicePaymentCollection { get; set; }
        public string CreditCardInfoCollection { get; set; }
    }
}
