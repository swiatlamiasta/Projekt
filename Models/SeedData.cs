using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Projekt.Models;
using Projekt.Data;

namespace Projekt.Models
{
    public class SeedData
    {
        public static void InitializeMovieStudios(IServiceProvider serviceProvider)
        {
            using (var context = new MovieContext(
                serviceProvider.GetRequiredService<DbContextOptions<MovieContext>>()))
            {
                context.MovieStudio.AddRange(
                        new MovieStudio
                        {
                            Name = "Walt Disney Pictures",
                            Founded = 1923
                        },

                        new MovieStudio
                        {
                            Name = "Warner Bros. Pictures",
                            Founded = 1923
                        },

                        new MovieStudio
                        {
                            Name = "Universal Pictures",
                            Founded = 1912
                        },

                      new MovieStudio
                      {
                          Name = "20th Century Fox",
                          Founded = 1935
                      }
                   );
                context.SaveChanges();
            }
        }
        public static void InitializeMovies(IServiceProvider serviceProvider)
        {
            using (var context1 = new MovieContext(
                serviceProvider.GetRequiredService<DbContextOptions<MovieContext>>()))
            {

                context1.Movie.AddRange(
                     new Movie
                     {
                         Title = "When Harry Met Sally",
                         ReleaseDate = DateTime.Parse("1989-1-11"),
                         Genre = "Romantic Comedy",
                         Price = 7.99M,
                         MovieStudioID = 30
                     },

                     new Movie
                     {
                         Title = "Ghostbusters ",
                         ReleaseDate = DateTime.Parse("1984-3-13"),
                         Genre = "Comedy",
                         Price = 8.99M,
                         MovieStudioID = 30
                     },

                     new Movie
                     {
                         Title = "Ghostbusters 2",
                         ReleaseDate = DateTime.Parse("1986-2-23"),
                         Genre = "Comedy",
                         Price = 9.99M,
                         MovieStudioID = 30
                     },

                   new Movie
                   {
                       Title = "Rio Bravo",
                       ReleaseDate = DateTime.Parse("1959-4-15"),
                       Genre = "Western",
                       Price = 3.99M,
                       MovieStudioID = 30
                   }
                );
                context1.SaveChanges();
            }
        }
    }
}