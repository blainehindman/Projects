using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CodeWidgitCore.Models
{
    public partial class Like
    {
        [Key]
        [Column("Like_ID")]
        public Guid LikeId { get; set; }
        [Column("Widgit_ID")]
        public Guid WidgitId { get; set; }
        [Column("Author_ID")]
        [StringLength(450)]
        public string AuthorId { get; set; } = null!;
        [Column("Author_Username")]
        [StringLength(256)]
        public string AuthorUsername { get; set; } = null!;
        [Column("Like_Date")]
        [StringLength(30)]
        public string LikeDate { get; set; } = null!;
    }
}
