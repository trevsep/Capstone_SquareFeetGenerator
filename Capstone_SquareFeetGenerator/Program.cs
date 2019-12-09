using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace Capstone_SquareFeetGenerator
{
    #region MAIN
    class Program
    {
        static void Main(string[] args)
        {
            List<Room> rooms = InitializeRoomList();

            DisplayWelcomeScreen();

            DisplayRules();

            DisplayMenuScreen(rooms);

            DisplayClosingScreen();

        }

        static List<Room> InitializeRoomList()
        {
            List<Room> rooms = new List<Room>();

            return rooms;
          
        }

        static void DisplayMenuScreen(List<Room> rooms)
        {
            bool quitApplication = false;

            string menuChoice;

            do { 

            DisplayScreenHeader("Main Menu");

                Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("a) Add A Room");

            Console.WriteLine();

            Console.WriteLine("b) View All Rooms");

            Console.WriteLine();

            Console.WriteLine("c) Edit Room(s)");

            Console.WriteLine();

            Console.WriteLine("d) Delete a room");

            Console.WriteLine();

            Console.WriteLine("e) Calculate Total Square Feet");

            Console.WriteLine();

            Console.WriteLine("q) Quit");

            Console.WriteLine();

            Console.Write("Enter Choice: ");

            Console.ForegroundColor = ConsoleColor.Yellow;

            menuChoice = Console.ReadLine().ToLower();

            

                switch (menuChoice)
                {
                    case "a":

                        DisplayAddNewRoom(rooms);

                        break;

                    case "b":

                        DisplayAllRooms(rooms);

                        break;

                    case "c":
                        DisplayEditRoom(rooms);

                        break;

                    case "d":
                        DisplayDeleteRoom(rooms);

                        break;

                    case "e":
                        DisplayCalculateTotalSquareFeet(rooms);

                        break;

                    case "f":
                        WriteToRoomInformation(rooms);

                        break;

                    case "q":


                        quitApplication = true;

                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine();
                        Console.WriteLine("Please enter a letter for the menu choice.");
                        DisplayContinuePrompt();
                        break;
                }
            } while (!quitApplication);
        }
        
        static void WriteToRoomInformation(List<Room> rooms)
        {
            string[] roomsString = new string[rooms.Count];

            for (int index = 0; index < rooms.Count; index++)
            {
                string roomString =
                    rooms[index].Name + "," +
                    rooms[index].Length + "," +
                    rooms[index].Width;

                roomsString[index] = roomString;

            }

            File.WriteAllLines(@"Room\RoomInformation.txt", roomsString);

            DisplayContinuePrompt();
        }

        #region CALCULATE TOTAL
        static void DisplayCalculateTotalSquareFeet(List<Room> rooms)
        {
            DisplayScreenHeader("Square Feet calculation");

            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.Cyan;
            string s = "Press any key to calculate square feet.";
            Console.WriteLine();
            Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
            Console.WriteLine(s);
            Console.WriteLine();
            Console.ReadKey();
            Console.CursorVisible = true;

            double totalArea = 0;
            double area;
            double feet;
            double areaLeft;

            foreach (Room room in rooms)
            {
                area = room.Length * room.Width;

                Console.ForegroundColor = ConsoleColor.Green;

                Console.Write($"total square inches of Room: ");

                Console.ForegroundColor = ConsoleColor.Cyan;

                Console.Write($"{room.Name}: ");

                Console.ForegroundColor = ConsoleColor.Yellow;

                Console.Write($"{room.AreaUser()}");

                Console.WriteLine();

                totalArea += area;
                          
            }

            DisplayContinuePrompt();

            Console.ForegroundColor = ConsoleColor.Green;

            Console.Write($"Total square feet in inches: ");

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.Write($"{totalArea} inches");

            Console.WriteLine();

            feet = Math.Floor(totalArea / 144);

            areaLeft = totalArea % 12;

            Console.ForegroundColor = ConsoleColor.Green;

            Console.Write("total square feet for all rooms: ");

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.Write($"{feet} ft and {areaLeft} inches.");

            Console.WriteLine();

            DisplayContinuePrompt();

        }

        #endregion

        #region DELETE ROOM
        static void DisplayDeleteRoom(List<Room> rooms)
        {
            DisplayScreenHeader("Delete a room");

            bool validResponse1 = false;
            Room selectedRoom = null;

          do{
                Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("List of Rooms");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            foreach (Room room in rooms)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(room.Name);
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Please choose which room you would like to edit: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            string roomName = Console.ReadLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");

            foreach (Room room in rooms)
            {
                if (room.Name == roomName)
                {
                    selectedRoom = room;

                    validResponse1 = true;

                    break;

                }
                else if (room.Name != roomName)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine();
                    Console.WriteLine("Please choose a room from the list provided.");
                    Console.WriteLine();

                }
            }

          } while (!validResponse1);

            if (selectedRoom != null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                rooms.Remove(selectedRoom);
                Console.WriteLine();
                Console.WriteLine($"{selectedRoom.Name} deleted");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine();
                Console.WriteLine($"{selectedRoom} not found");
            }

            DisplayContinuePrompt();

        }

        #endregion

        #region EDIT ROOM
        static void DisplayEditRoom(List<Room> rooms)
        {
            bool validResponse1 = false;
            bool validResponse2 = false;
            Room selectedRoom = null;
            string userResponse;
            do
            {
                do
                {

                    DisplayScreenHeader("Edit A Room");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("List of Rooms");
                    Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                    foreach (Room room in rooms)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(room.Name);
                        Console.WriteLine();
                    }
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Please choose which room you would like to edit: ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    string roomName = Console.ReadLine();
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");

                    foreach (Room room in rooms)
                    {
                        if (room.Name == roomName)
                        {
                            selectedRoom = room;

                            validResponse1 = true;

                            break;

                        }
                        else if (room.Name != roomName)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine();
                            Console.WriteLine("Please choose a room from the list provided.");
                            Console.WriteLine();

                        }
                    }

                } while (!validResponse1);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("You have chosen to update ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(selectedRoom.Name);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(" is this correct (y or n): ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                string correct = Console.ReadLine();
                if (correct == "y")
                {
                    validResponse1 = false;
                    Console.WriteLine();
                    Console.WriteLine();
                    DisplayContinuePrompt();

                }
                else
                {
                    validResponse1 = true;
                }
            } while (validResponse1 != false);


            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Current Name: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(selectedRoom.Name);
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"New Name: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            userResponse = Console.ReadLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            if (userResponse != "")
            {
                selectedRoom.Name = userResponse; 
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Current Length: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(selectedRoom.Length + " inches.");
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("New Length: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            userResponse = Console.ReadLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            if (userResponse != "")
            {     
                int.TryParse(userResponse, out int length);
                selectedRoom.Length = length;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"Current Width: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(selectedRoom.Width + " inches.");
            Console.WriteLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("New Width: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            userResponse = Console.ReadLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            if (userResponse != "")
            {
                int.TryParse(userResponse, out int width);
                selectedRoom.Width = width;
            }
            DisplayContinuePrompt();

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine();
            DisplayScreenHeader("New Room Properties");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            RoomInformation(selectedRoom);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");

            DisplayContinuePrompt();
        }
        #endregion

        #region ADD NEW ROOM
        static void DisplayAddNewRoom(List<Room> rooms)
        {
            Room newRoom = new Room();
            string userResponse;
            bool validResponse = false;

            do
            {
                DisplayScreenHeader("Add a new room.");

                //
                //Recieve Room Properties from User
                //
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Name of room: ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                newRoom.Name = Console.ReadLine();

                do
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Length of room: ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    userResponse = Console.ReadLine();

                    if (double.TryParse(userResponse, out double length))
                    {
                        newRoom.Length = length;
                        validResponse = false;

                    }
                    else
                    {
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Error: {userResponse} is not a valid input!");
                        validResponse = true;
                    }
                } while (validResponse != false);

                do
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("Width of room: ");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    if (double.TryParse(Console.ReadLine(), out double width))
                    {
                        newRoom.Width = width;
                        validResponse = false;

                    }
                    else
                    {
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Error: {userResponse} is not a valid input!");
                        validResponse = true;
                    }
                } while (validResponse != false);


                //
                //Display Room Properties
                //
                Console.Clear();
                Console.WriteLine();
                DisplayScreenHeader("Room Properties");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                RoomInformation(newRoom);
                rooms.Add(newRoom);
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Is this information correct? (y or n): ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                string correct = Console.ReadLine();
                if (correct.ToLower() == "y")
                {
                    Console.WriteLine();
                    validResponse = false;
                    DisplayContinuePrompt();

                }
                else
                {
                    rooms.Remove(newRoom);
                    validResponse = true;
                }
            } while (validResponse != false);
            
        }
        #endregion

        #region ROOM INFO
        static void RoomInformation(Room room)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"Name of Room: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"{room.Name}");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"Length of Room: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"{room.Length} inches.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"Width of Room: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"{room.Width} inches.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"Square inches of Room: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"{room.AreaUser()} inches.");
            Console.WriteLine();
        }
        #endregion

        #region DISPLAY ALL ROOMS
        static void DisplayAllRooms(List<Room> rooms)
        {
            DisplayScreenHeader("All Rooms");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine();
            foreach (Room room in rooms)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                RoomInformation(room);
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            }

            DisplayContinuePrompt();
        }

        #endregion

        #region RULES
        static void DisplayRules()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine();

            string a = ("Thanks for using the Square Feet Generator. Please make sure to follow these guidelines.");

            string b =("*The intended user is for a future homeowner");

            string c = ("*It is assumed that all dimensions the program asks for is to be input in inches.");

            string d = ("*It is assumed that the program will only function with rectangular spaces. (Length and Width)");

            string e = ("*Thank you, and enjoy the application.");

            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine();
            Console.SetCursorPosition((Console.WindowWidth - a.Length) / 2, Console.CursorTop);
            Console.WriteLine(a);
            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            DisplayContinuePrompt();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine();
            Console.SetCursorPosition((Console.WindowWidth - b.Length) / 2, Console.CursorTop);
            Console.WriteLine(b);
            Console.WriteLine();
            Console.SetCursorPosition((Console.WindowWidth - c.Length) / 2, Console.CursorTop);
            Console.WriteLine(c);
            Console.WriteLine();
            Console.SetCursorPosition((Console.WindowWidth - d.Length) / 2, Console.CursorTop);
            Console.WriteLine(d);
            Console.WriteLine();
            Console.SetCursorPosition((Console.WindowWidth - e.Length) / 2, Console.CursorTop);
            Console.WriteLine(e);
            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            DisplayContinuePrompt();

        }
        #endregion

        #region HELPER METHODS

        /// <summary>
        /// display welcome screen
        /// </summary>
        static void DisplayWelcomeScreen()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            String s = "Welcome to the Square Feet Generator";
            Console.Clear();
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine();
            Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
            Console.WriteLine(s);
            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine();
            DisplayContinuePrompt();
        }

        /// <summary>
        /// display closing screen
        /// </summary>
        static void DisplayClosingScreen()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            String s = "Thank you for using the square feet generator!";
            Console.Clear();
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine();
            Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
            Console.WriteLine(s);
            Console.WriteLine();
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine();

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display continue prompt
        /// </summary>
        static void DisplayContinuePrompt()
        {
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.Red;
            string s = "Press any key to continue.";
            Console.WriteLine();
            Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
            Console.WriteLine(s);
            Console.WriteLine();
            Console.ReadKey();
            Console.ForegroundColor = ConsoleColor.White;
            Console.CursorVisible = true;
        }

        /// <summary>
        /// display screen header
        /// </summary>
        static void DisplayScreenHeader(string headerText)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine();
            Console.SetCursorPosition((Console.WindowWidth - headerText.Length) / 2, Console.CursorTop);
            Console.WriteLine(headerText);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
        }

        #endregion
    }
    #endregion
}
