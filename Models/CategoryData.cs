using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BlazorQuiz.Models
{
    public partial class CategoryQuestions
    {
        [JsonProperty("category_id")]
        public long CategoryId { get; set; }

        [JsonProperty("category_question_count")]
        public CategoryQuestionCount CategoryQuestionCount { get; set; }
    }

    public partial class CategoryQuestionCount
    {
        [JsonProperty("total_question_count")]
        public long TotalQuestionCount { get; set; }

        [JsonProperty("total_easy_question_count")]
        public long TotalEasyQuestionCount { get; set; }

        [JsonProperty("total_medium_question_count")]
        public long TotalMediumQuestionCount { get; set; }

        [JsonProperty("total_hard_question_count")]
        public long TotalHardQuestionCount { get; set; }
    }

    public partial class CategoryQuestions
    {
        public static CategoryQuestions FromJson(string json) => JsonConvert.DeserializeObject<CategoryQuestions>(json, BlazorQuiz.Models.Converter.Settings);
    }


}
