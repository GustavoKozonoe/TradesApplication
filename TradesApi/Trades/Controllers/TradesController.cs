using Microsoft.AspNetCore.Mvc;
using Trades.Interface;
using Trades.ViewModels;

namespace Trades.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TradesController : ControllerBase
    {
        private readonly ITradesService _Tradeservice;

        public TradesController(ITradesService Tradeservice)
        {
            _Tradeservice = Tradeservice;
        }

        [HttpPost]
        public IActionResult Add(AddTradeViewModel newTrade)
        {
            var trade = newTrade.ToTrade();
            var result = _Tradeservice.Add(trade);
            if (result == null)
            {
                return UnprocessableEntity();
            }
            
            var newResult = new TradeViewModel(result);
            return Created("Trades", newResult); 
        }

        [HttpPut]
        public IActionResult Edit(EditTradeViewModel newTrade)
        {
            var trade = newTrade.ToTrade();
            var result = _Tradeservice.Edit(trade);
            if (result == null)
            {
                return UnprocessableEntity();
            }
            var newResult = new TradeViewModel(result);
            return Ok(newResult);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int Id)
        {
            _Tradeservice.Delete(Id);
            return NoContent();
        }

        [HttpGet]
        public IActionResult GetAllTrades()
        {
            var trades = _Tradeservice.GetAllTrades();
            var result = new List<TradeViewModel>();

            foreach(var trade in trades)
            {
                var tradeViewModel = new TradeViewModel(trade);
                result.Add(tradeViewModel);
            }

            return Ok(result);
        }

        [HttpGet("getByCounterpartyId/{counterpartyId}")]
        public IActionResult SearchTrade(int counterpartyId)
        {
            var trades = _Tradeservice.SearchTrade(counterpartyId);
            var result = new List<TradeViewModel>();

            foreach (var trade in trades)
            {
                var tradeViewModel = new TradeViewModel(trade);
                result.Add(tradeViewModel);
            }

            return Ok(result);
        }

        [HttpGet("getById/{id}")]
        public IActionResult GetTrade(int id)
        {
            var trade = _Tradeservice.GetTrade(id);

            var result = new TradeViewModel(trade);

            return Ok(result);
        }
    }
}
