using System.IO;
using Cassette.Configuration;
using Cassette.Scripts;
using Cassette.Stylesheets;

namespace MVC4
{
    /// <summary>
    /// Configures the Cassette asset modules for the web application.
    /// </summary>
    public class CassetteConfiguration : ICassetteConfiguration
    {
        public void Configure(BundleCollection bundles, CassetteSettings settings)
        {

            bundles.Add<StylesheetBundle>("Content");
            bundles.Add<ScriptBundle>("Scripts", new FileSearch { SearchOption = SearchOption.TopDirectoryOnly });
            bundles.AddPerIndividualFile<ScriptBundle>("Scripts/Pages");
            
            bundles.AddUrlWithLocalAssets(
                "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.7.1.min.js",
                new LocalAssetSettings
                    {
                        Path = "Scripts/CDN/jquery-1.7.1.js",
                        FallbackCondition = "!window.jQuery"
                    }
            );

             bundles.AddUrlWithLocalAssets(
                "http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.17/jquery-ui.min.js",
                new LocalAssetSettings
                    {
                        Path = "Scripts/CDN/jquery-ui-1.8.17.js",
                        FallbackCondition = "!window.jQuery.ui"
                    }
            );

             bundles.AddUrlWithAlias(
                "http://ajax.aspnetcdn.com/ajax/jquery.validate/1.9/jquery.validate.min.js",
                "jquery.validate"
                //new LocalAssetSettings
                //{
                //    Path = "Scripts/CDN/jquery.validate-1.9.js",
                //    FallbackCondition = "!window.jQuery.fn.validate"
                //}
            );

             bundles.AddUrlWithAlias(
                "http://ajax.aspnetcdn.com/ajax/jquery.mobile/1.0/jquery.mobile-1.0.min.js",
                "jquery.mobile"
                //new LocalAssetSettings
                //{
                //    Path = "Scripts/CDN/jquery.mobile-1.0.js",
                //    FallbackCondition = "!window.jQuery"
                //}
            );

            
            bundles.AddUrlWithAlias(
                "http://ajax.aspnetcdn.com/ajax/mvc/3.0/jquery.unobtrusive-ajax.min.js",
                "jquery.unobtrusive-ajax"
                //new LocalAssetSettings
                //{
                //    Path = "Scripts/CDN/jquery.unobtrusive-ajax.js",
                //    FallbackCondition = "!window.jQuery"
                //}
            );

            
            bundles.AddUrlWithAlias(
                "http://ajax.aspnetcdn.com/ajax/mvc/3.0/jquery.validate.unobtrusive.min.js",
                "jquery.validate.unobtrusive"
                //new LocalAssetSettings
                //{
                //    Path = "Scripts/CDN/jquery.validate.unobtrusive.js",
                //    FallbackCondition = "!window.jQuery"
                //}
            );

            
            // bundles.AddUrlWithLocalAssets(
            //    "http://ajax.aspnetcdn.com/ajax/mvc/3.0/MicrosoftMvcAjax.debug.js",
            //    new LocalAssetSettings
            //    {
            //        Path = "Scripts/CDN/MicrosoftMvcAjax.js",
            //        FallbackCondition = "!window.jQuery"
            //    }
            //);


            

        }
    }
}