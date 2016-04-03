using System.Globalization;
using System.Reflection;
using System.Resources;

namespace IEP.Helpers
{
    public static class LocalizationHelper
    {
        private static readonly ResourceManager Manager;

        static LocalizationHelper()
        {
            Manager = new ResourceManager("IEP.App_GlobalResources.App_GlobalResources", Assembly.GetExecutingAssembly());
        }

        private static string GetResourceValue(string key)
        {
            return Manager.GetString(key, CultureInfo.CurrentCulture);
        }

        public static string AppPurpose => GetResourceValue("AppPurpose");
    }
}