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
                        ArticleId = 1,
                        Title = "Indian IT",
                        IsComplete = true,
                        CreateDate = DateTime.Now,
                        UpdateDate = DateTime.Now,
                    },

                    new RO
                    {
                        ArticleId = 2,
                        Title = "Foreign aid",
                        IsComplete = true,
                        CreateDate = DateTime.Now,
                        UpdateDate = DateTime.Now,
                    },

                    new RO
                    {
                        ArticleId =3,
                        Title = "Jet Stream",
                        IsComplete = true,
                        CreateDate = DateTime.Now,
                        UpdateDate = DateTime.Now,
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
                        Content = "This way, I will have access to the best scientists in the world without having to produce them myself” says Mr. Maria.",
                        Location = 4
                    },
                    //second article
                    new Paragraph
                    {
                        ParentId = 2,
                        Content = "But beginning in the 1990s, foreign aid had begun to slowly improve.",
                        Location = 1
                    },
                    new Paragraph
                    {
                        ParentId = 2,
                        Content = "Scrutiny by the news media shamed many developed countries into curbing their bad practices.",
                        Location = 2
                    },
                    new Paragraph
                    {
                        ParentId = 2,
                        Content = "Today, the projects of organizations like the World Bank are meticulously inspected by watchdog groups.",
                        Location = 3
                    },
                    new Paragraph
                    {
                        ParentId = 2,
                        Content = "Although the system is far from perfect, it is certainly more transparent than it was when foreign aid routinely helped ruthless dictators stay in power.",
                        Location = 4
                    },

                    //thrid article 
                    new Paragraph
                    {
                        ParentId = 3,
                        Content = "Jet stream, narrow, swift currents or tubes of air found at heights ranging from 7 to 8 mi (11.3–12.9 km) above the surface of the earth.",
                        Location = 1
                    },
                    new Paragraph
                    {
                        ParentId = 3,
                        Content = "They are caused by great temperature differences between adjacent air masses. There are four major jet streams.",
                        Location = 2
                    },
                    new Paragraph
                    {
                        ParentId = 3,
                        Content = "Instead of moving along a straight line, the jet stream flows in a wavelike fashion; the waves propagate eastward (in the Northern Hemisphere) at speeds considerably slower than the wind speed itself.",
                        Location = 3
                    },
                    new Paragraph
                    {
                        ParentId = 3,
                        Content = "Since the progress of an airplane is aided or impeded depending on whether tail winds or head winds are encountered.",
                        Location = 4
                    },
                    new Paragraph
                    {
                        ParentId = 3,
                        Content = "In the Northern Hemisphere the jet stream is sought by eastbound aircraft, in order to gain speed and save fuel, and avoided by westbound aircraft.",
                        Location = 5
                    }
                };

                context.Paragraphs.AddRange(paragraph);

                context.SaveChanges();

            }
        }
    }
}
