using Diplom.Auth.Models;
using Diplom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diplom.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime Time { get; set; }
        public Account messageCreator { get; set; }

        public List<File> Files { get; set; }
        public List<MessageReferences> References { get; set; }
    }
}
