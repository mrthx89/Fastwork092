using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E4Storage.App.Model.ViewModel
{
    public class MutasiStok
    {
        public Guid IDInventor { get; set; }
        public string NamaBarang { get; set; }
        public Guid IDUOM { get; set; }
        public float SaldoAwal { get; set; }
        public float QtyMasuk { get; set; }
        public float QtyKeluar { get; set; }
        public float SaldoAkhir { get { return SaldoAwal + QtyMasuk - QtyKeluar; } }
        public double? QtyMin { get; set; }
        public double? QtyMax { get; set; }
    }
}
