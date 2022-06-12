namespace VKR
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("zadacha")]
    public partial class zadacha
    {
        [Key]
        public int id_zadacha { get; set; }

        public int? id_sotrudnik { get; set; }

        [StringLength(150)]
        public string opisanie_zadacha { get; set; }

        public int? id_ispolnitel_zadacha { get; set; }


        public DateTime srok_ispolnenia_zadacha { get; set; }

        [StringLength(200)]
        public string komentarii_zadacha { get; set; }

        [StringLength(50)]
        public string status_zadacha { get; set; }

        public int? vaznost_zadacha { get; set; }

        public virtual sotrudnik sotrudnik { get; set; }

        public virtual ICollection<zadacha_kompetenzia> zadacha_kompetenzia { get; set; }

        public virtual ICollection<jurnal> jurnal { get; set; }
    }
}
