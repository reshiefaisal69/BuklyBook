using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {

        private readonly ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void update(Product obj)
        {
            var objFromDb = _db.Products.FirstOrDefault(u => u.Id == obj.Id);
            if(objFromDb != null)
            {
                objFromDb.Title= obj.Title; 
                objFromDb.Description= obj.Description;
                objFromDb.ISBN = obj.ISBN;
                objFromDb.Author = obj.Author;
                objFromDb.ListPrice = obj.ListPrice;
                objFromDb.Price = obj.Price;
                objFromDb.ListPrice100 = obj.ListPrice100;
                objFromDb.ListPrice50 = obj.ListPrice50;
                objFromDb.CategoryId= obj.CategoryId;
                objFromDb.CoverTypeId = obj.CoverTypeId;
            }
            if(obj.ImageUrl != null)
            {
                objFromDb.ImageUrl = obj.ImageUrl;
            }
            //_db.Products.Update(obj);
        }
    }
}
