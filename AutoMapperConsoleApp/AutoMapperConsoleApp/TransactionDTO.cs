namespace AutoMapperConsoleApp
{
    // Data Transfer Object for Transaction, used for reporting or API responses
    public class TransactionDTO
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string Details { get; set; }
        public string AccountName { get; set; }
        public string DateString { get; set; }
    }
}
