using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tourism.Helpers;
using Tourism.Interfaces;
using Tourism.Models;

namespace Tourism.Services.Business
{
    public class CategoryService : ICategoryService
    {
        private readonly IRestClientService _restClient;

        public CategoryService()
        {
            _restClient = RefitHelper.GetService();
        }

        public async Task<List<DestinationCategoryResponse>> GetCategories()
        {
            return await _restClient.GetCategories();
        }
    }
}
