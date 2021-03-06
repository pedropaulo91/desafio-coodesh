// <auto-generated />
using System;
using FitnessFoods.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FitnessFoods.Infrastructure.Data.Migrations
{
    [DbContext(typeof(SqlServerContext))]
    partial class SqlServerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FitnessFoods.Domain.Entities.ImportHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Failure")
                        .HasColumnType("bit");

                    b.Property<string>("File")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("ImportHistory");
                });

            modelBuilder.Entity("FitnessFoods.Domain.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Brands")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Categories")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cities")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Created_t")
                        .HasColumnType("bigint");

                    b.Property<string>("Creator")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image_url")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Imported_t")
                        .HasColumnType("datetime2");

                    b.Property<string>("Ingredients_text")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Labels")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Last_modified_t")
                        .HasColumnType("bigint");

                    b.Property<string>("Main_category")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nutriscore_grade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Nutriscore_score")
                        .HasColumnType("int");

                    b.Property<string>("Product_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Purchase_places")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Quantity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Serving_quantity")
                        .HasColumnType("float");

                    b.Property<string>("Serving_size")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte?>("Status")
                        .HasColumnType("tinyint");

                    b.Property<string>("Stores")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Traces")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
