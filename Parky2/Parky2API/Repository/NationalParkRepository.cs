using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Parky2API.Data;
using Parky2API.Models;
using Parky2API.Repository.IRepository;

namespace Parky2API.Repository
{
    public class NationalParkRepository : INationalParkRepository
    {
        private readonly ApplicationDbContext _db;

        public NationalParkRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool CreateNationalPark(NationalPark nationalPark)
        {
            _db.NationalParks.Add(nationalPark);
            return Save();
        }

        public bool DeleteNationalPark(NationalPark nationalPark)
        {
            _db.NationalParks.Remove(nationalPark);
            return Save();
        }

        public NationalPark GetNationalPark(int nationalParkId)
        {
           return _db.NationalParks.FirstOrDefault(np => np.Id == nationalParkId);
        }

        public ICollection<NationalPark> GetNationalParks()
        {
            return _db.NationalParks.ToList();
        }

        public bool NationalParkExists(string name)
        {
            bool value = _db.NationalParks.Any(np => np.Name.ToLower().Trim() == name.ToLower().Trim());
            return value;
        }

        public bool NationalParkExists(int npId)
        {
            return _db.NationalParks.Any(np => np.Id == npId);
        }

        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdateNationalPark(NationalPark nationalPark)
        {
            _db.NationalParks.Update(nationalPark);
            return Save();
        }
    }
}
