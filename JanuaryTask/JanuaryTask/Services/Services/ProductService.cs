using AccessData.Models;
using AutoMapper;
using Interfaces.Interfaces;
using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Service
{
    public class ProductService : IProductService
    {
        private readonly IRepositoryProduct _repository;
        private readonly IMapper _mapper;
        public ProductService(IRepositoryProduct repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public bool Add(Product _create)
        {
            var create = _repository.Add(_create);
            //var mapcreate = _mapper.Map<Product>(create);
            return create;

        }

        public bool Delete(int id)
        {           
            _repository.Delete(id); 
            return true;
        }

        public List<Product> getAll()
        {
            var products = _repository.getAll();
            //return _mapper.Map<List<ProductDto>>(products);
            return products;
        }

        public Product getById(int id)
        {
            var product = _repository.getById(id);
            return product;
            //return _mapper.Map<ProductDto>(product);
        }

        //public ProductUpdateDto Update(int id, ProductUpdateDto _update)
        //{
        //    var product = _repository.getById(_update.Id);
        //    var exist = _mapper.Map<ProductUpdateDto>(product);
        //    return exist;
        //}
    }
}
