using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tourism.Helpers;
using Tourism.Interfaces;
using Tourism.Models;

namespace Tourism.Services.Business
{
    public class ImageService: IImageService
    {
        private readonly IRestClientService _restClient;

        public ImageService()
        {
            _restClient = RefitHelper.GetService();
        }

        public async Task<List<ImageResponse>> GetImages()
        {
            return await _restClient.GetImages();
        }
    }
}
