using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookShop.Server.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    BookTypeId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => new { x.UserId, x.BookId, x.BookTypeId });
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Visible = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Featured = table.Column<bool>(type: "bit", nullable: false),
                    Visible = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Zip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookVariants",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false),
                    BookTypeId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OriginalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Visible = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookVariants", x => new { x.BookId, x.BookTypeId });
                    table.ForeignKey(
                        name: "FK_BookVariants_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookVariants_BookTypes_BookTypeId",
                        column: x => x.BookTypeId,
                        principalTable: "BookTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    BookTypeId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => new { x.OrderId, x.BookId, x.BookTypeId });
                    table.ForeignKey(
                        name: "FK_OrderItems_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_BookTypes_BookTypeId",
                        column: x => x.BookTypeId,
                        principalTable: "BookTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BookTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Default" },
                    { 2, "Paperback" },
                    { 3, "E-Book" },
                    { 4, "Audiobook" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Deleted", "ImageURL", "Name", "URL", "Visible" },
                values: new object[,]
                {
                    { 1, false, "", "Adventure", "adventure", true },
                    { 2, false, "", "Story", "story", true },
                    { 3, false, "", "Horror", "horror", true }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "CategoryId", "Deleted", "Description", "Featured", "ImageURL", "Price", "Title", "Visible" },
                values: new object[,]
                {
                    { 1, "Arthur Conan Doyle", 1, false, "The Adventures of Sherlock Holmes is a collection of twelve short stories by Arthur Conan Doyle, first published on 14 October 1892. It contains the earliest short stories featuring the consulting detective Sherlock Holmes, which had been published in twelve monthly issues of The Strand Magazine from July 1891 to June 1892. The stories are collected in the same sequence, which is not supported by any fictional chronology. The only characters common to all twelve are Holmes and Dr. Watson and all are related in first-person narrative from Watson's point of view.", true, "https://upload.wikimedia.org/wikipedia/commons/thumb/b/b9/Adventures_of_sherlock_holmes.jpg/220px-Adventures_of_sherlock_holmes.jpg", 0m, "The Adventures of Sherlock Holmes", true },
                    { 2, "Arthur Conan Doyle", 1, false, "The Case-Book of Sherlock Holmes is the final set of twelve (out of a total of fifty-six) Sherlock Holmes short stories by Arthur Conan Doyle first published in the Strand Magazine between October 1921 and April 1927.", false, "https://upload.wikimedia.org/wikipedia/en/c/c2/Case-book_of_sherlock_holmes.jpg", 0m, "The Case-Book of Sherlock Holmes", true },
                    { 3, "Arthur Conan Doyle", 1, false, "A Study in Scarlet is an 1887 detective novel written by Arthur Conan Doyle. The story marks the first appearance of Sherlock Holmes and Dr. Watson, who would become the most famous detective duo in literature. The book's title derives from a speech given by Holmes, a consulting detective, to his friend and chronicler Watson on the nature of his work, in which he describes the story's murder investigation as his \"study in scarlet\": \"There's the scarlet thread of murder running through the colourless skein of life, and our duty is to unravel it, and isolate it, and expose every inch of it.\"", false, "https://upload.wikimedia.org/wikipedia/commons/thumb/2/2c/ArthurConanDoyle_AStudyInScarlet_annual.jpg/220px-ArthurConanDoyle_AStudyInScarlet_annual.jpg", 0m, "A Study in Scarlet", true },
                    { 4, "Rick Riordan", 2, false, "The Lightning Thief is a 2005 American-fantasy-adventure novel based on Greek mythology, the first young adult novel written by Rick Riordan in the Percy Jackson & the Olympians series. It won the Adult Library Services Association Best Books for Young Adults, among other awards. It was adapted into a film named Percy Jackson & the Olympians: The Lightning Thief released in the United States on February 12, 2010. On May 14, 2020, Riordan announced that a live-action TV series for Disney+ would adapt the Percy Jackson & the Olympians series, with the first season covering The Lightning Thief. The novel is followed by The Sea of Monsters and spawned two sequel series (The Heroes of Olympus and The Trials of Apollo) and the extended universe of the Camp Half-Blood Chronicles.", true, "https://upload.wikimedia.org/wikipedia/en/3/3b/The_Lightning_Thief_cover.jpg", 0m, "Percy Jackson & the Olympians: The Lightning Thief", true },
                    { 5, "Rick Riordan", 2, false, "The Sea of Monsters is an American fantasy-adventure novel based on Greek mythology written by Rick Riordan and published in 2006. It is the second novel in the Percy Jackson & the Olympians series and the sequel to The Lightning Thief. This book chronicles the adventures of thirteen-year-old demigod Percy Jackson as he and his friends rescue his satyr friend Grover from the Cyclops Polyphemus and save Camp Half-Blood from a Titan's attack by bringing the Golden Fleece to cure Thalia's poisoned pine tree.", false, "https://upload.wikimedia.org/wikipedia/en/thumb/4/46/PercySeamonsters.gif/220px-PercySeamonsters.gif", 0m, "The Sea of Monsters", true },
                    { 6, "Rick Riordan", 3, false, "The Titan's Curse is an American fantasy-adventure novel based on Greek mythology written by Rick Riordan. It was released on May 1, 2007, and is the third novel in the Percy Jackson & the Olympians series and the sequel to The Sea of Monsters. It is about the adventures of the 14-year-old demigod Percy Jackson as he and his friends go on a dangerous quest to rescue his 14-year-old demigod friend Annabeth Chase and the Greek goddess Artemis, who have both been kidnapped by the titans.", true, "https://upload.wikimedia.org/wikipedia/en/thumb/3/3c/The_titan%27s_curse.jpg/220px-The_titan%27s_curse.jpg", 0m, "The Titan's Curse", true }
                });

            migrationBuilder.InsertData(
                table: "BookVariants",
                columns: new[] { "BookId", "BookTypeId", "Deleted", "OriginalPrice", "Price", "Visible" },
                values: new object[,]
                {
                    { 1, 2, false, 19.99m, 9.99m, true },
                    { 2, 2, false, 12.99m, 9.99m, true },
                    { 3, 2, false, 14.99m, 13.99m, true },
                    { 4, 2, false, 21.99m, 19.99m, true },
                    { 5, 2, false, 24.99m, 22.99m, true },
                    { 6, 2, false, 22.99m, 18.99m, true }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_UserId",
                table: "Addresses",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_CategoryId",
                table: "Books",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_BookVariants_BookTypeId",
                table: "BookVariants",
                column: "BookTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_BookId",
                table: "OrderItems",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_BookTypeId",
                table: "OrderItems",
                column: "BookTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "BookVariants");

            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "BookTypes");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
