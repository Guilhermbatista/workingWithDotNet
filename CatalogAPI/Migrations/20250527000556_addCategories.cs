using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CatalogAPI.Migrations
{
    /// <inheritdoc />
    public partial class addCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO categories (name, imgURL) VALUES ('Bebidas', 'Bebidas.jpg')");
            mb.Sql("INSERT INTO categories (name, imgURL) VALUES ('Lanches', 'Lanches.jpg')");
            mb.Sql("INSERT INTO categories (name, imgURL) VALUES ('Sobremesas', 'Sobremesas.jpg')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE FROM categories");
        }
    }
}
