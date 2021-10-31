using System;
using System.Collections.Generic;

#nullable disable

namespace AlbumRent_MVC.Models
{
    public partial class Album
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Band { get; set; }
    }
}
