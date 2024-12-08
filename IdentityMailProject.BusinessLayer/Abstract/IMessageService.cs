using IdentityMailProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityMailProject.BusinessLayer.Abstract
{
    public interface IMessageService : IGenericService<Message>
    {
        Task<List<Message>> TMessageListByUserIdAsync(int id);
        Task<List<Message>> TGetSentMessagesByUserIdAsync(int id);

        Task<List<Message>> TGetMessagesByCategoryAndUserAsync(int categoryId, int userId);

        Task TCreateMailAsync(Message message, int senderId, List<int> Recipient);
        Task<Message> TGetMessageDetailAsync(int id);
    }
}
