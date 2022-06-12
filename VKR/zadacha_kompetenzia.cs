using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace VKR
{
    [Table("zadacha_kompetenzia")]
    public class zadacha_kompetenzia
    {
        [Key]
        public int id_zadacha_kompetenzia { get; set; }
        public int id_zadacha { get; set; }

        public int id_kompetenzia { get; set; }

        public int yroven_zadacha_kompetenzia { get; set; }

        kompetenzia kompetenzia { get; set; }

        zadacha zadacha { get; set; }
    }
}
