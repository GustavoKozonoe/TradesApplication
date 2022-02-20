using Trades.Entities;

namespace Trades.Interface
{
    public interface ITradesService
    {
        public Trade Add(Trade newTrade);
        public void Delete(int id);
        public Trade? Edit(Trade newTrade);
        public List<Trade> GetAllTrades();
        public List<Trade> SearchTrade(int counterpartyId);
        public Trade GetTrade(int id);
    };
}
