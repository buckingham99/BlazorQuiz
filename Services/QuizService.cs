using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using BlazorQuiz.Models;
using Newtonsoft.Json;

namespace BlazorQuiz.Services
{
    public class QuizService
    {
        private HttpClient _client = new HttpClient();
        private string BaseUrl = "";
        private HttpResponseMessage httpResponse = new HttpResponseMessage();
        public async Task<CategoryList> GetAllCategoriesAsync() 
        {
            BaseUrl = "https://opentdb.com/api_category.php";
            httpResponse = await _client.GetAsync(BaseUrl);
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
            BaseUrl = "https://opentdb.com/api_count.php?category=" + CategoryID;
            httpResponse = await _client.GetAsync(BaseUrl);
            
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
            BaseUrl = "https://opentdb.com/api.php?amount=10&category=" + selectedCategory +
                "&difficulty=" + difficulty + "&type=" + formatType;
            httpResponse = await _client.GetAsync(BaseUrl);

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot retrieve Questions");
            }

            var content = await httpResponse.Content.ReadAsStringAsync();
            content = content.Replace("&quot;", "'");
            content = content.Replace("&#039;", "'");
            content = content.Replace("&shy;", "-");
            content = content.Replace("&amp;", "&");
            content = content.Replace("&iacute;", "i");
            content = content.Replace("&auml;", "ä");
            content = content.Replace("&ouml;", "ö");
            content = content.Replace("&oacute;", "ó");
            content = content.Replace("&ndash;", "-");
            content = content.Replace("&Ograve;", "ò");
            content = content.Replace("&euml;", "ë");
            content = content.Replace("&rsquo;", "’");
            content = content.Replace("&ldquo;", "“");
            content = content.Replace("&rdquo;", "”");
            var result = JsonConvert.DeserializeObject<QuizQuestions>(content);

            return result;
        }

    }
}
