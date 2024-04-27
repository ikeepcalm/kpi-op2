using ConsoleTables;

namespace PrBx8.solution.client;

public class Client
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public List<string> Keywords { get; set; }

    public Client(string name, string surname, List<string> keywords)
    {
        this.Name = name;
        this.Surname = surname;
        this.Keywords = keywords;
    }

    public override string ToString()
    {
        return $"""
                 ==============================
                 Client: {this.Name} {this.Surname} ({this.Id})
                 Keywords: {string.Join(", ", this.Keywords)}
                """;
    }
    
    public static void ToString(List<Client> clients)
    {
        if (clients.Count == 0)
        {
            Console.WriteLine("No clients found");
            return;
        }
        var table = new ConsoleTable("Id", "Name", "Surname", "Keywords");
        foreach (Client client in clients)
        {
            table.AddRow(client.Id, client.Name, client.Surname, string.Join(", ", client.Keywords));
        }
        table.Write();
    }
}