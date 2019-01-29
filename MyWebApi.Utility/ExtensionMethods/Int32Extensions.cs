namespace MyWebApi.Utility.ExtensionMethods
{
    public static class Int32Extensions
    {
        public static bool IsNullOrZero(this int number)
        {
            return number == 0;
        }

        public static bool IsNullOrZero(this int? number)
        {
            return !number.HasValue || number.IsNullOrZero();
        }
    }
}
