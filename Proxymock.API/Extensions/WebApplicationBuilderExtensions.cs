namespace Proxymock.API.Extensions;

public static class WebApplicationBuilderExtensions
{
    private static IApplicationBuilder BuildDev(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        return app;
    }
    
    public static IApplicationBuilder UseMiddlewares(this WebApplication app)
    {
        app.BuildDev();
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        app.UseStatusCodePages();
        
        return app;
    }
}