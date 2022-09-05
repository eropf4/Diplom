using System;
using System.Collections.Generic;

namespace Diplom.Models
{
    public class ChatRoom
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Account> Accounts { get; set; }
        public List<Message> Messages { get; set; }
        public CreatingChatData CreatingChatData { get; set; }
    }
}
