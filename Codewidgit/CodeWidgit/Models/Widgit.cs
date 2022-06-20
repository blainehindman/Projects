using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CodeWidgit.Models
{
    [Table("Widgit")]
    public partial class Widgit
    {
        [Key]
        [Column("Widgit_ID")]
        public Guid WidgitId { get; set; }
        [Column("Widgit_Name")]
        [StringLength(30)]
        public string WidgitName { get; set; } = null!;
        [Column("Widgit_Description")]
        [StringLength(300)]
        public string WidgitDescription { get; set; } = null!;
        [Column("Creator_ID")]
        public Guid CreatorId { get; set; }
        [Column("Creator_Username")]
        [StringLength(30)]
        public string CreatorUsername { get; set; } = null!;
        [Column("Published_Date")]
        [StringLength(30)]
        public string PublishedDate { get; set; } = null!;
        [Column("Updated_Date")]
        [StringLength(30)]
        public string UpdatedDate { get; set; } = null!;
        [Column("Widgit_Price")]
        public double WidgitPrice { get; set; }
        [Column("Widgit_Downloads")]
        public int WidgitDownloads { get; set; }
        [Column("Widgit_Rating")]
        public double WidgitRating { get; set; }
        [Column("Widgit_Likes_Count")]
        public int WidgitLikesCount { get; set; }
        [Column("Widgit_Comments_Count")]
        public int WidgitCommentsCount { get; set; }
    }
}
