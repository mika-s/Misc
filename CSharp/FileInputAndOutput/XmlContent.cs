namespace FileInputAndOutput
{
    /// <summary>
    /// Enum used for testing XML content. Reading and parsing enums.
    /// </summary>
    public enum XmlEnumValues { EnumValue1, EnumValue2 };

    /// <summary>
    /// Class used for testing XML content.
    /// </summary>
    public sealed class XmlContent
    {
        public XmlContent(int childValue1, string childValue2, XmlEnumValues childValue3)
        {
            ChildValue1 = childValue1;
            ChildValue2 = childValue2;
            ChildValue3 = childValue3;
        }

        public int ChildValue1 { get; set; }
        public string ChildValue2 { get; set; }
        public XmlEnumValues ChildValue3 { get; set; }
    }
}
