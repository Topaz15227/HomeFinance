namespace HomeFinance.Domain.Entities
{
    public class ViewCardPays
    {
        public int Id { get; set; }
        public int NumOfPays { get; set; }
        public string CardName { get; set; }
        public decimal Total { get; set; }
        public decimal ActiveTotal { get; set; }
    }
}
