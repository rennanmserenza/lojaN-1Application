using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace lojaN_1Application.API.Migrations
{
    /// <inheritdoc />
    public partial class alteraçãonobanco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "grupo_permissao",
                columns: table => new
                {
                    cod_grupo = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    desc_permissao = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_grupo_permissao", x => x.cod_grupo);
                });

            migrationBuilder.CreateTable(
                name: "produto",
                columns: table => new
                {
                    cod_produto = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome_produto = table.Column<string>(type: "text", nullable: false),
                    marca = table.Column<string>(type: "text", nullable: false),
                    tamanho = table.Column<int>(type: "integer", nullable: false),
                    cor = table.Column<string>(type: "text", nullable: false),
                    preco = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_produto", x => x.cod_produto);
                });

            migrationBuilder.CreateTable(
                name: "status_entrega",
                columns: table => new
                {
                    cod_status = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    desc_status = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_status_entrega", x => x.cod_status);
                });

            migrationBuilder.CreateTable(
                name: "status_pedido",
                columns: table => new
                {
                    cod_status = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    desc_status = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_status_pedido", x => x.cod_status);
                });

            migrationBuilder.CreateTable(
                name: "pessoa",
                columns: table => new
                {
                    cod_pessoa = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome_pessoa = table.Column<string>(type: "text", nullable: false),
                    cod_grupo = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pessoa", x => x.cod_pessoa);
                    table.ForeignKey(
                        name: "FK_pessoa_grupo_permissao_cod_grupo",
                        column: x => x.cod_grupo,
                        principalTable: "grupo_permissao",
                        principalColumn: "cod_grupo",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "cliente",
                columns: table => new
                {
                    cod_cliente = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome_cliente = table.Column<string>(type: "text", nullable: false),
                    endereco = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    senha = table.Column<string>(type: "text", nullable: false),
                    senha_hash = table.Column<string>(type: "text", nullable: false),
                    cod_pessoa = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cliente", x => x.cod_cliente);
                    table.ForeignKey(
                        name: "FK_cliente_pessoa_cod_pessoa",
                        column: x => x.cod_pessoa,
                        principalTable: "pessoa",
                        principalColumn: "cod_pessoa",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "funcionario",
                columns: table => new
                {
                    cod_funcionario = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cod_pessoa = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_funcionario", x => x.cod_funcionario);
                    table.ForeignKey(
                        name: "FK_funcionario_pessoa_cod_pessoa",
                        column: x => x.cod_pessoa,
                        principalTable: "pessoa",
                        principalColumn: "cod_pessoa",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "pedido",
                columns: table => new
                {
                    cod_pedido = table.Column<int>(type: "integer", nullable: false),
                    data_pedido = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    endereco_entrega = table.Column<string>(type: "text", nullable: false),
                    vl_total = table.Column<double>(type: "double precision", nullable: false),
                    dt_status = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    cod_status = table.Column<int>(type: "integer", nullable: false),
                    cod_cliente = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pedido", x => x.cod_pedido);
                    table.ForeignKey(
                        name: "FK_pedido_cliente_cod_cliente",
                        column: x => x.cod_cliente,
                        principalTable: "cliente",
                        principalColumn: "cod_cliente");
                    table.ForeignKey(
                        name: "FK_pedido_status_pedido_cod_pedido",
                        column: x => x.cod_pedido,
                        principalTable: "status_pedido",
                        principalColumn: "cod_status",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "entrega",
                columns: table => new
                {
                    cod_entrega = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cod_pedido = table.Column<int>(type: "integer", nullable: false),
                    cod_status = table.Column<int>(type: "integer", nullable: false),
                    dt_previsao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    dt_status = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_entrega", x => x.cod_entrega);
                    table.ForeignKey(
                        name: "FK_entrega_pedido_cod_pedido",
                        column: x => x.cod_pedido,
                        principalTable: "pedido",
                        principalColumn: "cod_pedido",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_entrega_status_entrega_cod_status",
                        column: x => x.cod_status,
                        principalTable: "status_entrega",
                        principalColumn: "cod_status");
                });

            migrationBuilder.CreateTable(
                name: "item_pedido",
                columns: table => new
                {
                    cod_pedido = table.Column<int>(type: "integer", nullable: false),
                    cod_produto = table.Column<int>(type: "integer", nullable: false),
                    qtd_produto = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_item_pedido", x => new { x.cod_produto, x.cod_pedido });
                    table.ForeignKey(
                        name: "FK_item_pedido_pedido_cod_pedido",
                        column: x => x.cod_pedido,
                        principalTable: "pedido",
                        principalColumn: "cod_pedido");
                    table.ForeignKey(
                        name: "FK_item_pedido_produto_cod_produto",
                        column: x => x.cod_produto,
                        principalTable: "produto",
                        principalColumn: "cod_produto",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cliente_cod_pessoa",
                table: "cliente",
                column: "cod_pessoa",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_entrega_cod_pedido",
                table: "entrega",
                column: "cod_pedido",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_entrega_cod_status",
                table: "entrega",
                column: "cod_status",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_funcionario_cod_pessoa",
                table: "funcionario",
                column: "cod_pessoa",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_item_pedido_cod_pedido",
                table: "item_pedido",
                column: "cod_pedido",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_item_pedido_cod_produto",
                table: "item_pedido",
                column: "cod_produto",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_pedido_cod_cliente",
                table: "pedido",
                column: "cod_cliente",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_pessoa_cod_grupo",
                table: "pessoa",
                column: "cod_grupo",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "entrega");

            migrationBuilder.DropTable(
                name: "funcionario");

            migrationBuilder.DropTable(
                name: "item_pedido");

            migrationBuilder.DropTable(
                name: "status_entrega");

            migrationBuilder.DropTable(
                name: "pedido");

            migrationBuilder.DropTable(
                name: "produto");

            migrationBuilder.DropTable(
                name: "cliente");

            migrationBuilder.DropTable(
                name: "status_pedido");

            migrationBuilder.DropTable(
                name: "pessoa");

            migrationBuilder.DropTable(
                name: "grupo_permissao");
        }
    }
}
