using Lipsy.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lipsy.Models
{
    public class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
            {
                if (!context.Categories.Any())
                {
                    context.Categories.AddRange(Categories.Select(c => c.Value));
                }

                if (!context.Lipsticks.Any())
                {
                    context.AddRange
                    (
                        new Lipstick
                        {
                            Name = "Lip Moisturizer",
                            Price = 1000M,
                            ShortDescription = "Lip Moisturizer made with Cocoa Butter and rich natural oils which keeps your lips soft and moisturized all day",
                            LongDescription = "Lip Moisturizer made with Cocoa Butter and rich natural oils which keeps your lips soft and moisturized all day.  " +
                            "Coco Mint Lip-balm contains peppermint which refreshes your lips after applying.",
                            Category = Categories["Party-Glam"],
                            ImageUrl = "https://i.ibb.co/cTkytPW/2.jpg",
                            InStock = true,
                            IsPreferredLipstick = true,
                            ImageThumbnailUrl = "https://i.ibb.co/cTkytPW/2.jpg"
                        },
                        new Lipstick
                        {
                            Name = "Organic Pink lip Balm / Lip Lightening Cream",
                            Price = 2000M,
                            ShortDescription = "Organic Pink lip Balm / Lip Lightening",
                            LongDescription = "Organic Pink lip Balm / Lip Lightening. " +
                            "Cream formulated to get rid of dark, " +
                            "chapped lips caused by smoking, sun exposure and chemicals.",
                            Category = Categories["Clear-Gloss"],
                            ImageUrl = "https://i.ibb.co/h7yfqKG/3.jpg",
                            InStock = true,
                            IsPreferredLipstick = false,
                            ImageThumbnailUrl = "https://i.ibb.co/h7yfqKG/3.jpg"
                        },
                        new Lipstick
                        {
                            Name = "Ice Out Lip Gloss",
                            Price = 1000M,
                            ShortDescription = "This Gloss is super glossy, " +
                            "clear in the Lips and made with peppermint essential oil " +
                            "which will plump your lips and give them a cooling effect!",
                            LongDescription = "Ingredients: Hydrogenated Polyisobutene (and)" +
                            " Ethylene/Propylene/Styrene Copolymer (and) " +
                            "Butylene/Ethylene/Styrene Copolymer, Coconut Oil, Grapeseed oil and Vanilla Flavor.",
                            Category = Categories["Clear-Gloss"],
                            ImageUrl = "https://i.ibb.co/pZthCXw/5.jpg",
                            InStock = true,
                            IsPreferredLipstick = false,
                            ImageThumbnailUrl = "https://i.ibb.co/pZthCXw/5.jpg"
                        },
                        new Lipstick
                        {
                            Name = "Scarlet Glitz",
                            Price = 2000M,
                            ShortDescription = "Strawberry Scented.  " +
                            "It appears lightly Tinted Pink on the Lips with Shimmer. " +
                            "Non sticky and moisturizes the Lips All day.",
                            LongDescription = "Ingredients: Hydrogenated Polyisobutene (and) Ethylene/Propylene/Styrene Copolymer " +
                            "(and) Butylene/Ethylene/Styrene Copolymer, Coconut Oil, Grapeseed oil and Flavor.",
                            Category = Categories["Party-Glam"],
                            ImageUrl = "https://i.ibb.co/Zxh23r5/6.jpg",
                            InStock = true,
                            IsPreferredLipstick = false,
                            ImageThumbnailUrl = "https://i.ibb.co/Zxh23r5/6.jpg"
                        },
                        new Lipstick
                        {
                            Name = "Rosabella",
                            Price = 2000M,
                            ShortDescription = "🍍 Pineapple Scented 💧. " +
                            "It appears Rose Gold Tinted on the Lips with a Shimmer. " +
                            "It moistures the Lips all day. Non sticky!! ",
                            Category = Categories["Nude"],
                            LongDescription = "🦋Ingredients: Hydrogenated Polyisobutene (and) Ethylene/Propylene/Styrene Copolymer " +
                            "(and) Butylene/Ethylene/Styrene Copolymer, Coconut Oil, Grapeseed oil and Flavor.",
                            ImageUrl = "https://i.ibb.co/XX8Ly5q/7.jpg",
                            InStock = true,
                            IsPreferredLipstick = false,
                            ImageThumbnailUrl = "https://i.ibb.co/XX8Ly5q/7.jpg"
                        },
                        new Lipstick
                        {
                            Name = "Coco Pretty",
                            Price = 2000M,
                            ShortDescription = "Irish cream scented.",
                            LongDescription = "Irish cream scented. 💧Coco Pretty Appears Brown Tinted Nude-like. 💧Champagne Vodka Appears Brown Tinted Nude like with Glitters...",
                            Category = Categories["Nude"],
                            ImageUrl = "https://i.ibb.co/rQY0X6D/8.jpg",
                            InStock = false,
                            IsPreferredLipstick = false,
                            ImageThumbnailUrl = "https://i.ibb.co/rQY0X6D/8.jpg"
                        },
                        new Lipstick
                        {
                            Name = "Barbie Pink",
                            Price = 2000M,
                            ShortDescription = "🍓 Strawberry Scented.",
                            LongDescription = "🍓 Strawberry Scented. 💧It appears lightly Tinted Pink on the Lips with Shimmer. " +
                            "This Lip-gloss is handmade and packaged by me and they are non-sticky, they moisturize your lips all day.",
                            Category = Categories["Party-Glam"],
                            ImageUrl = "https://i.ibb.co/Br9pd4r/9.jpg",
                            InStock = false,
                            IsPreferredLipstick = false,
                            ImageThumbnailUrl = "https://i.ibb.co/Br9pd4r/9.jpg"
                        },
                        new Lipstick
                        {
                            Name = "Golden Girl",
                            Price = 2000M,
                            ShortDescription = "Golden Girl ☘ Irish Cream Scented/Flavored 💧. It appears Gold Tinted on the Lips with a Shimmer. " +
                            "It moistures the Lips all day. My Glosses are handmade and packaged by me and they are non-sticky.",
                            LongDescription = "🦋Ingredients: Hydrogenated Polyisobutene (and) Ethylene/Propylene/Styrene Copolymer (and) " +
                            "Butylene/Ethylene/Styrene Copolymer, Coconut Oil, Grapeseed oil and Flavor.",
                            Category = Categories["Nude"],
                            ImageUrl = "https://i.ibb.co/KXb5tKN/10.jpg",
                            InStock = false,
                            IsPreferredLipstick = false,
                            ImageThumbnailUrl = "https://i.ibb.co/KXb5tKN/10.jpg"
                        },
                        new Lipstick
                        {
                            Name = "Lip Scrub",
                            Price = 2000M,
                            ShortDescription = "🍒This scrub is meant to get rid of any dead dark skin on the lips " +
                            "making your lips soft, pink and moisturized. 🍓Strawberry Flavored!",
                            LongDescription = "🦋Ingredients: Granulated Sugar, Coconut Oil, Grapeseed Oil, Vitamin E, Castor Oil, and Flavor.",
                            Category = Categories["Nude"],
                            ImageUrl = "https://i.ibb.co/L69SLRc/1.jpg",
                            InStock = false,
                            IsPreferredLipstick = false,
                            ImageThumbnailUrl = "https://i.ibb.co/L69SLRc/1.jpg"
                        }
                    );
                }

                context.SaveChanges();
            }
        }

        private static Dictionary<string, Category> categories;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (categories == null)
                {
                    var genresList = new Category[]
                    {
                        new Category { CategoryName = "Party-Glam", Description="Party Glam Lipsticks/Lipgloss Collection" },
                        new Category { CategoryName = "Clear-Gloss", Description="Clear Gloss Lipsticks/Lipgloss Collection" },
                        new Category { CategoryName = "Nude", Description="Nude Glam Lipsticks/Lipgloss Collection" },
                    };

                    categories = new Dictionary<string, Category>();

                    foreach (Category genre in genresList)
                    {
                        categories.Add(genre.CategoryName, genre);
                    }
                }

                return categories;
            }
        }
    }
}
