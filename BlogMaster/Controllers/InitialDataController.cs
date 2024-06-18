using Azure;
using BlogMaster.DataAccess;
using BlogMaster.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlogMaster.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class InitialDataController : ControllerBase
    {

        private BMContext _context;

        public InitialDataController(BMContext context)           
        {
            _context = context;
        }

        public IActionResult Post()
        {
            if (_context.Tags.Any())
            {
                return Conflict();
            }

            List<Tag> tags = new List<Tag>
                {
                    new Tag{Title="Rock"},
                    new Tag{Title="Van Halen"},
                    new Tag{Title="Anniversaries"},
                    new Tag{Title="Culture"},
                    new Tag{Title="90s"},
                    new Tag{Title="History"},
                    new Tag{Title="Drums"},
                    new Tag{Title="Black Sabbath"},
                };

            List<Role> roles = new List<Role>
                {
                    new Role{Title="admin"},
                    new Role{Title="moderator"},
                    new Role{Title="user"}
                };

            var adminUseCases = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18 };
            var moderatorUseCases = new List<int> { 1, 2, 3, 4, 5, 6, 7, 15, 16 };
            var userUseCases = new List<int> { 1, 2, 3, 4, 5, 6, 7, 15, 16 };

            var roleUseCases = new List<RoleUseCase>();

            var roleUseCasesMap = new Dictionary<int, List<int>>
            {
                { 0, adminUseCases },
                { 1, moderatorUseCases },
                { 2, userUseCases }
            };

            foreach (var entry in roleUseCasesMap)
            {
                var role = roles.ElementAt(entry.Key);
                foreach (var useCaseId in entry.Value)
                {
                    roleUseCases.Add(new RoleUseCase
                    {
                        Role = role,
                        UseCaseId = useCaseId
                    });
                }
            }


            

            List<Image> images = new List<Image>
                {
                    new Image { Path = "photo1.jpg", Description = "Image description 1" },
                    new Image { Path = "photo2.jpg", Description = "Image description 2" },
                    new Image { Path = "photo3.jpg", Description = "Image description 3" },
                    new Image { Path = "photo4.jpg", Description = "Image description 4" },
                    new Image { Path = "photo5.jpg", Description = "Image description 5" },
                    new Image { Path = "photo6.jpg", Description = "Image description 6" },
                    new Image { Path = "photo7.jpg", Description = "Image description 7" },
                    new Image { Path = "photo8.jpg", Description = "Image description 8" },
                    new Image { Path = "photo9.jpg", Description = "Image description 9" },
                    new Image { Path = "photo10.jpg", Description = "Image description 10" },
                    new Image { Path = "photo11.jpg", Description = "Image description 11" },
                    new Image { Path = "photo12.jpg", Description = "Image description 12" },
                    new Image { Path = "photo13.jpg", Description = "Image description 13" },
                    new Image { Path = "photo14.jpg", Description = "Image description 14" },
                    new Image { Path = "photo15.jpg", Description = "Image description 15" },
                    new Image { Path = "photo16.jpg", Description = "Image description 16" },
                    new Image { Path = "photo17.jpg", Description = "Image description 17" },
                    new Image { Path = "photo18.jpg", Description = "Image description 18" }
                };
            List<User> users = new List<User>
                {
                    new User{FirstName="Admin", LastName="Administratovic", Username="admin", Password=BCrypt.Net.BCrypt.HashPassword("Sifra123"), ProfilePicture=images.ElementAt(1),
                    Email="admin@gmail.com", Role=roles.First()},
                    new User{FirstName="Moderator", LastName="Modic", Username="moderator", Password=BCrypt.Net.BCrypt.HashPassword("Sifra123"), ProfilePicture=images.ElementAt(2),
                    Email="moderator@gmail.com", Role=roles.ElementAt(1)},
                    new User{FirstName="Pera", LastName="Peric", Username="peraperic", Password=BCrypt.Net.BCrypt.HashPassword("Sifra123"), ProfilePicture=images.ElementAt(3),
                    Email="pera@gmail.com", Role=roles.ElementAt(2)},
                    new User{FirstName="Mika", LastName="Mikic", Username="mikamikic", Password=BCrypt.Net.BCrypt.HashPassword("Sifra123"), ProfilePicture=images.ElementAt(4),
                    Email="mika@gmail.com", Role=roles.ElementAt(2)},
                };

            var allUsersUseCase = new List<UserUseCase>();

            var userUseCasesMap = new Dictionary<int, List<int>>
            {
                { 3, userUseCases },
                { 2, userUseCases },
                { 1, moderatorUseCases },
                { 0, adminUseCases }
            };

            foreach (var entry in userUseCasesMap)
            {
                var user = users.ElementAt(entry.Key);
                foreach (var useCaseId in entry.Value)
                {
                    allUsersUseCase.Add(new UserUseCase
                    {
                        User = user,
                        UseCaseId = useCaseId
                    });
                }
            }


            List<Reaction> reactions = new List<Reaction>
                {
                    new Reaction{Title="Like",Image=images.ElementAt(5),CreatedAt=DateTime.UtcNow},
                    new Reaction{Title="Dislike",Image=images.ElementAt(6),CreatedAt=DateTime.UtcNow},
                    new Reaction{Title="Rock",Image=images.ElementAt(7),CreatedAt=DateTime.UtcNow},
                    new Reaction{Title="Love",Image=images.ElementAt(8),CreatedAt=DateTime.UtcNow},
                };

            List<BlogPost> blogPosts = new List<BlogPost>
                {
                    new BlogPost{Title="Smashing Pumpinks", Text="The Smashing Pumpkins appeared to be putting their best-known lineup back together in early 2018 when a nasty dispute re-ignited between stalwart frontman Billy Corgan and bassist D'arcy Wretzky. Of course, they'd never been known for pulling punches.", User=users.ElementAt(2)},
                    new BlogPost{Title="Kulick's secret", Text="Kulick held onto his secret for many years. \"It was important to me that when they said ‘This has to be between us and us only,' that I’m going to keep my word,\" he told UCR in 2018. \"It’s all about integrity, and that’s how I’m able to keep going.", User=users.ElementAt(2)},
                    new BlogPost{Title="RHCP", Text="Thing is, that's a relatively lengthy tenure for guitarists in this particular band – though most of them have been similarly erased. \"I still love those guys to death,\" Navarro told MTV in 1995, \"and being a Chili Pepper was one of the best experiences of my life.\" When they were inducted into the Hall of Fame, however, Navarro was conspicuously absent.", User=users.ElementAt(3)},
                    new BlogPost{Title="Keep my word", Text="\"It was important to me that when they said ‘This has to be between us and us only,' that I’m going to keep my word,\" he told UCR in 2018. \"It’s all about integrity, and that’s how I’m able to keep going.", User=users.ElementAt(3)}
                };

            List<BlogPostImage> blogPostImages = new List<BlogPostImage>
                {
                    new BlogPostImage{BlogPost=blogPosts.ElementAt(0),Image=images.ElementAt(9)},
                    new BlogPostImage{BlogPost=blogPosts.ElementAt(0),Image=images.ElementAt(10)},
                    new BlogPostImage{BlogPost=blogPosts.ElementAt(1),Image=images.ElementAt(11)},
                };

            List<BlogPostTag> blogPostTags = new List<BlogPostTag>
                {
                    new BlogPostTag{BlogPost=blogPosts.First(), Tag=tags.ElementAt(1) },
                    new BlogPostTag{BlogPost=blogPosts.First(), Tag=tags.ElementAt(2) },
                    new BlogPostTag{BlogPost=blogPosts.First(), Tag=tags.ElementAt(3) },
                    new BlogPostTag{BlogPost=blogPosts.ElementAt(1), Tag=tags.ElementAt(1) },
                    new BlogPostTag{BlogPost=blogPosts.ElementAt(1), Tag=tags.First() },
                    new BlogPostTag{BlogPost=blogPosts.ElementAt(2), Tag=tags.First() },
                    new BlogPostTag{BlogPost=blogPosts.ElementAt(3), Tag=tags.ElementAt(1) },
                };

            List<BlogPostReaction> blogPostReactions = new List<BlogPostReaction>
                {
                    new BlogPostReaction{BlogPost=blogPosts.First(), Reaction=reactions.ElementAt(1), User=users.ElementAt(1)},
                    new BlogPostReaction{BlogPost=blogPosts.First(), Reaction=reactions.ElementAt(2), User=users.ElementAt(2)},
                    new BlogPostReaction{BlogPost=blogPosts.First(), Reaction=reactions.ElementAt(3), User=users.ElementAt(3)},
                    new BlogPostReaction{BlogPost=blogPosts.ElementAt(1), Reaction=reactions.ElementAt(1), User=users.ElementAt(2)},
                    new BlogPostReaction{BlogPost=blogPosts.ElementAt(2), Reaction=reactions.ElementAt(2), User=users.ElementAt(3)},                  
                };




            List<Comment> comments = new List<Comment>
                {
                    new Comment{BlogPost=blogPosts.First(), Text="Great Article, I really like it",User=users.First(),},
                    new Comment{BlogPost=blogPosts.ElementAt(1), Text="Thank you for this amazing info",User=users.ElementAt(1)},
                    new Comment{BlogPost=blogPosts.ElementAt(2), Text="I didn't get the point",User=users.ElementAt(2)},
                    new Comment{BlogPost=blogPosts.ElementAt(3), Text="Great Job!",User=users.ElementAt(2)},
                    new Comment{BlogPost=blogPosts.ElementAt(3), Text="Ajmeeeeee",User=users.ElementAt(3)},
                };

            List<Comment> childrenComments = new List<Comment>
                {
                    new Comment{BlogPost=blogPosts.ElementAt(1), Text="Thank you!",User=users.ElementAt(3),Parent=comments.First()},
                    new Comment{BlogPost=blogPosts.ElementAt(1), Text="Do you really think that??",User=users.ElementAt(2),Parent=comments.First()},
                    new Comment{BlogPost=blogPosts.ElementAt(2), Text="Really??",User=users.ElementAt(3),Parent=comments.ElementAt(2)},
                };


            _context.Tags.AddRange(tags);
            _context.Images.AddRange(images);
            _context.Roles.AddRange(roles);
            _context.Users.AddRange(users);          
            _context.Reactions.AddRange(reactions);
            _context.BlogPostImages.AddRange(blogPostImages);
            _context.BlogPostReactions.AddRange(blogPostReactions);
            _context.BlogPosts.AddRange(blogPosts);
            _context.BlogPostTags.AddRange(blogPostTags);
            _context.Comments.AddRange(comments);
            _context.Comments.AddRange(childrenComments);

            _context.RoleUseCases.AddRange(roleUseCases);
            _context.UserUseCases.AddRange(allUsersUseCase);

            _context.SaveChanges();

            return Ok();
        }

        
    }
}
