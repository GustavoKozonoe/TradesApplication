using Trades.Entities;
using Trades.Entities.Enums;
using Trades.ViewModels.CounterParty;

namespace Trades.ViewModels
{
    public class TradeViewModel
    {
        public int CounterPartyId { get; set; }
        public DateTime Date { get; set; }
        public DirectionEnum Direction { get; set; }
        public int Id { get; set; }
        public double Price { get; set; }
        public string Product { get; set; }
        public int Quantity { get; set; }
        public CounterPartyViewModel CounterParty { get; set; }

        public TradeViewModel(Trade trade)
        {
            Id = trade.Id;
            CounterPartyId = trade.CounterPartyId;
            Date = trade.Date;
            Direction = trade.Direction;
            Price = trade.Price;
            Product = trade.Product;
            Quantity = trade.Quantity;
            if (trade.CounterParty != null)
                CounterParty = new CounterPartyViewModel(trade.CounterParty);
        }
    }
}
