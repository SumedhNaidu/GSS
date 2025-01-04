using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs
{
    public class MoviesDTO
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public IList<string> Cast { get; set; }
        public IList<string?> Generes { get; set; }
        //public ImageFileMachine Thumbnail { get; set; }
        //public moviesdata mvdata {  get; set; }
    }
}
