using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs
{
    public class CreateMoviesDTO
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public IList<string> Cast { get; set; }
        public string Generes { get; set; }
        //public ImageFileMachine Thumbnail { get; set; }
    }
}
