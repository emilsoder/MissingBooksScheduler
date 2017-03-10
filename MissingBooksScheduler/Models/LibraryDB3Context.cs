using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MissingBooksScheduler.Models
{
    public partial class LibraryDB3Context : DbContext
    {
        public virtual DbSet<Books> Books { get; set; }
        public virtual DbSet<BorrowedBooks> BorrowedBooks { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Courses> Courses { get; set; }
        public virtual DbSet<MissingBooks> MissingBooks { get; set; }
        public virtual DbSet<RoleClaim> RoleClaim { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Students> Students { get; set; }
        public virtual DbSet<UserClaims> UserClaims { get; set; }
        public virtual DbSet<UserLogin> UserLogin { get; set; }
        public virtual DbSet<UserRoles> UserRoles { get; set; }
        public virtual DbSet<UserTokens> UserTokens { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=EMILSERVER;Initial Catalog=LibraryDB3;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Books>(entity =>
            {
                entity.HasKey(e => e.BookId)
                    .HasName("PK_BookID");

                entity.Property(e => e.BookId).HasColumnName("BookID");

                entity.Property(e => e.BookName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Isbn)
                    .IsRequired()
                    .HasColumnName("ISBN")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<BorrowedBooks>(entity =>
            {
                entity.HasIndex(e => e.BookId)
                    .HasName("IX_BorrowedBooks_BookID");

                entity.HasIndex(e => e.StudentId)
                    .HasName("IX_BorrowedBooks_StudentID");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BookId).HasColumnName("BookID");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.BorrowedBooks)
                    .HasForeignKey(d => d.BookId)
                    .HasConstraintName("FK_BorrowedBoks_BookID");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.BorrowedBooks)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Categories>(entity =>
            {
                entity.Property(e => e.CategoryName).HasMaxLength(50);
            });

            modelBuilder.Entity<Courses>(entity =>
            {
                entity.HasKey(e => e.CourseId)
                    .HasName("PK_CourseID");

                entity.Property(e => e.CourseId).HasColumnName("CourseID");

                entity.Property(e => e.CourseName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<MissingBooks>(entity =>
            {
                entity.HasIndex(e => e.BookId)
                    .HasName("IX_MissingBooks_BookID");

                entity.HasIndex(e => e.BorrowedBookId)
                    .HasName("IX_MissingBooks_BorrowedBookID");

                entity.HasIndex(e => e.StudentId)
                    .HasName("IX_MissingBooks_StudentID");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BookId).HasColumnName("BookID");

                entity.Property(e => e.BorrowedBookId).HasColumnName("BorrowedBookID");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.MissingBooks)
                    .HasForeignKey(d => d.BookId)
                    .HasConstraintName("FK_MissingBooks_BookID");

                entity.HasOne(d => d.BorrowedBook)
                    .WithMany(p => p.MissingBooks)
                    .HasForeignKey(d => d.BorrowedBookId)
                    .HasConstraintName("FK_MissingBooks_BorrowedBookID");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.MissingBooks)
                    .HasForeignKey(d => d.StudentId);
            });

            modelBuilder.Entity<RoleClaim>(entity =>
            {
                entity.HasIndex(e => e.IdentityRoleStringId)
                    .HasName("IX_RoleClaim_IdentityRole<string>Id");

                entity.Property(e => e.IdentityRoleStringId)
                    .HasColumnName("IdentityRole<string>Id")
                    .HasMaxLength(450);

                entity.HasOne(d => d.IdentityRoleString)
                    .WithMany(p => p.RoleClaim)
                    .HasForeignKey(d => d.IdentityRoleStringId);
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.Property(e => e.Id).HasMaxLength(450);
            });

            modelBuilder.Entity<Students>(entity =>
            {
                entity.HasKey(e => e.StudentId)
                    .HasName("PK_StudentID");

                entity.HasIndex(e => e.CourseId)
                    .HasName("IX_Students_CourseID");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.CourseId).HasColumnName("CourseID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK_Students_CourseID");
            });

            modelBuilder.Entity<UserClaims>(entity =>
            {
                entity.HasIndex(e => e.ApplicationUserId)
                    .HasName("IX_UserClaims_ApplicationUserId");

                entity.Property(e => e.ApplicationUserId).HasMaxLength(450);

                entity.HasOne(d => d.ApplicationUser)
                    .WithMany(p => p.UserClaims)
                    .HasForeignKey(d => d.ApplicationUserId);
            });

            modelBuilder.Entity<UserLogin>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK_UserLogin");

                entity.HasIndex(e => e.ApplicationUserId)
                    .HasName("IX_UserLogin_ApplicationUserId");

                entity.Property(e => e.UserId).HasMaxLength(450);

                entity.Property(e => e.ApplicationUserId).HasMaxLength(450);

                entity.HasOne(d => d.ApplicationUser)
                    .WithMany(p => p.UserLogin)
                    .HasForeignKey(d => d.ApplicationUserId);
            });

            modelBuilder.Entity<UserRoles>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PK_UserRoles");

                entity.HasIndex(e => e.ApplicationUserId)
                    .HasName("IX_UserRoles_ApplicationUserId");

                entity.HasIndex(e => e.IdentityRoleStringId)
                    .HasName("IX_UserRoles_IdentityRole<string>Id");

                entity.Property(e => e.RoleId).HasMaxLength(450);

                entity.Property(e => e.ApplicationUserId).HasMaxLength(450);

                entity.Property(e => e.IdentityRoleStringId)
                    .HasColumnName("IdentityRole<string>Id")
                    .HasMaxLength(450);

                entity.HasOne(d => d.ApplicationUser)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.ApplicationUserId);

                entity.HasOne(d => d.IdentityRoleString)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.IdentityRoleStringId);
            });

            modelBuilder.Entity<UserTokens>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK_UserTokens");

                entity.Property(e => e.UserId).HasMaxLength(450);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.Id).HasMaxLength(450);
            });
        }
    }
}