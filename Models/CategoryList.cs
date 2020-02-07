using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BlazorQuiz.Models
{

    public partial class CategoryList
    {
        [JsonProperty("trivia_categories")]
        public CategoryList[] TriviaCategories { get; set; }
    }

    public partial class CategoryList
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public partial class CategoryList
    {
        public static CategoryList FromJson(string json) => JsonConvert.DeserializeObject<CategoryList>(json, BlazorQuiz.Models.Converter.Settings);
    }


}
