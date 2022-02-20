namespace Trades.ViewModels.CounterParty
{
    using Trades.Entities;
    public class CounterPartyViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public CounterPartyViewModel(CounterParty counterParty)
        {
            Id = counterParty.Id;
            Name = counterParty.Name;
        }
    }
}
