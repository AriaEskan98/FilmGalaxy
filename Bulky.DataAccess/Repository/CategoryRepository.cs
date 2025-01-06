using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FilmGalaxy.DataAccess.Data;
using FilmGalaxy.DataAccess.Repository.IRepository;
using FilmGalaxy.Models;

namespace FilmGalaxy.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private DataDbContext _db;

        public CategoryRepository(DataDbContext db) : base(db)
        {
            _db = db;

        }



        public void Update(Category category)
        {
            _db.Categories.Update(category);
        }
    }
}
