using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using NetAdmin.DataAccess;

namespace NetAdmin.DataAccess.Migrations
{
    [DbContext(typeof(NetAdminDbContext))]
    [Migration("20161219094757_add_dbConnections")]
    partial class add_dbConnections
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NetAdmin.DataAccess.DbConnection", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Host");

                    b.Property<string>("Password");

                    b.Property<int>("Port");

                    b.Property<long?>("UserId");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("DbConnections");
                });

            modelBuilder.Entity("NetAdmin.DataAccess.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<byte[]>("Password");

                    b.Property<byte[]>("Salt");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("NetAdmin.DataAccess.DbConnection", b =>
                {
                    b.HasOne("NetAdmin.DataAccess.User", "User")
                        .WithMany("DbConnections")
                        .HasForeignKey("UserId");
                });
        }
    }
}
