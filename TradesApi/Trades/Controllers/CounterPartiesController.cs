using Microsoft.AspNetCore.Mvc;
using Trades.Interface;
using Trades.ViewModels.CounterParty;

namespace Trades.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CounterPartiesController : ControllerBase
    {
        private readonly ICounterPartiesService _CounterPartyService;

        public CounterPartiesController(ICounterPartiesService Counterpartyservice)
        {
            _CounterPartyService = Counterpartyservice;
        }

        [HttpPost]
        public IActionResult Add(AddCounterPartyViewModel newCounterParty)
        {
            var counterParty = newCounterParty.ToCounterParty();
            var result = _CounterPartyService.Add(counterParty);
            if (result == null)
            {
                return UnprocessableEntity();
            }

            var newResult = new CounterPartyViewModel(result);
            return Created("CounterParties", newResult);
        }

        [HttpPut]
        public IActionResult Edit(EditCounterPartyViewModel newCounterParty)
        {
            var counterParty = newCounterParty.ToCounterParty();
            var result = _CounterPartyService.Edit(counterParty);
            if (result == null)
            {
                return UnprocessableEntity();
            }
            var newResult = new CounterPartyViewModel(result);
            return Ok(newResult);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _CounterPartyService.Delete(id);
            return NoContent();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var counterParties = _CounterPartyService.GetAll();
            var result = new List<CounterPartyViewModel>();
            foreach (var cp in counterParties)
            {
                var counterPartyViewModel = new CounterPartyViewModel(cp);
                result.Add(counterPartyViewModel);
            }

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult Search(int id)
        {
            var result = _CounterPartyService.Search(id);
            var newResult = new CounterPartyViewModel(result);
            return Ok(newResult);
        }

    }
}
