using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E4Storage.App.Model.ViewModel
{
    public class ItemMaster : Entity.BaseTable
    {
        [Key]
        public Guid ID { get; set; }
        [MaxLength(50)]
        public string PLU { get; set; }
        [MaxLength(150)]
        public string Desc { get; set; }
        public Guid IDUOM { get; set; }
        public double Saldo { get; set; }
        public double? QtyMin { get; set; }
        public double? QtyMax { get; set; }
    }
}
