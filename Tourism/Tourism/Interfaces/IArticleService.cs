using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tourism.Models;

namespace Tourism.Interfaces
{
    public interface IArticleService
    {
        Task<List<ArticleResponse>> GetRecentArticles();
        Task<ArticleResponse> GetArticle(string type);
    }
}
