using Microsoft.AspNetCore.Builder;
using WebMarkupMin.AspNetCore2;

namespace Syku.WebMarkupMin.Config
{
    public static class ApplicationBuilderExtensions
    {
        public static void UseDefaultWebMarkupMinConfig(this IApplicationBuilder app)
        {
            app.UseWebMarkupMin();
        }
    }
}