namespace JobBoardBackend.Entities.AuthEntities
{
    public class Client
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public int UserLoginId { get; set; }
        public virtual UserLogin UserLogin { get; set; }
    }
}
