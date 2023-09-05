using System.Net.Http;
using System.Text.Json;

namespace StringConverter.Data
{
    public class TranslateTexts:ITranslateText
    {
        private readonly HttpClient _httpClient;

        public TranslateTexts(IHttpClientFactory httpClientFactory)
        {
             _httpClient = httpClientFactory.CreateClient("StringHttpClient");
        }

        public async Task<string?> TranslateText(string text)
        {

            try
            {
                var result = await _httpClient.GetFromJsonAsync<TranslationResult>($"https://api.funtranslations.com/translate/leetspeak.json?text={text}");

                return result?.Contents?.Translated;
            }
            catch (HttpRequestException ex)
            {

            }
            catch (JsonException ex)
            {
                return string.Empty;
            }

            return null;
        }
    }

    public interface ITranslateText
    {
        Task<string?> TranslateText(string text);
    }
}
