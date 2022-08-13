using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CodeWidgitCore.Models
{
    [Table("User_Creation_Date")]
    public partial class UserCreationDate
    {
        [Key]
        [Column("User_ID")]
        public string UserId { get; set; } = null!;
        [Column("Creation_Date")]
        [StringLength(256)]
        public string CreationDate { get; set; } = null!;
    }
}
