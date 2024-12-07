using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityMailProject.EntityLayer.Concrete
{
    public class MessageSenderRecipient
    {

        public int SenderId { get; set; }
        public AppUser SenderUser {  get; set; }

        public int RecipientId {  get; set; }
        public AppUser RecipientUser { get; set; }

        public int MessageId { get; set; }
        public Message Message { get; set; }

    }
}
