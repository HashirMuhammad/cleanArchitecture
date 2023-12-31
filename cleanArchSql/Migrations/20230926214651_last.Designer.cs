﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using cleanArchSql.Data;

#nullable disable

namespace cleanArchSql.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230926214651_last")]
    partial class last
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AssignedUserFormData", b =>
                {
                    b.Property<int>("AssignedUsersId")
                        .HasColumnType("int");

                    b.Property<int>("FormDataId")
                        .HasColumnType("int");

                    b.HasKey("AssignedUsersId", "FormDataId");

                    b.HasIndex("FormDataId");

                    b.ToTable("AssignedUserFormData");
                });

            modelBuilder.Entity("cleanArchSql.Models.AssignedUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FormDataId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AssignedUser");
                });

            modelBuilder.Entity("cleanArchSql.Models.FormData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Active")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PageDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PageDesignFile")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PageName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PageType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FormDatas");
                });

            modelBuilder.Entity("cleanArchSql.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AssignedUserFormData", b =>
                {
                    b.HasOne("cleanArchSql.Models.AssignedUser", null)
                        .WithMany()
                        .HasForeignKey("AssignedUsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("cleanArchSql.Models.FormData", null)
                        .WithMany()
                        .HasForeignKey("FormDataId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
