﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace lojaN_1Application.API.Migrations
{
    [DbContext(typeof(ClienteContext))]
    [Migration("20230528235935_Criacao banco, tabelas e vinculos")]
    partial class Criacaobancotabelasevinculos
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Models.Cliente", b =>
                {
                    b.Property<int>("CodCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("cod_cliente");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CodCliente"));

                    b.Property<int>("CodPessoa")
                        .HasColumnType("integer")
                        .HasColumnName("cod_pessoa");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("endereco");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("nome_cliente");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("senha");

                    b.HasKey("CodCliente");

                    b.HasIndex("CodPessoa")
                        .IsUnique();

                    b.ToTable("cliente");
                });

            modelBuilder.Entity("lojaN_1Application.API.Models.Entrega", b =>
                {
                    b.Property<int>("CodEntrega")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("cod_entrega");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CodEntrega"));

                    b.Property<int>("CodPedido")
                        .HasColumnType("integer")
                        .HasColumnName("cod_pedido");

                    b.Property<int>("CodStatus")
                        .HasColumnType("integer")
                        .HasColumnName("cod_status");

                    b.Property<DateTime>("DataPrevisao")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("dt_previsao");

                    b.Property<DateTime>("DataStatus")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("dt_status");

                    b.HasKey("CodEntrega");

                    b.HasIndex("CodPedido")
                        .IsUnique();

                    b.HasIndex("CodStatus")
                        .IsUnique();

                    b.ToTable("entrega");
                });

            modelBuilder.Entity("lojaN_1Application.API.Models.Funcionario", b =>
                {
                    b.Property<int>("CodFuncionario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("cod_funcionario");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CodFuncionario"));

                    b.Property<int>("CodPessoa")
                        .HasColumnType("integer")
                        .HasColumnName("cod_pessoa");

                    b.HasKey("CodFuncionario");

                    b.HasIndex("CodPessoa")
                        .IsUnique();

                    b.ToTable("funcionario");
                });

            modelBuilder.Entity("lojaN_1Application.API.Models.GrupoPermissao", b =>
                {
                    b.Property<int>("CodGrupo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("cod_grupo");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CodGrupo"));

                    b.Property<string>("DescPermissao")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("desc_permissao");

                    b.HasKey("CodGrupo");

                    b.ToTable("grupo_permissao");
                });

            modelBuilder.Entity("lojaN_1Application.API.Models.ItemPedido", b =>
                {
                    b.Property<int>("CodProduto")
                        .HasColumnType("integer")
                        .HasColumnName("cod_produto");

                    b.Property<int>("CodPedido")
                        .HasColumnType("integer")
                        .HasColumnName("cod_pedido");

                    b.Property<int>("QtdProduto")
                        .HasColumnType("integer")
                        .HasColumnName("qtd_produto");

                    b.HasKey("CodProduto", "CodPedido");

                    b.HasIndex("CodPedido")
                        .IsUnique();

                    b.HasIndex("CodProduto")
                        .IsUnique();

                    b.ToTable("item_pedido");
                });

            modelBuilder.Entity("lojaN_1Application.API.Models.Pedido", b =>
                {
                    b.Property<int>("CodPedido")
                        .HasColumnType("integer")
                        .HasColumnName("cod_pedido");

                    b.Property<int>("CodCliente")
                        .HasColumnType("integer")
                        .HasColumnName("cod_cliente");

                    b.Property<int>("CodStatus")
                        .HasColumnType("integer")
                        .HasColumnName("cod_status");

                    b.Property<DateTime>("DataPedido")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("data_pedido");

                    b.Property<DateTime>("DataStatus")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("dt_status");

                    b.Property<string>("EnderecoEntrega")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("endereco_entrega");

                    b.Property<double>("ValorTotal")
                        .HasColumnType("double precision")
                        .HasColumnName("vl_total");

                    b.HasKey("CodPedido");

                    b.HasIndex("CodCliente")
                        .IsUnique();

                    b.ToTable("pedido");
                });

            modelBuilder.Entity("lojaN_1Application.API.Models.Pessoa", b =>
                {
                    b.Property<int>("CodPessoa")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("cod_pessoa");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CodPessoa"));

                    b.Property<int>("CodGrupo")
                        .HasColumnType("integer")
                        .HasColumnName("cod_grupo");

                    b.Property<string>("NomePessoa")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("nome_pessoa");

                    b.HasKey("CodPessoa");

                    b.HasIndex("CodGrupo")
                        .IsUnique();

                    b.ToTable("pessoa");
                });

            modelBuilder.Entity("lojaN_1Application.API.Models.Produto", b =>
                {
                    b.Property<int>("CodProduto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("cod_produto");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CodProduto"));

                    b.Property<string>("Cor")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("cor");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("marca");

                    b.Property<string>("NomeProduto")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("nome_produto");

                    b.Property<double>("Preco")
                        .HasColumnType("double precision")
                        .HasColumnName("preco");

                    b.Property<int>("Tamanho")
                        .HasColumnType("integer")
                        .HasColumnName("tamanho");

                    b.HasKey("CodProduto");

                    b.ToTable("produto");
                });

            modelBuilder.Entity("lojaN_1Application.API.Models.StatusEntrega", b =>
                {
                    b.Property<int>("CodStatus")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("cod_status");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CodStatus"));

                    b.Property<string>("DescStatus")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("desc_status");

                    b.HasKey("CodStatus");

                    b.ToTable("status_entrega");
                });

            modelBuilder.Entity("lojaN_1Application.API.Models.StatusPedido", b =>
                {
                    b.Property<int>("CodStatus")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("cod_status");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CodStatus"));

                    b.Property<string>("DescStatus")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("desc_status");

                    b.HasKey("CodStatus");

                    b.ToTable("status_pedido");
                });

            modelBuilder.Entity("Models.Cliente", b =>
                {
                    b.HasOne("lojaN_1Application.API.Models.Pessoa", "Pessoa")
                        .WithOne("Cliente")
                        .HasForeignKey("Models.Cliente", "CodPessoa")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("lojaN_1Application.API.Models.Entrega", b =>
                {
                    b.HasOne("lojaN_1Application.API.Models.Pedido", "Pedido")
                        .WithOne("Entrega")
                        .HasForeignKey("lojaN_1Application.API.Models.Entrega", "CodPedido")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("lojaN_1Application.API.Models.StatusEntrega", "StatusEntrega")
                        .WithOne("Entrega")
                        .HasForeignKey("lojaN_1Application.API.Models.Entrega", "CodStatus")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Pedido");

                    b.Navigation("StatusEntrega");
                });

            modelBuilder.Entity("lojaN_1Application.API.Models.Funcionario", b =>
                {
                    b.HasOne("lojaN_1Application.API.Models.Pessoa", "Pessoa")
                        .WithOne("Funcionario")
                        .HasForeignKey("lojaN_1Application.API.Models.Funcionario", "CodPessoa")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Pessoa");
                });

            modelBuilder.Entity("lojaN_1Application.API.Models.ItemPedido", b =>
                {
                    b.HasOne("lojaN_1Application.API.Models.Pedido", "Pedido")
                        .WithOne("ItemPedido")
                        .HasForeignKey("lojaN_1Application.API.Models.ItemPedido", "CodPedido")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("lojaN_1Application.API.Models.Produto", "Produto")
                        .WithOne("ItemPedido")
                        .HasForeignKey("lojaN_1Application.API.Models.ItemPedido", "CodProduto")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Pedido");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("lojaN_1Application.API.Models.Pedido", b =>
                {
                    b.HasOne("Models.Cliente", "Cliente")
                        .WithOne("Pedido")
                        .HasForeignKey("lojaN_1Application.API.Models.Pedido", "CodCliente")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("lojaN_1Application.API.Models.StatusPedido", "StatusPedido")
                        .WithOne("Pedido")
                        .HasForeignKey("lojaN_1Application.API.Models.Pedido", "CodPedido")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("StatusPedido");
                });

            modelBuilder.Entity("lojaN_1Application.API.Models.Pessoa", b =>
                {
                    b.HasOne("lojaN_1Application.API.Models.GrupoPermissao", "GrupoPermissao")
                        .WithOne("Pessoa")
                        .HasForeignKey("lojaN_1Application.API.Models.Pessoa", "CodGrupo")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.Navigation("GrupoPermissao");
                });

            modelBuilder.Entity("Models.Cliente", b =>
                {
                    b.Navigation("Pedido")
                        .IsRequired();
                });

            modelBuilder.Entity("lojaN_1Application.API.Models.GrupoPermissao", b =>
                {
                    b.Navigation("Pessoa")
                        .IsRequired();
                });

            modelBuilder.Entity("lojaN_1Application.API.Models.Pedido", b =>
                {
                    b.Navigation("Entrega")
                        .IsRequired();

                    b.Navigation("ItemPedido")
                        .IsRequired();
                });

            modelBuilder.Entity("lojaN_1Application.API.Models.Pessoa", b =>
                {
                    b.Navigation("Cliente")
                        .IsRequired();

                    b.Navigation("Funcionario")
                        .IsRequired();
                });

            modelBuilder.Entity("lojaN_1Application.API.Models.Produto", b =>
                {
                    b.Navigation("ItemPedido")
                        .IsRequired();
                });

            modelBuilder.Entity("lojaN_1Application.API.Models.StatusEntrega", b =>
                {
                    b.Navigation("Entrega")
                        .IsRequired();
                });

            modelBuilder.Entity("lojaN_1Application.API.Models.StatusPedido", b =>
                {
                    b.Navigation("Pedido")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}