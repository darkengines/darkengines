using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using DarkEngines.Server.Forex;

namespace DarkEngines.Server.Migrations
{
    [DbContext(typeof(ForexDbContext))]
    partial class ForexDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431");

            modelBuilder.Entity("DarkEngines.Server.Forex.Currency", b =>
                {
                    b.Property<int>("CurrencyId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code");

                    b.Property<int>("DecimalDigits");

                    b.Property<string>("Name");

                    b.Property<string>("NamePlural");

                    b.Property<string>("Symbol");

                    b.Property<string>("SymbolNative");

                    b.HasKey("CurrencyId");

                    b.ToTable("Currencies");
                });
        }
    }
}
