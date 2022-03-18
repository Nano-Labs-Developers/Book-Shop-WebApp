namespace BookShop.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<CartItem>()
				.HasKey(ci => new { ci.UserId, ci.BookId, ci.BookTypeId });

			modelBuilder.Entity<BookVariant>()
				.HasKey(b => new { b.BookId, b.BookTypeId });

			modelBuilder.Entity<OrderItem>()
				.HasKey(oi => new { oi.OrderId, oi.BookId, oi.BookTypeId });

			modelBuilder.Entity<BookType>().HasData(
				new BookType { Id = 1, Name = "Default" },
				new BookType { Id = 2, Name = "Paperback" },
				new BookType { Id = 3, Name = "E-Book" },
				new BookType { Id = 4, Name = "Audiobook" }
			);

			modelBuilder.Entity<Category>().HasData(
				new Category { Id = 1, Name = "Adventure", URL = "adventure", ImageURL = ""},
				new Category { Id = 2, Name = "Story", URL = "story", ImageURL = "" },
				new Category { Id = 3, Name = "Horror", URL = "horror", ImageURL = "" }
			);


			modelBuilder.Entity<Book>().HasData(
				new Book
				{
					Id = 1,
					Title = "The Adventures of Sherlock Holmes",
					Author = "Arthur Conan Doyle",
					Description = "The Adventures of Sherlock Holmes is a collection of twelve short stories by Arthur Conan Doyle, first published on 14 October 1892. It contains the earliest short stories featuring the consulting detective Sherlock Holmes, which had been published in twelve monthly issues of The Strand Magazine from July 1891 to June 1892. The stories are collected in the same sequence, which is not supported by any fictional chronology. The only characters common to all twelve are Holmes and Dr. Watson and all are related in first-person narrative from Watson's point of view.",
					ImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/b/b9/Adventures_of_sherlock_holmes.jpg/220px-Adventures_of_sherlock_holmes.jpg",
					CategoryId = 1,
					Featured = true
				},
				new Book
				{
					Id = 2,
					Title = "The Case-Book of Sherlock Holmes",
					Author = "Arthur Conan Doyle",
					Description = "The Case-Book of Sherlock Holmes is the final set of twelve (out of a total of fifty-six) Sherlock Holmes short stories by Arthur Conan Doyle first published in the Strand Magazine between October 1921 and April 1927.",
					ImageURL = "https://upload.wikimedia.org/wikipedia/en/c/c2/Case-book_of_sherlock_holmes.jpg",
					CategoryId = 1,
				},
				new Book
				{
					Id = 3,
					Title = "A Study in Scarlet",
					Author = "Arthur Conan Doyle",
					Description = "A Study in Scarlet is an 1887 detective novel written by Arthur Conan Doyle. The story marks the first appearance of Sherlock Holmes and Dr. Watson, who would become the most famous detective duo in literature. The book's title derives from a speech given by Holmes, a consulting detective, to his friend and chronicler Watson on the nature of his work, in which he describes the story's murder investigation as his \"study in scarlet\": \"There's the scarlet thread of murder running through the colourless skein of life, and our duty is to unravel it, and isolate it, and expose every inch of it.\"",
					ImageURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/2/2c/ArthurConanDoyle_AStudyInScarlet_annual.jpg/220px-ArthurConanDoyle_AStudyInScarlet_annual.jpg",
					CategoryId = 1,
				},
				new Book
				{
					Id = 4,
					Title = "Percy Jackson & the Olympians: The Lightning Thief",
					Author = "Rick Riordan",
					Description = "The Lightning Thief is a 2005 American-fantasy-adventure novel based on Greek mythology, the first young adult novel written by Rick Riordan in the Percy Jackson & the Olympians series. It won the Adult Library Services Association Best Books for Young Adults, among other awards. It was adapted into a film named Percy Jackson & the Olympians: The Lightning Thief released in the United States on February 12, 2010. On May 14, 2020, Riordan announced that a live-action TV series for Disney+ would adapt the Percy Jackson & the Olympians series, with the first season covering The Lightning Thief. The novel is followed by The Sea of Monsters and spawned two sequel series (The Heroes of Olympus and The Trials of Apollo) and the extended universe of the Camp Half-Blood Chronicles.",
					ImageURL = "https://upload.wikimedia.org/wikipedia/en/3/3b/The_Lightning_Thief_cover.jpg",
					CategoryId = 2,
					Featured = true
				},
				new Book
				{
					Id = 5,
					Title = "The Sea of Monsters",
					Author = "Rick Riordan",
					Description = "The Sea of Monsters is an American fantasy-adventure novel based on Greek mythology written by Rick Riordan and published in 2006. It is the second novel in the Percy Jackson & the Olympians series and the sequel to The Lightning Thief. This book chronicles the adventures of thirteen-year-old demigod Percy Jackson as he and his friends rescue his satyr friend Grover from the Cyclops Polyphemus and save Camp Half-Blood from a Titan's attack by bringing the Golden Fleece to cure Thalia's poisoned pine tree.",
					ImageURL = "https://upload.wikimedia.org/wikipedia/en/thumb/4/46/PercySeamonsters.gif/220px-PercySeamonsters.gif",
					CategoryId = 2,
				},
				new Book
				{
					Id = 6,
					Title = "The Titan's Curse",
					Author = "Rick Riordan",
					Description = "The Titan's Curse is an American fantasy-adventure novel based on Greek mythology written by Rick Riordan. It was released on May 1, 2007, and is the third novel in the Percy Jackson & the Olympians series and the sequel to The Sea of Monsters. It is about the adventures of the 14-year-old demigod Percy Jackson as he and his friends go on a dangerous quest to rescue his 14-year-old demigod friend Annabeth Chase and the Greek goddess Artemis, who have both been kidnapped by the titans.",
					ImageURL = "https://upload.wikimedia.org/wikipedia/en/thumb/3/3c/The_titan%27s_curse.jpg/220px-The_titan%27s_curse.jpg",
					CategoryId = 3,
					Featured = true
				}
			);

			modelBuilder.Entity<BookVariant>().HasData(
				new BookVariant
				{
					BookId = 1,
					BookTypeId = 2,
					Price = 9.99m,
					OriginalPrice = 19.99m
				},
				new BookVariant
				{
					BookId = 2,
					BookTypeId = 2,
					Price = 9.99m,
					OriginalPrice = 12.99m
				},
				new BookVariant
				{
					BookId = 3,
					BookTypeId = 2,
					Price = 13.99m,
					OriginalPrice = 14.99m
				},
				new BookVariant
				{
					BookId = 4,
					BookTypeId = 2,
					Price = 19.99m,
					OriginalPrice = 21.99m
				},
				new BookVariant
				{
					BookId = 5,
					BookTypeId = 2,
					Price = 22.99m,
					OriginalPrice = 24.99m
				},
				new BookVariant
				{
					BookId = 6,
					BookTypeId = 2,
					Price = 18.99m,
					OriginalPrice = 22.99m
				}
			);
		}

        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
		public DbSet<BookType> BookTypes { get; set; }
		public DbSet<BookVariant> BookVariants { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<CartItem> CartItems { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<OrderItem> OrderItems { get; set; }
		public DbSet<Address> Addresses { get; set; }
	}
}
