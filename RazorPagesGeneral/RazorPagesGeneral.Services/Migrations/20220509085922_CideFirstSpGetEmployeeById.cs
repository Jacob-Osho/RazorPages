using Microsoft.EntityFrameworkCore.Migrations;

namespace RazorPagesGeneral.Services.Migrations
{
    public partial class CideFirstSpGetEmployeeById : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Create procedure CideFirstSpGetEmployeeById
                                @Id int
                                as
                                Begin
                                Select *
                                From Employees
                                Where Id =@Id
                                End";
            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Drop procedure CideFirstSpGetEmployeeById";
            migrationBuilder.Sql(procedure);
        }
    }
}
