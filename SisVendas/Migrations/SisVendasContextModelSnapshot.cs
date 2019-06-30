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
                    b.Property<int>("ItemID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProdutoId");

                    b.Property<int>("VendasId");

                    b.Property<double>("douValor");

                    b.Property<int>("intQuant");

                    b.HasKey("ItemID");

                    b.HasIndex("ProdutoId");

                    b.HasIndex("VendasId");

                    b.ToTable("ItemVendas");
                });

            modelBuilder.Entity("SisVendas.Models.Produto", b =>
                {
                    b.Property<int>("IdProd")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DepartamentoId");

                    b.Property<double>("douPreco");

                    b.Property<double>("douQuant");

                    b.Property<string>("strFoto")
                        .IsRequired();

                    b.Property<string>("strNomeProd")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<string>("strUnid")
                        .IsRequired()
                        .HasMaxLength(3);

                    b.HasKey("IdProd");

                    b.HasIndex("DepartamentoId");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("SisVendas.Models.Vendas", b =>
                {
                    b.Property<int>("IdVenda")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClienteId");

                    b.Property<int>("FormaPagtoId");

                    b.Property<string>("ListaProdutos");

                    b.Property<int?>("ProdutoIdProd");

                    b.Property<int>("Status");

                    b.Property<double>("TotalVend");

                    b.Property<int>("VendedorId");

                    b.Property<DateTime>("dtVenda");

                    b.HasKey("IdVenda");

                    b.HasIndex("ClienteId");

                    b.HasIndex("FormaPagtoId");

                    b.HasIndex("ProdutoIdProd");

                    b.HasIndex("VendedorId");

                    b.ToTable("Vendas");
                });

            modelBuilder.Entity("SisVendas.Models.Vendedor", b =>
                {
                    b.Property<int>("IdVend")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("StrNomeVend")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<double>("douSalBase");

                    b.Property<string>("strEmail")
                        .IsRequired();

                    b.HasKey("IdVend");

                    b.ToTable("Vendedor");
                });

            modelBuilder.Entity("SisVendas.Models.ItemVendas", b =>
                {
                    b.HasOne("SisVendas.Models.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SisVendas.Models.Vendas", "Vendas")
                        .WithMany()
                        .HasForeignKey("VendasId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SisVendas.Models.Produto", b =>
                {
                    b.HasOne("SisVendas.Models.Departamento", "Departamento")
                        .WithMany("Produtos")
                        .HasForeignKey("DepartamentoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SisVendas.Models.Vendas", b =>
                {
                    b.HasOne("SisVendas.Models.Cliente", "Cliente")
                        .WithMany("Vendas")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SisVendas.Models.FormaPagto", "Pagto")
                        .WithMany()
                        .HasForeignKey("FormaPagtoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SisVendas.Models.Produto")
                        .WithMany("Vendas")
                        .HasForeignKey("ProdutoIdProd");

                    b.HasOne("SisVendas.Models.Vendedor", "Vendedor")
                        .WithMany("Vendas")
                        .HasForeignKey("VendedorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
