using AccessData.Models;
using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Interfaces
{
    public interface IProductService
    {
        public Product getById(int id);
        public List<Product> getAll();
        public bool Add(Product _create);
        public bool Delete(int id);
    }
}
