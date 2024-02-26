using Api.Services;
using Core.Abstractions;
using Core.Domain;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuteController(
        IRepository<Currency> repository,
        IHttpContextAccessor httpContext,
        CurrencyRatesHelper currencyRatesHelper) : ControllerBase

    {
        // GET: api/<ValuteController>
        [HttpGet("currencies")]
        public async Task<IEnumerable<Currency?>> GetAll(int pageNumber, int pageSize)
        {
            return await repository.GetByPaginationAsync(pageSize, pageNumber);
        }

        // GET api/<ValuteController>/5
        [HttpGet("currency/{id}")]
        public async Task<Currency?> GetById(string id)
        {
            return await repository.GetByIdAsync(id);
        }

        // POST api/<ValuteController>
        [HttpPost]
        public async Task<string> Post()
        {
            var res = await currencyRatesHelper.GetCurrencyRatesAsync(httpContext);
            var currencyRatesObject = JsonConvert.DeserializeObject<CurrencyData>(res);
            if (currencyRatesObject == null) return "Ошибка чтения!";

            repository.CreateRange(currencyRatesHelper.GetValuteRange(currencyRatesObject));
            return $"Успешно загружено {currencyRatesObject.Valute.Count} записей";
        }

        // PUT api/<ValuteController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuteController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}