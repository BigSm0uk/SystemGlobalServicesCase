using System.Net;
using Core.Domain;

namespace Api.Services;

public class CurrencyRatesHelper
{
    public async Task<string> GetCurrencyRatesAsync(IHttpContextAccessor context)
    {

        using var httpClient = new HttpClient();
        
        httpClient.BaseAddress = new Uri("https://www.cbr-xml-daily.ru/");
        
        var response = await httpClient.GetAsync("daily_json.js");

        if (response.StatusCode != HttpStatusCode.OK)
        {
            if (context.HttpContext != null) context.HttpContext.Response.StatusCode = (int)response.StatusCode;
            return $"Error: {response.StatusCode}";
        }
        
        var content = await response.Content.ReadAsStringAsync();
        
        return content;
    }

    public IEnumerable<Currency> GetValuteRange(CurrencyData data)
    {
        return data.Valute.Select(item => item.Value);
    }
}