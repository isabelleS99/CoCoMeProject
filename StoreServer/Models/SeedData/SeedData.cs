﻿using Microsoft.EntityFrameworkCore;
using StoreServer.Data;

namespace StoreServer.Models.SeedData
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new StoreServerContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<StoreServerContext>>()))
            {
                if (context == null || context.InventoryItem == null || context.ItemIdentifier == null)
                {
                    throw new ArgumentNullException("Null StoreServerContext");
                }

                // Look for any ItemIdentifiers.
                if (!context.ItemIdentifier.Any())
                {
                    context.ItemIdentifier.AddRange(
                    new ItemIdentifier
                    {
                        Name = "Apfel"
                    },
                    new ItemIdentifier
                    {
                        Name = "Tofu"
                    },
                    new ItemIdentifier
                    {
                        Name = "Toilettenpapier"
                    },
                    new ItemIdentifier
                    {
                        Name = "Oliven"
                    }

                );
                }
                context.SaveChanges();

                // Look for any InventoryItems.
                if (!context.InventoryItem.Any())
                {
                    context.InventoryItem.AddRange(
                    new InventoryItem
                    {
                        ItemIdentifier = context.ItemIdentifier.ToList().Find((ItemIdentifier) => ItemIdentifier.Name == "Tofu"),
                        Count = 10,
                        Price = 3.5M
                    },
                    new InventoryItem
                    {
                        ItemIdentifier = context.ItemIdentifier.ToList().Find((ItemIdentifier) => ItemIdentifier.Name == "Apfel"),
                        Count = 15,
                        Price = 2.50M
                    },
                    new InventoryItem
                    {
                        ItemIdentifier = context.ItemIdentifier.ToList().Find((ItemIdentifier) => ItemIdentifier.Name == "Toilettenpapier"),
                        Count = 0,
                        Price = 3.1M
                    },
                    new InventoryItem
                    {
                        ItemIdentifier = context.ItemIdentifier.ToList().Find((ItemIdentifier) => ItemIdentifier.Name == "Oliven"),
                        Count = 5,
                        Price = 3M
                    }
                );
                }

                
                context.SaveChanges();
            }
        }
    }
}