using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CodeWidgitCore.Models
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
        [StringLength(450)]
        public string AuthorId { get; set; } = null!;
        [Column("Author_Username")]
        [StringLength(256)]
        public string AuthorUsername { get; set; } = null!;
        public int Score { get; set; }
        [Column("Rating_Date")]
        [StringLength(30)]
        public string RatingDate { get; set; } = null!;
    }
}
