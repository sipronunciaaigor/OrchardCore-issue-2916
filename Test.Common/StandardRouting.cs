namespace Test.Common
{
    public struct StandardRouting
    {
        private const string _TEST = "test/";

        public struct Partial
        {
            private const string _PREFIX = "p/";
            public const string _TEST_STRUCUTRE = _PREFIX + _TEST + "{testValue}";
        }
    }
}
