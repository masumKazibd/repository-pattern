using Repository_Pattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Pattern.Repositories
{
    public class HotelRepo : IRepo
    {
        public void Delete(int HotelId)
        {
            Hotel hotel = HotelDB.HotelList.FirstOrDefault(x => x.HotelId == HotelId);
            HotelDB.HotelList.Remove(hotel);
        }

        public IEnumerable<Hotel> GetAll()
        {
            return HotelDB.HotelList;
        }

        public Hotel GetById(int HotelId)
        {
            Hotel hotel = HotelDB.HotelList.FirstOrDefault(x => x.HotelId == HotelId);
            return hotel;
        }

        public void Insert(Hotel Hotel)
        {
            HotelDB.HotelList.Add(Hotel);
        }

        public void Update(Hotel Hotel)
        {
            Hotel _hotel = HotelDB.HotelList.FirstOrDefault(x => x.HotelId == Hotel.HotelId);
            if (Hotel.HotelName != null)
            {
                _hotel.HotelName = Hotel.HotelName;
            }
            if (Hotel.Location != null)
            {
                _hotel.Location = Hotel.Location;
            }
        }
    }
}
