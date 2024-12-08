using IdentityMailProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityMailProject.DataAccessLayer.Abstract
{
    public interface IMessageDal : IGenericDal<Message>
    {

        Task<List<Message>> MessageListByUserIdAsync(int id);

        Task<List<Message>> GetSentMessagesByUserIdAsync(int id);

        Task<List<Message>> GetMessagesByCategoryAndUserAsync(int categoryId, int userId);

        Task CreateMailAsync(Message message, int senderId, List<int> Recipient);

        Task<Message> GetMessageDetailAsync(int id);
    }
}
