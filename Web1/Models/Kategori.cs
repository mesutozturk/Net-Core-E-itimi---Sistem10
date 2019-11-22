using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Web1.Models
{
    [Table("Kategoriler")]
    public class Kategori
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string KategoriAdi { get; set; }
        [StringLength(7)]
        public string Renk { get; set; } = "#ff0000";
        //Auto setter
        public DateTime EklenmeTarihi { get; set; } = DateTime.Now;
    }
}
