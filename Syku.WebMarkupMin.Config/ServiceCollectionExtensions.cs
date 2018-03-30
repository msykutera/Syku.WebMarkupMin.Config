using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.IO.Compression;
using WebMarkupMin.AspNet.Common.Compressors;
using WebMarkupMin.AspNetCore2;
using WebMarkupMin.Core;
using WebMarkupMin.NUglify;

namespace Syku.WebMarkupMin.Config
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureDefaultWebMarkupMinConfig(this IServiceCollection services)
        {
            services.AddWebMarkupMin(o =>
            {
                o.DisablePoweredByHttpHeaders = true;
                o.AllowCompressionInDevelopmentEnvironment = true;
                o.AllowMinificationInDevelopmentEnvironment = true;
            })
            .AddHtmlMinification(o =>
            {
                var settings = o.MinificationSettings;
                var jsSettings = new NUglifyJsMinificationSettings
                {
                    LocalRenaming = LocalRenaming.CrunchAll,
                    RemoveUnneededCode = true
                };

                settings.RemoveEmptyAttributes = false;
                settings.MinifyAngularBindingExpressions = true;
                settings.RemoveHtmlComments = true;
                settings.RemoveOptionalEndTags = true;
                settings.WhitespaceMinificationMode = WhitespaceMinificationMode.Aggressive;
                settings.AttributeQuotesRemovalMode = HtmlAttributeQuotesRemovalMode.Html5;
                o.CssMinifierFactory = new NUglifyCssMinifierFactory();
                o.JsMinifierFactory = new NUglifyJsMinifierFactory(jsSettings);
            })
            .AddHttpCompression(o =>
            {
                o.CompressorFactories = new List<ICompressorFactory>
                {
                    new BrotliCompressorFactory(new BrotliCompressionSettings { Level = CompressionLevel.Fastest }),
                    new DeflateCompressorFactory(new DeflateCompressionSettings { Level = CompressionLevel.Fastest }),
                    new GZipCompressorFactory(new GZipCompressionSettings { Level = CompressionLevel.Fastest }),
                };
            });
        }
    }
}