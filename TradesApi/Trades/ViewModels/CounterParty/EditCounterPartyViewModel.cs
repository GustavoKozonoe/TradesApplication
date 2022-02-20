namespace Trades.ViewModels.CounterParty
{
    using Trades.Entities;
    public class EditCounterPartyViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public CounterParty ToCounterParty()
        {
            var result = new CounterParty
            {
                Name = Name,
                Id = Id
            };

            return result;
        }
    }
}
