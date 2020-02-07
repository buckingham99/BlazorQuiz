using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorQuiz.Models
{
    public class CategoryQuestion
    {
        public string category { get; set; }
        public string type { get; set; }
        public string difficulty { get; set; }
        public string question { get; set; }
        public string correct_answer { get; set; }
        public List<string> incorrect_answers { get; set; }
    }

    public class RootObject_CategoryQuestion
    {
        public int response_code { get; set; }
        public CategoryQuestion[] results { get; set; }
    }
}
