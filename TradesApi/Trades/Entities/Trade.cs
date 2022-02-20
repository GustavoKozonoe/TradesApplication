using Trades.Entities.Enums;

namespace Trades.Entities
{
    public class Trade
    {
        public int CounterPartyId { get; set; }
        public CounterParty CounterParty { get; set; }
        public DateTime Date { get; set; }
        public DirectionEnum Direction { get; set; }
        public int Id { get; set; }
        public double Price { get; set; }
        public string Product { get; set; }
        public int Quantity { get; set; }
        public void Update(Trade newTrade)
        {
            CounterPartyId = newTrade.CounterPartyId;
            Date = newTrade.Date;
            Direction = newTrade.Direction;
            Price = newTrade.Price;
            Product = newTrade.Product;
            Quantity = newTrade.Quantity;
        }
    }
}
