using System;
using System.Collections.Generic;
using BookStoreApp.API.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;



namespace BookStorApp.API.Data;

public partial class BookStoreDbContext : IdentityDbContext<ApiUser>
{
    public BookStoreDbContext()
    {
    }

    public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Authors__3214EC079E5B80FC");

            entity.Property(e => e.Bio).HasMaxLength(250);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Books__3214EC07EE40F6E7");

            entity.HasIndex(e => e.Isbn, "UQ__Books__447D36EAB53DCA8F").IsUnique();

            entity.Property(e => e.Image).HasMaxLength(50);
            entity.Property(e => e.Isbn)
                .HasMaxLength(50)
                .HasColumnName("ISBN");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Summary).HasMaxLength(250);
            entity.Property(e => e.Title).HasMaxLength(50);

            entity.HasOne(d => d.Author).WithMany(p => p.Books)
                .HasForeignKey(d => d.AuthorId)
                .HasConstraintName("FK_Books_ToTable");
        });

        modelBuilder.Entity<IdentityRole>().HasData(
            new IdentityRole
            {
                Name = "User",
                NormalizedName = "USER",
                Id = "cb7b1fd1-881c-4959-a659-60717a771f8b"
            },


            new IdentityRole
            {
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR",
                Id = "e8f2a8db-fd51-4a5d-8bcb-d7cf56baef15"
            }
        );

        var hasher = new PasswordHasher<ApiUser>();

        modelBuilder.Entity<ApiUser>().HasData(
             new ApiUser
             {
                 Id = "dcf2b06f-6b0b-4a29-b647-f653b53ef284",
                 Email = "admin@bookstore.com",
                 NormalizedEmail = "ADMIN@BOOKSTORE.COM",
                 UserName = "admin@bookstore.com",
                 NormalizedUserName = "ADMIN@BOOKSTORE.COM",
                 FirstName = "System",
                 LastName = "Admin",
                 PasswordHash = hasher.HashPassword(null, "P@ssword1")
             },


             new ApiUser
             {
                 Id = "6e9457dc-383e-4090-9154-f813e89f8192",
                 Email = "user@bookstore.com",
                 NormalizedEmail = "USER@BOOKSTORE.COM",
                 UserName = "user@bookstore.com",
                 NormalizedUserName = "USER@BOOKSTORE.COM",
                 FirstName = "System",
                 LastName = "User",
                 PasswordHash = hasher.HashPassword(null, "P@ssword1")
             }
        );

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(
             new IdentityUserRole<string>
             {
                 RoleId = "cb7b1fd1-881c-4959-a659-60717a771f8b",
                 UserId = "6e9457dc-383e-4090-9154-f813e89f8192"
             },

             new IdentityUserRole<string>
             {
                 RoleId = "e8f2a8db-fd51-4a5d-8bcb-d7cf56baef15",
                 UserId = "dcf2b06f-6b0b-4a29-b647-f653b53ef284"
             }
        );

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
