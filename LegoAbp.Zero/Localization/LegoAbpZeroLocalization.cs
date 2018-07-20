using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using System.Reflection;

namespace LegoAbp.Zero.Localization
{
    public static class LegoAbpZeroLocalization
    {
        /// <summary>
        /// 配置本地化xml信息
        /// </summary>
        /// <param name="localizationConfiguration"></param>
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(new DictionaryBasedLocalizationSource(
                    LegoAbpZeroConsts.LocalizationSourceName,
                    new XmlFileLocalizationDictionaryProvider(
                        @"F:\github\LegoAbp\LegoAbp.Zero\Localization\Source\"
                        )));
        }
    }
}
