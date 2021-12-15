using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace AlbumRent_MVC.Models
{
    [Table("Album")]
    public class Album
    {
        [Column("id")]
        public string Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("band")]
        public string Band { get; set; }
    }
}
