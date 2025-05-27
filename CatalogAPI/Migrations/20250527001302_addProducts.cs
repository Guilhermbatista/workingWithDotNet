using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CatalogAPI.Migrations
{
    /// <inheritdoc />
    public partial class addProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO Products (name, description, price, ImgURL, stock, dateRegister, categoryId) " +
                     "VALUES ('Hamburguer Artesanal', 'Pao brioche, hamburguer bovino 180g', 22.90, 'https://exemplo.com/imagens/hamburguer-artesanal.jpg', 30, NOW(), 2)");

            mb.Sql("INSERT INTO Products (name, description, price, ImgURL, stock, dateRegister, categoryId) " +
                   "VALUES ('Brownie com Sorvete', 'Brownie de chocolate meio amargo', 14.00, 'https://exemplo.com/imagens/brownie-sorvete.jpg', 20, NOW(), 3)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE FROM Products");

        }
    }
}
