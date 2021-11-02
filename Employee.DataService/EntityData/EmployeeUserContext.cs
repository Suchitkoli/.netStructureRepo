using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using DataService.EntityData.EntityModels;

#nullable disable

namespace DataService.EntityData
{
    public partial class EmployeeUserContext : DbContext
    {
        public EmployeeUserContext()
        {
        }

        public EmployeeUserContext(DbContextOptions<EmployeeUserContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserMessage> UserMessages { get; set; }
        public virtual DbSet<UserMessageType> UserMessageTypes { get; set; }
        public virtual DbSet<UserPersonalDetail> UserPersonalDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-G42KIK4M\\SQLEXPRESS;Database=EmployeeUser;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.HasIndex(e => e.Userid, "UQ__Employee__CBA1B256587B344D")
                    .IsUnique();

                entity.Property(e => e.Employeeid).HasColumnName("employeeid");

                entity.Property(e => e.ChangedBy).HasColumnName("changedBy");

                entity.Property(e => e.ChangedOn)
                    .HasColumnType("date")
                    .HasColumnName("changedOn");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("date")
                    .HasColumnName("createdOn");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.HasOne(d => d.User)
                    .WithOne(p => p.Employee)
                    .HasForeignKey<Employee>(d => d.Userid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Employee__userid__30F848ED");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ChangedBy).HasColumnName("changedBy");

                entity.Property(e => e.ChangedOn)
                    .HasColumnType("date")
                    .HasColumnName("changedOn");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("date")
                    .HasColumnName("createdOn");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.FirstLoggedIn)
                    .HasColumnType("date")
                    .HasColumnName("firstLoggedIn");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<UserMessage>(entity =>
            {
                entity.ToTable("UserMessage");

                entity.Property(e => e.Body)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.ChangedBy).HasColumnName("changedBy");

                entity.Property(e => e.ChangedOn)
                    .HasColumnType("date")
                    .HasColumnName("changedOn");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("date")
                    .HasColumnName("createdOn");

                entity.Property(e => e.Subject)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.UserMessages)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserMessa__TypeI__46E78A0C");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserMessages)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserMessa__UserI__45F365D3");
            });

            modelBuilder.Entity<UserMessageType>(entity =>
            {
                entity.ToTable("UserMessageType");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserPersonalDetail>(entity =>
            {
                entity.HasIndex(e => e.UserId, "UQ__UserPers__CB9A1CFEF4A09DAE")
                    .IsUnique();

                entity.Property(e => e.ChangedBy).HasColumnName("changedBy");

                entity.Property(e => e.ChangedOn)
                    .HasColumnType("date")
                    .HasColumnName("changedOn");

                entity.Property(e => e.CreatedBy).HasColumnName("createdBy");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("date")
                    .HasColumnName("createdOn");

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("dob");

                entity.Property(e => e.EmpId).HasColumnName("empId");

                entity.Property(e => e.Fname)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("fname");

                entity.Property(e => e.Lname)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("lname");

                entity.Property(e => e.Mname)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("mname");

                entity.Property(e => e.RejectedOn)
                    .HasColumnType("date")
                    .HasColumnName("rejectedOn");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.UserPersonalDetails)
                    .HasForeignKey(d => d.EmpId)
                    .HasConstraintName("FK__UserPerso__empId__36B12243");

                entity.HasOne(d => d.User)
                    .WithOne(p => p.UserPersonalDetail)
                    .HasForeignKey<UserPersonalDetail>(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__UserPerso__userI__35BCFE0A");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
