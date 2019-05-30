using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CrowDo1st.Migrations
{
    public partial class initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Dateofbirth = table.Column<DateTime>(name: "Date of birth", nullable: false),
                    Dateofregistration = table.Column<DateTime>(name: "Date of registration", nullable: false),
                    Location = table.Column<string>(nullable: true),
                    Cardnumber = table.Column<long>(name: "Card number", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "ProjectProfilePage",
                columns: table => new
                {
                    ProjectId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DateOfCreation = table.Column<DateTime>(nullable: false),
                    TimeScope = table.Column<int>(nullable: false),
                    DeadLine = table.Column<DateTime>(nullable: false),
                    Balance = table.Column<decimal>(nullable: false),
                    Category = table.Column<int>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectProfilePage", x => x.ProjectId);
                    table.ForeignKey(
                        name: "FK_ProjectProfilePage_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FundedProjects",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    ProjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FundedProjects", x => new { x.UserId, x.ProjectId });
                    table.ForeignKey(
                        name: "FK_FundedProjects_ProjectProfilePage_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "ProjectProfilePage",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FundedProjects_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Package",
                columns: table => new
                {
                    PackageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LowerBound = table.Column<decimal>(nullable: false),
                    Reward = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ProjectId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Package", x => x.PackageId);
                    table.ForeignKey(
                        name: "FK_Package_ProjectProfilePage_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "ProjectProfilePage",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    PhotoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    ProjectProfilePageProjectId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.PhotoId);
                    table.ForeignKey(
                        name: "FK_Photos_ProjectProfilePage_ProjectProfilePageProjectId",
                        column: x => x.ProjectProfilePageProjectId,
                        principalTable: "ProjectProfilePage",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Updates",
                columns: table => new
                {
                    UpdatesId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    DescriptionOfUpdate = table.Column<string>(nullable: true),
                    DateOfUpdate = table.Column<DateTime>(nullable: false),
                    ProjectProfilePageProjectId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Updates", x => x.UpdatesId);
                    table.ForeignKey(
                        name: "FK_Updates_ProjectProfilePage_ProjectProfilePageProjectId",
                        column: x => x.ProjectProfilePageProjectId,
                        principalTable: "ProjectProfilePage",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Videos",
                columns: table => new
                {
                    VideoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    ProjectProfilePageProjectId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videos", x => x.VideoId);
                    table.ForeignKey(
                        name: "FK_Videos_ProjectProfilePage_ProjectProfilePageProjectId",
                        column: x => x.ProjectProfilePageProjectId,
                        principalTable: "ProjectProfilePage",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FundedProjects_ProjectId",
                table: "FundedProjects",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Package_ProjectId",
                table: "Package",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Photos_ProjectProfilePageProjectId",
                table: "Photos",
                column: "ProjectProfilePageProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectProfilePage_UserId",
                table: "ProjectProfilePage",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Updates_ProjectProfilePageProjectId",
                table: "Updates",
                column: "ProjectProfilePageProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Videos_ProjectProfilePageProjectId",
                table: "Videos",
                column: "ProjectProfilePageProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FundedProjects");

            migrationBuilder.DropTable(
                name: "Package");

            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropTable(
                name: "Updates");

            migrationBuilder.DropTable(
                name: "Videos");

            migrationBuilder.DropTable(
                name: "ProjectProfilePage");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
