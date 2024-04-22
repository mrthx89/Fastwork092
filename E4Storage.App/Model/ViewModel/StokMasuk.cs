using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E4Storage.App.Model.ViewModel
{
    public class StokMasuk : Entity.BaseTable
    {
        [Key]
        public Guid ID { get; set; }
        [Required]
        public DateTime Tanggal { get; set; }
        [StringLength(30)]
        public string DocNo { get; set; }
        [StringLength(30)]
        public string NoSJ { get; set; }
        [StringLength(150)]
        public string Supplier { get; set; }
        public Guid IDInventor { get; set; }
        public Guid IDUOM { get; set; }
        public float Qty { get; set; }
        public Guid? IDBelt { get; set; }
        [StringLength(150)]
        public string PIC { get; set; }
        [StringLength(255)]
        public string Keterangan { get; set; }
        public Guid? IDCategory { get; set; }
        [Range(0, int.MaxValue)]
        public int? Cabinet { get; set; }
        [StringLength(255)]
        public string Row { get; set; }

        //ViewModel
        public string Periode
        {
            get
            {
                return (Tanggal == null ? DateTime.Now : Tanggal).ToString("MMMM");
            }
        }
        public Guid IDType { get; set; }
        public string NamaBarang { get; set; }
    }
}
