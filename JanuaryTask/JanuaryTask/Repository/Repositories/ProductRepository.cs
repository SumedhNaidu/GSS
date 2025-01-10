using AccessData.Context;
using AccessData.Models;
using AutoMapper;
using Interfaces.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class ProductRepository : IRepositoryProduct
    {
        private readonly ProductDbContext _context;
        private readonly ILogger<ProductRepository> _logger;
        private readonly IMemoryCache _cache;
        private readonly IMapper _mapper;
        public ProductRepository(ProductDbContext context, ILogger<ProductRepository> logger, IMemoryCache cache, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _cache = cache;
            _mapper = mapper;
        }
        //public ProductRepository(ProductDbContext context, IMapper mapper)
        //{
        //    _context = context;          
        //    _mapper = mapper;
        //}
        string CacheKey = $"ProductKey";
        public bool Add(Product _create)
        {
            //var product = _mapper.Map<Product>(_create);
            var a = _context.Products.Add(_create);
            _context.SaveChanges();
            //var prod = _mapper.Map<Product>(product);
            //return prod;
            return true;
        }

        public void Delete(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);
            _context.Products.Remove(product);
            _context.SaveChanges();
        }

        public List<Product> getAll()
        {
            var products = _context.Products.ToList();
            return products;
        }

        public Product getById(int id)
        {
            if (!_cache.TryGetValue(CacheKey, out var product))
            {
                _context.Products.FirstOrDefault(p => p.Id == id);
                _cache.Set(CacheKey, product);
            } else
            {
                _cache.TryGetValue(CacheKey, out product);
            }
            return _context.Products.FirstOrDefault(p => p.Id == id);
        }

        //public ProductDto Update(ProductUpdateDTO _create)
        //{
        //    _context.Products.Update(_create);
        //    _context.SaveChanges();
        //}
    }
}
