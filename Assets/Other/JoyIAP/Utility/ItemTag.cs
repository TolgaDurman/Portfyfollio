namespace JoyIAP
{
    public struct ItemTag
    {
        public ItemTag(string name)
        {
            Name = name;
        }
        /// Name is used to identify the item the default type is a string. It should be unique. Can be used to compare two items. 
        /// You can modify the object type to int or any other type if you want to use other type to identify the item.
        /// You must specify Equals and GetHashCode method if you want to use other type to identify the item.
        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            return Name == ((ItemTag)obj).Name;
        }

        public readonly override int GetHashCode() => Name.GetHashCode();
    }
}
