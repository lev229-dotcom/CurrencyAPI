using CurrencyAPI.Models;
using Flurl.Http;

namespace CurrencyAPI.Services;

public class CurrencyService : ICurrencyService
{
    public async Task<CurrenciesResponse> GetCurrenciesAsync()
    {
        var response = await System.Configuration.ConfigurationManager.AppSettings.Get("Url")
            .GetJsonAsync<CurrenciesResponse>();
        return response;
    }

}
