using System;
using System.Linq;
using System.Threading.Tasks;
using Flurl.Http;
using TranslatorAzure.Models;

namespace TranslatorAzure
{
    class Program
    {
        const string REGION = "brazilsouth";
        const string BASE_TRANSLATOR_URL = "https://api.cognitive.microsofttranslator.com/";
        const string API_URL = "translate?api-version=3.0&to=en";
        const string TRANSLATOR_KEY = "AQUI_ESTÁ_SUA_CHAVE_TRANSLATOR";
        static async Task Main(string[] args)
        {
            Console.WriteLine("-------Serviço de tradução do Português para Inglês-------");
            string text;

            while (true) {
                Console.WriteLine("Digite um texto em português ou '0' para encerrar.");
                text = Console.ReadLine();

                if (text == "0")
                    break;

                var translation = await GetTranslationFromPtToEn(text);

                Console.WriteLine($"A tradução para o inglês é: {translation}");
            }    
        }

        static async Task<string> GetTranslationFromPtToEn(string textInPortuguese) {
            var fullTranslatorUrl = BASE_TRANSLATOR_URL + API_URL;

            var body = new object[] { new { Text = textInPortuguese } };

            var result = await fullTranslatorUrl
                .WithHeader("Ocp-Apim-Subscription-Key", TRANSLATOR_KEY)
                .WithHeader("Ocp-Apim-Subscription-Region", REGION)
                .PostJsonAsync(body)
                .ReceiveJson<TranslationResult[]>();

            return result[0].Translations.First().Text;
        }
    }
}
