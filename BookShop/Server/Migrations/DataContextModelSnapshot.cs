// <auto-generated />
using System;
using BookShop.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookShop.Server.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BookShop.Shared.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("Zip")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("BookShop.Shared.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Featured")
                        .HasColumnType("bit");

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Visible")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "Arthur Conan Doyle",
                            CategoryId = 1,
                            Deleted = false,
                            Description = "The Adventures of Sherlock Holmes is a collection of twelve short stories by Arthur Conan Doyle, first published on 14 October 1892. It contains the earliest short stories featuring the consulting detective Sherlock Holmes, which had been published in twelve monthly issues of The Strand Magazine from July 1891 to June 1892. The stories are collected in the same sequence, which is not supported by any fictional chronology. The only characters common to all twelve are Holmes and Dr. Watson and all are related in first-person narrative from Watson's point of view.",
                            Featured = true,
                            ImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/b/b9/Adventures_of_sherlock_holmes.jpg/220px-Adventures_of_sherlock_holmes.jpg",
                            Price = 0m,
                            Title = "The Adventures of Sherlock Holmes",
                            Visible = true
                        },
                        new
                        {
                            Id = 2,
                            Author = "Arthur Conan Doyle",
                            CategoryId = 1,
                            Deleted = false,
                            Description = "The Case-Book of Sherlock Holmes is the final set of twelve (out of a total of fifty-six) Sherlock Holmes short stories by Arthur Conan Doyle first published in the Strand Magazine between October 1921 and April 1927.",
                            Featured = false,
                            ImageURL = "https://upload.wikimedia.org/wikipedia/en/c/c2/Case-book_of_sherlock_holmes.jpg",
                            Price = 0m,
                            Title = "The Case-Book of Sherlock Holmes",
                            Visible = true
                        },
                        new
                        {
                            Id = 3,
                            Author = "Arthur Conan Doyle",
                            CategoryId = 1,
                            Deleted = false,
                            Description = "A Study in Scarlet is an 1887 detective novel written by Arthur Conan Doyle. The story marks the first appearance of Sherlock Holmes and Dr. Watson, who would become the most famous detective duo in literature. The book's title derives from a speech given by Holmes, a consulting detective, to his friend and chronicler Watson on the nature of his work, in which he describes the story's murder investigation as his \"study in scarlet\": \"There's the scarlet thread of murder running through the colourless skein of life, and our duty is to unravel it, and isolate it, and expose every inch of it.\"",
                            Featured = false,
                            ImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/2/2c/ArthurConanDoyle_AStudyInScarlet_annual.jpg/220px-ArthurConanDoyle_AStudyInScarlet_annual.jpg",
                            Price = 0m,
                            Title = "A Study in Scarlet",
                            Visible = true
                        },
                        new
                        {
                            Id = 4,
                            Author = "Rick Riordan",
                            CategoryId = 2,
                            Deleted = false,
                            Description = "The Lightning Thief is a 2005 American-fantasy-adventure novel based on Greek mythology, the first young adult novel written by Rick Riordan in the Percy Jackson & the Olympians series. It won the Adult Library Services Association Best Books for Young Adults, among other awards. It was adapted into a film named Percy Jackson & the Olympians: The Lightning Thief released in the United States on February 12, 2010. On May 14, 2020, Riordan announced that a live-action TV series for Disney+ would adapt the Percy Jackson & the Olympians series, with the first season covering The Lightning Thief. The novel is followed by The Sea of Monsters and spawned two sequel series (The Heroes of Olympus and The Trials of Apollo) and the extended universe of the Camp Half-Blood Chronicles.",
                            Featured = true,
                            ImageURL = "https://upload.wikimedia.org/wikipedia/en/3/3b/The_Lightning_Thief_cover.jpg",
                            Price = 0m,
                            Title = "Percy Jackson & the Olympians: The Lightning Thief",
                            Visible = true
                        },
                        new
                        {
                            Id = 5,
                            Author = "Rick Riordan",
                            CategoryId = 2,
                            Deleted = false,
                            Description = "The Sea of Monsters is an American fantasy-adventure novel based on Greek mythology written by Rick Riordan and published in 2006. It is the second novel in the Percy Jackson & the Olympians series and the sequel to The Lightning Thief. This book chronicles the adventures of thirteen-year-old demigod Percy Jackson as he and his friends rescue his satyr friend Grover from the Cyclops Polyphemus and save Camp Half-Blood from a Titan's attack by bringing the Golden Fleece to cure Thalia's poisoned pine tree.",
                            Featured = false,
                            ImageURL = "https://upload.wikimedia.org/wikipedia/en/thumb/4/46/PercySeamonsters.gif/220px-PercySeamonsters.gif",
                            Price = 0m,
                            Title = "The Sea of Monsters",
                            Visible = true
                        },
                        new
                        {
                            Id = 6,
                            Author = "Rick Riordan",
                            CategoryId = 3,
                            Deleted = false,
                            Description = "The Titan's Curse is an American fantasy-adventure novel based on Greek mythology written by Rick Riordan. It was released on May 1, 2007, and is the third novel in the Percy Jackson & the Olympians series and the sequel to The Sea of Monsters. It is about the adventures of the 14-year-old demigod Percy Jackson as he and his friends go on a dangerous quest to rescue his 14-year-old demigod friend Annabeth Chase and the Greek goddess Artemis, who have both been kidnapped by the titans.",
                            Featured = true,
                            ImageURL = "https://upload.wikimedia.org/wikipedia/en/thumb/3/3c/The_titan%27s_curse.jpg/220px-The_titan%27s_curse.jpg",
                            Price = 0m,
                            Title = "The Titan's Curse",
                            Visible = true
                        });
                });

            modelBuilder.Entity("BookShop.Shared.BookType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BookTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Default"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Paperback"
                        },
                        new
                        {
                            Id = 3,
                            Name = "E-Book"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Audiobook"
                        });
                });

            modelBuilder.Entity("BookShop.Shared.BookVariant", b =>
                {
                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("BookTypeId")
                        .HasColumnType("int");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<decimal>("OriginalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("Visible")
                        .HasColumnType("bit");

                    b.HasKey("BookId", "BookTypeId");

                    b.HasIndex("BookTypeId");

                    b.ToTable("BookVariants");

                    b.HasData(
                        new
                        {
                            BookId = 1,
                            BookTypeId = 2,
                            Deleted = false,
                            OriginalPrice = 19.99m,
                            Price = 9.99m,
                            Visible = true
                        },
                        new
                        {
                            BookId = 2,
                            BookTypeId = 2,
                            Deleted = false,
                            OriginalPrice = 12.99m,
                            Price = 9.99m,
                            Visible = true
                        },
                        new
                        {
                            BookId = 3,
                            BookTypeId = 2,
                            Deleted = false,
                            OriginalPrice = 14.99m,
                            Price = 13.99m,
                            Visible = true
                        },
                        new
                        {
                            BookId = 4,
                            BookTypeId = 2,
                            Deleted = false,
                            OriginalPrice = 21.99m,
                            Price = 19.99m,
                            Visible = true
                        },
                        new
                        {
                            BookId = 5,
                            BookTypeId = 2,
                            Deleted = false,
                            OriginalPrice = 24.99m,
                            Price = 22.99m,
                            Visible = true
                        },
                        new
                        {
                            BookId = 6,
                            BookTypeId = 2,
                            Deleted = false,
                            OriginalPrice = 22.99m,
                            Price = 18.99m,
                            Visible = true
                        });
                });

            modelBuilder.Entity("BookShop.Shared.CartItem", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("BookTypeId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("UserId", "BookId", "BookTypeId");

                    b.ToTable("CartItems");
                });

            modelBuilder.Entity("BookShop.Shared.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("URL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Visible")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Deleted = false,
                            ImageURL = "",
                            Name = "Adventure",
                            URL = "adventure",
                            Visible = true
                        },
                        new
                        {
                            Id = 2,
                            Deleted = false,
                            ImageURL = "",
                            Name = "Story",
                            URL = "story",
                            Visible = true
                        },
                        new
                        {
                            Id = 3,
                            Deleted = false,
                            ImageURL = "",
                            Name = "Horror",
                            URL = "horror",
                            Visible = true
                        });
                });

            modelBuilder.Entity("BookShop.Shared.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("BookShop.Shared.OrderItem", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("BookTypeId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("OrderId", "BookId", "BookTypeId");

                    b.HasIndex("BookId");

                    b.HasIndex("BookTypeId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("BookShop.Shared.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BookShop.Shared.Address", b =>
                {
                    b.HasOne("BookShop.Shared.User", null)
                        .WithOne("Address")
                        .HasForeignKey("BookShop.Shared.Address", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookShop.Shared.Book", b =>
                {
                    b.HasOne("BookShop.Shared.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("BookShop.Shared.BookVariant", b =>
                {
                    b.HasOne("BookShop.Shared.Book", "Book")
                        .WithMany("Variants")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookShop.Shared.BookType", "BookType")
                        .WithMany()
                        .HasForeignKey("BookTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("BookType");
                });

            modelBuilder.Entity("BookShop.Shared.OrderItem", b =>
                {
                    b.HasOne("BookShop.Shared.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookShop.Shared.BookType", "BookType")
                        .WithMany()
                        .HasForeignKey("BookTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookShop.Shared.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("BookType");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("BookShop.Shared.Book", b =>
                {
                    b.Navigation("Variants");
                });

            modelBuilder.Entity("BookShop.Shared.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("BookShop.Shared.User", b =>
                {
                    b.Navigation("Address")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
