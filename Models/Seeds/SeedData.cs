using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Movies.Data;
using System;
using System.Linq;

namespace Movies.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MoviesContext(serviceProvider.GetRequiredService<DbContextOptions<MoviesContext>>()))
            {
                //Hay películas
                if(context.Movie.Any())
                {
                    return; //No corre la operación
                }

                context.Movie.AddRange(
                    new Movie
                    {
                        Title = "Star Wars",
                        ReleaseDate = DateTime.Parse("1970-05-05"),
                        Genre = "Sci-Fi",
                        Price = 2800
                    },
                    new Movie
                    {
                        Title = "Star Trek",
                        ReleaseDate = DateTime.Parse("1980-05-05"),
                        Genre = "Sci-Fi",
                        Price = 4500
                    },
                    new Movie
                    {
                        Title = "Riddik",
                        ReleaseDate = DateTime.Parse("1973-05-05"),
                        Genre = "Action",
                        Price = 3400
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
