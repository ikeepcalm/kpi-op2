using ConsoleTables;

namespace PrBx8.solution.client;

public class Order
{
    public long Id { get; set; }
    public long ClientId { get; set; }
    public long HotelId { get; set; }
    public long RoomId { get; set; }
    public long Price { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
    public string Description { get; set; }

    public Order(long clientId, long hotelId, long roomId, long price, DateOnly startDate, DateOnly endDate,
        string description)
    {
        this.ClientId = clientId;
        this.HotelId = hotelId;
        this.RoomId = roomId;
        this.Price = price;
        this.StartDate = startDate;
        this.EndDate = endDate;
        this.Description = description;
    }

    public override string ToString()
    {
        string toString = $"""
                           ==============================
                           Reservation: {this.Id}
                           Client: {this.ClientId} - Hotel: {this.HotelId}
                           Room: {this.RoomId}
                           Start date: {this.StartDate}
                           End date: {this.EndDate}
                           Description: {this.Description}
                           ==============================
                           """;
        return toString;
    }

    public static void ToString(List<Order> orders)
    {
        if (orders.Count == 0)
        {
            Console.WriteLine("No reservations found");
            return;
        }

        var table = new ConsoleTable("Id", "Client", "Hotel", "Room", "Price", "Start date", "End date", "Description");
        foreach (Order order in orders)
        {
            if (order.Description.Length > 40)
            {
                table.AddRow(order.Id, order.ClientId, order.HotelId, order.RoomId, order.Price, order.StartDate,
                    order.EndDate,
                    order.Description.Substring(0, 40) + "...");
            }
            else
            {
                table.AddRow(order.Id, order.ClientId, order.HotelId, order.RoomId, order.Price, order.StartDate,
                    order.EndDate,
                    order.Description);
            }
        }

        table.Write();
    }
}