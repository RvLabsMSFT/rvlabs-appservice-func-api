using System;
using System.Collections.Generic;

namespace coreapi
{
    public class MovieItem
    {
        public string Title { get; set; }
        public string Rank { get; set; }
        public string Id { get; set; }
    }

    public class MovieList
    {
        public List<MovieItem> Movies { get; set; }
    }
    
}