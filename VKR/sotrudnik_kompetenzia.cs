using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace VKR
{
    [Table("sotrudnik_kompetenzia")]
   public class sotrudnik_kompetenzia
    {
        [Key]
        public int id_sotrudnik_kompetenzia { get; set; }
        public int id_sotrudnik { get; set; }

        public int id_kompetenzia { get; set; }

        public int ozenka_sotrudnik_kompetenzia { get; set; }

        sotrudnik sotrudnik { get; set; }

        kompetenzia kompetenzia { get; set; }
    }
}
