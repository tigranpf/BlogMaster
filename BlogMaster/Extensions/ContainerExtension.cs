using BlogMaster.API.Core;
using BlogMaster.Application.UseCases.Commands.BlogPostReactions;
using BlogMaster.Application.UseCases.Commands.BlogPosts;
using BlogMaster.Application.UseCases.Commands.Comments;
using BlogMaster.Application.UseCases.Commands.Tags;
using BlogMaster.Application.UseCases.Commands.UseCases;
using BlogMaster.Application.UseCases.Commands.Users;
using BlogMaster.Application.UseCases.Queries;
using BlogMaster.Application;
using BlogMaster.Implementation.UseCases.Commands.EntityFramework.BlogPostCommands;
using BlogMaster.Implementation.UseCases.Commands.EntityFramework.BlogPostReactionCommands;
using BlogMaster.Implementation.UseCases.Commands.EntityFramework.CommentCommands;
using BlogMaster.Implementation.UseCases.Commands.EntityFramework.Tags;
using BlogMaster.Implementation.UseCases.Commands.EntityFramework.UseCases;
using BlogMaster.Implementation.UseCases.Commands.EntityFramework.UserCommands;
using BlogMaster.Implementation.UseCases.Queries.EntityFramework.BlogPostQueries;
using BlogMaster.Implementation.UseCases.Queries.EntityFramework.Logs;
using BlogMaster.Implementation.UseCases.Queries.EntityFramework.Users;
using BlogMaster.Implementation.Validators;

namespace BlogMaster.API.Extensions
{
    public static class ContainerExtension
    {
        public static void AddUseCases(this IServiceCollection services)
        {
            services.AddTransient<IUseCaseLogger, DbUseCaseLogger>();

            services.AddTransient<IGetOneBlogPostQuery, EfGetOneBlogPostQuery>();
            services.AddTransient<IGetBlogPostsQuery, EfGetBlogPostsQuery>();
            services.AddTransient<IAddBlogPostCommand, EfAddBlogPostCommand>();
            services.AddTransient<IEditBlogPostCommand, EfEditBlogPostCommand>();
            services.AddTransient<IDeleteBlogPostCommand, EfDeleteBlogPostCommand>();

            services.AddTransient<IAddCommentCommand, EfAddCommentCommand>();
            services.AddTransient<IDeleteCommentCommand, EfDeleteCommentCommand>();

            services.AddTransient<IAddTagCommand, EfAddTagCommand>();
            services.AddTransient<IDeleteTagCommand, EfDeleteTagCommand>();

            services.AddTransient<IRegisterUserCommand, EfRegisterUserCommand>();
            services.AddTransient<IDeleteUserCommand, EfDeleteUserCommand>();
            services.AddTransient<IEditUserCommand, EfEditUserCommand>();

            services.AddTransient<IAddBlogPostReactionCommand, EfAddBlogPostReactionCommand>();
            services.AddTransient<IDeleteBlogPostReactionCommand, EfDeleteBlogPostReactionCommand>();

            services.AddTransient<IAddUserUseCaseCommand, EfAddUserUseCaseCommand>();
            services.AddTransient<IDeleteUserUseCaseCommand, EfDeleteUserUseCaseCommand>();

            services.AddTransient<IGetAllUsersQuery, EfGetAllUsersQuery>();

            services.AddTransient<IGetAuditLogsQuery, EfGetAuditLogsQuery>();

            services.AddTransient<BlogPostReactionValidator>();
            services.AddTransient<AddTagValidator>();
            services.AddTransient<RegisterUserValidator>();
            services.AddTransient<AddBlogPostValidator>();
            services.AddTransient<EditBlogPostValidator>();
            services.AddTransient<EditUserValidator>();
        }
    }
}
