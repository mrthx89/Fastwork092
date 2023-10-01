using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM4.App.Model.ViewModel
{
    public class ItemLookUp
    {
        [Key]
        public Guid ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string PLU { get; set; }
        [Required]
        [MaxLength(150)]
        public string Desc { get; set; }
        [Required]
        public Guid IDUOM { get; set; }
        public string Satuan { get; set; }
        public double Saldo { get; set; }
    }
}
