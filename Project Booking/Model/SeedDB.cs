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
                Id = "sweEurowayHotel",
                HotelName = "Euroway Hotel",
                HotelInfo = "Euroway Hotel offers 40 rooms with space for up to 94 guests. Our rooms are equipped with desk, shower, toilet, Cable TV & wireless internet (for free). " +
                "Most of the rooms also have refrigarator, microwave and water boiler. We want you to enjoy you stay with us. Good service, fast problem solving and good recommendations for activities are something we strive for. " +
                "The room rate includes of course the breakfast buffet and parking in our garage.",
                City = "Gothenburg",
                NumberOfRooms = 40,
                HotelPictureBig = "/Images/Gothenburg/EurowayBig.jpg",
                HotelPictureSmallOne = "/Images/Gothenburg/EurowayLobby.jpg",
                HotelPictureSmallTwo = "/Images/Gothenburg/EurowayRoomOne.jpg",
                HotelPictureSmallThree = "/Images/Gothenburg/EurowayRoomTwo.jpg",
                HotelStars = "&#9733; &#9733; &#9733; &#9734; &#9734;",
                RoomPrice = 506.99
            });
            context.Hotel.Add(new Hotel
            {
                Id = "sweGothiaTowers",
                HotelName = "Gothia Towers Hotel",
                HotelInfo = "Welcome to Gothia Towers in Gothenburg. Here you can stay high above the city in one of our extremely comfortable rooms, of which there are 1,200, " +
                "and still have easy access to the commercial centre and the event district of Korsvägen. Our hotel is popular with business travellers, people enjoying a weekend break and families – " +
                "anyone, in fact, who wants a bit of relaxation but also the chance to treat themselves; our tastefully decorated rooms have everything from that bit of added comfort to discreet luxury in every detail." +
                " You decide what suits you best; we have rooms in all of our three towers, with sweeping views across the beautiful city of Gothenburg.",
                City = "Gothenburg",
                NumberOfRooms = 150,
                HotelPictureBig = "/Images/Gothenburg/GothiaTowersBig.jpg",
                HotelPictureSmallOne = "/Images/Gothenburg/GothiaTowersLobby.jpg",
                HotelPictureSmallTwo = "/Images/Gothenburg/GothiaTowersRoomOne.jpg",
                HotelPictureSmallThree = "/Images/Gothenburg/GothiaTowersRoomTwo.jpg",
                HotelStars = "&#9733; &#9733; &#9733; &#9733; &#9734;",
                RoomPrice = 990
            });
            context.Hotel.Add(new Hotel
            {
                Id = "sweDorsiaHotel",
                HotelName = "Dorsia Hotel",
                HotelInfo = "This modern and exclusive boutique hotel, 6 minutes’ walk from Gothenburg Central Station, is just 200 m from Kungsportsplatsen Tram Stop. " +
                "It offers free WiFi and a contemporary restaurant with bar. Bold décor and luxury Carpe Diem beds with Egyptian cotton bedding are featured in all Dorsia Hotel rooms. Each includes a mini - bar, " +
                "bathrobes with slippers and an internet - connected Lava Invit TV with free movie channels.",
                City = "Gothenburg",
                NumberOfRooms = 10,
                HotelPictureBig = "/Images/Gothenburg/DorsiaBig.jpg",
                HotelPictureSmallOne = "/Images/Gothenburg/DorsiaLobby.jpg",
                HotelPictureSmallTwo = "/Images/Gothenburg/DorsiaRoomOne.jpg",
                HotelPictureSmallThree = "/Images/Gothenburg/DorsiaRoomTwo.jpg",
                HotelStars = "&#9733; &#9733; &#9733; &#9733; &#9733;",
                RoomPrice = 1999.99
            });
            context.Hotel.Add(new Hotel
            {
                Id = "czeHiltonOldTown",
                HotelName = "Hilton Prague Old Town",
                HotelInfo = "Renovated in 2018, Hilton Prague Old Town rooms combine state of the art facilities with contemporary styling and sumptuous furnishings. " +
                "Special rooms with easy access are available for guests with a disability. The modern rooms at Hilton Prague Old Town feature comfortable beds, a flat-screen TV and a mini-bar. " +
                "Executive rooms enjoy access to the Executive lounges, where guests can enjoy free continental breakfast and refreshments, and private check-in and check-out.",
                City = "Prague",
                NumberOfRooms = 68,
                HotelPictureBig = "/Images/Prague/HiltonPragueBig.jpg",
                HotelPictureSmallOne = "/Images/Prague/HiltonPragueLobby.jpg",
                HotelPictureSmallTwo = "/Images/Prague/HiltonPragueRoomOne.jpg",
                HotelPictureSmallThree = "/Images/Prague/HiltonPragueRoomTwo.jpg",
                HotelStars = "&#9733; &#9733; &#9733; &#9733; &#9733;",
                RoomPrice = 1500
            });
            context.Hotel.Add(new Hotel
            {
                Id = "czeResidenceAgnes",
                HotelName = "Hotel Residence Agnes",
                HotelInfo = "This 4-star boutique hotel offers a central Prague location less than half a kilometer from the beautiful Old Town Square. " +
                "It offers bright and airy rooms with air conditioning, LCD satellite TVs and work desks. Housed in a historic building, Residence Agnes provides 24 - hour front desk with an exchange office, " +
                "concierge services and transportation with private limousines. The minibar in the rooms has a wide selection of drinks and guests can enjoy room service. " +
                "All rooms have free Wi-Fi and a spacious bathroom. Agnes Residence serves a rich buffet breakfast including hot and cold plates. There are many excellent restaurants within easy walking distance. ",
                City = "Prague",
                NumberOfRooms = 30,
                HotelPictureBig = "/Images/Prague/HotelAgnesBig.jpg",
                HotelPictureSmallOne = "/Images/Prague/HotelAgnesLobby.jpg",
                HotelPictureSmallTwo = "/Images/Prague/HotelAgnesRoomOne.jpg",
                HotelPictureSmallThree = "/Images/Prague/HotelAgnesRoomTwo.jpg",
                HotelStars = "&#9733; &#9733; &#9733; &#9733; &#9734;",
                RoomPrice = 2990
            });
            context.Hotel.Add(new Hotel
            {
                Id = "czeOneRoomHotel",
                HotelName = "One Room Hotel",
                HotelInfo = "Set in the Žižkov TV tower at 68 m above ground, One Room Hotel features splendid views over Prague, offering a suite with a glassed-in bathroom with a bath and free Wi-Fi. " +
                "International à la carte cuisine and drinks are served at the on-site café and bar. The Jewish Cemetary is located next to the One Room, while the statue of Jan Žižka, " +
                "which is the biggest equestrian statue in Europe, can be found on Vítkov Hill, 0.9 mi away. Guests can choose between free on - site parking or guarded garage parking, " +
                "which is available at a surcharge.Flóra Shopping Center is 0.6 mi away, while public transport is a 4-minute walk from the One Room Hotel. ",
                City = "Prague",
                NumberOfRooms = 1,
                HotelPictureBig = "/Images/Prague/OneRoomHotelBig.jpg",
                HotelPictureSmallOne = "/Images/Prague/OneRoomHotelLobby.jpg",
                HotelPictureSmallTwo = "/Images/Prague/OneRoomHotelRoomOne.jpg",
                HotelPictureSmallThree = "/Images/Prague/OneRoomHotelRoomTwo.jpg",
                HotelStars = "&#9733; &#9733; &#9733; &#9733; &#9733;",
                RoomPrice = 6000
            });
            context.Hotel.Add(new Hotel
            {
                Id = "espTheTouch",
                HotelName = "The Touch Puerto Banús",
                HotelInfo = "Located in Marbella, 8 km from Marbella Bus Station, Hotel The Touch Puerto Banus has a garden and a bar. " +
                "Built in 1960, the property is within 9 km of Plaza de los Naranjos and 9 km of Teatro Ciudad de Marbella. The accommodation provides a 24-hour front desk and free WiFi is available. " +
                "At the hotel, all rooms are fitted with a wardrobe. Each room includes a private bathroom with a hair dryer. At Hotel The Touch Puerto Banus every room is equipped with air conditioning " +
                "and a flat-screen TV. A continental breakfast is available every morning at the property.",
                City = "Marbella",
                NumberOfRooms = 35,
                HotelPictureBig = "/Images/Marbella/TheTouchBig.jpg",
                HotelPictureSmallOne = "/Images/Marbella/TheTouchLobby.jpg",
                HotelPictureSmallTwo = "/Images/Marbella/TheTouchRoomOne.jpg",
                HotelPictureSmallThree = "/Images/Marbella/TheTouchRoomTwo.jpg",
                HotelStars = "&#9733; &#9733; &#9734; &#9734; &#9734;",
                RoomPrice = 1506.99
            });
            context.Hotel.Add(new Hotel
            {
                Id = "espAmareBeach",
                HotelName = "Amàre Beach Hotel",
                HotelInfo = "Set on the beachfront, in the centre of Marbella's old town, this adults-only hotel offers a spa and outdoor swimming pool. Amare Marbella Beach Hotel - Adults Only features free WiFi " +
                "throughout the property and at the Beach Club. The modern, stylish rooms are spacious and bright, and most rooms have a balcony with side or front sea views.The hotel also offers Exclusive Rooms, " +
                "which include VIP treatment and access to the adults - only The One Lounge. One of the hotel´s main attractions is Amàre Club, divided into 3 areas that combine music and entertaining by the sea. " +
                "Amàre Beach offers restaurant and sun bathing areas, and Amàre Pool has an outdoor swimming pool and a sun terrace.The Amàre Lounge, a relax area with a bar and café, which also features evening entertainment.",
                City = "Marbella",
                NumberOfRooms = 200,
                HotelPictureBig = "/Images/Marbella/AmareBeachBig.jpg",
                HotelPictureSmallOne = "/Images/Marbella/AmareBeachLobby.jpg",
                HotelPictureSmallTwo = "/Images/Marbella/AmareBeachRoomOne.jpg",
                HotelPictureSmallThree = "/Images/Marbella/AmareBeachRoomTwo.jpg",
                HotelStars = "&#9733; &#9733; &#9733; &#9733; &#9733;",
                RoomPrice = 2700
            });
            context.Hotel.Add(new Hotel
            {
                Id = "espMarbellaClub",
                HotelName = "Marbella Club Hotel",
                HotelInfo = "This luxurious beachfront hotel, set between Marbella and Puerto Banús, has 2 luxurious pools and 5 restaurants. " +
                "Surrounded by lush gardens with direct beach access, it offers 1 free green fee per person per stay at Marbella Club Golf Resort. " +
                "Featuring bedrooms with a private terrace and sea or garden views, Marbella Club Hotel was originally the private residence of Prince Alfonso von Hohenlohe, the founder of the hotel. " +
                "The property has 5 restaurants, serving International and traditional Spanish cuisine. Puerto Banús offers a wide range of designer shops, bars, and restaurants.",
                City = "Marbella",
                NumberOfRooms = 25,
                HotelPictureBig = "/Images/Marbella/MarbellaClubBig.jpg",
                HotelPictureSmallOne = "/Images/Marbella/MarbellaClubLobby.jpg",
                HotelPictureSmallTwo = "/Images/Marbella/MarbellaClubRoomOne.jpg",
                HotelPictureSmallThree = "/Images/Marbella/MarbellaClubRoomTwo.jpg",
                HotelStars = "&#9733; &#9733; &#9733; &#9733; &#9734;",
                RoomPrice = 1430
            });

            context.SaveChanges();
        }
    }
}
