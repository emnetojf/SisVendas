﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SisVendas.Models;

namespace SisVendas.Migrations
{
    [DbContext(typeof(SisVendasContext))]
    partial class SisVendasContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SisVendas.Models.Cliente", b =>
                {
                    b.Property<int>("IdCli")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DtNasc");

                    b.Property<int>("Sexo");

                    b.Property<int>("UF");

                    b.Property<string>("strNomeCli")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.HasKey("IdCli");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("SisVendas.Models.Departamento", b =>
                {
                    b.Property<int>("IdDepto")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("strDepto")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("IdDepto");

                    b.ToTable("Departamentos");
                });

            modelBuilder.Entity("SisVendas.Models.FormaPagto", b =>
                {
                    b.Property<int>("IdPagto")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("strPagto")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("IdPagto");

                    b.ToTable("FormaPagtos");
                });

            modelBuilder.Entity("SisVendas.Models.ItemVendas", b =>
                {
                    b.Property<int>("ItemVendasID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProdId");

                    b.Property<int?>("ProdId");

                    b.Property<int>("VendasId");

                    b.Property<double>("douValor");

                    b.Property<int>("intQuant");

                    b.HasKey("ItemVendasID");

                    b.HasIndex("ProdId");

                    b.HasIndex("VendasId");

                    b.ToTable("ItemVendas");
                });

            modelBuilder.Entity("SisVendas.Models.Produto", b =>
                {
                    b.Property<int>("IdProd")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("douPreco");

                    b.Property<string>("strNomeProd")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.HasKey("IdProd");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("SisVendas.Models.Vendas", b =>
                {
                    b.Property<int>("IdVenda")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClienteId");

                    b.Property<int>("PagtoId");

                    b.Property<int>("Status");

                    b.Property<int>("VendedorId");

                    b.Property<DateTime>("dtVenda");

                    b.HasKey("IdVenda");

                    b.HasIndex("ClienteId");

                    b.HasIndex("PagtoId");

                    b.HasIndex("VendedorId");

                    b.ToTable("Vendas");
                });

            modelBuilder.Entity("SisVendas.Models.Vendedor", b =>
                {
                    b.Property<int>("IdVend")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DeptoId");

                    b.Property<double>("douSalBase");

                    b.Property<string>("strEmail")
                        .IsRequired();

                    b.Property<string>("strNomeVend")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.HasKey("IdVend");

                    b.HasIndex("DeptoId");

                    b.ToTable("Vendedor");
                });

            modelBuilder.Entity("SisVendas.Models.ItemVendas", b =>
                {
                    b.HasOne("SisVendas.Models.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdId");

                    b.HasOne("SisVendas.Models.Vendas", "Vendas")
                        .WithMany()
                        .HasForeignKey("VendasId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SisVendas.Models.Vendas", b =>
                {
                    b.HasOne("SisVendas.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SisVendas.Models.FormaPagto", "Pagto")
                        .WithMany()
                        .HasForeignKey("PagtoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SisVendas.Models.Vendedor", "Vendedor")
                        .WithMany()
                        .HasForeignKey("VendedorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SisVendas.Models.Vendedor", b =>
                {
                    b.HasOne("SisVendas.Models.Departamento", "Depto")
                        .WithMany()
                        .HasForeignKey("DeptoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
