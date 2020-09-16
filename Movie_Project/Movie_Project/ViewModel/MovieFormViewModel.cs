using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Movie_Project.Models;

namespace Movie_Project.ViewModel
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genre { get; set; }
        public Movie movies { get; set; }

        public string Title
        {
            get
            {
                if(movies == null || movies.Id == 0)
                {
                    return "New Movie";   
                }
                else
                {
                    return "Edit Movie";
                }
                
            }
        }
    }
}