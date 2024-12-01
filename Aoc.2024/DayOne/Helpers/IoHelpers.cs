namespace DayOne.Helpers;

internal static class IoHelpers
{
    public static string[] ReadInput(string path)
    {
        return File.ReadAllLines(path);
    }
}
