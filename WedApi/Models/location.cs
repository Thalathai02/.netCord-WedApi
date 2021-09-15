
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WedApi.Models
{
    [Table("location")]
    public class location
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public double lat { get; set; }
        [Required]
        public double lng { get; set; }
        [Required]
        public string Date { get; set; }
        [Required]
        [ForeignKey("IdUsers")]
        public int User { get; set; }
        // Foreign Key (UserID)
        //public int UserID { get; set; }
        //public user user { get; set; }

    }
    [Table("user")]
    public class user
    {

        [Key]
        [Required]
        public int IdUsers { get; set; }
        [Required]
        public string UUID { get; set; }
        [Required]
        [Column(TypeName = "varchar(20)")]
        public string email { get; set; }

    


    }
}
