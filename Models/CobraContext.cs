﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WIL_Project.Models;

public partial class CobraContext : DbContext
{
    public CobraContext()
    {
    }

    public CobraContext(DbContextOptions<CobraContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<SupportTeamMember> SupportTeamMembers { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<TicketAttachment> TicketAttachments { get; set; }

    public virtual DbSet<TicketResponse> TicketResponses { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=tcp:wil.database.windows.net,1433;Initial Catalog=Cobra;Persist Security Info=False;User ID=admin2;Password=Cobra123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.AdminId).HasName("PK__Admin__719FE4E894BE1E8E");

            entity.ToTable("Admin");

            entity.Property(e => e.AdminId).HasColumnName("AdminID");
            entity.Property(e => e.AdminEmail)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Admin_Email");
            entity.Property(e => e.AdminName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Admin_Name");
        });

        modelBuilder.Entity<SupportTeamMember>(entity =>
        {
            entity.HasKey(e => e.SupportMemberId).HasName("PK__SupportT__62477E4393FE1C4B");

            entity.ToTable("SupportTeamMember");

            entity.Property(e => e.SupportMemberId).HasColumnName("SupportMemberID");
            entity.Property(e => e.SupportMemberEmail)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("SupportMember_Email");
            entity.Property(e => e.SupportMemberName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("SupportMember_Name");
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.TicketId).HasName("PK__Ticket__ED7260D971C15E7C");

            entity.ToTable("Ticket");

            entity.Property(e => e.TicketId).HasColumnName("Ticket_ID");
            entity.Property(e => e.TicketAttachmentsId).HasColumnName("Ticket_AttachmentsID");
            entity.Property(e => e.TicketBody)
                .HasColumnType("text")
                .HasColumnName("Ticket_Body");
            entity.Property(e => e.TicketCreationDate)
                .HasColumnType("date")
                .HasColumnName("Ticket_CreationDate");
            entity.Property(e => e.TicketStatus)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Ticket_Status");
            entity.Property(e => e.TicketSubject)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Ticket_Subject");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.TicketAttachments).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.TicketAttachmentsId)
                .HasConstraintName("FK__Ticket__Ticket_A__17036CC0");

            entity.HasOne(d => d.User).WithMany(p => p.Tickets)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Ticket__UserID__160F4887");
        });

        modelBuilder.Entity<TicketAttachment>(entity =>
        {
            entity.HasKey(e => e.TicketAttachmentsId).HasName("PK__TicketAt__B27E4A2138F3BD8C");

            entity.Property(e => e.TicketAttachmentsId).HasColumnName("Ticket_AttachmentsID");
            entity.Property(e => e.Attachments1)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Attachments2)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Attachments3)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TicketResponse>(entity =>
        {
            entity.HasKey(e => e.ResponseId).HasName("PK__TicketRe__B736E9545D944F03");

            entity.Property(e => e.ResponseId).HasColumnName("Response_ID");
            entity.Property(e => e.ResponseBody)
                .HasColumnType("text")
                .HasColumnName("Response_Body");
            entity.Property(e => e.ResponseSubject)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Response_Subject");
            entity.Property(e => e.TicketId).HasColumnName("Ticket_ID");

            entity.HasOne(d => d.Ticket).WithMany(p => p.TicketResponses)
                .HasForeignKey(d => d.TicketId)
                .HasConstraintName("FK__TicketRes__Ticke__19DFD96B");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCACA903C082");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.UserEmail)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("User_Email");
            entity.Property(e => e.UserFullName)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}