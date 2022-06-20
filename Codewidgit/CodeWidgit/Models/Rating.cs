using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CodeWidgit.Models
{
    [Table("Rating")]
    public partial class Rating
    {
        [Key]
        [Column("Rating_ID")]
        public Guid RatingId { get; set; }
        [Column("Widgit_ID")]
        public Guid WidgitId { get; set; }
        [Column("Author_ID")]
        public Guid AuthorId { get; set; }
        [Column("Author_Username")]
        [StringLength(30)]
        public string AuthorUsername { get; set; } = null!;
        [Column("Rating_Date")]
        [StringLength(30)]
        public string RatingDate { get; set; } = null!;
    }
}
