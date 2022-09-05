using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Diplom.Models;
using Diplom.Auth.Models;


namespace Diplom.DBContext
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<ChatRoom> ChatRooms { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<UserReference> UserReferences { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<UserTask> UserTasks { get; set; }
        public DbSet<CreatingChatData> CreatingChatDatas { get; set; }
        public DbSet<Workgroup> Workgroups { get; set; }
        public DbSet<WorkgroupStatus> WorkgroupStatuses { get; set; }
        public DbSet<WorkgroupTask> WorkgroupTasks { get; set; }
        public DbSet<WorkgroupTaskStatus> WorkgroupTaskStatuses { get; set; }
        public DbSet<ProjectStatus> projectStatuses { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<MessageReferences> MessageReferences { get; set; }
    }
}
