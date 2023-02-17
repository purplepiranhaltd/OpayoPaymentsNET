namespace OpayoPaymentsNet.Domain.Entities.Transactions.Responses
{
    public class OpayoCardResponse
    {
        public string CardType { get; set; }
        public string LastFourDigits { get; set; }
        public string Expiry { get; set; }
        public string CardIdentifier { get; set; }
        public bool Reusable { get; set; }
    }
}
