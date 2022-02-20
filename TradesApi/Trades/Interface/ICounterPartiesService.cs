using Trades.Entities;

namespace Trades.Interface
{
    public interface ICounterPartiesService
    {
        public CounterParty Add(CounterParty newCounterParty);
        public void Delete(int id);
        public CounterParty? Edit(CounterParty newCounterParty);
        public List<CounterParty> GetAll();
        public CounterParty? Search(int id);
    }
}
