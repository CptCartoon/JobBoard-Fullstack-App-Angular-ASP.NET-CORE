using JobBoardBackend.Entities.AuthEntities;

namespace JobBoardBackend.Entities.JobBoardEntities
{
    public class JobPosting
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
        public int PostingStatusId { get; set; }
        public virtual PostingStatus PostingStatus { get; set; }
    }
}
