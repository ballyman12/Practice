using Microsoft.EntityFrameworkCore.Migrations;

namespace Practice.DataAccess.Migrations
{
    public partial class InitialFixData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropIndex(
                name: "IX_UserState_ActionStateId",
                table: "UserState");

            migrationBuilder.DropIndex(
                name: "IX_SupplierState_ActionStateId",
                table: "SupplierState");

            migrationBuilder.DropIndex(
                name: "IX_OrderState_ActionStateId",
                table: "OrderState");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
