using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Shared.Models
{
    public class Message
    {
        public string[] Recipients { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        public Message(string[] recipients, string subject, string body)
        {
            Recipients = recipients;
            Subject = subject;
            Body = body;
        }
    }
}
