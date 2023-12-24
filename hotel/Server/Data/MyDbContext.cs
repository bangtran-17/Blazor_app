using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Hotel.Shared.Models;

namespace Hotel.Server.Data;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Discount> Discounts { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<Guest> Guests { get; set; }

    public virtual DbSet<Hotel1> Hotels { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<RoomImg> RoomImgs { get; set; }

    public virtual DbSet<Roomtype> Roomtypes { get; set; }

    public virtual DbSet<Salary> Salaries { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<Servicesbooked> Servicesbookeds { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("name=DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedName] IS NOT NULL)");

            entity.Property(e => e.Name).HasMaxLength(256);
            entity.Property(e => e.NormalizedName).HasMaxLength(256);
        });

        modelBuilder.Entity<AspNetRoleClaim>(entity =>
        {
            entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

            entity.HasOne(d => d.Role).WithMany(p => p.AspNetRoleClaims).HasForeignKey(d => d.RoleId);
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

            entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedUserName] IS NOT NULL)");

            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);
            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);
            entity.Property(e => e.UserName).HasMaxLength(256);

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole",
                    r => r.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                    l => l.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId");
                        j.ToTable("AspNetUserRole");
                        j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                    });
        });

        modelBuilder.Entity<AspNetUserClaim>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserLogin>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

            entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

            entity.Property(e => e.LoginProvider).HasMaxLength(128);
            entity.Property(e => e.ProviderKey).HasMaxLength(128);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<AspNetUserToken>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

            entity.Property(e => e.LoginProvider).HasMaxLength(128);
            entity.Property(e => e.Name).HasMaxLength(128);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserTokens).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.BId).HasName("PK__BOOKING__4B26EFE62E59BE7A");

            entity.ToTable("BOOKING");

            entity.HasIndex(e => e.DId, "IX_BOOKING_D_ID");

            entity.HasIndex(e => e.EId, "IX_BOOKING_E_ID");

            entity.HasIndex(e => e.GId, "IX_BOOKING_G_ID");

            entity.HasIndex(e => e.HId, "IX_BOOKING_H_ID");

            entity.HasIndex(e => e.Rid, "IX_BOOKING_Rid");

            entity.Property(e => e.BId).HasColumnName("B_ID");
            entity.Property(e => e.BAmount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("B_Amount");
            entity.Property(e => e.BCheckingDate)
                .HasColumnType("date")
                .HasColumnName("B_CheckingDate");
            entity.Property(e => e.BCheckoutDate)
                .HasColumnType("date")
                .HasColumnName("B_CheckoutDate");
            entity.Property(e => e.BCost)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("B_Cost");
            entity.Property(e => e.BDate)
                .HasColumnType("date")
                .HasColumnName("B_DATE");
            entity.Property(e => e.BStatus)
                .HasMaxLength(50)
                .HasColumnName("B_Status");
            entity.Property(e => e.BCost)
              .HasColumnType("decimal(18, 2)")
              .HasColumnName("B_Cost");
            entity.Property(e => e.BStayDuration).HasColumnName("B_StayDuration");
            entity.Property(e => e.DId).HasColumnName("D_ID");
            entity.Property(e => e.EId).HasColumnName("E_ID");
            entity.Property(e => e.GId).HasColumnName("G_ID");
            entity.Property(e => e.HId).HasColumnName("H_ID");
            entity.Property(e => e.Rid).HasColumnName("Rid");


            entity.HasOne(d => d.DIdNavigation).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.DId)
                .HasConstraintName("FK__BOOKING__D_ID__75A278F5");

            entity.HasOne(d => d.EIdNavigation).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.EId)
                .HasConstraintName("FK__BOOKING__E_ID__73BA3083");

            entity.HasOne(d => d.GIdNavigation).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.GId)
                .HasConstraintName("FK__BOOKING__G_ID__74AE54BC");

            entity.HasOne(d => d.HIdNavigation).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.HId)
                .HasConstraintName("FK__BOOKING__H_ID__72C60C4A");

            entity.HasOne(d => d.RidNavigation).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.Rid)
                .HasConstraintName("FK__BOOKING__Rid__01142BA1");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DeId).HasName("PK__DEPARTME__F2DD468775278C67");

            entity.ToTable("DEPARTMENT");

            entity.Property(e => e.DeId).HasColumnName("DE_ID");
            entity.Property(e => e.DeDescription).HasColumnName("DE_Description");
            entity.Property(e => e.DeInitialSalary)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("DE_InitialSalary");
            entity.Property(e => e.DeName)
                .HasMaxLength(50)
                .IsUnicode(true)
                .HasColumnName("DE_Name");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(true);
        });

        modelBuilder.Entity<Discount>(entity =>
        {
            entity.HasKey(e => e.DId).HasName("PK__DISCOUNT__76B8FF7D48D2F315");

            entity.ToTable("DISCOUNT");

            entity.Property(e => e.DId)
                .ValueGeneratedOnAdd()
                .HasColumnName("D_ID");
            entity.Property(e => e.DDescription)
                .IsUnicode(true)
                .HasColumnName("D_Description");
            entity.Property(e => e.DName)
                .HasMaxLength(50)
                .IsUnicode(true)
                .HasColumnName("D_Name");
            entity.Property(e => e.DRate)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("D_Rate");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(true);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EId).HasName("PK__EMPLOYEE__D730AF543A07B3C3");

            entity.ToTable("EMPLOYEE");

            entity.Property(e => e.EId)
                .ValueGeneratedOnAdd()
                .HasColumnName("E_ID");
            entity.Property(e => e.DeId).HasColumnName("DE_ID");
            entity.Property(e => e.EAddress)
                .IsUnicode(true)
                .HasColumnName("E_Address");
            entity.Property(e => e.EContactNumber)
                .HasMaxLength(20)
                .IsUnicode(true)
                .HasColumnName("E_ContactNumber");
            entity.Property(e => e.EDesignation)
                .HasMaxLength(50)
                .IsUnicode(true)
                .HasColumnName("E_Designation");
            entity.Property(e => e.EEmail)
                .HasMaxLength(255)
                .IsUnicode(true)
                .HasColumnName("E_Email");
            entity.Property(e => e.EFirstName)
                .HasMaxLength(50)
                .IsUnicode(true)
                .HasColumnName("E_FirstName");
            entity.Property(e => e.EJoinDate)
                .HasColumnType("date")
                .HasColumnName("E_JoinDate");
            entity.Property(e => e.ELastName)
                .HasMaxLength(50)
                .IsUnicode(true)
                .HasColumnName("E_LastName");
            entity.Property(e => e.HId).HasColumnName("H_ID");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(true);

            entity.HasOne(d => d.De).WithMany(p => p.Employees)
                .HasForeignKey(d => d.DeId)
                .HasConstraintName("FK__EMPLOYEE__DE_ID__6D0D32F4");

            entity.HasOne(d => d.HIdNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.HId)
                .HasConstraintName("FK__EMPLOYEE__H_ID__6E01572D");
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.FId).HasName("PK__FEEDBACK__2C6EC7C379E7FF2F");

            entity.ToTable("FEEDBACK");

            entity.HasIndex(e => e.BId, "IX_FEEDBACK_B_ID");

            entity.HasIndex(e => e.GId, "IX_FEEDBACK_G_ID");

            entity.Property(e => e.FId).HasColumnName("F_ID");
            entity.Property(e => e.BId).HasColumnName("B_ID");
            entity.Property(e => e.FDate)
                .HasColumnType("date")
                .HasColumnName("F_Date");
            entity.Property(e => e.FDescription).HasColumnName("F_Description");
            entity.Property(e => e.FRate).HasColumnName("F_Rate");
            entity.Property(e => e.GId).HasColumnName("G_ID");
            entity.Property(e => e.Status).HasMaxLength(50);

            entity.HasOne(d => d.BIdNavigation).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.BId)
                .HasConstraintName("FK__FEEDBACK__B_ID__08B54D69");

            entity.HasOne(d => d.GIdNavigation).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.GId)
                .HasConstraintName("FK__FEEDBACK__G_ID__07C12930");
        });

        modelBuilder.Entity<Guest>(entity =>
        {
            entity.HasKey(e => e.GId).HasName("PK__GUEST__153A8ED2E509F5A5");

            entity.ToTable("GUEST");

            entity.Property(e => e.GId)
                .ValueGeneratedOnAdd()
                .HasColumnName("G_ID");
            entity.Property(e => e.GAccount)
                .HasMaxLength(255)
                .IsUnicode(true)
                .HasColumnName("G_Account");
            entity.Property(e => e.GCccd)
                .HasMaxLength(20)
                .IsUnicode(true)
                .HasColumnName("G_CCCD");
            entity.Property(e => e.GEmail)
                .HasMaxLength(255)
                .IsUnicode(true)
                .HasColumnName("G_Email");
            entity.Property(e => e.GFirstName)
                .HasMaxLength(50)
                .IsUnicode(true)
                .HasColumnName("G_FirstName");
            entity.Property(e => e.GLastName)
                .HasMaxLength(50)
                .IsUnicode(true)
                .HasColumnName("G_LastName");
            entity.Property(e => e.GSdt)
                .HasMaxLength(20)
                .IsUnicode(true)
                .HasColumnName("G_SDT");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(true);
        });

        modelBuilder.Entity<Hotel1>(entity =>
        {
            entity.HasKey(e => e.HId).HasName("PK__HOTEL__61F3893D4FB0689A");

            entity.ToTable("HOTEL");

            entity.Property(e => e.HId)
                .ValueGeneratedOnAdd()
                .HasColumnName("H_ID");
            entity.Property(e => e.HAddress)
                .IsUnicode(true)
                .HasColumnName("H_Address");
            entity.Property(e => e.HDescription)
                .IsUnicode(true)
                .HasColumnName("H_Description");
            entity.Property(e => e.HEmail)
                .HasMaxLength(255)
                .IsUnicode(true)
                .HasColumnName("H_Email");
            entity.Property(e => e.HFloorCount).HasColumnName("H_FloorCount");
            entity.Property(e => e.HName)
                .HasMaxLength(255)
                .IsUnicode(true)
                .HasColumnName("H_Name");
            entity.Property(e => e.HSdt)
                .HasMaxLength(20)
                .IsUnicode(true)
                .HasColumnName("H_SDT");
            entity.Property(e => e.HTotalRoom).HasColumnName("H_TotalRoom");
            entity.Property(e => e.HWebsite)
                .HasMaxLength(255)
                .IsUnicode(true)
                .HasColumnName("H_Website");
            entity.Property(e => e.HZip)
                .HasMaxLength(20)
                .IsUnicode(true)
                .HasColumnName("H_ZIP");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PId).HasName("PK__PAYMENT__A3420A77DE9AEC7C");

            entity.ToTable("PAYMENT");

            entity.Property(e => e.PId)
                .ValueGeneratedOnAdd()
                .HasColumnName("P_ID");
            entity.Property(e => e.BId).HasColumnName("B_ID");
            entity.Property(e => e.PAmout)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("P_Amout");
            entity.Property(e => e.PDatCoc)
                .HasColumnType("date")
                .HasColumnName("P_DatCoc");
            entity.Property(e => e.PaidDate)
               .HasColumnType("datetime")
               .HasColumnName("PaidDate");
            entity.Property(e => e.PStatus)
                .HasMaxLength(50)
                .IsUnicode(true)
                .HasColumnName("P_Status");
            entity.Property(e => e.PType)
                .HasMaxLength(50)
                .IsUnicode(true)
                .HasColumnName("P_Type");
            entity.Property(e => e.PaidDate).HasColumnType("datetime");
            entity.Property(e => e.Status).HasMaxLength(50);

            entity.HasOne(d => d.BIdNavigation).WithMany(p => p.Payments)
                .HasForeignKey(d => d.BId)
                .HasConstraintName("FK__PAYMENT__B_ID__02084FDA");
        });


        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.RId).HasName("PK__ROOM__DE152E89CDA1DB90");

            entity.ToTable("ROOM");

            entity.HasIndex(e => e.RtId, "IX_ROOM_RT_ID");

            entity.Property(e => e.RId).HasColumnName("R_ID");
            entity.Property(e => e.RAvailable)
                .HasMaxLength(10)
                .HasColumnName("R_Available");
            entity.Property(e => e.RNumber)
                .HasMaxLength(50)
                .HasColumnName("R_Number");
            entity.Property(e => e.RtId).HasColumnName("RT_ID");
            entity.Property(e => e.Status).HasMaxLength(50);

            entity.HasOne(d => d.Rt).WithMany(p => p.Rooms)
                .HasForeignKey(d => d.RtId)
                .HasConstraintName("FK__ROOM__RT_ID__68487DD7");
        });


        modelBuilder.Entity<RoomImg>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__RoomImg__3214EC076EFE77A3");

            entity.ToTable("RoomImg");

            entity.HasIndex(e => e.RoomId, "IX_RoomImg_RoomId");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ImgUrl).HasColumnName("ImgURL");

            entity.HasOne(d => d.Room).WithMany(p => p.RoomImgs)
                .HasForeignKey(d => d.RoomId)
                .HasConstraintName("FK__RoomImg__RoomId__160F4887");
        });

        modelBuilder.Entity<Roomtype>(entity =>
        {
            entity.HasKey(e => e.RtId).HasName("PK__ROOMTYPE__4056367E2D56CACE");

            entity.ToTable("ROOMTYPE");

            entity.Property(e => e.RtId).HasColumnName("RT_ID");
            entity.Property(e => e.RArea)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("R_Area");
            entity.Property(e => e.RtCost)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("RT_Cost");
            entity.Property(e => e.RtDes)
                .HasDefaultValueSql("(N'')")
                .HasColumnName("RT_DES")
            .HasColumnType("nvarchar(max)");
            entity.Property(e => e.RtDes1)
              .HasDefaultValueSql("(N'')")
              .HasColumnName("RtDes1")
          .HasColumnType("nvarchar(max)");
            entity.Property(e => e.RtName)
                .HasMaxLength(50)
                .HasDefaultValueSql("(N'')")
                .HasColumnName("RT_NAME")
             .HasColumnType("nvarchar(50)");
            entity.Property(e => e.RtSmokeFriendly)
                .HasMaxLength(10)
                .HasDefaultValueSql("(N'')")
                .HasColumnName("RT_SmokeFriendly")
             .HasColumnType("nvarchar(10)");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasDefaultValueSql("(N'')");
        });

        modelBuilder.Entity<Salary>(entity =>
        {
            entity.HasKey(e => e.SalaryId).HasName("PK__SALARY__D64E0E24600A4D58");

            entity.ToTable("SALARY");

            entity.HasIndex(e => e.EId, "IX_SALARY_E_ID");

            entity.Property(e => e.SalaryId).HasColumnName("Salary_ID");
            entity.Property(e => e.EId).HasColumnName("E_ID");
            entity.Property(e => e.Salary1)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Salary");
            entity.Property(e => e.SalaryDate)
                .HasColumnType("date")
                .HasColumnName("Salary_Date");
            entity.Property(e => e.Status).HasMaxLength(50);

            entity.HasOne(d => d.EIdNavigation).WithMany(p => p.Salaries)
                .HasForeignKey(d => d.EId)
                .HasConstraintName("FK__SALARY__E_ID__04E4BC85");
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.SId).HasName("PK__SERVICES__A3DFF16D6E06E772");

            entity.ToTable("SERVICES");

            entity.Property(e => e.SId).HasColumnName("S_ID");
            entity.Property(e => e.SCost)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("S_Cost");
            entity.Property(e => e.SDescription).HasColumnName("S_Description");
            entity.Property(e => e.SName)
                .HasMaxLength(50)
                .IsUnicode(true)
                .HasColumnName("S_Name");
            entity.Property(e => e.Status).HasMaxLength(50);
        });

        modelBuilder.Entity<Servicesbooked>(entity =>
        {
            entity.HasKey(e => new { e.SId, e.BId }).HasName("PK__SERVICES__D76D9F93DCA2E309");

            entity.ToTable("SERVICESBOOKED");

            entity.HasIndex(e => e.BId, "IX_SERVICESBOOKED_B_ID");

            entity.Property(e => e.SId).HasColumnName("S_ID");
            entity.Property(e => e.BId).HasColumnName("B_ID");
            entity.Property(e => e.Status).HasMaxLength(50);

            entity.HasOne(d => d.BIdNavigation).WithMany(p => p.Servicesbookeds)
                .HasForeignKey(d => d.BId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SERVICESBO__B_ID__7F2BE32F");

            entity.HasOne(d => d.SIdNavigation).WithMany(p => p.Servicesbookeds)
                .HasForeignKey(d => d.SId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SERVICESBO__S_ID__7E37BEF6");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
