namespace JobBoardBackend.Entities.JobBoardEntities
{
    public class SalaryRange
    {
        public int Id { get; set; }
        public decimal LowRange { get; set; }
        public decimal HighRange { get; set; }
        public int TypeOfContractId { get; set; }
        public virtual TypeOfContract TypeOfContract { get; set; }
        public int JobPostingID { get; set; }
        public virtual JobPosting JobPosting { get; set; }
    }
}
