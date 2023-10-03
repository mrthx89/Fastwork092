using EM4.App.Model.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM4.App.Model.ViewModel
{
    public class KartuStok : BaseTable
    {
        public Guid ID { get; set; }
        public DateTime Tanggal { get; set; }
        public string DocNo { get; set; }
        public Guid IDInventor { get; set; }
        public Guid IDUOM { get; set; }
        public Guid IDTransaksi { get; set; }
        public Guid IDTransaksiD { get; set; }
        public Guid IDType { get; set; }
        public float QtyMasuk { get; set; }
        public float QtyKeluar { get; set; }
        public Guid IDBelt { get; set; }
        public string PIC { get; set; }
        public string NamaBarang { get; set; }

        public float SaldoAwal { get; set; }
        public float SaldoAkhir { get { return SaldoAwal + QtyMasuk - QtyKeluar; } }
        public int NoUrut { get; set; }
    }
}
