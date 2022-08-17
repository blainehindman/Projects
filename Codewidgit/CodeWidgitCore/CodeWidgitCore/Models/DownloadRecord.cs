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
        [Column("Creator_ID")]
        [StringLength(450)]
        public string CreatorId { get; set; } = null!;
        [Column("Creator_Username")]
        [StringLength(256)]
        public string CreatorUsername { get; set; } = null!;
        [Column("Client_ID")]
        [StringLength(450)]
        public string ClientId { get; set; } = null!;
        [Column("Client_Username")]
        [StringLength(256)]
        public string ClientUsername { get; set; } = null!;
        [Column("Download_Date")]
        [StringLength(256)]
        public string DownloadDate { get; set; } = null!;
    }
}
