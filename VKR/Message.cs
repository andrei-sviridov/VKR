

namespace VKR
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Message")]
    public partial class Message
    {
        [Key]
        public int id_message { get; set; }

        public int? id_sotrudnik { get; set; }

        public int? id_zadacha { get; set; }

        [StringLength(200)]
        public string tekst_message { get; set; }
    }
}
