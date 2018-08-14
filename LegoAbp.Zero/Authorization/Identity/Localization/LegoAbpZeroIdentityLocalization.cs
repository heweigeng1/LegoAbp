using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using System;
using System.IO;
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
             localizationConfiguration.Sources.Add(new DictionaryBasedLocalizationSource(
                    LegoAbpZeroConsts.LocalizationIdentitySourceName,
                    new XmlFileLocalizationDictionaryProvider(
                        Path.GetDirectoryName(typeof(LegoAbpZeroModule).Assembly.Location) + @"\Authorization\Identity\Localization\SourceExt\"
                        )));
        }
    }
}
