namespace BankingWebApp.Models
{
    public partial class Account
    {
        public override string ToString() {
            return this.Id + " " + this.AccNo;
        }
    }
}
