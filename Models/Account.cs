using Diplom.Auth.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Diplom.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Role AccountRole { get; set; }
        public bool InSystem { get; set; }
        public string NickName { get; set; }
        public UserRole UserRole { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public string PhoneNumber { get; set; }
        public Icon UserIcon { get; set; }

        public List<UserReference> References { get; set; }
        public List<UserTask> UserTasks { get; set; }

        public List<ChatRoom> ChatRooms { get; set; }
        public List<Workgroup> Workgroups { get; set; }
        public List<Project> Projects { get; set; }
    }

    public enum Role
    {
        User,
        Admin
    }
}
