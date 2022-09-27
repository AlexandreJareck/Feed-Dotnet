using Feed.Business.Interfaces;
using Feed.Business.Interfaces.Repositories;
using Feed.Business.Interfaces.Services;
using Feed.Business.Notifications;
using Feed.Business.Services;
using Feed.Data.Context;
using Feed.Data.Repository;

namespace Feed.Api.Configuration;
public static class DependencyInjectionConfig
{
    public static IServiceCollection ResolveDependencies(this IServiceCollection services)
    {
        services.AddScoped<FeedDbContext>();
        services.AddScoped<IAuthorRepository, AuthorRepository>();
        services.AddScoped<IContentRepository, ContentRepository>();
        services.AddScoped<IPostRepository, PostRepository>();

        services.AddScoped<INotifier, Notifier>();
        services.AddScoped<IAuthorService, AuthorService>();
        services.AddScoped<IContentService, ContentService>();
        services.AddScoped<IPostService, PostService>();

        return services;
    }
}

