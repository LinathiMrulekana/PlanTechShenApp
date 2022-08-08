using Microsoft.EntityFrameworkCore.Migrations;

namespace PlanTechShenWebApi.migrations
{
    public partial class Mitigation1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authentication",
                columns: table => new
                {
                    AuthenticationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastLoginTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Enabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authentication", x => x.AuthenticationId);
                });

            migrationBuilder.CreateTable(
               name: "Client",
               columns: table => new
               {
                   UserId = table.Column<int>(type: "int", nullable: false)
                       .Annotation("SqlServer:Identity", "1, 1"),
                   FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   CellPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   AuthenticationId = table.Column<int>(type: "int", nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Client", x => x.UserId);
                   table.ForeignKey(
                       name: "FK_Client_Authentication_AuthenticationId",
                       column: x => x.AuthenticationId,
                       principalTable: "Authentication",
                       principalColumn: "AuthenticationId",
                       onDelete: ReferentialAction.Cascade);
               });
            migrationBuilder.CreateTable(
name: "UserAccount",
columns: table => new
{
    UserAccountId = table.Column<int>(type: "int", nullable: false)
        .Annotation("SqlServer:Identity", "1, 1"),
   
    UserId = table.Column<int>(type: "int", nullable: false),
    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
   
},
constraints: table =>
{
    
    table.ForeignKey(
        name: "FK_UserAccount_Client_uUserId",
        column: x => x.UserId,
        principalTable: "Client",
        principalColumn: "UserId",
        onDelete: ReferentialAction.Cascade);
});
            migrationBuilder.CreateIndex(
                           name: "IX_UserAccount_UserrId",
                           table: "UserAccount",
                           column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Client_AuthenticationId",
                table: "Client",
                column: "AuthenticationId");


        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.DropTable(
                name: "UserAccount");

  

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Authentication");
        }
    }
}
