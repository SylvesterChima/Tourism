using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tourism.Interfaces;
using Tourism.Models;

namespace Tourism.Services.Business
{
    public class AppState : IAppState
    {
        public List<DestinationResponse> Destinations { get; set; } = new List<DestinationResponse>();
        public List<EventResponse> Events { get; set; } = new List<EventResponse>();
        public List<ImageResponse> Images { get; set; } = new List<ImageResponse>();

        public List<DestinationResponse> GetBanners()
        {
            if(Destinations.Count > 5)
            {
                return GetRandomFromList(Destinations, 5);
            }
            else
            {
                return Destinations;
            }
        }

        public List<EventResponse> GetRandomEvents()
        {
            if (Events.Count > 5)
            {
                return GetRandomFromList(Events, 5);
            }
            else
            {
                return Events;
            }
        }

        public List<ImageResponse> GetRecentImages()
        {
            return Images.OrderBy(c => c.Date).Take(5).ToList();
        }

        public List<DestinationResponse> GetTopDestinations()
        {
            return Destinations.OrderBy(c => c.Date).Take(5).ToList();
        }

        private List<T> GetRandomFromList<T>(List<T> passedList, int numberToChoose)
        {
            System.Random rnd = new System.Random();
            List<T> chosenItems = new List<T>();

            for (int i = 1; i <= numberToChoose; i++)
            {
                int index = rnd.Next(passedList.Count);
                chosenItems.Add(passedList[index]);
            }


            return chosenItems;
        }
    }
}
