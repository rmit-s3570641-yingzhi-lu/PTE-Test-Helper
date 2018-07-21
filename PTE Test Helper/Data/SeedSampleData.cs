using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PTE_Test_Helper.Models;

namespace PTE_Test_Helper.Data
{
    public static class SeedSampleData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new PTE_Test_HelperContext(
                serviceProvider.GetRequiredService<DbContextOptions<PTE_Test_HelperContext>>()))
            {
                if (context.RO.Any() && context.Paragraphs.Any())
                {
                    return;
                }

                var ro = new[]
                {
                    new RO
                    {
                        ID = 1,
                        Title = "Indian IT",
                        IsComplete = true,
                        CreateDate = DateTime.Today,
                        UpdateDate = DateTime.Today,
                    }
                };

                context.RO.AddRange(ro);

                var paragraph = new[]
                {
                    new Paragraph
                    {
                    ParentId = 1,
                    Content = "Innovation in India is as much due to entrepreneurialism as it is to IT skills, says Arun Maria, chairman of Boston Consulting Group in India.",
                    Location = 1
                    },
                    new Paragraph
                    {
                        ParentId = 1,
                        Content = "Indian businessmen have used IT to create new business models that enable them to provide services in a more cost-effective way. This is not something that necessarily requires expensive technical research.",
                        Location = 2
                    },
                    new Paragraph
                    {
                        ParentId = 1,
                        Content = "He suggests the country’s computer services industry can simply outsource research to foreign universities if the capability is not available locally.",
                        Location = 3
                    },
                    new Paragraph
                    {
                        ParentId = 1,
                        Content = "“This way, I will have access to the best scientists in the world without having to produce them myself” says Mr. Maria.",
                        Location = 4
                    }
                };

                context.Paragraphs.AddRange(paragraph);

                context.SaveChanges();

            }
        }
    }
}
