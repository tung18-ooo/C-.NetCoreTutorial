internal static class RequestProcessHelpers
{
    public static string ProcessForm(HttpRequest request)
    {
        var format = File.ReadAllText("formtest.html");

        var html = string.Format( format, "hoten", "tungqwe1802@gmail.com", "no");
        return html;
    }
}
