using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace Imdb.Controllers
{
    public class MovieController : ApiController
    {
        [ActionName("Categories")]
        [ResponseType(typeof(Category))]
        public IHttpActionResult GetCategories()
        {
            var categories = MovieCategorySource();
            return this.Ok(categories);
        }
        // GET: Movies

        [ActionName("MovieListbyCategory")]
        [ResponseType(typeof(Movie))]
        public IHttpActionResult GetMoviesByCategory(int catId)
        {
            var movies = MovieSource().Where(w => w.CategoryId == catId).ToList();
            return this.Ok(movies);
        }

        [ActionName("GetMovie")]
        [ResponseType(typeof(Movie))]
        public IHttpActionResult GetMovie(int id)
        {
            var movie = MovieSource().Where(w => w.Id == id).SingleOrDefault();
            return this.Ok(movie);
        }

        [ActionName("GetMovieByName")]
        [ResponseType(typeof(Movie))]
        public IHttpActionResult GetMovieByName(string key)
        {
            var movies = MovieSource().Where(w => w.Name.ToLower().Contains(key.ToLower())).ToList();
            return this.Ok(movies);
        }

        [ActionName("GetCategoryName")]
        [ResponseType(typeof(string))]
        public IHttpActionResult GetCategoryName(int id)
        {
            var movieCat = MovieCategorySource().Where(w => w.Id == id).SingleOrDefault();
                
            return this.Ok(movieCat.Name);
        }

        // data source for moview categories
        private static List<Category> MovieCategorySource()
        {
            return new List<Category>
                                {
                                    new Category { Id = 1 , Name = "Comedy" },
                                    new Category { Id = 2 , Name = "Romantic"},
                                    new Category { Id = 3 , Name = "Musicals"},
                                    new Category { Id = 4 , Name = "Sci-Fi" }
                                };
        }

        //data source for movies
        private static List<Movie> MovieSource()
        {
            return new List<Movie>
                                {
                                    new Movie { Id = 1, CategoryId = 1, Name = "Deadpool", Director = "Tim Miller", Writer = "Rhett Reese, Paul Wernick", ReleaseDate = new DateTime(2016, 2, 12, 0, 0, 0), Description = "A fast-talking mercenary with a morbid sense of humor is subjected to a rogue experiment that leaves him with accelerated healing powers and a quest for revenge.", ImageLink = "https://images-na.ssl-images-amazon.com/images/M/MV5BMjQyODg5Njc4N15BMl5BanBnXkFtZTgwMzExMjE3NzE@._V1_SY1000_SX686_AL_.jpg"},
                                    new Movie { Id = 2, CategoryId = 1, Name = "Forrest Gump", Director = "Robert Zemeckis", Writer = "Winston Groom", ReleaseDate = new DateTime(1994, 7, 6, 0, 0, 0), Description = "While not intelligent, Forrest Gump has accidentally been present at many historic moments, but his true love, Jenny Curran, eludes him.", ImageLink = "https://images-na.ssl-images-amazon.com/images/M/MV5BYThjM2MwZGMtMzg3Ny00NGRkLWE4M2EtYTBiNWMzOTY0YTI4XkEyXkFqcGdeQXVyNDYyMDk5MTU@._V1_SY1000_CR0,0,757,1000_AL_.jpg"},
                                    new Movie { Id = 3, CategoryId = 1, Name = "The Bucket List", Director = "Rob Reiner", Writer = "Justin Zackham", ReleaseDate = new DateTime(2008, 1, 11, 0, 0, 0) , Description = "Two terminally ill men escape from a cancer ward and head off on a road trip with a wish list of to-dos before they die.", ImageLink = "https://images-na.ssl-images-amazon.com/images/M/MV5BMTY2NTUyMjIyNF5BMl5BanBnXkFtZTYwNzYwMDM4._V1_.jpg"},
                                    new Movie { Id = 4, CategoryId = 1, Name = "Kingsman: The Secret Service", Director = "Matthew Vaughn", Writer = "Jane Goldman, Matthew Vaughn", ReleaseDate = new DateTime(2015, 2, 13, 0,0,0), Description = "A spy organization recruits an unrefined, but promising street kid into the agency's ultra-competitive training program, just as a global threat emerges from a twisted tech genius.", ImageLink = "https://images-na.ssl-images-amazon.com/images/M/MV5BMTkxMjgwMDM4Ml5BMl5BanBnXkFtZTgwMTk3NTIwNDE@._V1_SY1000_CR0,0,675,1000_AL_.jpg"},
                                    new Movie { Id = 5, CategoryId = 2, Name = "Me Before You", Director = "Thea Sharrock", Writer = "Jojo Moyes", ReleaseDate = new DateTime(2016, 6,3,0,0,0), Description = "A girl in a small town forms an unlikely bond with a recently-paralyzed man she's taking care of.", ImageLink = "https://images-na.ssl-images-amazon.com/images/M/MV5BMTQ2NjE4NDE2NV5BMl5BanBnXkFtZTgwOTcwNDE5NzE@._V1_SY1000_CR0,0,674,1000_AL_.jpg"},
                                    new Movie { Id = 6, CategoryId = 2, Name = "Titanic", Director = "James Cameron", Writer = "James Cameron", ReleaseDate = new DateTime(1997, 12, 19, 0,0,0), Description = "A seventeen-year-old aristocrat falls in love with a kind but poor artist aboard the luxurious, ill-fated R.M.S. Titanic.", ImageLink = "https://images-na.ssl-images-amazon.com/images/M/MV5BMDdmZGU3NDQtY2E5My00ZTliLWIzOTUtMTY4ZGI1YjdiNjk3XkEyXkFqcGdeQXVyNTA4NzY1MzY@._V1_SY1000_CR0,0,671,1000_AL_.jpg"},
                                    new Movie { Id = 7, CategoryId = 2, Name = "The Princess Bride", Director = "Rob Reiner", Writer = "William Goldman ", ReleaseDate = new DateTime(1987, 10, 9,0,0,0), Description = "While home sick in bed, a young boy's grandfather reads him a story called The Princess Bride.", ImageLink = "https://images-na.ssl-images-amazon.com/images/M/MV5BMGM4M2Q5N2MtNThkZS00NTc1LTk1NTItNWEyZjJjNDRmNDk5XkEyXkFqcGdeQXVyMjA0MDQ0Mjc@._V1_SY1000_CR0,0,676,1000_AL_.jpg"},
                                    new Movie { Id = 8, CategoryId = 2, Name = "The Notebook", Director = "Nick Cassavetes", Writer = "Jeremy Leven", ReleaseDate = new DateTime(2004, 6, 25, 0,0,0), Description = "A poor yet passionate young man falls in love with a rich young woman, giving her a sense of freedom, but they are soon separated because of their social differences.", ImageLink = "https://images-na.ssl-images-amazon.com/images/M/MV5BMTk3OTM5Njg5M15BMl5BanBnXkFtZTYwMzA0ODI3._V1_.jpg"},
                                    new Movie { Id = 9, CategoryId = 3, Name = "Beauty and the Beast", Director = "Bill Condon", Writer = "Stephen Chbosky ",ReleaseDate = new DateTime(2017, 3, 17, 0,0,0), Description="An adaptation of the fairy tale about a monstrous-looking prince and a young woman who fall in love.", ImageLink ="https://images-na.ssl-images-amazon.com/images/M/MV5BMTUwNjUxMTM4NV5BMl5BanBnXkFtZTgwODExMDQzMTI@._V1_SY1000_CR0,0,674,1000_AL_.jpg" },
                                    new Movie { Id = 10, CategoryId = 3, Name = "La La Land", Director = "Damien Chazelle", Writer = "Damien Chazelle", ReleaseDate = new DateTime(2016, 12, 25, 0,0,0), Description="Two proper L.A. dreamers, a suavely charming soft-spoken jazz pianist and a brilliant vivacious playwright, while waiting for their big break, attempt to reconcile aspirations and relationship in a magical old-school romance.", ImageLink = "https://images-na.ssl-images-amazon.com/images/M/MV5BMzUzNDM2NzM2MV5BMl5BanBnXkFtZTgwNTM3NTg4OTE@._V1_SY1000_SX675_AL_.jpg" },
                                    new Movie { Id = 11, CategoryId = 3, Name = "Les Misérables", Director = "Tom Hooper", Writer = "William Nicholson", ReleaseDate = new DateTime(2012, 12,25, 0,0,0), Description = "In 19th-century France, Jean Valjean, who for decades has been hunted by the ruthless policeman Javert after breaking parole, agrees to care for a factory worker's daughter. The decision changes their lives forever.", ImageLink = "https://images-na.ssl-images-amazon.com/images/M/MV5BMTQ4NDI3NDg4M15BMl5BanBnXkFtZTcwMjY5OTI1OA@@._V1_SY1000_CR0,0,674,1000_AL_.jpg"},
                                    new Movie { Id = 12, CategoryId = 3, Name = "The Lion King", Director = "Roger Allers, Rob Minkoff", Writer = "Irene Mecchi", ReleaseDate = new DateTime(1994, 6, 24, 0,0,0), Description = "Lion cub and future king Simba searches for his identity. His eagerness to please others and penchant for testing his boundaries sometimes gets him into trouble.", ImageLink = "https://images-na.ssl-images-amazon.com/images/M/MV5BYTYxNGMyZTYtMjE3MS00MzNjLWFjNmYtMDk3N2FmM2JiM2M1XkEyXkFqcGdeQXVyNjY5NDU4NzI@._V1_SY1000_CR0,0,673,1000_AL_.jpg"},
                                    new Movie { Id = 13, CategoryId = 4, Name = "Logan", Director = "James Mangold", Writer = "James Mangold", ReleaseDate = new DateTime(2017, 3,3,0,0,0), Description="In the near future, a weary Logan cares for an ailing Professor X, somewhere on the Mexican border. However, Logan's attempts to hide from the world, and his legacy, are upended when a young mutant arrives, pursued by dark forces.", ImageLink = "https://images-na.ssl-images-amazon.com/images/M/MV5BMjQwODQwNTg4OV5BMl5BanBnXkFtZTgwMTk4MTAzMjI@._V1_.jpg" },
                                    new Movie { Id = 14, CategoryId = 4, Name = "Wonder Woman", Director = "Patty Jenkins", Writer = "Allan Heinberg", ReleaseDate = new DateTime(2017, 6, 2, 0, 0, 0), Description="Before she was Wonder Woman, she was Diana, princess of the Amazons, trained warrior. When a pilot crashes and tells of conflict in the outside world, she leaves home to fight a war, discovering her full powers and true destiny.", ImageLink = "https://images-na.ssl-images-amazon.com/images/M/MV5BNDFmZjgyMTEtYTk5MC00NmY0LWJhZjktOWY2MzI5YjkzODNlXkEyXkFqcGdeQXVyMDA4NzMyOA@@._V1_SY1000_SX675_AL_.jpg" },
                                    new Movie { Id = 15, CategoryId = 4, Name = "Inception ", Director = "Christopher Nolan", Writer = "Christopher Nolan", ReleaseDate = new DateTime(2010, 7, 16, 0,0,0), Description = "A thief, who steals corporate secrets through use of dream-sharing technology, is given the inverse task of planting an idea into the mind of a CEO.", ImageLink = "https://images-na.ssl-images-amazon.com/images/M/MV5BMjAxMzY3NjcxNF5BMl5BanBnXkFtZTcwNTI5OTM0Mw@@._V1_SY1000_CR0,0,675,1000_AL_.jpg"},
                                    new Movie { Id = 16, CategoryId = 4, Name = "The Matrix", Director = "Lana Wachowski, Lilly Wachowski", Writer = "Lana Wachowski, Lilly Wachowski", ReleaseDate = new DateTime(1999, 3, 31, 0,0,0), Description = "A computer hacker learns from mysterious rebels about the true nature of his reality and his role in the war against its controllers.", ImageLink = "https://images-na.ssl-images-amazon.com/images/M/MV5BNzQzOTk3OTAtNDQ0Zi00ZTVkLWI0MTEtMDllZjNkYzNjNTc4L2ltYWdlXkEyXkFqcGdeQXVyNjU0OTQ0OTY@._V1_SY1000_CR0,0,665,1000_AL_.jpg"},


                                };
        }
    }

    public class Movie
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Director { get; set; }
        public string Writer { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Description { get; set; }
        public string ImageLink { get; set; }
    }

    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}