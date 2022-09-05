using Diplom.Models;
using System;
using System.Collections.Generic;

namespace Diplom.Auth.Models
{
    public class WorkgroupTask
    {
        public int Id { get; set; }
        public DateTime BeginDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string Title { get; set; }
        public string Definition { get; set; }
        public WorkgroupTaskStatus WorkgroupTaskStatus {get;set;}

        public List<UserTask> UserTasks { get; set; }
    }
}