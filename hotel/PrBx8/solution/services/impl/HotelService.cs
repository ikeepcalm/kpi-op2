using System.Text.Json;
using PrBx8.solution.hotel;

namespace PrBx8.solution.services.impl
{
    public class HotelService : IService<Hotel>
    {
        private const string FilePath = "hotels.json";

        public void Save(Hotel hotel)
        {
            List<Hotel> hotels = LoadFromFile();

            if (hotels.Any(h => h.Id == hotel.Id))
            {
                Hotel foundHotel = hotels[hotels.FindIndex(h => h.Id == hotel.Id)];
                foundHotel.Name = hotel.Name;
                foundHotel.Description = hotel.Description;
                foundHotel.Capacity = hotel.Capacity;
                foundHotel.Rooms = hotel.Rooms;
                foundHotel.Reservations = hotel.Reservations;
                foundHotel.Keywords = hotel.Keywords;
            }
            else
            {
                hotel.Id = hotels.Count > 0 ? hotels.Max(h => h.Id) + 1 : 1;
                hotels.Add(hotel);
            }
            
            SaveToFile(hotels);
        }

        public void Delete(long id)
        {
            List<Hotel>? hotels = LoadFromFile();
            
            if (hotels == null)
            {
                throw new Exception("Hotel not found");
            }

            Hotel? hotel = hotels.Find(h => h.Id == id);
            if (hotel == null)
            {
                throw new Exception("Hotel not found");
            }

            hotels.Remove(hotel);
            SaveToFile(hotels);
        }

        public Hotel Get(long id)
        {
            List<Hotel>? hotels = LoadFromFile();

            if (hotels == null)
            {
                throw new Exception("Hotel not found");
            }
            
            Hotel? hotel = hotels.Find(h => h.Id == id);
            if (hotel == null)
            {
                throw new Exception("Hotel not found");
            }

            return hotel;
        }

        public List<Hotel> GetAll()
        {
            return LoadFromFile();
        }

        public List<Hotel> GetAll(ClientService.SortField sortField, ClientService.SortOrder sortOrder)
        {
            throw new NotImplementedException();
        }

        public List<Hotel> FindAll(List<string> query)
        {
            List<Hotel> hotels = LoadFromFile();
            return hotels.Where(h => query.All(k => h.Keywords.Contains(k))).ToList();
        }
        
        public List<Hotel> LoadFromFile()
        {
            if (File.Exists(FilePath))
            {
                var json = File.ReadAllText(FilePath);
                return JsonSerializer.Deserialize<List<Hotel>>(json) ?? new List<Hotel>();
            }

            return new List<Hotel>();
        }

        public void SaveToFile(List<Hotel> hotels)
        {
            var json = JsonSerializer.Serialize(hotels);
            File.WriteAllText(FilePath, json);
        }
    }
}