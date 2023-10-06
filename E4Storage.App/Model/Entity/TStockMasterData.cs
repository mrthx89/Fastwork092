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
    [Table("TStockMasterData")]
    public partial class TStockMasterData : BaseTable
    {
        [Key]
        public Guid ID { get; set; }
        [Required]
        public DateTime Tanggal { get; set; }
        [Required]
        [StringLength(30)]
        public string DocNo { get; set; }
        [Required]
        public Guid IDInventor { get; set; }
        [Required]
        public Guid IDUOM { get; set; }
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Qty yang diinputkan salah")]
        public float Qty { get; set; }
        [StringLength(255)]
        public string Keterangan { get; set; }


        public virtual TInventor Inventor { get; set; }
        public virtual TUOM UOM { get; set; }
    }
}
