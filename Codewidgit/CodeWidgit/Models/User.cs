using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CodeWidgit.Models
{
    [Table("User")]
    public partial class User
    {
        [Key]
        [Column("User_ID")]
        public Guid UserId { get; set; }
        [Column("First_Name")]
        [StringLength(30)]
        public string FirstName { get; set; } = null!;
        [Column("Last_Name")]
        [StringLength(30)]
        public string LastName { get; set; } = null!;
        [StringLength(30)]
        public string Username { get; set; } = null!;
        [StringLength(30)]
        public string Password { get; set; } = null!;
        [StringLength(30)]
        public string Birthday { get; set; } = null!;
        [Column("Date_Joined")]
        [StringLength(30)]
        public string DateJoined { get; set; } = null!;
    }
}
