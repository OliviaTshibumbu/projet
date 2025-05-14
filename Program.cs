using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

string apiKey = ("KEY");
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

