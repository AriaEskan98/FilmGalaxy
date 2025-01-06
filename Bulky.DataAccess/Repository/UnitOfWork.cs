using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FilmGalaxy.DataAccess.Data;
using FilmGalaxy.DataAccess.Repository.IRepository;

namespace FilmGalaxy.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private DataDbContext _db;
        public ICategoryRepository Category { get; private set; }
        public IMovieRepository Movie { get; private set; }

        public UnitOfWork(DataDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            Movie = new MovieRepository(_db);

        }
       

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
