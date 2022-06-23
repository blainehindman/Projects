﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CodeWidgit.Models
{
    public partial class Comment
    {
        [Key]
        [Column("Rating_ID")]
        public Guid RatingId { get; set; }
        [Column("Wigit_ID")]
        public Guid WigitId { get; set; }
        [Column("Author_ID")]
        public Guid AuthorId { get; set; }
        [Column("Author_Username")]
        [StringLength(30)]
        public string AuthorUsername { get; set; } = null!;
        [Column("Comment_Date")]
        [StringLength(30)]
        public string CommentDate { get; set; } = null!;
        public int Edited { get; set; }
    }
}