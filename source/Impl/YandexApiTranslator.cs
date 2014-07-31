namespace YandexClipboardTranslator.Impl
{
    using System.Collections.Generic;
    using System.Net.Http;
    using Newtonsoft.Json;

    public class YandexApiTranslator : IYandexApiTranslator
    {

        public string Translate(string source)
        {
            var client = new HttpClient();
            var url = string.Format("{0}?key={1}&text={2}&lang={3}", YandexApiSettings.YandexApiUrl, YandexApiSettings.ApiKey, source, YandexApiSettings.Lang);
            var serverResult = client.GetAsync(url).Result.Content.ReadAsStringAsync().Result;
            var apiResult = JsonConvert.DeserializeObject<YandexApiResult>(serverResult);

            return string.Join(" ", apiResult.Text);
        }

        private class YandexApiResult
        {
            public int Code { get; set; }
            public string Lang { get; set; }
            public IEnumerable<string> Text { get; set; }
        }
    }
}