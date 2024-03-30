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
    [Table("TStockCard")]
    public partial class TStockCard : BaseTable
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
        public Guid IDTransaksi { get; set; }
        [Required]
        public Guid IDTransaksiD { get; set; }
        [Required]
        public Guid IDType { get; set; }
        [Required]
        public float QtyMasuk { get; set; }
        [Required]
        public float QtyKeluar { get; set; }
        public Guid? IDBelt { get; set; }
        [StringLength(150)]
        public string PIC { get; set; }
        public Guid? IDCategory { get; set; }
        [Range(0, int.MaxValue)]
        public int? Cabinet { get; set; }
        [StringLength(255)]
        public string Row { get; set; }


        public virtual TInventor Inventor { get; set; }
        public virtual TUOM UOM { get; set; }
        public virtual TTypeTransaction TypeTransaction { get; set; }
    }
}
