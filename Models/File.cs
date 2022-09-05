using Diplom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diplom.Auth.Models
{
    public class File
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Definition { get; set; }
        public DateTime Datetime { get; set; }
        public string Path { get; set; }
        public Account Creator { get; set; }
    }
}
