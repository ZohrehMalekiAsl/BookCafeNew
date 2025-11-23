namespace BookCafe.Domain.Entities
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalId { get; set; }
        public string Email { get; set; }
        public string CellPhone { get; set; }
        public Address Address { get; set; }
    }
}
