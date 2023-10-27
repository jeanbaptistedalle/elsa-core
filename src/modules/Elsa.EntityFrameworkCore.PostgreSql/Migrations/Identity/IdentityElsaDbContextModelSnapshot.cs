﻿// <auto-generated />
using Elsa.EntityFrameworkCore.Modules.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Elsa.EntityFrameworkCore.PostgreSql.Migrations.Identity
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
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Elsa.Identity.Entities.Application", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ClientId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("HashedApiKey")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("HashedApiKeySalt")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("HashedClientSecret")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("HashedClientSecretSalt")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Roles")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Roles");

                    b.Property<string>("TenantId")
                        .HasColumnType("text");

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
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Permissions")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Permissions");

                    b.Property<string>("TenantId")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasDatabaseName("IX_Role_Name");

                    b.ToTable("Roles", "Elsa");
                });

            modelBuilder.Entity("Elsa.Identity.Entities.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("HashedPassword")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("HashedPasswordSalt")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Roles")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Roles");

                    b.Property<string>("TenantId")
                        .HasColumnType("text");

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
