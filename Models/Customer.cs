using System.ComponentModel.DataAnnotations.Schema;

namespace AlbumRent_MVC.Models
{
    [Table("Customer")]
    public class Customer
    {
        [Column("id")]
        public string Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
    }
}
