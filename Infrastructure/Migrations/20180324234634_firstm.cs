using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Infrastructure.Migrations
{
    public partial class firstm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FM_Customer",
                columns: table => new
                {
                    F_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    F_Account = table.Column<string>(maxLength: 50, nullable: true),
                    F_Address = table.Column<string>(maxLength: 100, nullable: true),
                    F_FirstName = table.Column<string>(nullable: false),
                    F_LastModifiedDate = table.Column<DateTime>(nullable: false),
                    F_LastName = table.Column<string>(nullable: false),
                    F_MobilePhone = table.Column<string>(maxLength: 15, nullable: true),
                    F_Sex = table.Column<int>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FM_Customer", x => x.F_Id);
                });

            migrationBuilder.CreateTable(
                name: "FM_OrderItemsStatus",
                columns: table => new
                {
                    F_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    F_LastModifiedDate = table.Column<DateTime>(nullable: false),
                    F_OrderItemStatus = table.Column<string>(maxLength: 30, nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FM_OrderItemsStatus", x => x.F_Id);
                });

            migrationBuilder.CreateTable(
                name: "FM_OrderStatus",
                columns: table => new
                {
                    F_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    F_LastModifiedDate = table.Column<DateTime>(nullable: false),
                    F_OrderStatus = table.Column<string>(maxLength: 30, nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FM_OrderStatus", x => x.F_Id);
                });

            migrationBuilder.CreateTable(
                name: "FM_Paymentmethods",
                columns: table => new
                {
                    F_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    F_LastModifiedDate = table.Column<DateTime>(nullable: false),
                    F_PaymentName = table.Column<string>(maxLength: 30, nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FM_Paymentmethods", x => x.F_Id);
                });

            migrationBuilder.CreateTable(
                name: "FM_ProductCarategory",
                columns: table => new
                {
                    F_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    F_FullName = table.Column<string>(maxLength: 50, nullable: false),
                    F_LastModifiedDate = table.Column<DateTime>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FM_ProductCarategory", x => x.F_Id);
                });

            migrationBuilder.CreateTable(
                name: "FM_SalesOrder",
                columns: table => new
                {
                    F_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomerId = table.Column<int>(nullable: false),
                    F_LastModifiedDate = table.Column<DateTime>(nullable: false),
                    F_OrderDate = table.Column<DateTime>(nullable: false),
                    F_OrderNumber = table.Column<string>(nullable: false),
                    F_PayDate = table.Column<DateTime>(nullable: false),
                    F_SubTotal = table.Column<decimal>(nullable: false),
                    F_TaxAmt = table.Column<decimal>(nullable: false),
                    F_TotalDue = table.Column<decimal>(nullable: false),
                    OrderStatusId = table.Column<int>(nullable: false),
                    PaymentMethodId = table.Column<int>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FM_SalesOrder", x => x.F_Id);
                    table.ForeignKey(
                        name: "FK_FM_SalesOrder_FM_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "FM_Customer",
                        principalColumn: "F_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FM_SalesOrder_FM_OrderStatus_OrderStatusId",
                        column: x => x.OrderStatusId,
                        principalTable: "FM_OrderStatus",
                        principalColumn: "F_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FM_SalesOrder_FM_Paymentmethods_PaymentMethodId",
                        column: x => x.PaymentMethodId,
                        principalTable: "FM_Paymentmethods",
                        principalColumn: "F_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FM_Products",
                columns: table => new
                {
                    F_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CatalogId = table.Column<int>(nullable: false),
                    F_EnCode = table.Column<string>(maxLength: 8, nullable: false),
                    F_FullName = table.Column<string>(maxLength: 50, nullable: false),
                    F_GuidePrice = table.Column<decimal>(nullable: false),
                    F_ImageUrl1 = table.Column<string>(maxLength: 100, nullable: true),
                    F_LastModifiedDate = table.Column<DateTime>(nullable: false),
                    F_SalePrice = table.Column<decimal>(nullable: false),
                    F_StandardCost = table.Column<decimal>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FM_Products", x => x.F_Id);
                    table.ForeignKey(
                        name: "FK_FM_Products_FM_ProductCarategory_CatalogId",
                        column: x => x.CatalogId,
                        principalTable: "FM_ProductCarategory",
                        principalColumn: "F_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FM_OrderItem",
                columns: table => new
                {
                    F_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    F_LastModifiedDate = table.Column<DateTime>(nullable: false),
                    F_LineTotal = table.Column<decimal>(nullable: false),
                    F_Price = table.Column<decimal>(nullable: false),
                    F_ProductId = table.Column<int>(nullable: false),
                    F_Quantity = table.Column<float>(nullable: false),
                    F_SalesOrderId = table.Column<int>(nullable: false),
                    OrderItemStatusId = table.Column<int>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FM_OrderItem", x => x.F_Id);
                    table.ForeignKey(
                        name: "FK_FM_OrderItem_FM_Products_F_ProductId",
                        column: x => x.F_ProductId,
                        principalTable: "FM_Products",
                        principalColumn: "F_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FM_OrderItem_FM_SalesOrder_F_SalesOrderId",
                        column: x => x.F_SalesOrderId,
                        principalTable: "FM_SalesOrder",
                        principalColumn: "F_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FM_OrderItem_FM_OrderItemsStatus_OrderItemStatusId",
                        column: x => x.OrderItemStatusId,
                        principalTable: "FM_OrderItemsStatus",
                        principalColumn: "F_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FM_ProductChanges",
                columns: table => new
                {
                    F_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    F_LastModifiedDate = table.Column<DateTime>(nullable: false),
                    F_NewPrice = table.Column<decimal>(nullable: false),
                    F_ProductId = table.Column<int>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FM_ProductChanges", x => x.F_Id);
                    table.ForeignKey(
                        name: "FK_FM_ProductChanges_FM_Products_F_ProductId",
                        column: x => x.F_ProductId,
                        principalTable: "FM_Products",
                        principalColumn: "F_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FM_OrderItem_F_ProductId",
                table: "FM_OrderItem",
                column: "F_ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_FM_OrderItem_F_SalesOrderId",
                table: "FM_OrderItem",
                column: "F_SalesOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_FM_OrderItem_OrderItemStatusId",
                table: "FM_OrderItem",
                column: "OrderItemStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_FM_ProductChanges_F_ProductId",
                table: "FM_ProductChanges",
                column: "F_ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_FM_Products_CatalogId",
                table: "FM_Products",
                column: "CatalogId");

            migrationBuilder.CreateIndex(
                name: "IX_FM_SalesOrder_CustomerId",
                table: "FM_SalesOrder",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_FM_SalesOrder_OrderStatusId",
                table: "FM_SalesOrder",
                column: "OrderStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_FM_SalesOrder_PaymentMethodId",
                table: "FM_SalesOrder",
                column: "PaymentMethodId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FM_OrderItem");

            migrationBuilder.DropTable(
                name: "FM_ProductChanges");

            migrationBuilder.DropTable(
                name: "FM_SalesOrder");

            migrationBuilder.DropTable(
                name: "FM_OrderItemsStatus");

            migrationBuilder.DropTable(
                name: "FM_Products");

            migrationBuilder.DropTable(
                name: "FM_Customer");

            migrationBuilder.DropTable(
                name: "FM_OrderStatus");

            migrationBuilder.DropTable(
                name: "FM_Paymentmethods");

            migrationBuilder.DropTable(
                name: "FM_ProductCarategory");
        }
    }
}
