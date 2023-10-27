﻿// <auto-generated />
using Elsa.EntityFrameworkCore.Modules.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Elsa.EntityFrameworkCore.MySql.Migrations.Identity
{
    [DbContext(typeof(IdentityElsaDbContext))]
    partial class IdentityElsaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Elsa")
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Elsa.Identity.Entities.Application", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ClientId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("HashedApiKey")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("HashedApiKeySalt")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("HashedClientSecret")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("HashedClientSecretSalt")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Roles")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("Roles");

                    b.Property<string>("TenantId")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("ClientId")
                        .IsUnique()
                        .HasDatabaseName("IX_Application_ClientId");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasDatabaseName("IX_Application_Name");

                    b.ToTable("Applications", "Elsa");
                });

            modelBuilder.Entity("Elsa.Identity.Entities.Role", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Permissions")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("Permissions");

                    b.Property<string>("TenantId")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasDatabaseName("IX_Role_Name");

                    b.ToTable("Roles", "Elsa");
                });

            modelBuilder.Entity("Elsa.Identity.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("HashedPassword")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("HashedPasswordSalt")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Roles")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("Roles");

                    b.Property<string>("TenantId")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasDatabaseName("IX_User_Name");

                    b.ToTable("Users", "Elsa");
                });
#pragma warning restore 612, 618
        }
    }
}
