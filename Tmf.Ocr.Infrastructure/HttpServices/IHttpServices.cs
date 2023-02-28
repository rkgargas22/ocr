using System.Text.Json;

namespace Tmf.Ocr.Infrastructure.HttpServices;

public interface IHttpServices
{
    Task<JsonDocument> GetAsync(string uri);

    Task<JsonDocument> PostAsync<TIn>(string uri, TIn model);
}
