using Repository_Pattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Pattern.Repositories
{
    public interface IRepo
    {
        IEnumerable<Hotel> GetAll();
        Hotel GetById(int HotelId);
        void Insert(Hotel Hotel);
        void Update(Hotel Hotel);
        void Delete(int HotelId);
    }
}
