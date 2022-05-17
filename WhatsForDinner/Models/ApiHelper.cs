using System.Threading.Tasks;
using RestSharp;
using System;

namespace WhatsForDinner.Models
{
  public class ApiHelper
  {
    public static async Task<string> ApiCall(string apiKey, string recipeUrl)
    {
      RestClient client = new RestClient($"https://api.spoonacular.com/recipes/");
      RestRequest request = new RestRequest($"extract?apiKey={apiKey}&url={recipeUrl}");
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }
  }
}