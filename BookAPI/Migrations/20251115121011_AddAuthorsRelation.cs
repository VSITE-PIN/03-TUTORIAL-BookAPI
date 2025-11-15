using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddAuthorsRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BooksAuthors_Authors_AuthorId",
                table: "BooksAuthors");

            migrationBuilder.DropForeignKey(
                name: "FK_BooksAuthors_Books_BookId",
                table: "BooksAuthors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BooksAuthors",
                table: "BooksAuthors");

            migrationBuilder.RenameTable(
                name: "BooksAuthors",
                newName: "BookAuthors");

            migrationBuilder.RenameIndex(
                name: "IX_BooksAuthors_BookId",
                table: "BookAuthors",
                newName: "IX_BookAuthors_BookId");

            migrationBuilder.RenameIndex(
                name: "IX_BooksAuthors_AuthorId",
                table: "BookAuthors",
                newName: "IX_BookAuthors_AuthorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookAuthors",
                table: "BookAuthors",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthors_Authors_AuthorId",
                table: "BookAuthors",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthors_Books_BookId",
                table: "BookAuthors",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthors_Authors_AuthorId",
                table: "BookAuthors");

            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthors_Books_BookId",
                table: "BookAuthors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookAuthors",
                table: "BookAuthors");

            migrationBuilder.RenameTable(
                name: "BookAuthors",
                newName: "BooksAuthors");

            migrationBuilder.RenameIndex(
                name: "IX_BookAuthors_BookId",
                table: "BooksAuthors",
                newName: "IX_BooksAuthors_BookId");

            migrationBuilder.RenameIndex(
                name: "IX_BookAuthors_AuthorId",
                table: "BooksAuthors",
                newName: "IX_BooksAuthors_AuthorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BooksAuthors",
                table: "BooksAuthors",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BooksAuthors_Authors_AuthorId",
                table: "BooksAuthors",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BooksAuthors_Books_BookId",
                table: "BooksAuthors",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
