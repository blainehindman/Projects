using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CodeWidgitCore.Models
{
    [Table("User_Followers_Count")]
    public partial class UserFollowersCount
    {
        [Key]
        [Column("User_ID")]
        public string UserId { get; set; } = null!;
        [StringLength(256)]
        public string? Username { get; set; }
        public int? Followers { get; set; }
    }
}
