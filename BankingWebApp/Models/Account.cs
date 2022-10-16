namespace BankingWebApp.Models
{
    public partial class Account
    {
        public int Id { get; set; }
        public string? AccNo { get; set; }
        public string? CustomerName { get; set; }
        public decimal Balance { get; set; }
    }
}
