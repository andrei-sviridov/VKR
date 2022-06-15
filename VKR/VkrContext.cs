using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace VKR
{
    public partial class VkrContext : DbContext
    {
        public VkrContext()
            : base("name=VKR2")
        {
        }

        public virtual DbSet<kompetenzia> kompetenzia { get; set; }
        public virtual DbSet<sotrudnik> sotrudnik { get; set; }
        public virtual DbSet<zadacha> zadacha { get; set; }
        public virtual DbSet<sotrudnik_kompetenzia> sotrudnik_kompetenzia { get; set; }
        public virtual DbSet<zadacha_kompetenzia> zadacha_kompetenzia { get; set; }
        public virtual DbSet<jurnal> jurnal { get; set; }
        public virtual DbSet<grupa> grupa { get; set; }
        public virtual DbSet<Message> Message { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<kompetenzia>()
                .Property(e => e.nazvaine_kompetenzia)
                .IsUnicode(false);

            modelBuilder.Entity<kompetenzia>()
                .Property(e => e.opisanie_kompetenzia)
                .IsUnicode(false);

            modelBuilder.Entity<sotrudnik>()
                .Property(e => e.fio_sotrudnik)
                .IsUnicode(false);

            modelBuilder.Entity<sotrudnik>()
                .Property(e => e.doljnost_sotrudnik)
                .IsUnicode(false);

            modelBuilder.Entity<sotrudnik>()
                .Property(e => e.login_sotrudnik)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<sotrudnik>()
                .Property(e => e.parol_sotrudnik)
                .IsUnicode(false);

            modelBuilder.Entity<zadacha>()
                .Property(e => e.opisanie_zadacha)
                .IsUnicode(false);

            modelBuilder.Entity<zadacha>()
                .Property(e => e.komentarii_zadacha)
                .IsUnicode(false);

            modelBuilder.Entity<zadacha>()
                .Property(e => e.status_zadacha)
                .IsUnicode(false);

        }
    }
}
