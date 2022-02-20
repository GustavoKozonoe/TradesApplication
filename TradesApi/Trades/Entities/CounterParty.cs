namespace Trades.Entities
{
    public class CounterParty
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<Trade> trades { get; set; }

        public void Update(CounterParty counterParty)
        {
            Name = counterParty.Name;
        }
    }
}
