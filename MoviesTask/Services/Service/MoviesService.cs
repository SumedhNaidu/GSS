using AccessData.Models;
using Interfaces.Interfaces;
using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Service
{
    public class MoviesService : IServiceMovies
    {
        private readonly IRepositoryMovies _repositoryMovies;
        public MoviesService(IRepositoryMovies repositoryMovies)
        {
            _repositoryMovies = repositoryMovies;
        }

        public ResponseDTO Addall(IList<CreateMoviesDTO> createMoviesDTO)
        {
            //var addall = _repositoryMovies.Addall(createMoviesDTO);
            //return addall;
            var movies = createMoviesDTO.Select(dto => new Movies
            {
                Title = dto.Title,
                Year = dto.Year,
                Cast = dto.Cast,
                Generes = dto.Generes
            }).ToList();

            _repositoryMovies.Addall(movies);
            return new ResponseDTO
            {
                Success = true,
                Message = "Products added successfully."
            };
        }

        public IList<MoviesDTO> FilterByGenre(string genre)
        {
            var filterGenre = _repositoryMovies.FilterByGenre(genre);
            return filterGenre;
        }

        public IList<MoviesDTO> FilterByTitle(string title)
        {
            var filterTitle = _repositoryMovies.FilterByTitle(title);
            return filterTitle;
        }
    }
}

//public ResponseDto AddBulk(List<CreateProductDto> productDtos)
//{
//    var products = productDtos.Select(dto => new Product
//    {
//        Name = dto.Name,
//        Description = dto.Description,
//        Price = dto.Price,
//        StockQuantity = dto.StockQuantity,
//        CreatedAt = DateTime.Now,
//        UpdatedAt = DateTime.Now
//    }).ToList();

//    _productRepository.AddBulk(products);

//    return new ResponseDto
//    {
//        Success = true,
//        Message = "Products added successfully."
//    };
//}