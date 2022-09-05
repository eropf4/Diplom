using Diplom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diplom.Auth.Models
{
    public class Project
    {
        public int Id { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public string ProjectTittle { get; set; }
        public string Refference { get; set; }
        public List<Account> ProjectUsers { get; set; }
        public string Description { get; set; }
        public ProjectStatus Status { get; set; }
        public ChatRoom ChatRoom { get; set; }
        public List<Workgroup> Workgroups { get; set; }
        public List<File> Files { get; set; }
    }
}
