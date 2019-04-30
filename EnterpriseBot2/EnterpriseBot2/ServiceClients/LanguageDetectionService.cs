using EnterpriseBot2.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseBot2.ServiceClients
{
    public static class LanguageDetectionService
    {
        public static string endpoint = "YOUR_LANGUAGE_DETECTION_API"; //eg.https://southeastasia.api.cognitive.microsoft.com/text/analytics/v2.0/languages
        public static string key = "YOUR_TEXT_ANALYTICS_API_KEY";

        public static async Task<string> DetectAsync(string text)
        {
            try
            {
                string id = "1";
                LanguageDetectionRequestModel model = new LanguageDetectionRequestModel();
                model.documents = new List<Document>(){
                    new Document()
                    {
                        id = id,
                        text = text
                    }
                };
                using (HttpClient client = new HttpClient())
                {
                    // Request headers
                    client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", key);
                    

                    var a = JsonConvert.SerializeObject(model);
                    HttpResponseMessage message = await client.PostAsync(endpoint, new StringContent(a, Encoding.UTF8, "application/json"));
                    if (message.IsSuccessStatusCode)
                    {
                        var content = await message.Content.ReadAsStringAsync();
                        var m = JsonConvert.DeserializeObject<LanguageDetection>(content);

                        var languageName = m.documents.FirstOrDefault(x => x.id == id).detectedLanguages[0].iso6391Name;
                        return languageName.Substring(0, 2);
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;

        }
    }
}
