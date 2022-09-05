using Diplom.Auth.Models;
using System.Collections.Generic;
using System;
namespace Diplom.Models
{
    public class UserTask
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description {get;set;}
        public string Reference { get; set; }
        public string Review { get; set; }
        public Readiness Readiness { get; set; }
        public DateTime EndDateTime { get; set; }
        public List<File> Files { get; set; }
    }

    public enum Readiness
    {
        Given,
        Started,
        UnderReview,
        Done
    }
}