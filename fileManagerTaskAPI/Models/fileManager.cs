using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace fileManagerTaskAPI.Models
{
    public class fileManager
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [StringLength(200)]
        public string descreption { get; set; }
        [StringLength(200)]
        public string DocumentURL { get; set; }
        public string fileType { get; set; }
        [Column(Order =3,TypeName = "date")]
        public DateTime CreatationDate { get; set; }

    }
}
