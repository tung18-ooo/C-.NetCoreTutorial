
using System.Net;
using System.Text;

//var url = "https://postman-echo.com/post";
var url = "https://www.google.com/";
//var url = "https://www.facebook.com/";

var cokies = new CookieContainer();

//tao chuoi handler
var bottomHandler = new MyHttpClientHandler(cokies);
var changeUriHandler = new ChangeUri(bottomHandler);
var denyAccessFacebook = new DenyAccessFacebook(changeUriHandler);



/*using var handler = new SocketsHttpHandler();

handler.AllowAutoRedirect = true;
handler.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
handler.UseCookies = true;
handler.CookieContainer = cookies;*/
using var handler = new SocketsHttpHandler
{
    AllowAutoRedirect = true,
    AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip,
    UseCookies = true,
    CookieContainer = cokies,
};

//using var httpClient = new HttpClient(handler);


using var httpClient = new HttpClient(denyAccessFacebook);

using var httpRequestMessage = new HttpRequestMessage();

httpRequestMessage.Method = HttpMethod.Get;
httpRequestMessage.RequestUri = new Uri(url);
httpRequestMessage.Headers.Add("User-Agent", "Mozilla/5.0");

var para = new List<KeyValuePair<string, string>>();
para.Add(new KeyValuePair<string, string>("key1", "value1"));
para.Add(new KeyValuePair<string, string>("key2", "value2"));

httpRequestMessage.Content = new FormUrlEncodedContent(para);

var response = await httpClient.SendAsync(httpRequestMessage);

cokies.GetCookies(new Uri(url)).ToList().ForEach(c =>
{
    Console.WriteLine($"{c.Name} {c.Value}");
});

var html = await response.Content.ReadAsStringAsync();
Console.WriteLine(html);


class MyHttpClientHandler : HttpClientHandler
{
    public MyHttpClientHandler(CookieContainer cookie_container)
    {
        CookieContainer = cookie_container;
        AllowAutoRedirect = false;
        AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
        UseCookies = true;
    }
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        Console.WriteLine("Bat dau ket noi " + request.RequestUri.ToString());
        //thuc hien truy van den Server
        var response = await base.SendAsync(request, cancellationToken);
        Console.WriteLine("Hoan thanh tai du lieu");
        return response;
    }
}

class ChangeUri : DelegatingHandler
{
    public ChangeUri(HttpMessageHandler innerHandler) : base(innerHandler) { }
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var host = request.RequestUri.Host.ToLower();
        Console.WriteLine($"Check in ChangeUri - {host}");
        if (host.Contains("google.com"))
        {
            request.RequestUri = new Uri("https://github.com/");
        }
        return await base.SendAsync(request, cancellationToken);
    }
}

class DenyAccessFacebook: DelegatingHandler
{
    public DenyAccessFacebook(HttpMessageHandler innerHandler) : base( innerHandler) { }
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var host = request.RequestUri.Host.ToLower();
        Console.WriteLine($"Check in DenyFacebook - {host}");
        if (host.Contains("facebook.com"))
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new ByteArrayContent(Encoding.UTF8.GetBytes("Khong duoc truy cap"));
            return await Task.FromResult<HttpResponseMessage>(response);
        }
        return await base.SendAsync(request, cancellationToken);
    }
}