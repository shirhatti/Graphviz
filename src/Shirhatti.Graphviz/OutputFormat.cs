namespace Shirhatti.Graphviz
{
    public class OutputFormat
    {
        private OutputFormat(string value) => Value = value;

        internal string Value { get;}

        public static OutputFormat Svg { get { return new OutputFormat("svg"); } }
        public static OutputFormat Png { get { return new OutputFormat("png"); } }
    }
}
