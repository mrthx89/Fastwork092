using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace E4Storage.App.Model.Entity
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
        [Range(0d, Double.MaxValue, ErrorMessage ="{0} harus diisi antara {1} dan {2}!")]
        public double? QtyMin { get; set; }
        [Range(0d, Double.MaxValue, ErrorMessage = "{0} harus diisi antara {1} dan {2}!")]
        public double? QtyMax { get; set; }


        public virtual TUOM UOM { get; set; }
        public virtual ICollection<TStockIn> StockIns { get; set; }
        public virtual ICollection<TStockOut> StockOuts { get; set; }
        public virtual ICollection<TStockCard> StockCards { get; set; }
        public virtual ICollection<TStockPengembalian> StockPengembalians { get; set; }
        public virtual ICollection<TStockMasterData> StockMasterDatas { get; set; }
    }
}
