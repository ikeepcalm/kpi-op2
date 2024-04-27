using ConsoleTables;
using PrBx8.solution.client;

namespace PrBx8.solution.hotel;

public class Hotel
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Capacity { get; set; }
    public List<Room> Rooms { get; set; }
    public List<Order> Reservations { get; set; }
    public List<string> Keywords { get; set; }

    public Hotel(string name, string description, int capacity, List<string> keywords)
    {
        this.Name = name;
        this.Description = description;
        this.Capacity = capacity;
        this.Keywords = keywords;
        this.InitializeReservations();
        this.GenerateRooms();
    }

    private void GenerateRooms()
    {
        Rooms = new List<Room>();
        for (int i = 0; i < this.Capacity; i++)
        {
            Room room = new Room(i, new Random().Next(1, 1000));
            room.IsReserved = false;
            this.Rooms.Add(room);
        }
    }

    private void InitializeReservations()
    {
        Reservations = new List<Order>();
    }

    public override string ToString()
    {
        int reservedRooms = Capacity - this.Rooms.Count(r => r.IsReserved);
        string toString = $"""
                           ==============================
                           Hotel: {this.Name} ({this.Id})
                           Description: {this.Description}
                           Capacity: {reservedRooms} / {this.Capacity}
                           ==============================
                           """;
        return toString;
    }

    public static void PrintHotels(List<Hotel> hotels)
    {
        if (hotels.Count == 0)
        {
            Console.WriteLine("No hotels found");
            return;
        }

        var table = new ConsoleTable("Hotel Name", "Description", "Capacity", "Keywords");
        foreach (Hotel hotel in hotels)
        {
            if (hotel.Description.Length > 40)
            {
                table.AddRow(hotel.Name, hotel.Description.Substring(0, 40) + "...",
                    $"{hotel.Rooms.Count(r => !r.IsReserved)} / {hotel.Capacity}", string.Join(", ", hotel.Keywords));
            }
            else
            {
                table.AddRow(hotel.Name, hotel.Description,
                    $"{hotel.Rooms.Count(r => !r.IsReserved)} / {hotel.Capacity}", string.Join(", ", hotel.Keywords));
            }
        }

        table.Write();
    }


    public void AddReservation(Order order)
    {
        this.Reservations.Add(order);
        long maxId = this.Reservations.Max(r => r.Id);
        order.Id = maxId + 1;
        Rooms.Find(r => r.Id == order.RoomId).IsReserved = true;
    }

    public void RemoveReservation(Order order)
    {
        this.Reservations.Remove(order);
    }

    public void UpdateReservation(Order order)
    {
        Order? oldReservation = this.Reservations.Find(r => r.Id == order.Id);
        if (oldReservation == null)
        {
            throw new Exception("Reservation not found");
        }

        this.Reservations.Remove(oldReservation);
        this.Reservations.Add(order);
    }
}