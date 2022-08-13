using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CodeWidgitCore.Models
{
    [Table("Download_Record")]
    public partial class DownloadRecord
    {
        [Key]
        [Column("Download_ID")]
        public Guid DownloadId { get; set; }
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
        [Column("Client_ID")]
        public Guid ClientId { get; set; }
        [Column("Client_Username")]
        [StringLength(30)]
        public string ClientUsername { get; set; } = null!;
        [Column("Widgit_Price")]
        public double WidgitPrice { get; set; }
        [Column("Download_Date")]
        [StringLength(30)]
        public string DownloadDate { get; set; } = null!;
    }
}
