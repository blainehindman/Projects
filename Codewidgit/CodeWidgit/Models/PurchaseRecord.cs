using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CodeWidgit.Models
{
    [Table("Purchase_Record")]
    public partial class PurchaseRecord
    {
        [Key]
        [Column("Transaction_ID")]
        public Guid TransactionId { get; set; }
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
        [Column("Purchaser_ID")]
        public Guid PurchaserId { get; set; }
        [Column("Purchaser_Username")]
        [StringLength(30)]
        public string PurchaserUsername { get; set; } = null!;
        [Column("Widgit_Price")]
        public double WidgitPrice { get; set; }
        [Column("Purchase_Date")]
        [StringLength(30)]
        public string PurchaseDate { get; set; } = null!;
    }
}
