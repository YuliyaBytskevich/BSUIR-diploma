namespace Obfuscation.Core.Entities
{
    internal class RenameItem
    {
        public RenameItemType Type { get; private set; }

        public string OriginalName { get; private set; }

        public string GeneratedName { get; private set; }

        public string Location { get; private set; }

        public RenameItem(RenameItemType itemType, string originalName, string newName)
        {
            Type = itemType;
            OriginalName = originalName;
            GeneratedName = newName;
        }

        public RenameItem(RenameItemType itemType, string originalName, string newName, string location)
        {
            Type = itemType;
            OriginalName = originalName;
            GeneratedName = newName;
            Location = location;
        }
    }
}
