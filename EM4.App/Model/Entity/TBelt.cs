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
    [Table("TBelt")]
    public partial class TBelt : BaseTable
    {
        [Key]
        public Guid ID { get; set; }
        [Required]
        [StringLength(20)]
        public string Belt { get; set; }

        public virtual ICollection<TStockOut> StockOuts { get; set; }
    }
}
