namespace Diplom.Auth.Models
{
    public class WorkgroupTaskStatus
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Reference { get; set; }
        public Readiness Readiness { get; set; }
    }

    public enum Readiness
    {
        Given,
        Started,
        UnderReview,
        Done
    }
}