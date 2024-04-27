using System.Text.Json;
using PrBx8.solution.client;

namespace PrBx8.solution.services.impl
{
    public class ClientService : IService<Client>
    {
        private const string FilePath = "clients.json";

        public void Save(Client client)
        {
            List<Client> clients = LoadFromFile();

            if (clients.Any(с => с.Id == client.Id))
            {
                Client foundClient = clients[clients.FindIndex(c => c.Id == client.Id)];
                foundClient.Name = client.Name;
                foundClient.Surname = client.Surname;
            }
            else
            {
                client.Id = clients.Count > 0 ? clients.Max(c => c.Id) + 1 : 1;
                clients.Add(client);
            }

            SaveToFile(clients);
        }
        
        public void Delete(long id)
        {
            List<Client>? clients = LoadFromFile();
            
            if (clients == null)
            {
                throw new Exception("Client not found");
            }

            Client client = clients.Find(c => c.Id == id) ?? throw new InvalidOperationException();

            clients.Remove(client);
            SaveToFile(clients);
        }

        public Client Get(long id)
        {
            List<Client>? clients = LoadFromFile();
            
            if (clients == null)
            {
                throw new Exception("Client not found");
            }

            Client client = clients.Find(c => c.Id == id) ?? throw new Exception();

            return client;
        }

        public List<Client> GetAll()
        {
            return LoadFromFile();
        }

        public List<Client> GetAll(SortField sortField, SortOrder sortOrder)
        {
            List<Client> clients = LoadFromFile();

            switch (sortField)
            {
                case SortField.Name:
                    clients = sortOrder == SortOrder.Asc
                        ? clients.OrderBy(c => c.Name).ToList()
                        : clients.OrderByDescending(c => c.Name).ToList();
                    break;
                case SortField.Surname:
                    clients = sortOrder == SortOrder.Asc
                        ? clients.OrderBy(c => c.Surname).ToList()
                        : clients.OrderByDescending(c => c.Surname).ToList();
                    break;
            }

            return clients;
        }

        public List<Client> FindAll(List<string> query)
        {
            List<Client> clients = LoadFromFile();
            return clients.Where(c => query.All(k => c.Keywords.Contains(k))).ToList();
        }

        public List<Client> LoadFromFile()
        {
            if (File.Exists(FilePath))
            {
                var json = File.ReadAllText(FilePath);
                return JsonSerializer.Deserialize<List<Client>>(json) ?? new List<Client>();
            }

            return new List<Client>();
        }

        public void SaveToFile(List<Client>? clients)
        {
            var json = JsonSerializer.Serialize(clients);
            File.WriteAllText(FilePath, json);
        }

        public enum SortField
        {
            Name,
            Surname
        }

        public enum SortOrder
        {
            Asc,
            Desc
        }
    }
}