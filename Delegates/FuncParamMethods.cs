namespace GitGoodScrub
{
    public static class FuncParamMethods
    {
        public static string IntToString(CustomFunc<int, string> operation, int number)
        {   
            return $"Converted: {operation(number)}";
        }
    }
}
