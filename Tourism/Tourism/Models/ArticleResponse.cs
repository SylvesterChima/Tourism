using System;
using System.Collections.Generic;
using System.Text;

namespace Tourism.Models
{
    public class ArticleResponse
    {
        public int Id { get; set; }
        public string AType { get; set; }
        public string ATitle { get; set; }
        public string ImageUrl { get; set; }
        public string AContent { get; set; }
        public DateTime Date { get; set; }
    }
}
