using IdentityMailProject.BusinessLayer.Abstract;
using IdentityMailProject.DataAccessLayer.Abstract;
using IdentityMailProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityMailProject.BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {

        private readonly IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public async Task TCreateMailAsync(Message message, int senderId, List<int> Recipient)
        {
           await _messageDal.CreateMailAsync(message, senderId, Recipient);
        }

        public void TDelete(int id)
        {
            _messageDal.Delete(id);
        }

        public List<Message> TGetAll()
        {
           return _messageDal.GetAll();
        }

        public Message TGetById(int id)
        {
            return _messageDal.GetById(id);
        }

        public Task<Message> TGetMessageDetailAsync(int id)
        {
            return   _messageDal.GetMessageDetailAsync(id);
        }

        public async Task<List<Message>> TGetMessagesByCategoryAndUserAsync(int categoryId, int userId)
        {
            return await _messageDal.GetMessagesByCategoryAndUserAsync(categoryId, userId);
        }

        public async Task<List<Message>> TGetSentMessagesByUserIdAsync(int id)
        {
            return await _messageDal.GetSentMessagesByUserIdAsync(id);
        }

        public void TInsert(Message entity)
        {
            _messageDal.Insert(entity);
        }

        public async Task<List<Message>> TMessageListByUserIdAsync(int id)
        {
           return await _messageDal.MessageListByUserIdAsync(id);
        }

        public void TUpdate(Message entity)
        {
          _messageDal.Update(entity);
        }
    }
}
