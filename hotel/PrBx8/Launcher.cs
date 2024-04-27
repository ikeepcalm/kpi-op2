using PrBx8.solution.client;
using PrBx8.solution.hotel;
using PrBx8.solution.services;
using PrBx8.solution.services.impl;

namespace PrBx8;

class Launcher
{
    static readonly IService<Hotel> HotelService = new HotelService();
    static readonly IService<Client> ClientService = new ClientService();

    static void Main()
    {
        bool running = true;
        while (running)
        {
            int selectedOption = Interface.CreateLayout("Hotel Management System v. 1.0.0", "Hotel Management",
                "Client Management", "Reservation Management",
                "Exit");
            switch (selectedOption)
            {
                case 0:
                    HotelMenu();
                    break;
                case 1:
                    ClientMenu();
                    break;
                case 2:
                    ReservationMenu();
                    break;
                case 3:
                    running = false;
                    break;
            }
        }

        Environment.Exit(0);
    }

    static void HotelMenu()
    {
        int selectedOption = Interface.CreateLayout("Hotel Management Menu",
            "Create Hotel",
            "Update Hotel",
            "Delete Hotel",
            "List Hotels",
            "Certain Hotel",
            "Search by Keywords",
            "Examine rooms",
            "Back to Main Menu");
        switch (selectedOption)
        {
            case 0:
                CreateHotel();
                break;
            case 1:
                UpdateHotel();
                break;
            case 2:
                DeleteHotel();
                break;
            case 3:
                ListHotels();
                break;
            case 4:
                CertainHotel();
                break;
            case 5:
                FindHotelsByKeywords();
                break;
            case 6:
                ExamineRooms();
                break;
            case 7:
                return;
        }
    }

    private static void CertainHotel()
    {
        Hotel hotel;

        try
        {
            hotel = GetValidHotel("Enter Hotel Id to display:");
        }
        catch (Exception)
        {
            return;
        }

        Console.Clear();
        Console.WriteLine(hotel);
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    static void ClientMenu()
    {
        int selectedOption = Interface.CreateLayout("Client Management Menu", 
            "Create Client", 
            "Update Client",
            "Delete Client",
            "Certain Client",
            "List Clients",
            "Search by Keywords", "Back to Main Menu");
        switch (selectedOption)
        {
            case 0:
                CreateClient();
                break;
            case 1:
                UpdateClient();
                break;
            case 2:
                DeleteClient();
                break;
            case 3:
                CertainClient();
                break;
            case 4:
                ListClients();
                break;
            case 5:
                FindClientsByKeyword();
                break;
            case 6:
                return;
        }
    }

    private static void CertainClient()
    {
        Client client;

        try
        {
            client = GetValidClient("Enter Client Id to display:");
        }
        catch (Exception)
        {
            return;
        }

        Console.Clear();
        Console.WriteLine(client);
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }


    static void ReservationMenu()
    {
        int option = Interface.CreateLayout("Reservation Management Menu",
            "Create Reservation",
            "Update Reservation",
            "Cancel Reservation",
            "List Reservations",
            "Reservations by Date",
            "Back to Main Menu");
        switch (option)
        {
            case 0:
                CreateReservation();
                break;
            case 1:
                UpdateReservation();
                break;
            case 2:
                CancelReservation();
                break;
            case 3:
                ListReservations();
                break;
            case 4:
                DateReservations();
                break;
            case 5:
                return;
        }
    }


    static void CreateHotel()
    {
        var name = GetValidString("Enter Hotel Name:");

        var description = GetValidString("Enter Hotel Description:");

        var capacity = int.Parse(GetValidString("Enter Hotel Capacity:"));

        List<string> keywords = GetValidKeywords("Enter Hotel Keywords (comma separated):");

        var hotel = new Hotel(name, description, capacity, keywords);
        HotelService.Save(hotel);
        Console.WriteLine("Hotel created successfully!");
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    static void UpdateHotel()
    {
        Hotel hotel;

        try
        {
            hotel = GetValidHotel("Enter Hotel Id to update:");
        }
        catch (Exception)
        {
            return;
        }

        var name = GetValidString("Enter New Hotel Name:");

        var description = GetValidString("Enter New Hotel Description:");

        var capacityInput = GetValidString("Enter New Hotel Capacity:");

        List<string> keywords = GetValidKeywords("Enter New Hotel Keywords (comma separated):");

        hotel.Name = name;
        hotel.Description = description;
        hotel.Capacity = int.Parse(capacityInput);
        hotel.Keywords = keywords;
        HotelService.Save(hotel);
        Console.WriteLine("Hotel updated successfully!");
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    static void DeleteHotel()
    {
        Hotel hotel;

        try
        {
            hotel = GetValidHotel("Enter Hotel Id to delete:");
        }
        catch (Exception)
        {
            return;
        }

        HotelService.Delete(hotel.Id);
        Console.WriteLine("Hotel deleted successfully!");
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    static void ListHotels()
    {
        Console.Clear();
        var hotels = HotelService.GetAll();
        Hotel.PrintHotels(hotels);

        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    static void FindHotelsByKeywords()
    {
        var keywords = GetValidKeywords("Enter Hotel Keywords to find:");
        var hotels = HotelService.FindAll(keywords);
        foreach (var hotel in hotels)
        {
            Console.WriteLine(hotel);
        }

        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    private static void ExamineRooms()
    {
        Hotel hotel;

        try
        {
            hotel = GetValidHotel("Enter Hotel Id to examine rooms:");
        }
        catch (Exception)
        {
            return;
        }

        Console.Clear();
        Console.WriteLine($"Rooms for {hotel.Name}:");
        Room.ToString(hotel.Rooms);

        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
        Console.Clear();
    }

    static void CreateClient()
    {
        var name = GetValidString("Enter Client Name:");

        var surname = GetValidString("Enter Client Surname:");

        List<string> keywords = GetValidKeywords("Enter Client Keywords (comma separated):");

        var client = new Client(name, surname, keywords);
        ClientService.Save(client);
        Console.WriteLine("Client added successfully!");
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    static void UpdateClient()
    {
        Client client;

        try
        {
            client = GetValidClient("Enter Client Id to update:");
        }
        catch (Exception)
        {
            return;
        }

        var name = GetValidString("Enter New Client Name:");
        var surname = GetValidString("Enter New Client Surname:");

        client.Name = name;
        client.Surname = surname;

        ClientService.Save(client);
        Console.WriteLine("Client updated successfully!");
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    static void DeleteClient()
    {
        Client client;

        try
        {
            client = GetValidClient("Enter Client Id to delete:");
        }
        catch (Exception)
        {
            return;
        }

        ClientService.Delete(client.Id);
        Console.WriteLine("Client deleted successfully!");
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    static void ListClients()
    {
        Console.Clear();
        var clients = ClientService.GetAll();
        Client.ToString(clients);

        ClientService.SortField currentSortField = solution.services.impl.ClientService.SortField.Name;
        ClientService.SortOrder currentSortOrder = solution.services.impl.ClientService.SortOrder.Asc;
        while (true)
        {
            Console.WriteLine("\nSorting by " + currentSortField + " in " + currentSortOrder + " order:");
            Console.WriteLine("\nPress UP to change sorting order, DOWN to change sorting field, or ENTER to exit...");
            ConsoleKeyInfo key = Console.ReadKey();

            if (key.Key == ConsoleKey.UpArrow)
            {
                if (currentSortOrder == solution.services.impl.ClientService.SortOrder.Asc)
                {
                    currentSortOrder = solution.services.impl.ClientService.SortOrder.Desc;
                }
                else
                {
                    currentSortOrder = solution.services.impl.ClientService.SortOrder.Asc;
                }

                Console.Clear();
                List<Client> sortedClients = ClientService.GetAll(currentSortField, currentSortOrder);
                Client.ToString(sortedClients);
            }
            else if (key.Key == ConsoleKey.DownArrow)
            {
                if (currentSortField == solution.services.impl.ClientService.SortField.Name)
                {
                    currentSortField = solution.services.impl.ClientService.SortField.Surname;
                }
                else
                {
                    currentSortField = solution.services.impl.ClientService.SortField.Name;
                }

                Console.Clear();
                List<Client> sortedClients = ClientService.GetAll(currentSortField, currentSortOrder);
                Client.ToString(sortedClients);
            }
            else if (key.Key == ConsoleKey.Enter)
            {
                break;
            }
        }
    }

    static void FindClientsByKeyword()
    {
        var keywords = GetValidKeywords("Enter Keywords to find:");
        var clients = ClientService.FindAll(keywords);
        foreach (var client in clients)
        {
            Console.WriteLine(client);
        }

        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    static void CreateReservation()
    {
        Client client;

        try
        {
            client = GetValidClient("Enter Client Id to associate with Reservation:");
        }
        catch (Exception)
        {
            return;
        }

        Hotel hotel;

        try
        {
            hotel = GetValidHotel("Enter Hotel Id to associate with Reservation:");
        }
        catch (Exception)
        {
            return;
        }

        long roomId;

        try
        {
            roomId = GetValidRoom("Enter Room Id:", hotel).Id;
        }
        catch (Exception)
        {
            return;
        }

        var startDate = GetValidDate("Enter Start Date (yyyy-MM-dd):");

        var endDate = GetValidDate("Enter End Date (yyyy-MM-dd):");

        var description = GetValidString("Enter Reservation Description:");

        long price = (endDate.DayOfYear - startDate.DayOfYear) * hotel.Rooms.First(r => r.Id == roomId).Price;
        
        var reservation = new Order(client.Id, hotel.Id, roomId,price, startDate, endDate, description);
        hotel.AddReservation(reservation);
        HotelService.Save(hotel);
        Console.WriteLine("Reservation created successfully!");
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    static void UpdateReservation()
    {
        Hotel hotel;

        try
        {
            hotel = GetValidHotel("Enter Hotel Id associated with Reservation:");
        }
        catch (Exception)
        {
            return;
        }

        Order reservation;
        try
        {
            reservation = GetValidReservation("Enter Reservation Id to update:", hotel);
        }
        catch (Exception)
        {
            return;
        }

        var startDateInput = GetValidDate("Enter New Start Date (yyyy-MM-dd):");

        var endDateInput = GetValidDate("Enter New End Date (yyyy-MM-dd) (Press Enter to keep current):");

        var description = GetValidString("Enter New Reservation Description: ");

        reservation.StartDate = startDateInput;
        if (endDateInput != DateOnly.MinValue)
        {
            reservation.EndDate = endDateInput;
        }

        reservation.Description = description;
        hotel.UpdateReservation(reservation);
        HotelService.Save(hotel);
        Console.WriteLine("Reservation updated successfully!");
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    static void CancelReservation()
    {
        Hotel hotel;

        try
        {
            hotel = GetValidHotel("Enter Hotel Id associated with Reservation");
        }
        catch (Exception)
        {
            return;
        }

        var id = GetValidLong("Enter Reservation Id to cancel:");

        try
        {
            var reservation = hotel.Reservations.FirstOrDefault(r => r.Id == id) ?? throw new Exception();
            hotel.Rooms.First(r => r.Id == reservation.RoomId).IsReserved = false;
            hotel.RemoveReservation(reservation);
        }
        catch (Exception)
        {
            Console.WriteLine("There are no reservations associated with this hotel or reservation not found!");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            return;
        }

        HotelService.Save(hotel);
        Console.WriteLine("Reservation canceled successfully!");
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    static void ListReservations()
    {
        Console.Clear();
        var hotels = HotelService.GetAll();
        foreach (var hotel in hotels)
        {
            if (hotel.Reservations.Count != 0)
            {
                Console.WriteLine($"Current reservations for {hotel.Name}:");
                Order.ToString(hotel.Reservations);
            }
        }

        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    private static void DateReservations()
    {
        var startDate = GetValidDate("Enter Start Date (yyyy-MM-dd):");
        var endDate = GetValidDate("Enter End Date (yyyy-MM-dd):");
        var hotels = HotelService.GetAll();
        foreach (var hotel in hotels)
        {
            foreach (var reservation in hotel.Reservations)
            {
                if (reservation.StartDate >= startDate && reservation.EndDate <= endDate)
                {
                    Console.WriteLine(reservation);
                }
            }
        }

        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }

    private static string GetValidString(string message)
    {
        Console.Clear();
        while (true)
        {
            Console.WriteLine(message);
            var input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
            {
                Console.Clear();
                return input;
            }

            Console.WriteLine("Invalid input! Please try again.");
        }
    }

    private static Client GetValidClient(string message)
    {
        Console.Clear();
        while (true)
        {
            long id = GetValidLong(message);
            try
            {
                return ClientService.Get(id);
            }
            catch (Exception)
            {
                Console.WriteLine("Client not found! Please try again.");
                List<Client> clients = ClientService.GetAll();
                if (clients.Count > 0)
                {
                    Console.WriteLine("Possible clients:");
                    foreach (var client in clients)
                    {
                        Console.WriteLine(client);
                    }
                }
                else
                {
                    Console.WriteLine("No clients found at all! Please create one first");
                    Console.WriteLine("Press any key to exit to main menu...");
                    Console.ReadKey();
                    throw new Exception("Client not found");
                }
            }
        }
    }

    private static Hotel GetValidHotel(string message)
    {
        Console.Clear();
        while (true)
        {
            long id = GetValidLong(message);
            try
            {
                return HotelService.Get(id);
            }
            catch (Exception)
            {
                Console.WriteLine("Hotel not found! Please try again.");
                List<Hotel> hotels = HotelService.GetAll();
                if (hotels.Count > 0)
                {
                    Console.WriteLine("Possible hotels:");
                    foreach (var hotel in hotels)
                    {
                        Console.WriteLine(hotel);
                    }
                }
                else
                {
                    Console.WriteLine("No hotels found at all! Please create one first");
                    Console.WriteLine("Press any key to exit to main menu...");
                    Console.ReadKey();
                    throw new Exception("Hotel not found");
                }
            }
        }
    }

    private static Room GetValidRoom(string message, Hotel hotel)
    {
        Console.Clear();
        while (true)
        {
            long id = GetValidLong(message);
            try
            {
                return hotel.Rooms.First(r => r.Id == id);
            }
            catch (Exception)
            {
                Console.WriteLine("Room not found! Please try again.");
                List<Room>? rooms = hotel.Rooms;
                if (rooms == null)
                {
                    Console.WriteLine("No rooms found at all! Please create one first");
                    Console.WriteLine("Press any key to exit to the main menu ...");
                    Console.ReadKey();
                    throw new Exception("Room not found");
                }
            }
        }
    }

    private static Order GetValidReservation(string message, Hotel hotel)
    {
        Console.Clear();
        while (true)
        {
            long id = GetValidLong(message);
            try
            {
                return hotel.Reservations.First(r => r.Id == id);
            }
            catch (Exception)
            {
                Console.WriteLine("Reservation not found! Please try again.");
                List<Order>? reservations = hotel.Reservations;
                if (reservations == null)
                {
                    Console.WriteLine("\nNo reservations found at all! Please create one first");
                    Console.WriteLine("\nPress any key to exit to the main menu...");
                    Console.ReadKey();
                    throw new Exception("Reservation not found");
                }
            }
        }
    }

    private static long GetValidLong(string message)
    {
        while (true)
        {
            Console.WriteLine(message);
            var input = Console.ReadLine();
            if (long.TryParse(input, out var result))
            {
                Console.Clear();
                return result;
            }

            Console.WriteLine("Invalid number input received! Please try again.");
        }
    }

    private static DateOnly GetValidDate(string message)
    {
        Console.Clear();
        while (true)
        {
            Console.WriteLine(message);
            var input = Console.ReadLine();
            if (DateOnly.TryParse(input, out var result))
            {
                Console.Clear();
                return result;
            }

            Console.WriteLine("Invalid DateTime input received! Please try again.");
        }
    }

    private static List<string> GetValidKeywords(string enterHotelKeywordsCommaSeparated)
    {
        Console.Clear();
        while (true)
        {
            Console.WriteLine(enterHotelKeywordsCommaSeparated);
            var input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
            {
                Console.Clear();
                return input.Split(",").ToList();
            }

            Console.WriteLine("Invalid input! Please try again.");
        }
    }
}