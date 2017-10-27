namespace NetsSharp
{
    public sealed class Language
    {
        private readonly string _value;

        public static readonly Language Norwegian = new Language("no_NO");
        public static readonly Language Swedish = new Language("sv_SE");
        public static readonly Language Danish = new Language("da_DK");
        public static readonly Language German = new Language("de_DE");
        public static readonly Language Finnish = new Language("fi_FI");
        public static readonly Language Russian = new Language("ru_RU");
        public static readonly Language Polish = new Language("pl_PL");
        public static readonly Language Spanish = new Language("es_ES");
        public static readonly Language English = new Language("en_GB");

        private Language(string value)
        {
            _value = value;
        }

        public override string ToString()
        {
            return _value;
        }
    }
}