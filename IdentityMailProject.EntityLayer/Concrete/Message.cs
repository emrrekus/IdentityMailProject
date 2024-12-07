using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityMailProject.EntityLayer.Concrete
{
    public class Message
    {

        public int MessageId { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public DateTime SentDate {  get; set; } 

        public int CategoryId { get; set; }
        public Category Category { get; set; }


        public ICollection<MessageSenderRecipient> Recipients { get; set; }
    }
}
