namespace VKR
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("sotrudnik")]
    public partial class sotrudnik
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public sotrudnik()
        {
            zadacha = new HashSet<zadacha>();
        }

        [StringLength(50)]
        public string fio_sotrudnik { get; set; }

        [StringLength(30)]
        public string doljnost_sotrudnik { get; set; }

        [Key]
        public int id_sotrudnik { get; set; }

        [StringLength(20)]
        public string login_sotrudnik { get; set; }

        [StringLength(20)]
        public string parol_sotrudnik { get; set; }

        public int? rukovoditel_sotrudnik { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<zadacha> zadacha { get; set; }

        public virtual ICollection<sotrudnik_kompetenzia> sotrudnik_kompetenzia { get; set; }

        public override string ToString()
        {
            return fio_sotrudnik;
        }
    }
}
