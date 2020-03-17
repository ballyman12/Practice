using Microsoft.EntityFrameworkCore.Migrations;

namespace Practice.DataAccess.Migrations
{
    public partial class InitialFixCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ActionStateId",
                table: "UserState",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ActionStateId",
                table: "SupplierState",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ActionStateId",
                table: "OrderState",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ActionStateId",
                table: "ItemState",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ActionStates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    By = table.Column<int>(nullable: false),
                    On = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionStates", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserState_ActionStateId",
                table: "UserState",
                column: "ActionStateId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierState_ActionStateId",
                table: "SupplierState",
                column: "ActionStateId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderState_ActionStateId",
                table: "OrderState",
                column: "ActionStateId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderState_ActionStates_ActionStateId",
                table: "OrderState",
                column: "ActionStateId",
                principalTable: "ActionStates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SupplierState_ActionStates_ActionStateId",
                table: "SupplierState",
                column: "ActionStateId",
                principalTable: "ActionStates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserState_ActionStates_ActionStateId",
                table: "UserState",
                column: "ActionStateId",
                principalTable: "ActionStates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderState_ActionStates_ActionStateId",
                table: "OrderState");

            migrationBuilder.DropForeignKey(
                name: "FK_SupplierState_ActionStates_ActionStateId",
                table: "SupplierState");

            migrationBuilder.DropForeignKey(
                name: "FK_UserState_ActionStates_ActionStateId",
                table: "UserState");

            migrationBuilder.DropTable(
                name: "ActionStates");

            migrationBuilder.DropIndex(
                name: "IX_UserState_ActionStateId",
                table: "UserState");

            migrationBuilder.DropIndex(
                name: "IX_SupplierState_ActionStateId",
                table: "SupplierState");

            migrationBuilder.DropIndex(
                name: "IX_OrderState_ActionStateId",
                table: "OrderState");

            migrationBuilder.DropColumn(
                name: "ActionStateId",
                table: "UserState");

            migrationBuilder.DropColumn(
                name: "ActionStateId",
                table: "SupplierState");

            migrationBuilder.DropColumn(
                name: "ActionStateId",
                table: "OrderState");

            migrationBuilder.DropColumn(
                name: "ActionStateId",
                table: "ItemState");
        }
    }
}
