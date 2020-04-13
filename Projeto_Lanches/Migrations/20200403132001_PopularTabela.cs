using Microsoft.EntityFrameworkCore.Migrations;

namespace Projeto_Lanches.Migrations
{
    public partial class PopularTabela : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Categories (CateoryName, Description) VALUES('Normal', 'Lanche feito com ingredientes normais')");
            migrationBuilder.Sql("INSERT INTO Categories (CateoryName, Description) VALUES('Natural', 'Lanche feito com ingredientes integrais e naturais')");
            
            migrationBuilder.Sql("INSERT INTO Snacks (CategoryId, Name, DescriptionShort, DescriptionDetailed, Price, ImageURL,ImageThumbnaiURL, Preferred, InStock) VALUES(SELECT Id from Categories where CategoryName='Normal','Egg-Burger','Pão, Hamburger, ovo, presunto, queijo e batata palha','Delicioso pão de hambúrger com ovo frito; presunto e queijo de primeira qualidade acompanhado com batata palha','10.00','http://www.macoratti.net/Imagens/lanches/cheesesalada1.jpg','http://www.macoratti.net/Imagens/lanches/cheesesalada1.jpg','1','1')");
            migrationBuilder.Sql("INSERT INTO Snacks (CategoryId, Name, DescriptionShort, DescriptionDetailed, Price, ImageURL,ImageThumbnaiURL, Preferred, InStock) VALUES(SELECT Id from Categories where CategoryName='Normal','Misto Quente','Pão, presunto, mussarela e tomate','Delicioso pão francês quentinho na chapa com presunto e mussarela bem servidos com tomate preparado com carinho.','5.00','http://www.macoratti.net/Imagens/lanches/mistoquente4.jpg','http://www.macoratti.net/Imagens/lanches/mistoquente4.jpg','1','1')");
            migrationBuilder.Sql("INSERT INTO Snacks (CategoryId, Name, DescriptionShort, DescriptionDetailed, Price, ImageURL,ImageThumbnaiURL, Preferred, InStock) VALUES(SELECT Id from Categories where CategoryName='Normal','Burguer','Pão, Hamburger, presunto, mussarela e batata palha','Pão de hambúrger especial com hambúrger de nossa preparação e presunto e mussarela; acompanha batata palha','8.00','http://www.macoratti.net/Imagens/lanches/cheeseburger1.jpg','http://www.macoratti.net/Imagens/lanches/cheeseburger1.jpg','0','1')");
            migrationBuilder.Sql("INSERT INTO Snacks (CategoryId, Name, DescriptionShort, DescriptionDetailed, Price, ImageURL,ImageThumbnaiURL, Preferred, InStock) VALUES(SELECT Id from Categories where CategoryName='Natural','Peito de Peru','Pão Integral, queijo branco, peito de peru, cenoura, alface, iogurte','Pão integral natural com queijo branco, peito de peru e cenoura ralada com alface picado e iorgurte natural.','15.00','http://www.macoratti.net/Imagens/lanches/lanchenatural.jpg','http://www.macoratti.net/Imagens/lanches/lanchenatural.jpg','1','1')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Category");
            migrationBuilder.Sql("DELETE FROM Snack");
        }
    }
}