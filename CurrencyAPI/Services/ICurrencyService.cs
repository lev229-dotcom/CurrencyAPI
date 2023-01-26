using CurrencyAPI.Models;

namespace CurrencyAPI.Services;

public interface ICurrencyService
{
    Task<CurrenciesResponse> GetCurrenciesAsync();
}
