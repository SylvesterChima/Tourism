using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tourism.Models;

namespace Tourism.Interfaces
{
    public interface ICategoryService
    {
        Task<List<DestinationCategoryResponse>> GetCategories();
    }
}
