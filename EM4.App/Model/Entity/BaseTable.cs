using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM4.App.Model.Entity
{
    public class BaseTable
    {
        public Guid IDUserEntri { get; set; }
        public DateTime? TglEntri { get; set; } = DateTime.Now;
        public Guid IDUserEdit { get; set; }
        public DateTime? TglEdit { get; set; }
        public Guid IDUserHapus { get; set; }
        public DateTime? TglHapus { get; set; }
    }
}
