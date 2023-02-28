using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text;
using Tmf.Ocr.Core.Options;
using Microsoft.Extensions.Options;

namespace Tmf.Ocr.Infrastructure.HttpServices;

public class HttpServices : IHttpServices
{
    private readonly IHttpClientFactory _httpClientFactory;
    private OcrOptions _options;
    public HttpServices(IHttpClientFactory httpClientFactory, IOptions<OcrOptions> options)
    {
        _httpClientFactory = httpClientFactory;
        _options = options.Value;
    }

    public async Task<JsonDocument> GetAsync(string uri)
    {
        var httpClient = _httpClientFactory.CreateClient();
        httpClient.DefaultRequestHeaders.Clear();
        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        httpClient.DefaultRequestHeaders.Add(_options.ApiKey, _options.ApiKeyValue);
        httpClient.DefaultRequestHeaders.Add(_options.AccountId, _options.AccountIdValue);


        HttpResponseMessage response = await httpClient.GetAsync(uri);
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception();
        }

        return await response.Content.ReadFromJsonAsync<JsonDocument>();
    }

    public async Task<JsonDocument> PostAsync<TIn>(string uri, TIn model)
    {
        var httpClient = _httpClientFactory.CreateClient();
        httpClient.DefaultRequestHeaders.Clear();
        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        httpClient.DefaultRequestHeaders.Add(_options.ApiKey, _options.ApiKeyValue);
        httpClient.DefaultRequestHeaders.Add(_options.AccountId, _options.AccountIdValue);

        HttpResponseMessage response = await httpClient.PostAsync(uri, new StringContent(JsonSerializer.Serialize(model), UnicodeEncoding.UTF8, "application/json"));
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception();
        }

        return await response.Content.ReadFromJsonAsync<JsonDocument>();
    }
}