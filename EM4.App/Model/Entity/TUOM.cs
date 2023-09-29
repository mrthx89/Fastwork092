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
    [Table("TUOM")]
    public partial class TUOM : BaseTable
    {
        [Key]
        public Guid ID { get; set; }
        [Required]
        [StringLength(20)]
        public string Satuan { get; set; }

        public virtual ICollection<TInventor> Inventors { get; set; }
        public virtual ICollection<TStockIn> StockIns { get; set; }
        public virtual ICollection<TStockOut> StockOuts { get; set; }
        public virtual ICollection<TStockCard> StockCards { get; set; }
    }
}
