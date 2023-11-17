namespace EasyRedmineApiClient.Internals.Utilities;

internal static class Guard
{
    public static void NotEmpty(string arg, string argName, string message = null)
    {
        if (!string.IsNullOrEmpty(arg))
            return;

        if (string.IsNullOrEmpty(message))
            throw new ArgumentException($"ArgumentException: {argName} string not valid.");

        throw new ArgumentException($"{message}");
    }
    
    public static void NotNull<T>(T arg, string argName)
        where T : class
    {
        if (arg == null)
            throw new ArgumentException($"ArgumentException: {argName} is null");
    }
}