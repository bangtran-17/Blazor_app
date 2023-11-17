using System;
using System.Collections.Generic;
using Hotel_Framework_Test.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Framework_Test.Server.Models;
public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Discount> Discounts { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<Guest> Guests { get; set; }

    public virtual DbSet<Hotel> Hotels { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<Roomtype> Roomtypes { get; set; }

    public virtual DbSet<Salary> Salaries { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<Servicesbooked> Servicesbookeds { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("name=DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.BId).HasName("PK__BOOKING__4B26EFE6EC1CECA1");

            entity.ToTable("BOOKING");

            entity.Property(e => e.BId)
                .ValueGeneratedNever()
                .HasColumnName("B_ID");
            entity.Property(e => e.BAmount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("B_Amount");
            entity.Property(e => e.BCheckingDate)
                .HasColumnType("date")
                .HasColumnName("B_CheckingDate");
            entity.Property(e => e.BCheckoutDate)
                .HasColumnType("date")
                .HasColumnName("B_CheckoutDate");
            entity.Property(e => e.BDate)
                .HasColumnType("date")
                .HasColumnName("B_DATE");
            entity.Property(e => e.BStatus)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("B_Status");
            entity.Property(e => e.BStayDuration).HasColumnName("B_StayDuration");
            entity.Property(e => e.DId).HasColumnName("D_ID");
            entity.Property(e => e.EId).HasColumnName("E_ID");
            entity.Property(e => e.GId).HasColumnName("G_ID");
            entity.Property(e => e.HId).HasColumnName("H_ID");

            entity.HasOne(d => d.DIdNavigation).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.DId)
                .HasConstraintName("FK__BOOKING__D_ID__160F4887");

            entity.HasOne(d => d.EIdNavigation).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.EId)
                .HasConstraintName("FK__BOOKING__E_ID__14270015");

            entity.HasOne(d => d.GIdNavigation).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.GId)
                .HasConstraintName("FK__BOOKING__G_ID__151B244E");

            entity.HasOne(d => d.HIdNavigation).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.HId)
                .HasConstraintName("FK__BOOKING__H_ID__1332DBDC");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DeId).HasName("PK__DEPARTME__F2DD46873A025AE2");

            entity.ToTable("DEPARTMENT");

            entity.Property(e => e.DeId)
                .ValueGeneratedNever()
                .HasColumnName("DE_ID");
            entity.Property(e => e.DeDescription)
                .IsUnicode(false)
                .HasColumnName("DE_Description");
            entity.Property(e => e.DeInitialSalary)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("DE_InitialSalary");
            entity.Property(e => e.DeName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DE_Name");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Discount>(entity =>
        {
            entity.HasKey(e => e.DId).HasName("PK__DISCOUNT__76B8FF7D3A14820A");

            entity.ToTable("DISCOUNT");

            entity.Property(e => e.DId)
                .ValueGeneratedNever()
                .HasColumnName("D_ID");
            entity.Property(e => e.DDescription)
                .IsUnicode(false)
                .HasColumnName("D_Description");
            entity.Property(e => e.DName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("D_Name");
            entity.Property(e => e.DRate)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("D_Rate");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EId).HasName("PK__EMPLOYEE__D730AF548A61DF08");

            entity.ToTable("EMPLOYEE");

            entity.Property(e => e.EId)
                .ValueGeneratedNever()
                .HasColumnName("E_ID");
            entity.Property(e => e.DeId).HasColumnName("DE_ID");
            entity.Property(e => e.EAddress)
                .IsUnicode(false)
                .HasColumnName("E_Address");
            entity.Property(e => e.EContactNumber)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("E_ContactNumber");
            entity.Property(e => e.EDesignation)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("E_Designation");
            entity.Property(e => e.EEmail)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("E_Email");
            entity.Property(e => e.EFirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("E_FirstName");
            entity.Property(e => e.EJoinDate)
                .HasColumnType("date")
                .HasColumnName("E_JoinDate");
            entity.Property(e => e.ELastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("E_LastName");
            entity.Property(e => e.HId).HasColumnName("H_ID");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.De).WithMany(p => p.Employees)
                .HasForeignKey(d => d.DeId)
                .HasConstraintName("FK__EMPLOYEE__DE_ID__0D7A0286");

            entity.HasOne(d => d.HIdNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.HId)
                .HasConstraintName("FK__EMPLOYEE__H_ID__0E6E26BF");
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.FId).HasName("PK__FEEDBACK__2C6EC7C3F4CC9E80");

            entity.ToTable("FEEDBACK");

            entity.Property(e => e.FId)
                .ValueGeneratedNever()
                .HasColumnName("F_ID");
            entity.Property(e => e.BId).HasColumnName("B_ID");
            entity.Property(e => e.FDate)
                .HasColumnType("date")
                .HasColumnName("F_Date");
            entity.Property(e => e.FDescription)
                .IsUnicode(false)
                .HasColumnName("F_Description");
            entity.Property(e => e.FRate).HasColumnName("F_Rate");
            entity.Property(e => e.GId).HasColumnName("G_ID");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.BIdNavigation).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.BId)
                .HasConstraintName("FK__FEEDBACK__B_ID__29221CFB");

            entity.HasOne(d => d.GIdNavigation).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.GId)
                .HasConstraintName("FK__FEEDBACK__G_ID__282DF8C2");
        });

        modelBuilder.Entity<Guest>(entity =>
        {
            entity.HasKey(e => e.GId).HasName("PK__GUEST__153A8ED277EF1584");

            entity.ToTable("GUEST");

            entity.Property(e => e.GId)
                .ValueGeneratedNever()
                .HasColumnName("G_ID");
            entity.Property(e => e.GAccount)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("G_Account");
            entity.Property(e => e.GCccd)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("G_CCCD");
            entity.Property(e => e.GEmail)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("G_Email");
            entity.Property(e => e.GFirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("G_FirstName");
            entity.Property(e => e.GLastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("G_LastName");
            entity.Property(e => e.GSdt)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("G_SDT");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Hotel>(entity =>
        {
            entity.HasKey(e => e.HId).HasName("PK__HOTEL__61F3893D5BE7E725");

            entity.ToTable("HOTEL");

            entity.Property(e => e.HId)
                .ValueGeneratedNever()
                .HasColumnName("H_ID");
            entity.Property(e => e.HAddress)
                .IsUnicode(false)
                .HasColumnName("H_Address");
            entity.Property(e => e.HDescription)
                .IsUnicode(false)
                .HasColumnName("H_Description");
            entity.Property(e => e.HEmail)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("H_Email");
            entity.Property(e => e.HFloorCount).HasColumnName("H_FloorCount");
            entity.Property(e => e.HName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("H_Name");
            entity.Property(e => e.HSdt)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("H_SDT");
            entity.Property(e => e.HTotalRoom).HasColumnName("H_TotalRoom");
            entity.Property(e => e.HWebsite)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("H_Website");
            entity.Property(e => e.HZip)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("H_ZIP");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PId).HasName("PK__PAYMENT__A3420A77C595964F");

            entity.ToTable("PAYMENT");

            entity.Property(e => e.PId)
                .ValueGeneratedNever()
                .HasColumnName("P_ID");
            entity.Property(e => e.BId).HasColumnName("B_ID");
            entity.Property(e => e.PAmout)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("P_Amout");
            entity.Property(e => e.PDatCoc)
                .HasColumnType("date")
                .HasColumnName("P_DatCoc");
            entity.Property(e => e.PStatus)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("P_Status");
            entity.Property(e => e.PType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("P_Type");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.BIdNavigation).WithMany(p => p.Payments)
                .HasForeignKey(d => d.BId)
                .HasConstraintName("FK__PAYMENT__B_ID__22751F6C");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.RId).HasName("PK__ROOM__DE152E8998372E18");

            entity.ToTable("ROOM");

            entity.Property(e => e.RId)
                .ValueGeneratedNever()
                .HasColumnName("R_ID");
            entity.Property(e => e.RAvailable)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("R_Available");
            entity.Property(e => e.RNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("R_Number");
            entity.Property(e => e.RtId).HasColumnName("RT_ID");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Rt).WithMany(p => p.Rooms)
                .HasForeignKey(d => d.RtId)
                .HasConstraintName("FK__ROOM__RT_ID__08B54D69");

            entity.HasMany(d => d.BIds).WithMany(p => p.RIds)
                .UsingEntity<Dictionary<string, object>>(
                    "Roombooked",
                    r => r.HasOne<Booking>().WithMany()
                        .HasForeignKey("BId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__ROOMBOOKED__B_ID__19DFD96B"),
                    l => l.HasOne<Room>().WithMany()
                        .HasForeignKey("RId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__ROOMBOOKED__R_ID__18EBB532"),
                    j =>
                    {
                        j.HasKey("RId", "BId").HasName("PK__ROOMBOOK__AAA74077FD1E9890");
                        j.ToTable("ROOMBOOKED");
                        j.IndexerProperty<int>("RId").HasColumnName("R_ID");
                        j.IndexerProperty<int>("BId").HasColumnName("B_ID");
                    });
        });

        modelBuilder.Entity<Roomtype>(entity =>
        {
            entity.HasKey(e => e.RtId).HasName("PK__ROOMTYPE__4056367EA9C36459");

            entity.ToTable("ROOMTYPE");

            entity.Property(e => e.RtId)
                .ValueGeneratedNever()
                .HasColumnName("RT_ID");
            entity.Property(e => e.RArea)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("R_Area");
            entity.Property(e => e.RtCost)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("RT_Cost");
            entity.Property(e => e.RtDes)
                .IsUnicode(false)
                .HasColumnName("RT_DES");
            entity.Property(e => e.RtName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("RT_NAME");
            entity.Property(e => e.RtSmokeFriendly)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("RT_SmokeFriendly");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Salary>(entity =>
        {
            entity.HasKey(e => e.SalaryId).HasName("PK__SALARY__D64E0E2435593CCF");

            entity.ToTable("SALARY");

            entity.Property(e => e.SalaryId)
                .ValueGeneratedNever()
                .HasColumnName("Salary_ID");
            entity.Property(e => e.EId).HasColumnName("E_ID");
            entity.Property(e => e.Salary1)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Salary");
            entity.Property(e => e.SalaryDate)
                .HasColumnType("date")
                .HasColumnName("Salary_Date");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.EIdNavigation).WithMany(p => p.Salaries)
                .HasForeignKey(d => d.EId)
                .HasConstraintName("FK__SALARY__E_ID__25518C17");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.SId).HasName("PK__SERVICES__A3DFF16D5838FB6B");

            entity.ToTable("SERVICES");

            entity.Property(e => e.SId)
                .ValueGeneratedNever()
                .HasColumnName("S_ID");
            entity.Property(e => e.SCost)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("S_Cost");
            entity.Property(e => e.SDescription)
                .IsUnicode(false)
                .HasColumnName("S_Description");
            entity.Property(e => e.SName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("S_Name");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Servicesbooked>(entity =>
        {
            entity.HasKey(e => new { e.SId, e.BId }).HasName("PK__SERVICES__D76D9F93AAD37B49");

            entity.ToTable("SERVICESBOOKED");

            entity.Property(e => e.SId).HasColumnName("S_ID");
            entity.Property(e => e.BId).HasColumnName("B_ID");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.BIdNavigation).WithMany(p => p.Servicesbookeds)
                .HasForeignKey(d => d.BId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SERVICESBO__B_ID__1F98B2C1");

            entity.HasOne(d => d.SIdNavigation).WithMany(p => p.Servicesbookeds)
                .HasForeignKey(d => d.SId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SERVICESBO__S_ID__1EA48E88");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
