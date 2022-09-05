using System;

namespace Diplom.Models
{
    public class CreatingChatData
    {
        public int Id { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public Account UserCreate { get; set; }
    }
}