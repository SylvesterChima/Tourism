using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tourism.Helpers;
using Tourism.Interfaces;
using Tourism.Models;

namespace Tourism.Services.Business
{
    public class ArticleService : IArticleService
    {
        private readonly IRestClientService _restClient;

        public ArticleService()
        {
            _restClient = RefitHelper.GetService();
        }

        public async Task<ArticleResponse> GetArticle(string type)
        {
            return await _restClient.GetArticle(type);
        }

        public async Task<List<ArticleResponse>> GetRecentArticles()
        {
            return await _restClient.GetRecentArticles();
        }
    }
}
