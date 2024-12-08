using IdentityMailProject.DataAccessLayer.Abstract;
using IdentityMailProject.DataAccessLayer.Context;
using IdentityMailProject.DataAccessLayer.Repositories;
using IdentityMailProject.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityMailProject.DataAccessLayer.EntityFramework
{
    public class EfMessageDal : GenericRepository<Message>, IMessageDal
    {
        private readonly IdentityMailContext _context;
        public EfMessageDal(IdentityMailContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Message>> GetSentMessagesByUserIdAsync(int id)
        {
            return await _context.Messages.Where(x => x.Recipients.Any(x => x.SenderId == id))
                 .Include(x => x.Category)
                 .OrderByDescending(x => x.SentDate)
                 .ToListAsync();
        }

        public async Task<List<Message>> MessageListByUserIdAsync(int id)
        {

            return await _context.Messages.Where(x => x.Recipients.Any(x => x.RecipientId == id))
                .Include(x => x.Category)
                .OrderByDescending(x => x.SentDate)
                .ToListAsync();

        }

        public async Task<List<Message>> GetMessagesByCategoryAndUserAsync(int categoryId, int userId)
        {
            return await _context.Messages
                .Where(m => m.Recipients.Any(r => r.RecipientId == userId)
                            && m.CategoryId == categoryId)
                .Include(m => m.Category)
                .OrderByDescending(m => m.SentDate)
                .ToListAsync();
        }

        public async Task CreateMailAsync(Message message, int senderId, List<int> Recipient)
        {
            message.SentDate = DateTime.UtcNow;
            message.IsRead = false;

            Random rnd = new Random();
            var totalCategories = await _context.Categories.CountAsync();
            if (totalCategories > 0)
            {
                var categoryId = rnd.Next(1, totalCategories + 1);
                message.CategoryId = categoryId;
            }



            if (message.Recipients == null)
                message.Recipients = new List<MessageSenderRecipient>();


            if (Recipient != null)
            {
                foreach (var recipient in Recipient)
                {
                    message.Recipients.Add(new MessageSenderRecipient
                    {
                        SenderId = senderId,
                        Message = message,
                        RecipientId = recipient


                    });
                }
            }


            _context.Messages.Add(message);
            await _context.SaveChangesAsync();

        }

        public async Task<Message> GetMessageDetailAsync(int id)
        {
            return await _context.Messages.Where(x => x.MessageId == id)
                .Include(x => x.Recipients)
                .ThenInclude(x => x.RecipientUser)
                .Include(x=> x.Recipients)
                .ThenInclude(x => x.SenderUser)
                .FirstOrDefaultAsync();

        }
    }
}
