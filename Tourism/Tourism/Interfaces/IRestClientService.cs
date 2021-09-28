using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tourism.Models;

namespace Tourism.Interfaces
{
    [Headers("User-Agent: Enugu Tourism", "Authorization: Bearer")]
    public interface IRestClientService
    {
        [Get("/api/Destinations")]
        Task<List<DestinationResponse>> GetDestinations();
        [Get("/api/Destinations/{id}")]
        Task<DestinationResponse> GetDestinationById(int Id);

        [Get("/api/Images")]
        Task<List<ImageResponse>> GetImages();

        [Get("/api/Events")]
        Task<List<EventResponse>> GetEvents();

        [Get("/api/Destinations/categories")]
        Task<List<DestinationCategoryResponse>> GetCategories();

        [Get("/api/WhereToStay")]
        Task<List<WhereToStayResponse>> GetWhereToStays();

        [Get("/api/Destinations/articles")]
        Task<List<ArticleResponse>> GetRecentArticles();

        [Get("/api/Destinations/article/{type}")]
        Task<ArticleResponse> GetArticle(string type);

        [Get("/api/WhereToStay/{id}")]
        Task<WhereToStayResponse> GetWhereToStayDetails(int Id);

        [Get("/api/Events/{id}")]
        Task<EventResponse> GetEventDetails(int Id);
    }
}
