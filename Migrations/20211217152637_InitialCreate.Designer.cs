// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Shop.Data;

namespace Shop.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20211217152637_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Shop.Models.Categoria", b =>
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

            modelBuilder.Entity("Shop.Models.Cliente", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("cgc")
                        .IsRequired()
                        .HasMaxLength(18)
                        .HasColumnType("character varying(18)");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("id");

                    b.ToTable("cliente");
                });

            modelBuilder.Entity("Shop.Models.Pedido", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<int>("clienteId")
                        .HasColumnType("integer")
                        .HasColumnName("cliente_id");

                    b.Property<decimal>("total")
                        .HasColumnType("numeric");

                    b.Property<int>("vendedorId")
                        .HasColumnType("integer")
                        .HasColumnName("vendedor_id");

                    b.HasKey("id");

                    b.HasIndex("clienteId");

                    b.HasIndex("vendedorId");

                    b.ToTable("pedido");
                });

            modelBuilder.Entity("Shop.Models.PedidoItem", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<int>("pedidoId")
                        .HasColumnType("integer")
                        .HasColumnName("pedido_id");

                    b.Property<int>("produtoId")
                        .HasColumnType("integer")
                        .HasColumnName("produto_id");

                    b.Property<int>("qtd")
                        .HasColumnType("integer");

                    b.Property<decimal>("total")
                        .HasColumnType("numeric");

                    b.Property<decimal>("unitario")
                        .HasColumnType("numeric");

                    b.HasKey("id");

                    b.HasIndex("pedidoId");

                    b.HasIndex("produtoId");

                    b.ToTable("pedido_item");
                });

            modelBuilder.Entity("Shop.Models.Produto", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<int>("categoriaId")
                        .HasColumnType("integer")
                        .HasColumnName("categoria_id");

                    b.Property<string>("descricao")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("character varying(60)");

                    b.Property<decimal>("preco")
                        .HasColumnType("numeric");

                    b.Property<int>("quantidade")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.HasIndex("categoriaId");

                    b.ToTable("produto");
                });

            modelBuilder.Entity("Shop.Models.Vendedor", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("cgc")
                        .IsRequired()
                        .HasMaxLength(18)
                        .HasColumnType("character varying(18)");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("id");

                    b.ToTable("vendedor");
                });

            modelBuilder.Entity("Shop.Models.Pedido", b =>
                {
                    b.HasOne("Shop.Models.Cliente", "cliente")
                        .WithMany()
                        .HasForeignKey("clienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shop.Models.Vendedor", "vendedor")
                        .WithMany()
                        .HasForeignKey("vendedorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("cliente");

                    b.Navigation("vendedor");
                });

            modelBuilder.Entity("Shop.Models.PedidoItem", b =>
                {
                    b.HasOne("Shop.Models.Pedido", "pedido")
                        .WithMany("pedidoItems")
                        .HasForeignKey("pedidoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shop.Models.Produto", "produto")
                        .WithMany()
                        .HasForeignKey("produtoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("pedido");

                    b.Navigation("produto");
                });

            modelBuilder.Entity("Shop.Models.Produto", b =>
                {
                    b.HasOne("Shop.Models.Categoria", "categoria")
                        .WithMany()
                        .HasForeignKey("categoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("categoria");
                });

            modelBuilder.Entity("Shop.Models.Pedido", b =>
                {
                    b.Navigation("pedidoItems");
                });
#pragma warning restore 612, 618
        }
    }
}
