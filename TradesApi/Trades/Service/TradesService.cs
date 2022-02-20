using Microsoft.EntityFrameworkCore;
using Trades.DataBase;
using Trades.Entities;

namespace Trades.Interface
{
    public class TradesService : ITradesService
    {
        private readonly DataContext _context;

        public TradesService(DataContext context)
        {
            _context = context;
        }
        public void Delete(int id)
        {
            var tradeFound = _context.Trades.FirstOrDefault(t => t.Id == id);

            if (tradeFound != null)
            {
                _context.Trades.Remove(tradeFound);
                _context.SaveChanges();
            }
        }
        public Trade Add(Trade newTrade)
        {
            var counterParty = _context.CounterParty.FirstOrDefault(cp => cp.Id == newTrade.CounterPartyId);
            if (counterParty != null)
            {
                _context.Trades.Add(newTrade);
                _context.SaveChanges();
                return newTrade;
            }
            return null;
        }
        public Trade? Edit(Trade newTrade)
        {
            var tradeFound = _context.Trades.FirstOrDefault(t => t.Id == newTrade.Id);
            if (tradeFound == null) return null;

            var counterPartyExists = _context.CounterParty.Any(cp => cp.Id == newTrade.CounterPartyId);
            if (counterPartyExists)
            {
                tradeFound.Update(newTrade);
                _context.SaveChanges();
            }

            return tradeFound;
        }
        public List<Trade> GetAllTrades()
        {
            var allTrades = _context.Trades;

            return allTrades.Include(t => t.CounterParty).AsNoTracking().ToList();
        }
        public List<Trade> SearchTrade(int counterpartyId)
        {
            var tradesFound = _context.Trades 
                .Include(t => t.CounterParty)
                .AsNoTracking()
                .Where(t => t.CounterPartyId == counterpartyId)
                .ToList();

            return tradesFound;
        }

        public Trade? GetTrade(int id)
        {
            var tradeFound = _context.Trades
                .Include(t => t.CounterParty)
                .AsNoTracking()
                .FirstOrDefault(t => t.Id == id);

            return tradeFound;
        }
    }
}

