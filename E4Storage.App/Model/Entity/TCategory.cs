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
    [Table("TCategory")]
    public partial class TCategory : BaseTable
    {
        [Key]
        public Guid ID { get; set; }
        [Required]
        [StringLength(20)]
        public string Category { get; set; }

        public virtual ICollection<TStockOut> StockOuts { get; set; }
    }
}
