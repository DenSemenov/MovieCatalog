using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieCatalog.Models
{
    public class PageClass
    {
        public List<Movies> pageMovies { get; set; }
        public int currPage { get; set; }
        public List<int> pagesAvaible { get; set; }
        public string currUser { get; set; }
    }


}