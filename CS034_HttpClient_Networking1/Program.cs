
using System.Net;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;


// uri, Dns, Ping

string url = "https://xuanthulab.net/lap-trinh/csharp/?page=3#acff";
var uri = new Uri(url);
var uritype = typeof(Uri);
uritype.GetProperties().ToList().ForEach(p =>
{
    Console.WriteLine($"{p.Name,15} {p.GetValue(uri)}");
});
Console.WriteLine($"Segment: {string.Join(",", uri.Segments)}");
Console.WriteLine("--------------------");


var hostname = Dns.GetHostName();
Console.WriteLine(hostname);

Console.WriteLine("--------------------");


var url1 = "https://www.bootstrapcdn.com/";
var uri1 = new Uri(url1);
Console.WriteLine(uri1.Host);

var iphostentry = Dns.GetHostEntry(uri1.Host);
Console.WriteLine(iphostentry.HostName);
iphostentry.AddressList.ToList().ForEach(p => { Console.WriteLine(p); });

Console.WriteLine("--------------------");


var ping = new Ping();
var pingReply = ping.Send("google.com.vn");
Console.WriteLine(pingReply.Status);
if (pingReply.Status == IPStatus.Success)
{
    Console.WriteLine(pingReply.RoundtripTime);
    Console.WriteLine(pingReply.Address);
}


//Http request - HttpClient (Get/Post)
var url2 = "https://www.googl.com/search?q=xuanthulab";
var html = await GetWebContext(url2);

Console.WriteLine(html);

/*static async Task<string> GetWebContext(string url)
{
    using var httpClient = new HttpClient();

    *//*HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(url);
    string html = await httpResponseMessage.Content.ReadAsStringAsync();
    return html;*//*
    try
    {
        HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(url);
        string html = await httpResponseMessage.Content.ReadAsStringAsync();
        return html;
    }
    catch(Exception e)
    {
        Console.WriteLine(e.Message);
        return "Loi";
    }

}*/

static void ShowHeaders(HttpResponseHeaders headers)
{
    Console.WriteLine("Cac header");
    foreach (var header in headers)
    {
        Console.WriteLine($"{header.Key} - {header.Value}");
    }
}
Console.WriteLine("-----------------------");

var url3 = "https://raw.githubusercontent.com/xuanthulabnet/jekyll-example/master/images/jekyll-01.png";
var bytes = await DownloadDataBytes(url3);
string filename = "1.png";
using var stream = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.None);

stream.Write(bytes, 0, bytes.Length);


await DownloadStream(url3, "2.png");


using var httpClient = new HttpClient();
var httpRequestMessage = new HttpRequestMessage();
httpRequestMessage.Method = HttpMethod.Get;
httpRequestMessage.RequestUri = new Uri("https://www.google.com.vn");
httpRequestMessage.Headers.Add("User-Agent", "Mozilla/5.0 (X11; Linux x86_64; rv:12.0) Gecko/20100101 Firefox/12.0");

var httpResponseMessage  = await httpClient.SendAsync(httpRequestMessage);
var html1 = await httpResponseMessage.Content.ReadAsStringAsync();
Console.WriteLine(html1);

static async Task<string> GetWebContext(string url)
{
    using var httpClient = new HttpClient();

    /*HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(url);
    string html = await httpResponseMessage.Content.ReadAsStringAsync();
    return html;*/
    try
    {
        //them header 
        httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0");
        HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(url);

        ShowHeaders(httpResponseMessage.Headers);

        string html = await httpResponseMessage.Content.ReadAsStringAsync();
        return html;
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
        return "Loi";
    }

}

static async Task<byte[]> DownloadDataBytes(string url)
{
    using var httpClient = new HttpClient();

    /*HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(url);
    string html = await httpResponseMessage.Content.ReadAsStringAsync();
    return html;*/
    try
    {
        //them header 
        httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0");
        HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(url);

        ShowHeaders(httpResponseMessage.Headers);

        var bytes = await httpResponseMessage.Content.ReadAsByteArrayAsync();
        return bytes;
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
        return null;
    }

}

static async Task DownloadStream(string url, string filename)
{
    using var httpClient = new HttpClient();

    try
    {
        HttpResponseMessage httpResponseMessage = await httpClient.GetAsync(url);

        using var stream = await httpResponseMessage.Content.ReadAsStreamAsync();


        using var streamwrite = File.OpenWrite(filename);


        int SIZEBUFFER = 500;
        var buffer = new byte[SIZEBUFFER];


        bool endread = false;
        do
        {
            int numByte = await stream.ReadAsync(buffer, 0, SIZEBUFFER);
            if (numByte == 0)
            {
                endread = true;
            }
            else
            {
                await streamwrite.WriteAsync(buffer, 0, numByte);
            }
        } while (!endread);

    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
   }

}