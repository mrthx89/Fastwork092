﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EM4.App.Model.Entity
{
    [Table("TInventor")]
    public partial class TInventor : BaseTable
    {
        [Key]
        public Guid ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string PLU { get; set; }
        [Required]
        [MaxLength(150)]
        public string Desc { get; set; }
        [Required]
        public Guid IDUOM { get; set; }

        public virtual TUOM UOM { get; set; }
        public virtual ICollection<TStockIn> StockIns { get; set; }
        public virtual ICollection<TStockOut> StockOuts { get; set; }
        public virtual ICollection<TStockCard> StockCards { get; set; }
        public virtual ICollection<TStockPengembalian> StockPengembalians { get; set; }
    }
}
