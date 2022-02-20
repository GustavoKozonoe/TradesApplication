using Microsoft.EntityFrameworkCore;
using Trades.DataBase;
using Trades.Entities;
using Trades.Interface;

namespace Trades
{
    public class CounterPartiesService : ICounterPartiesService
    {
        private readonly DataContext _context;

        public CounterPartiesService(DataContext context)
        {
            _context = context;
        }

        public CounterParty Add(CounterParty newCounterParty)
        {
            _context.CounterParty.Add(newCounterParty);
            _context.SaveChanges();
 
            return newCounterParty;
        }

        public void Delete(int id)
        {
            var counterParty = _context.CounterParty.FirstOrDefault(cp => cp.Id == id);

            if (counterParty != null)
            {
                _context.CounterParty.Remove(counterParty);
                _context.SaveChanges();
            }
        }

        public CounterParty? Edit(CounterParty newCounterParty)
        {
            var counterPartyFound = _context.CounterParty.FirstOrDefault(cp => cp.Id == newCounterParty.Id);
            if (counterPartyFound != null)
            {
                counterPartyFound.Update(newCounterParty);
                _context.SaveChanges();
                return counterPartyFound;
            }

            return null;
        }

        public List<CounterParty> GetAll()
        {
            var allCounterParties = _context.CounterParty;
            return allCounterParties.AsNoTracking().ToList();
        }

        public CounterParty? Search(int id)
        {
            var CounterPartyFound = _context.CounterParty
                .AsNoTracking()
                .FirstOrDefault(cp => cp.Id == id);

            return CounterPartyFound;
        }
    }
}
