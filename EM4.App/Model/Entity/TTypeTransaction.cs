using Newtonsoft.Json;
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
    [Table("TTypeTransaction")]
    public partial class TTypeTransaction : BaseTable
    {
        [Key]
        public Guid ID { get; set; }
        [Required]
        [StringLength(100)]
        public string Transaksi { get; set; }
        [Required]
        public int NoUrut { get; set; }


        public virtual ICollection<TStockCard> StockCards { get; set; }
    }
}
