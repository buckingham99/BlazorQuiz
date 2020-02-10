using System;
using System.Net.Http;
using System.Threading.Tasks;
using BlazorQuiz.Models;
using Newtonsoft.Json;
using BlazorQuiz.Helpers;
namespace BlazorQuiz.Services
{
    public class QuizService
    {
        private HttpClient _client = new HttpClient();
        private SpecialCharactersCheck specialCharacters = new SpecialCharactersCheck();
        private string BaseUrl = @"https://opentdb.com/";
        private HttpResponseMessage httpResponse = new HttpResponseMessage();
        public async Task<CategoryList> GetAllCategoriesAsync() 
        {
            var _BaseUrl = BaseUrl + @"api_category.php";
            httpResponse = await GetResponse(_BaseUrl);

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrieve Categories");
            }
            var content = await httpResponse.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<CategoryList>(content);
            return result;
        }
        public async Task<CategoryQuestions> GetQuestionsInCategoryAsync(string CategoryID)
        {
            var _BaseUrl = BaseUrl + @"api_count.php?category=" + CategoryID;
            httpResponse = await GetResponse(_BaseUrl);

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrieve Questions");
            }
            var content = await httpResponse.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<CategoryQuestions>(content);
            return result;
        }
        public async Task<QuizQuestions> GetQuestions(string selectedCategory, string difficulty, string formatType)
        {
            var _BaseUrl = BaseUrl + 
                @"api.php?amount=10&category=" + selectedCategory +
                "&difficulty=" + difficulty + "&type=" + formatType;

            httpResponse = await GetResponse(_BaseUrl);

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrieve Questions");
            }

            Task<string> _content = ReadResponseContent(httpResponse);
            var content = specialCharacters.CharacterCheck(await _content);

            var result = JsonConvert.DeserializeObject<QuizQuestions>(content);

            return result;
        }
        private async Task<HttpResponseMessage> GetResponse(string _url)
        {
            return await _client.GetAsync(_url);
        }
        private Task<string> ReadResponseContent(HttpResponseMessage _response)
        { 
            return _response.Content.ReadAsStringAsync();
        }
    }
}
