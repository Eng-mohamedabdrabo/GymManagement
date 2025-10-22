using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymManagementDAL.Data.Migrations
{
    /// <inheritdoc />
    public partial class EditionCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MemberSessions",
                table: "MemberSessions");

            migrationBuilder.DropIndex(
                name: "IX_MemberSessions_MembersId",
                table: "MemberSessions");

            migrationBuilder.DropColumn(
                name: "MemberesId",
                table: "MemberSessions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MemberSessions",
                table: "MemberSessions",
                columns: new[] { "MembersId", "SessionsId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MemberSessions",
                table: "MemberSessions");

            migrationBuilder.AddColumn<int>(
                name: "MemberesId",
                table: "MemberSessions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MemberSessions",
                table: "MemberSessions",
                columns: new[] { "MemberesId", "SessionsId" });

            migrationBuilder.CreateIndex(
                name: "IX_MemberSessions_MembersId",
                table: "MemberSessions",
                column: "MembersId");
        }
    }
}
