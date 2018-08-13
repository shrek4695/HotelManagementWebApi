using FluentAssertions;
using HotelManagementSystem.Models;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace HotelManagementSystem.Tests
{
    [Binding]
    public class AddHotelSteps
    {
        private Hotel hotel = new Hotel();
        private Hotel addHotelResponse;
        private List<Hotel> hotels = new List<Hotel>();
        private List<int> idList = new List<int>();
        public int id { get; set; }


        [Given(@"User provided valid Id '(.*)'  and '(.*)'for hotel")]
        public void GivenUserProvidedValidIdAndForHotel(int id, string name)
        {
            hotel.Id = id;
            hotel.Name = name;
            this.id = id;
        }

        [Given(@"User has added required details for hotel")]
        public void GivenUseHasAddedRequiredDetailsForHotel()
        {
            SetHotelBasicDetails();
        }
        [Given(@"User calls AddHotel api")]
        [When(@"User calls AddHotel api")]
        public void WhenUserCallsAddHotelApi()
        {
            hotels = HotelsApiCaller.AddHotel(hotel);
            idList.Add(hotel.Id);
        }

        [Then(@"Hotel with name '(.*)' should be present in the response")]
        public void ThenHotelWithNameShouldBePresentInTheResponse(string name)
        {
            hotel = hotels.Find(htl => htl.Name.ToLower().Equals(name.ToLower()));
            hotel.Should().NotBeNull(string.Format("Hotel with name {0} not found in response",name));
        }

        private void SetHotelBasicDetails()
        {
            hotel.ImageURLs = new List<string>() { "image1", "image2" };
            hotel.LocationCode = "Location";
            hotel.Rooms = new List<Room>() { new Room() { NoOfRoomsAvailable = 10, RoomType = "delux" } };
            hotel.Address = "Address1";
            hotel.Amenities = new List<string>() { "swimming pool", "gymnasium" };
        }
        
        [When(@"User calls GetHotelById api")]
        public void WhenUserCallsGetHotelByIdApi()
        {
            hotel = HotelsApiCaller.GetHotelById(this.id);
        }
        [Then(@"Hotel with id '(.*)' should be present in the database")]
        public void ThenHotelWithIdShouldBePresentInTheDatabase(int id)
        {
            
            hotel.Should().NotBeNull(string.Format("Hotel with id {0} not found in response", id));
        }
        [When(@"User calls GetAllHotels api")]
        public void WhenUserCallsGetAllHotelsApi()
        {
            hotels = HotelsApiCaller.GetAllHotels();
        }
        [Then(@"Hotels added should be present in the database")]
        public void ThenHotelsAddedShouldBePresentInTheDatabase()
        {
            for (int loop=0;loop<idList.Count;loop++)
            {
                hotel = hotels.Find(x => x.Id == idList[loop]);
                hotel.Should().NotBeNull(string.Format("Hotel with id {0} not found in response", idList[loop]));
            }
        }
    }
}
