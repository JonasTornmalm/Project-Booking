using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Booking.Model
{
    public class SeedDB
    {
        public static void AddHotelsDB(ConnectionContext context)
        {
            context.Hotel.Add(new Hotel
            {
                Id = "gbgEurowayHotel",
                HotelName = "Euroway Hotel",
                HotelInfo = "Euroway Hotel offers 40 rooms with space for up to 94 guests. Our rooms are equipped with desk, shower, toilet, Cable TV & wireless internet (for free). " +
                "Most of the rooms also have refrigarator, microwave and water boiler. We want you to enjoy you stay with us. Good service, fast problem solving and good recommendations for activities are something we strive for. " +
                "The room rate includes of course the breakfast buffet and parking in our garage.",
                City = "Gothenburg",
                NumberOfRooms = 40,
                HotelPictureBig = "/Images/EurowayBig.jpg",
                HotelPictureSmallOne = "/Images/EurowayLobby.jpg",
                HotelPictureSmallTwo = "/Images/EurowayRoomOne.jpg",
                HotelPictureSmallThree = "/Images/EurowayRoomTwo.jpg",
                HotelStars = "&#9733; &#9733; &#9733; &#9734; &#9734;",
                RoomPrice = 506.99
            });
            context.Hotel.Add(new Hotel
            {
                Id = "gbgGothiaTowers",
                HotelName = "Gothia Towers Hotel",
                HotelInfo = "Welcome to Gothia Towers in Gothenburg. Here you can stay high above the city in one of our extremely comfortable rooms, of which there are 1,200, " +
                "and still have easy access to the commercial centre and the event district of Korsvägen. Our hotel is popular with business travellers, people enjoying a weekend break and families – " +
                "anyone, in fact, who wants a bit of relaxation but also the chance to treat themselves; our tastefully decorated rooms have everything from that bit of added comfort to discreet luxury in every detail." +
                " You decide what suits you best; we have rooms in all of our three towers, with sweeping views across the beautiful city of Gothenburg.",
                City = "Gothenburg",
                NumberOfRooms = 150,
                HotelPictureBig = "/Images/GothiaTowersBig.jpg",
                HotelPictureSmallOne = "/Images/GothiaTowersLobby.jpg",
                HotelPictureSmallTwo = "/Images/GothiaTowersRoomOne.jpg",
                HotelPictureSmallThree = "/Images/GothiaTowersRoomTwo.jpg",
                HotelStars = "&#9733; &#9733; &#9733; &#9733; &#9734;",
                RoomPrice = 990
            });
            context.Hotel.Add(new Hotel
            {
                Id = "gbgDorsiaHotel",
                HotelName = "Dorsia Hotel",
                HotelInfo = "This modern and exclusive boutique hotel, 6 minutes’ walk from Gothenburg Central Station, is just 200 m from Kungsportsplatsen Tram Stop. " +
                "It offers free WiFi and a contemporary restaurant with bar. Bold décor and luxury Carpe Diem beds with Egyptian cotton bedding are featured in all Dorsia Hotel rooms. Each includes a mini - bar, " +
                "bathrobes with slippers and an internet - connected Lava Invit TV with free movie channels.",
                City = "Gothenburg",
                NumberOfRooms = 10,
                HotelPictureBig = "/Images/DorsiaBig.jpg",
                HotelPictureSmallOne = "/Images/DorsiaLobby.jpg",
                HotelPictureSmallTwo = "/Images/DorsiaRoomOne.jpg",
                HotelPictureSmallThree = "/Images/DorsiaRoomTwo.jpg",
                HotelStars = "&#9733; &#9733; &#9733; &#9733; &#9733;",
                RoomPrice = 1999.99
            });
            context.Hotel.Add(new Hotel
            {
                Id = "prHiltonOldTown",
                HotelName = "Hilton Prague Old Town",
                HotelInfo = "Renovated in 2018, Hilton Prague Old Town rooms combine state of the art facilities with contemporary styling and sumptuous furnishings. " +
                "Special rooms with easy access are available for guests with a disability. The modern rooms at Hilton Prague Old Town feature comfortable beds, a flat-screen TV and a mini-bar. " +
                "Executive rooms enjoy access to the Executive lounges, where guests can enjoy free continental breakfast and refreshments, and private check-in and check-out.",
                City = "Prague",
                NumberOfRooms = 40,
                HotelPictureBig = "/Images/EurowayBig.jpg",
                HotelPictureSmallOne = "/Images/EurowayLobby.jpg",
                HotelPictureSmallTwo = "/Images/EurowayRoomOne.jpg",
                HotelPictureSmallThree = "/Images/EurowayRoomTwo.jpg",
                HotelStars = "&#9733; &#9733; &#9733; &#9734; &#9734;",
                RoomPrice = 506.99
            });
            context.Hotel.Add(new Hotel
            {
                Id = "gbgGothiaTowers",
                HotelName = "Gothia Towers Hotel",
                HotelInfo = "Welcome to Gothia Towers in Gothenburg. Here you can stay high above the city in one of our extremely comfortable rooms, of which there are 1,200, " +
                "and still have easy access to the commercial centre and the event district of Korsvägen. Our hotel is popular with business travellers, people enjoying a weekend break and families – " +
                "anyone, in fact, who wants a bit of relaxation but also the chance to treat themselves; our tastefully decorated rooms have everything from that bit of added comfort to discreet luxury in every detail." +
                " You decide what suits you best; we have rooms in all of our three towers, with sweeping views across the beautiful city of Gothenburg.",
                City = "Göteborg",
                NumberOfRooms = 150,
                HotelPictureBig = "/Images/GothiaTowersBig.jpg",
                HotelPictureSmallOne = "/Images/GothiaTowersLobby.jpg",
                HotelPictureSmallTwo = "/Images/GothiaTowersRoomOne.jpg",
                HotelPictureSmallThree = "/Images/GothiaTowersRoomTwo.jpg",
                HotelStars = "&#9733; &#9733; &#9733; &#9733; &#9734;",
                RoomPrice = 990
            });
            context.Hotel.Add(new Hotel
            {
                Id = "gbgDorsiaHotel",
                HotelName = "Dorsia Hotel",
                HotelInfo = "This modern and exclusive boutique hotel, 6 minutes’ walk from Gothenburg Central Station, is just 200 m from Kungsportsplatsen Tram Stop. " +
                "It offers free WiFi and a contemporary restaurant with bar. Bold décor and luxury Carpe Diem beds with Egyptian cotton bedding are featured in all Dorsia Hotel rooms. Each includes a mini - bar, " +
                "bathrobes with slippers and an internet - connected Lava Invit TV with free movie channels.",
                City = "Göteborg",
                NumberOfRooms = 10,
                HotelPictureBig = "/Images/DorsiaBig.jpg",
                HotelPictureSmallOne = "/Images/DorsiaLobby.jpg",
                HotelPictureSmallTwo = "/Images/DorsiaRoomOne.jpg",
                HotelPictureSmallThree = "/Images/DorsiaRoomTwo.jpg",
                HotelStars = "&#9733; &#9733; &#9733; &#9733; &#9733;",
                RoomPrice = 1999.99
            });
            context.Hotel.Add(new Hotel
            {
                Id = "gbgEurowayHotel",
                HotelName = "Euroway Hotel",
                HotelInfo = "Euroway Hotel offers 40 rooms with space for up to 94 guests. Our rooms are equipped with desk, shower, toilet, Cable TV & wireless internet (for free). " +
                "Most of the rooms also have refrigarator, microwave and water boiler. We want you to enjoy you stay with us. Good service, fast problem solving and good recommendations for activities are something we strive for. " +
                "The room rate includes of course the breakfast buffet and parking in our garage.",
                City = "Göteborg",
                NumberOfRooms = 40,
                HotelPictureBig = "/Images/EurowayBig.jpg",
                HotelPictureSmallOne = "/Images/EurowayLobby.jpg",
                HotelPictureSmallTwo = "/Images/EurowayRoomOne.jpg",
                HotelPictureSmallThree = "/Images/EurowayRoomTwo.jpg",
                HotelStars = "&#9733; &#9733; &#9733; &#9734; &#9734;",
                RoomPrice = 506.99
            });
            context.Hotel.Add(new Hotel
            {
                Id = "gbgGothiaTowers",
                HotelName = "Gothia Towers Hotel",
                HotelInfo = "Welcome to Gothia Towers in Gothenburg. Here you can stay high above the city in one of our extremely comfortable rooms, of which there are 1,200, " +
                "and still have easy access to the commercial centre and the event district of Korsvägen. Our hotel is popular with business travellers, people enjoying a weekend break and families – " +
                "anyone, in fact, who wants a bit of relaxation but also the chance to treat themselves; our tastefully decorated rooms have everything from that bit of added comfort to discreet luxury in every detail." +
                " You decide what suits you best; we have rooms in all of our three towers, with sweeping views across the beautiful city of Gothenburg.",
                City = "Göteborg",
                NumberOfRooms = 150,
                HotelPictureBig = "/Images/GothiaTowersBig.jpg",
                HotelPictureSmallOne = "/Images/GothiaTowersLobby.jpg",
                HotelPictureSmallTwo = "/Images/GothiaTowersRoomOne.jpg",
                HotelPictureSmallThree = "/Images/GothiaTowersRoomTwo.jpg",
                HotelStars = "&#9733; &#9733; &#9733; &#9733; &#9734;",
                RoomPrice = 990
            });
            context.Hotel.Add(new Hotel
            {
                Id = "gbgDorsiaHotel",
                HotelName = "Dorsia Hotel",
                HotelInfo = "This modern and exclusive boutique hotel, 6 minutes’ walk from Gothenburg Central Station, is just 200 m from Kungsportsplatsen Tram Stop. " +
                "It offers free WiFi and a contemporary restaurant with bar. Bold décor and luxury Carpe Diem beds with Egyptian cotton bedding are featured in all Dorsia Hotel rooms. Each includes a mini - bar, " +
                "bathrobes with slippers and an internet - connected Lava Invit TV with free movie channels.",
                City = "Göteborg",
                NumberOfRooms = 10,
                HotelPictureBig = "/Images/DorsiaBig.jpg",
                HotelPictureSmallOne = "/Images/DorsiaLobby.jpg",
                HotelPictureSmallTwo = "/Images/DorsiaRoomOne.jpg",
                HotelPictureSmallThree = "/Images/DorsiaRoomTwo.jpg",
                HotelStars = "&#9733; &#9733; &#9733; &#9733; &#9733;",
                RoomPrice = 1999.99
            });

            context.SaveChanges();
        }
    }
}
