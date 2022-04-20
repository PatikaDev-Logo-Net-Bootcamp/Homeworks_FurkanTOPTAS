using ApartmanYonetimOtomasyonu.API.ApiDataResponse;
using ApartmanYonetimOtomasyonu.API.DataAccess.Abstract;
using ApartmanYonetimOtomasyonu.API.DTOs;
using ApartmanYonetimOtomasyonu.API.Entities;
using ApartmanYonetimOtomasyonu.API.Validators;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApartmanYonetimOtomasyonu.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {

        private readonly IInvoiceService _invoiceService;
        private readonly ICreditCardInfoService _creditCardInfoService;
        public PaymentController(IInvoiceService invoiceService, ICreditCardInfoService creditCardInfoService)
        {
            _invoiceService = invoiceService;
            _creditCardInfoService = creditCardInfoService;
        }
        [Route("CreatePayment")]
        [HttpPost]
        public async Task<ApiDataResponse<string>> CreatePayment(InvoicePaymentDto createPaymentDto)
        {
            var validator = new CreateInvoicePaymentValidator();
            var results = validator.Validate(createPaymentDto);
            if (!results.IsValid)
            {
                return InternalServerError(results.ToString());
            }

            var creditCardResult = await _creditCardInfoService.GetByFilter(createPaymentDto);

            if (creditCardResult == null)
            {
                return InternalServerError("Geçersiz kredi kartı/ Kredi kartı bulunamadı.");
            }
            if (creditCardResult.Balance <= createPaymentDto.InvoiceAmount)
            {
                return InternalServerError("Yetersiz bakiye.");
            }
            var createInvoicePayment = new InvoicePayment()
            {
                CardNumber = createPaymentDto.CardNumber,
                Owner = createPaymentDto.Owner,
                Cvv = createPaymentDto.Cvv,
                InvoiceAmount = createPaymentDto.InvoiceAmount,
                ValidMonth = createPaymentDto.ValidMonth,
                ValidYear = createPaymentDto.ValidYear,
                FlatId = createPaymentDto.FlatId,
                ExpenseId = createPaymentDto.ExpenseId
            };
            creditCardResult.Balance -= createPaymentDto.InvoiceAmount;

            await _creditCardInfoService.Update(creditCardResult.Id, creditCardResult);
            await _invoiceService.Add(createInvoicePayment);
            return Success(createInvoicePayment.Id);
        }

        [Route("CreateCreditCard")]
        [HttpPost]
        public async Task<string> CreateCreditCard(CreditCardInfoDto creditCardInfoDto)
        {
            var createCreditCard = new CreditCardInfo()
            {
                CardNumber = creditCardInfoDto.CardNumber,
                Owner = creditCardInfoDto.Owner,
                Cvv = creditCardInfoDto.Cvv,
                Balance = creditCardInfoDto.Balance,
                ValidMonth = creditCardInfoDto.ValidMonth,
                ValidYear = creditCardInfoDto.ValidYear,
            };

            await _creditCardInfoService.Add(createCreditCard);

            return "Succes";
        }

        private ApiDataResponse<string> Success(string data)
        {
            return new ApiDataResponse<string>
            {
                Data = data,
                Message = "İşlem başarılı",
                StatusCode = StatusCodes.Status200OK
            };
        }

        private ApiDataResponse<string> InternalServerError(string errorMessage)
        {
            return new ApiDataResponse<string>
            {
                Data = null,
                Message = errorMessage,
                StatusCode = StatusCodes.Status500InternalServerError
            };
        }
    }
}
