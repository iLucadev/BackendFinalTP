using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookLibrary.Migrations
{
    /// <inheritdoc />
    public partial class secondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customer_BookViewModel");

            migrationBuilder.DropColumn(
                name: "Available",
                table: "Books");

            migrationBuilder.AddColumn<bool>(
                name: "IsBorrowed",
                table: "Books",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "BookCustomers",
                columns: table => new
                {
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCustomers", x => new { x.BookId, x.CustomerId });
                    table.ForeignKey(
                        name: "FK_BookCustomers_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookCustomers_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookCustomers_CustomerId",
                table: "BookCustomers",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookCustomers");

            migrationBuilder.DropColumn(
                name: "IsBorrowed",
                table: "Books");

            migrationBuilder.AddColumn<bool>(
                name: "Available",
                table: "Books",
                type: "bit",
                maxLength: 300,
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Customer_BookViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Borrowed = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer_BookViewModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customer_BookViewModel_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Guid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Customer_BookViewModel_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customer_BookViewModel_BookId",
                table: "Customer_BookViewModel",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_BookViewModel_CustomerId",
                table: "Customer_BookViewModel",
                column: "CustomerId");
        }
    }
}
