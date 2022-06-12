namespace VKR
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("kompetenzia")]
    public partial class kompetenzia
    {
        [Key]
        public int id_kompetenzia { get; set; }

        public int id_grupa { get; set; }

        [StringLength(50)]
        public string nazvaine_kompetenzia { get; set; }

        [StringLength(150)]
        public string opisanie_kompetenzia { get; set; }

        public virtual ICollection<sotrudnik_kompetenzia> sotrudnik_kompetenzia { get; set; }

        public virtual ICollection<zadacha_kompetenzia> zadacha_kompetenzia { get; set; }

        public virtual grupa grupa { get; set; }

        public override string ToString()
        {
            return nazvaine_kompetenzia;
        }
    }
}
