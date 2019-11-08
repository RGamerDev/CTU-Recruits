using Microsoft.EntityFrameworkCore.Migrations;

namespace CTU_Recruits.Migrations
{
    public partial class AddAndSeedUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    CompanyName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobSeeker",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 20, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Skills = table.Column<string>(nullable: false),
                    YearsOfExperience = table.Column<int>(nullable: false),
                    CVPath = table.Column<string>(nullable: true),
                    PhotoPath = table.Column<string>(nullable: true),
                    PublicCV = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobSeeker", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Employer",
                columns: new[] { "Id", "CompanyName", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Techer", "jfkdlsahjkdasghsdjka", "Mary" },
                    { 2, "ITD", "jfkdlsahjkdasghsdjka", "John" },
                    { 3, "UMC", "jfkdlsahjkdasghsdjka", "Sam" }
                });

            migrationBuilder.InsertData(
                table: "JobSeeker",
                columns: new[] { "Id", "CVPath", "Description", "Name", "PhotoPath", "PublicCV", "Skills", "YearsOfExperience" },
                values: new object[,]
                {
                    { 1, "~/Images/CV.png", "jkfld;ajskgl;ag", "Mary", "~/Images/Mary.jpg", true, "abc", 1 },
                    { 2, "~/Images/CV.png", "jkfld;ajskgl;ag", "John", "~/Images/John.jpg", true, "def", 1 },
                    { 3, "~/Images/CV.png", "jkfld;ajskgl;ag", "Sam", "~/Images/Sam.jpg", true, "ghi", 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employer");

            migrationBuilder.DropTable(
                name: "JobSeeker");
        }
    }
}
