﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Shop.Data;

namespace Shop.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.10");

            modelBuilder.Entity("Shop.Models.Category", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("descricao")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("character varying(60)");

                    b.HasKey("id");

                    b.ToTable("categoria");
                });

            modelBuilder.Entity("Shop.Models.Order", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<int>("idPessoa")
                        .HasColumnType("integer");

                    b.Property<int>("idVendedor")
                        .HasColumnType("integer");

                    b.Property<decimal>("total")
                        .HasColumnType("numeric");

                    b.HasKey("id");

                    b.ToTable("pedido");
                });

            modelBuilder.Entity("Shop.Models.OrderItem", b =>
                {
                    b.Property<int>("idPedido")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<int?>("Orderid")
                        .HasColumnType("integer");

                    b.Property<int>("idProduto")
                        .HasColumnType("integer");

                    b.Property<int>("qtd")
                        .HasColumnType("integer");

                    b.Property<decimal>("total")
                        .HasColumnType("numeric");

                    b.Property<decimal>("unitario")
                        .HasColumnType("numeric");

                    b.HasKey("idPedido");

                    b.HasIndex("Orderid");

                    b.ToTable("pedido_item");
                });

            modelBuilder.Entity("Shop.Models.People", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("cgc")
                        .HasMaxLength(18)
                        .HasColumnType("character varying(18)");

                    b.Property<string>("nome")
                        .HasColumnType("text");

                    b.Property<int>("tipo")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.ToTable("pessoa");
                });

            modelBuilder.Entity("Shop.Models.Product", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<int>("categoriaid")
                        .HasColumnType("integer");

                    b.Property<string>("descricao")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("character varying(60)");

                    b.Property<decimal>("preco")
                        .HasColumnType("numeric");

                    b.Property<int>("quantidade")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.ToTable("produto");
                });

            modelBuilder.Entity("Shop.Models.OrderItem", b =>
                {
                    b.HasOne("Shop.Models.Order", null)
                        .WithMany("orderItem")
                        .HasForeignKey("Orderid");
                });

            modelBuilder.Entity("Shop.Models.Order", b =>
                {
                    b.Navigation("orderItem");
                });
#pragma warning restore 612, 618
        }
    }
}
