namespace Trades.ViewModels.CounterParty
{
    using Trades.Entities;
    public class AddCounterPartyViewModel
    {
        public string? Name { get; set; }

        public CounterParty ToCounterParty()
        {
            var result = new CounterParty
            {
                Name = Name,
            };

            return result;
        }
    }
}
