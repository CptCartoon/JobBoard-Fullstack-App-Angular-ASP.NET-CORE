namespace JobBoardBackend.Entities
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public int UserLoginId { get; set; }
        public virtual UserLogin UserLogin { get; set; }
    }
}
