using System.Collections.Generic;
using System.Linq;
using Obfuscation.Core.Helpers;

namespace Obfuscation.Core.Entities
{
    internal static class RenameTable
    {
        private static List<RenameItem> collection = new List<RenameItem>();

        public static bool Add(RenameItem item)
        {
            if (item != null && !ContainsOriginal(item.OriginalName, item.Type))
            {
                collection.Add(item);
                return true;
            }

            return false;
        }

        public static bool Add(RenameItemType itemType, string originalName, string generatedName)
        {
            if (!ContainsOriginal(originalName, itemType))
            {
                collection.Add(new RenameItem(itemType, originalName, generatedName));
                return true;
            }

            return false;
        }

        public static RenameItem GetItem(string originalName, RenameItemType type)
        {
            return collection.FirstOrDefault(x => x.OriginalName == originalName && x.Type == type);
        }

        public static bool Add(RenameItemType itemType, string originalName, string generatedName, string location)
        {
            if (!ContainsOriginal(originalName, itemType))
            {
                collection.Add(new RenameItem(itemType, originalName, generatedName, location));
                return true;
            }

            return false;
        }

        public static bool ContainsOriginal(string originalName, RenameItemType type)
        {
            return collection.Any(x => x.OriginalName == originalName && x.Type == type);
        }


        public static bool ContainsOriginal(string originalName)
        {
            return collection.Any(x => x.OriginalName == originalName);
        }

        public static bool ContainsOriginal(string originalName, string location)
        {
            return collection.Any(x => x.OriginalName == originalName && x.Location == location);
        }

        public static bool ContainsGenerated(string generatedName)
        {
            return collection.Any(x => x.GeneratedName == generatedName);
        }

        public static bool ContainsGenerated(string generatedName, RenameItemType type)
        {
            return collection.Any(x => x.GeneratedName == generatedName && x.Type == type);
        }

        public static string GetGenerated(string originalName)
        {
            if (ContainsOriginal(originalName))
            {
                return collection.FirstOrDefault(x => x.OriginalName == originalName).GeneratedName;
            }

            return null;
        }

        public static string GetGenerated(string originalName, RenameItemType type)
        {
            if (ContainsOriginal(originalName, type))
            {
                return collection.FirstOrDefault(x => x.OriginalName == originalName && x.Type == type).GeneratedName;
            }

            return null;
        }

        public static string GetOriginal(string obfuscatedName)
        {
            var item = collection.FirstOrDefault(x => x.GeneratedName == obfuscatedName);
            if (item != null)
            {
                return item.OriginalName;
            }

            return null;
        }

        public static string GetOriginal(string obfuscatedName, RenameItemType type)
        {
            var item = collection.FirstOrDefault(x => x.GeneratedName == obfuscatedName && x.Type == type);
            if (item != null)
            {
                return item.OriginalName;
            }

            return null;
        }

        public static string GetGenerated(string originalName, string location)
        {
            var found = collection.FirstOrDefault(x => x.OriginalName == originalName && x.Location == location);
            if (found != null)
            {
                return found.GeneratedName;
            }

            return null;
        }

        public static void Refresh()
        {
            collection = new List<RenameItem>();
        }

        public static string ToString()
        {
            string result = "";
            result += "+--------------------+------------------------------+------------------------------+--------------------------------------------------------------------------------+\n";
            result += "|        TYPE        |           ORIGINAL           |          OBFUSCATED          |                                   LOCATION                                     |\n";
            result += "+--------------------+------------------------------+------------------------------+--------------------------------------------------------------------------------+\n";
            foreach(var item in collection)
            {
                result += string.Format("|{0}|{1}|{2}|{3}|\n", StringHelper.FitLength(item.Type.ToString(), 20), StringHelper.FitLength(item.OriginalName, 30), StringHelper.FitLength(item.GeneratedName, 30), StringHelper.FitLength(item.Location, 80));
                result += "+--------------------+------------------------------+------------------------------+--------------------------------------------------------------------------------+\n";
            }

            return result;
        }

    }
}
