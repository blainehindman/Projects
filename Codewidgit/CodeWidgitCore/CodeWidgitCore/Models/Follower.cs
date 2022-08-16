using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CodeWidgitCore.Models
{
    public partial class Follower
    {
        [Key]
        [Column("Follow_ID")]
        public Guid FollowId { get; set; }
        [Column("Follower_ID")]
        [StringLength(450)]
        public string FollowerId { get; set; } = null!;
        [Column("Follower_Username")]
        [StringLength(256)]
        public string FollowerUsername { get; set; } = null!;
        [Column("Followed_ID")]
        [StringLength(450)]
        public string FollowedId { get; set; } = null!;
        [Column("Followed_Username")]
        [StringLength(256)]
        public string FollowedUsername { get; set; } = null!;
    }
}
