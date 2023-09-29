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
    [Table("TUser")]
    public partial class TUser : BaseTable
    {
        [Key]
        public Guid ID { get; set; }
        [Required]
        [StringLength(100)]
        public string UserID { get; set; }
        [Required]
        [StringLength(150)]
        public string Nama { get; set; }
        [JsonIgnore]
        [Required]
        [StringLength(100)]
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
    }
}
