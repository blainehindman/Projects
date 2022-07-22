using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CodeWidgitCore.Models
{
    [Table("WidgitContent")]
    public partial class WidgitContent
    {
        [Key]
        [Column("WidgitFileID")]
        public Guid WidgitFileId { get; set; }
        [Unicode(false)]
        public string WidgitFile { get; set; } = null!;
    }
}
