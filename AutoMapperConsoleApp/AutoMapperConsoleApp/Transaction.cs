namespace AutoMapperConsoleApp
{
    // Represents a financial transaction in the domain model
    public class Transaction
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public Account Account { get; set; }
    }
}
