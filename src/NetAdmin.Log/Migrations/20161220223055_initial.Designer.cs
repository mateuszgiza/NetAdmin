using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using NetAdmin.Log.Contexts;
using NetAdmin.Log;

namespace NetAdmin.Log.Migrations
{
    [DbContext(typeof(LogDbContext))]
    [Migration("20161220223055_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NetAdmin.Log.Log", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("LogObject");

                    b.Property<byte>("Type");

                    b.HasKey("Id");

                    b.ToTable("Logs");
                });
        }
    }
}
