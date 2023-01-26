using Microsoft.AspNetCore.Mvc;
using CurrencyAPI.Services;

namespace CurrencyAPI.Controllers;

[ApiController]
public class CurrenciesController : Controller
{
    private readonly ICurrencyService _currencyService;

    public CurrenciesController(ICurrencyService currencyService) =>
        _currencyService = currencyService;


    /// <summary>
    /// Возвращает список валют 
    /// </summary>
    /// <param name="page">Текущая страница</param>
    /// <param name="pageSize">Кол-во элементов на странице</param>
    [HttpGet]
    [Route("api/currencies")]
    public async Task<ActionResult> GetCurrenciesAsync(int page = 1, int pageSize = 10)
    {
        var currencies = await _currencyService.GetCurrenciesAsync();
        var source = currencies.Valute.Values.ToList();
        var items = source.Skip((page - 1) * pageSize).Take(pageSize);

        return Ok(items);
    }

    /// <summary>
    /// Метод получения курса валюты
    /// </summary>
    /// <param name="id">Id валюты</param>
    [HttpGet]
    [Route("api/currency/{id?}")]
    public async Task<ActionResult> GetCurrencyAsync(string id)
    {
        var currencies = await _currencyService.GetCurrenciesAsync();
        decimal result = 0;
        foreach (var key in currencies.Valute.Keys)
            if (currencies.Valute[key].ID == id)
                result = currencies.Valute[key].Value;

        return Ok(result);
    }

}
