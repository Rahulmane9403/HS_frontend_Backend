using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HomeServiceApp.Models
{
    public partial class HomeServiceDBContext : DbContext
    {
        public HomeServiceDBContext()
        {
        }

        public HomeServiceDBContext(DbContextOptions<HomeServiceDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Booking> Bookings { get; set; } = null!;
        public virtual DbSet<Feedback> Feedbacks { get; set; } = null!;
        public virtual DbSet<Payment> Payments { get; set; } = null!;
        public virtual DbSet<Support> Supports { get; set; } = null!;
        public virtual DbSet<SystemAdministration> SystemAdministrations { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Worker> Workers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-9KVL7AU9\\SQLEXPRESS;Database=HomeServiceDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.ToTable("bookings", "homeservice");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.JobDetails)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("job_details");

                entity.Property(e => e.Location)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("location");

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("price");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.Property(e => e.Time)
                    .HasColumnType("datetime")
                    .HasColumnName("time");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.WorkerId).HasColumnName("worker_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__bookings__user_i__5070F446");

                entity.HasOne(d => d.Worker)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.WorkerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__bookings__worker__5165187F");
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.ToTable("feedbacks", "homeservice");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BookingId).HasColumnName("booking_id");

                entity.Property(e => e.Rating)
                    .HasColumnType("decimal(2, 1)")
                    .HasColumnName("rating");

                entity.Property(e => e.Review)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("review");

                entity.Property(e => e.Time)
                    .HasColumnType("datetime")
                    .HasColumnName("time")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.BookingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__feedbacks__booki__5629CD9C");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("payments", "homeservice");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Amount)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("amount");

                entity.Property(e => e.BookingId).HasColumnName("booking_id");

                entity.Property(e => e.PaymentMethod)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("payment_method");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.Property(e => e.Time)
                    .HasColumnType("datetime")
                    .HasColumnName("time");

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.BookingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__payments__bookin__59063A47");
            });

            modelBuilder.Entity<Support>(entity =>
            {
                entity.ToTable("supports", "homeservice");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BookingId).HasColumnName("booking_id");

                entity.Property(e => e.IssueDescription)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("issue_description");

                entity.Property(e => e.Resolution)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("resolution");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.WorkerId).HasColumnName("worker_id");

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.Supports)
                    .HasForeignKey(d => d.BookingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__supports__bookin__5DCAEF64");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Supports)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__supports__user_i__5BE2A6F2");

                entity.HasOne(d => d.Worker)
                    .WithMany(p => p.Supports)
                    .HasForeignKey(d => d.WorkerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__supports__worker__5CD6CB2B");
            });

            modelBuilder.Entity<SystemAdministration>(entity =>
            {
                entity.ToTable("system_administration", "homeservice");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ActionDescription)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("action_description");

                entity.Property(e => e.ActionTime)
                    .HasColumnType("datetime")
                    .HasColumnName("action_time")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ActionType)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("action_type");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.WorkerId).HasColumnName("worker_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.SystemAdministrations)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__system_ad__user___619B8048");

                entity.HasOne(d => d.Worker)
                    .WithMany(p => p.SystemAdministrations)
                    .HasForeignKey(d => d.WorkerId)
                    .HasConstraintName("FK__system_ad__worke__628FA481");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users", "homeservice");

                entity.HasIndex(e => e.Email, "UC_Email")
                    .IsUnique();

                entity.HasIndex(e => e.Phone, "UC_Phone")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasColumnType("text")
                    .HasColumnName("address");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Phone)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("phone");

                entity.Property(e => e.Preferences)
                    .HasColumnType("text")
                    .HasColumnName("preferences");
            });

            modelBuilder.Entity<Worker>(entity =>
            {
                entity.ToTable("workers", "homeservice");

                entity.HasIndex(e => e.Mobile, "UC_Mobile")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Availability)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("availability");

                entity.Property(e => e.Experience)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("experience");

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("gender");

                entity.Property(e => e.IdentityProof).HasColumnName("identity_proof");

                entity.Property(e => e.Languages)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("languages");

                entity.Property(e => e.Mobile)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("mobile");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Photo).HasColumnName("photo");

                entity.Property(e => e.Ratings)
                    .HasColumnType("decimal(2, 1)")
                    .HasColumnName("ratings");

                entity.Property(e => e.Skills)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("skills");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
