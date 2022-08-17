using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CodeWidgitCore.Models
{
    public partial class Hashtag
    {
        [Key]
        [Column("Hashtag_ID")]
        public Guid HashtagId { get; set; }
        [Column("Widgit_ID")]
        public Guid WidgitId { get; set; }
        [Column("Hashtag")]
        [StringLength(10)]
        public string Hashtag1 { get; set; } = null!;
    }
}
