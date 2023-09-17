using Repository_Pattern.Models;
using Repository_Pattern.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Pattern
{

    internal class Program
    {
        static void Main(string[] args)
        {
            DisplayOption();
            Console.ReadKey();
        }
        public static void DisplayOption()
        {
            Console.WriteLine("==========================");
            Console.WriteLine("1. Insert Hotel info");
            Console.WriteLine("2. Show All Hotel");
            Console.WriteLine("3. Update Hotel info");
            Console.WriteLine("4. Delete Hotel");

            var index = int.Parse(Console.ReadLine());
            Show(index);
        }
        public static void Show(int index)
        {
            HotelRepo hotelRepo = new HotelRepo();

            //index 1 for insert hotel
            if (index == 1)
            {
                Console.WriteLine("==========================");
                Console.Write("Hotel Name " +
                    "\t: ");
                string name = Console.ReadLine();
                Console.Write("Location \t: ");
                string location = Console.ReadLine();

                int maxId = hotelRepo.GetAll().Any() ? hotelRepo.GetAll().Max(x => x.HotelId) : 0;

                Hotel hotel = new Hotel
                {
                    HotelId = maxId + 1,
                    HotelName = name,
                    Location = location
                };
                hotelRepo.Insert(hotel);
                Console.WriteLine();
                Console.WriteLine("\tData inserted successfully!!");
                DisplayOption();
            }
            //Index 2 for get all hotel
            else if (index == 2)
            {
                var hotelList = hotelRepo.GetAll();
                if (hotelList.Count() == 0)
                {
                    Console.WriteLine("==========================");
                    Console.WriteLine("No item found in the list!!!");
                    Console.WriteLine("==========================");
                }
                else
                {
                    foreach (var item in hotelRepo.GetAll())
                    {
                        Console.WriteLine();
                        Console.WriteLine($"\tHotel Id : {item.HotelId},\tName :{item.HotelName},\tLocation :{item.Location}");

                    }
                    Console.WriteLine("");
                    DisplayOption();
                }
            }

            
            //index 3 for update hotel
            else if (index == 3)
            {
                Console.WriteLine("==========================");
                Console.Write("Enter hotelId to update :");
                int id = Convert.ToInt32(Console.ReadLine());
                var _hotel = hotelRepo.GetById(id);
                if (_hotel == null)
                {
                    Console.WriteLine("==========================");
                    Console.WriteLine("Hotel id is invalid!!!");
                    Console.WriteLine("==========================");
                    return;
                }
                else
                {
                    Console.WriteLine($"Update Info for hotel id :{id}");
                    Console.WriteLine("==========================");

                    Console.Write("Hotel Name\t: ");
                    string name = Console.ReadLine();
                    Console.Write("Location \t: ");
                    string location = Console.ReadLine();

                    Hotel hotel = new Hotel
                    {
                        HotelId = id,
                        HotelName = name,
                        Location = location
                    };
                    hotelRepo.Update(hotel);
                    Console.WriteLine("Data updated successfully!!");
                    DisplayOption();
                }
            }
            //index 4 for delete data
            else if (index == 4)
            {
                Console.WriteLine("==========================");
                Console.Write("Enter hotelId to delete :");

                int id = Convert.ToInt32(Console.ReadLine());
                var _hotel = hotelRepo.GetById(id);

                if (_hotel == null)
                {
                    Console.WriteLine("==========================");
                    Console.WriteLine("Hotel id is invalid!!!");
                    Console.WriteLine("==========================");
                    return;
                }
                else
                {
                    hotelRepo.Delete(id);
                    Console.WriteLine("Data deleted successfully!!!");
                    Console.WriteLine("==========================");
                    DisplayOption();
                }
            }

        }
    }
}