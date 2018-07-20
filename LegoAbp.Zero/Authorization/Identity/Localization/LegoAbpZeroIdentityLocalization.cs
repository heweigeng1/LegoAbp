using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;
using System.Reflection;

namespace LegoAbp.Zero.Authorization.Identity.Localization
{
    public static class LegoAbpZeroIdentityLocalization
    {
        /// <summary>
        /// 配置identity本地化xml信息
        /// </summary>
        /// <param name="localizationConfiguration"></param>
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
          var ass= typeof(LegoAbpZeroIdentityLocalization).GetAssembly();
            var abc = new CatDictionaryBasedLocalizationSource(
                    LegoAbpZeroConsts.LocalizationIdentitySourceName,
                    new XmlFileLocalizationDictionaryProvider(
                        @"F:\github\LegoAbp\LegoAbp.Zero\Authorization\Identity\Localization\SourceExt\"
                        ));
            localizationConfiguration.Sources.Add(new CatDictionaryBasedLocalizationSource(
                    LegoAbpZeroConsts.LocalizationIdentitySourceName,
                    new XmlFileLocalizationDictionaryProvider(
                        @"F:\github\LegoAbp\LegoAbp.Zero\Authorization\Identity\Localization\SourceExt\"
                        )));
        }
    }
}
