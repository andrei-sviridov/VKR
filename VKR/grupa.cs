namespace VKR
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("grupa")]
    public partial class grupa
    {
        [Key]
        public int id_grupa { get; set; }

        [StringLength(20)]
        public string nazvanie_grupa { get; set; }


       
       /// //////////////////////////////////////////////////////////////
       
        public virtual ICollection<kompetenzia> kompetenzia { get; set; }

        public override string ToString()
        {
            return nazvanie_grupa;
        }
    }
}
