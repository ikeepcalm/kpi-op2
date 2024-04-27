using ConsoleTables;

namespace PrBx8.solution.hotel;

public class Room
{
    public long Id { get; set; }
    public long Price { get; set; }
    public bool IsReserved { get; set; }

    public Room(long id, long price)
    {
        this.Id = id;
        this.Price = price;
    }
    
    public override string ToString()
    {
        string toString = $"""
                          ==============================
                          Room: {this.Id}
                          Price: {this.Price}
                          Taken: {this.IsReserved}
                          ==============================
                          """;
        return toString;
    }
    
    public static void ToString(List<Room> rooms)
    {
        if (rooms.Count == 0)
        {
            Console.WriteLine("No rooms found");
            return;
        }
        var table = new ConsoleTable("Id", "Price", "Taken");
        foreach (Room room in rooms)
        {
            table.AddRow(room.Id, room.Price, room.IsReserved);
        }
        table.Write();
    }
}