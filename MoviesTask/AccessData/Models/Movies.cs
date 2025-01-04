using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AccessData.Models
{
    public class Movies
    {
        [Key]
        [Required]
        public string Title { get; set; }
        [Required]
        public int Year { get; set; }
        public IList<string> Cast {  get; set; }
        public string Generes { get; set; }
        //public ImageFileMachine Thumbnail { get; set; }

    }
}
