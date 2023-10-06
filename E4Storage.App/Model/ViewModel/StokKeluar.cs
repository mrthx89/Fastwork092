using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E4Storage.App.Model.ViewModel
{
    public class StokKeluar : Entity.BaseTable
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
        [Range(0, float.MaxValue, ErrorMessage = "Qty yang diinputkan salah")]
        public float Qty { get; set; }
        [Required]
        public Guid IDBelt { get; set; }
        [Required]
        [StringLength(150)]
        public string PIC { get; set; }
        [StringLength(255)]
        public string Keterangan { get; set; }
        public float Saldo { get; set; }

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
