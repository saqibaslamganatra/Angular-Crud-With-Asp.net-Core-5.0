using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string BookName { get; set; }

        [Column(TypeName = "nvarchar(255)")]
        public string BookDescription { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string BookAuthor{ get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string BookPublisher{ get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string ISBN { get; set; }

    }
}
