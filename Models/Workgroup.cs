using Diplom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Diplom.Auth.Models
{
    public class Workgroup
    {
        public int Id { get; set; }
        public DateTime CreatedDataTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string Title { get; set; }
        public string Descripton { get; set; }
        public WorkgroupStatus WorkgroupStatus { get; set; }
        public List<Project> Projects { get; set; }
        public List<Account> WorkingUsers { get; set; }
        public List<WorkgroupTask> WorkgroupTasks { get; set; }
    }
}
