using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MyGraphQLs.Models
{
    public partial class BookShellContext : DbContext
    {

        public BookShellContext(DbContextOptions<BookShellContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<PermissionDetail> PermissionDetails { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserPermission> UserPermissions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("Book");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AuthenId).HasColumnName("authen_id");

                entity.Property(e => e.BookAuthor).HasMaxLength(100);

                entity.Property(e => e.BookName).HasMaxLength(100);

                entity.Property(e => e.Img)
                    .HasMaxLength(4000)
                    .HasColumnName("img");

                entity.HasOne(d => d.Authen)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.AuthenId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Books_Users");
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.ToTable("Permission");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.NamePermission)
                    .HasMaxLength(50)
                    .HasColumnName("name_permission");
            });

            modelBuilder.Entity<PermissionDetail>(entity =>
            {
                entity.ToTable("PermissionDetail");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdPermission).HasColumnName("id_permission");

                entity.HasOne(d => d.IdPermissionNavigation)
                    .WithMany(p => p.PermissionDetails)
                    .HasForeignKey(d => d.IdPermission)
                    .HasConstraintName("FK_PermissionDetail_Permission");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Displayname)
                    .HasMaxLength(50)
                    .HasColumnName("displayname");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .HasColumnName("password")
                    .UseCollation("Latin1_General_BIN2");

                entity.Property(e => e.Token)
                    .HasMaxLength(4000)
                    .HasColumnName("token");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<UserPermission>(entity =>
            {
                entity.ToTable("UserPermission");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdPermission).HasColumnName("id_permission");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.HasOne(d => d.IdPermissionNavigation)
                    .WithMany(p => p.UserPermissions)
                    .HasForeignKey(d => d.IdPermission)
                    .HasConstraintName("FK_UserPermission_Permission");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.UserPermissions)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK_UserPermission_User");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
