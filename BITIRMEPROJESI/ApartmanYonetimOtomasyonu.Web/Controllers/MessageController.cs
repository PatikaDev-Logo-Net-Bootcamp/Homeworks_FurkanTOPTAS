using ApartmanYonetimOtomasyonu.Business.Abstract;
using ApartmanYonetimOtomasyonu.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net.Mail;

namespace ApartmanYonetimOtomasyonu.Web.Controllers
{
    public class MessageController : Controller
    {
        private readonly IMessageService messageService;
        private readonly UserManager<User> userManager;

        public MessageController(IMessageService messageService, UserManager<User> userManager)
        {
            this.messageService = messageService;
            this.userManager = userManager;
        }
        [HttpGet]
        public IActionResult InBox()
        {
            var messages = messageService.GetAll().Where(x => x.ReceiverId == userManager.GetUserId(User)).ToList();
            return View(messages);
        }
        [HttpGet]
        public IActionResult OutBox()
        {
            var messages = messageService.GetAll().Where(x => x.SenderId == userManager.GetUserId(User)).ToList();
            return View(messages);
        }

        [HttpGet]
        public IActionResult SendMessage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendMessage(Message message)
        {
            MailAddress mail = new MailAddress(message.ReceiverEmail);
            if (ModelState.IsValid) 
            {
                message.SenderId = userManager.GetUserId(User);
                message.SenderEmail = userManager.GetUserName(User);

                message.ReceiverId = userManager.FindByEmailAsync(message.ReceiverEmail).Result.Id;
                message.ReceiverEmail = message.ReceiverEmail;
                
                messageService.Add(message);
                return RedirectToAction("InBox");
            }
           

            messageService.Add(message);
            return RedirectToAction("OutBox");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var message = messageService.GetById(id);
            messageService.Delete(message);
            return RedirectToAction("InBox");
        }
        
        [HttpPost]
        public IActionResult Read(int id)
        {
            var message = messageService.GetById(id);
            message.IsRead = true;
            messageService.Update(message);
            return View(message);
        }

        [HttpGet]
        public IActionResult Reply(int id)
        {
            var message = messageService.GetById(id);
            return View(message);
        }


        [HttpPost]
        public IActionResult Reply(Message message)
        {

            if (!ModelState.IsValid)
            {
                return View(message);
            }
            messageService.Update(message);
            return RedirectToAction("OutBox");
        }

    }
}
