namespace DW_IAP
{
    public struct ItemTag
    {
        public ItemTag(string name)
        {
            Value = name;
        }
        /// Name is used to identify the item the default type is a string. It should be unique. Can be used to compare two items. 
        /// You can modify the object type to int or any other type if you want to use other type to identify the item.
        /// You must specify Equals and GetHashCode method if you want to use other type to identify the item.
        public string Value { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            return Value == ((ItemTag)obj).Value;
        }

        public readonly override int GetHashCode() => Value.GetHashCode();
    }
}
