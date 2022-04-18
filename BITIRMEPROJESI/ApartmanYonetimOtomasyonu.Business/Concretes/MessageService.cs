using ApartmanYonetimOtomasyonu.Business.Abstract;
using ApartmanYonetimOtomasyonu.DataAccess.EntityFramework.Repository.Abstracts;
using ApartmanYonetimOtomasyonu.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmanYonetimOtomasyonu.Business.Concretes
{
    public class MessageService : IMessageService
    {
        private readonly IRepository<Message> repository;
        private readonly IUnitOfWork unitOfWork;

        public MessageService(IRepository<Message> repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public void Add(Message message)
        {
            repository.Add(message);
            unitOfWork.Commit();
        }

        public void Delete(Message message)
        {
            var exitMessage = repository.Get().FirstOrDefault(x => x.Id == message.Id);
            if (exitMessage != null)
            {
                exitMessage.IsDeleted = true;
                repository.Update(exitMessage);
                unitOfWork.Commit();
            }
        }

        public List<Message> GetAll()
        {
            return repository.Get().ToList();
        }

        public Message GetById(int Id)
        {
            return repository.Get().FirstOrDefault(x => x.Id == Id);
        }

        public void Update(Message message)
        {
            var exitMessage = repository.Get().FirstOrDefault(x => x.Id == message.Id);
            if (exitMessage != null)
            {
                exitMessage.MessageContent = !string.IsNullOrEmpty(message.MessageContent) ? message.MessageContent : exitMessage.MessageContent;
               
                repository.Update(exitMessage);
                unitOfWork.Commit();
            }
        }
    }
}
