namespace Zork.Common
{
    public class Item
    {
        public string Name { get; }

        public string LookDescription { get; }

        public string InventoryDescription { get; }

        public bool CanOpen { get; }
        private bool _canOpen;

        public bool CanClose { get; set; }

        public Item(string name, string lookDescription, string inventoryDescription, bool canOpen, bool canClose)
        {
            Name = name;
            LookDescription = lookDescription;
            InventoryDescription = inventoryDescription;
            CanOpen = canOpen;
            CanClose = canClose;
        }

        public override string ToString() => Name;
    }
}