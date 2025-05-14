using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

string apiKey = ("OPENAI_API_KEY");
//methode pour corriger les fautes d'orthographes
static async Task<string> CorrectText(string text)
{
    using var client = new HttpClient();// Creer un client http qui communique avec open IA
    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

  
        messages = new[]
        {
            new { role = "user", content = $"Corrige le texte suivant : {text}" }
        }
    

    var response = await client.PostAsJsonAsync("https://api.openai.com/v1/chat/completions", requestBody);
    response.EnsureSuccessStatusCode();

    var result = await response.Content.ReadFromJsonAsync<dynamic>();
    return result.choices[0].message.content.ToString();*/
}

//methode pour traduire en anglais

static async Task<string> TranslateText(string text, string language)
{
    

    using var client = new HttpClient();
    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

    var requestBody = new
    {
        model = "gpt-3.5-turbo",
        messages = new[]
        {
            new { role = "user", content = $"Traduis le texte suivant en anglais ({language}) : {text}" }
        }
    };

    var response = await client.PostAsJsonAsync("https://api.openai.com/v1/chat/completions", requestBody);
    response.EnsureSuccessStatusCode();

    var result = await response.Content.ReadFromJsonAsync<dynamic>();
    return result.choices[0].message.content.ToString();
}

// methode pour gerer les erreurs (main)

 static async Task Main(string[] args)
{
    try
    {
        Console.WriteLine("Entrez le texte à corriger :");
        string inputText = Console.ReadLine();

        string correctedText = await CorrectText(inputText);
        Console.WriteLine("Texte corrigé :\n" + correctedText);

        Console.WriteLine("Choisissez la langue pour la traduction (US/UK) :");
        string language = Console.ReadLine();

        string translatedText = await TranslateText(correctedText, language);
        Console.WriteLine("Texte traduit :\n" + translatedText);

        GenerateHtmlFile(translatedText, "result.html");
        Console.WriteLine("Fichier HTML généré : result.html");
    }
    catch (Exception ex)
    {
        Console.WriteLine("Erreur : " + ex.Message);
    }
}
s
