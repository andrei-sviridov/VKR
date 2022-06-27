namespace VKR
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("jurnal")]
    public partial class jurnal
    {
        [Key]
        public int id_jurnal { get; set; }

        public int? id_zadacha { get; set; }

        public DateTime data_jurnal { get; set; }

        [StringLength(20)]
        public string old_jurnal { get; set; }

        [StringLength(20)]
        public string new_jurnal { get; set; }

        public int? id_sotrudnik { get; set; }
        /// <summary>
        /// ////////////////////////////////////////////////////////////////
        /// </summary>
        public virtual zadacha zadacha { get; set; }

        public virtual sotrudnik sotrudnik { get; set; }

    }
}
