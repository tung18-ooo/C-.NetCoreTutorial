
using System.Net;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;
using System.Text;


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

//httpMessageRequest.Content => Form HTML, File,..

var httpResponseMessage  = await httpClient.SendAsync(httpRequestMessage);

ShowHeaders(httpResponseMessage.Headers);

var html1 = await httpResponseMessage.Content.ReadAsStringAsync();
Console.WriteLine(html1);

using var httpClient1 = new HttpClient();
var httpRequestMessage1 = new HttpRequestMessage();
httpRequestMessage1.Method = HttpMethod.Post;
httpRequestMessage1.RequestUri = new Uri("https://postman-echo.com/post");
httpRequestMessage1.Headers.Add("User-Agent", "Mozilla/5.0 (X11; Linux x86_64; rv:12.0) Gecko/20100101 Firefox/12.0");

//httpMessageRequest.Content => Form HTML, File,..
//Post => Form HTML
/*
 key1 => value1                     // Input
key2 => [value2-1, value2-2]        //[Multi Select]
 */

var parameters = new List<KeyValuePair<string, string>>();
parameters.Add(new KeyValuePair<string, string>("key1", "value1"));
parameters.Add(new KeyValuePair<string, string>("key2", "value2-1"));
parameters.Add(new KeyValuePair<string, string>("key2", "value2-2"));

var content = new FormUrlEncodedContent(parameters);
httpRequestMessage1.Content = content;

var httpResponseMessage1 = await httpClient1.SendAsync(httpRequestMessage1);

ShowHeaders(httpResponseMessage1.Headers);

var html2 = await httpResponseMessage1.Content.ReadAsStringAsync();
Console.WriteLine(html2);

Console.WriteLine("--------------------------------");

using var httpClient2 = new HttpClient();
var httpRequestMessage2 = new HttpRequestMessage();
httpRequestMessage2.Method = HttpMethod.Post;
httpRequestMessage2.RequestUri = new Uri("https://postman-echo.com/post");
httpRequestMessage2.Headers.Add("User-Agent", "Mozilla/5.0 (X11; Linux x86_64; rv:12.0) Gecko/20100101 Firefox/12.0");


string data = @"{
""key1"": ""giatri1"",
""key1"": ""giatri2"",
}";
Console.WriteLine(data);

var content2 = new StringContent(data,Encoding.UTF8, "application/json");
httpRequestMessage2.Content = content;

var httpResponseMessage2 = await httpClient2.SendAsync(httpRequestMessage2);

ShowHeaders(httpResponseMessage2.Headers);

var html3 = await httpResponseMessage2.Content.ReadAsStringAsync();
Console.WriteLine(html3);

Console.WriteLine("---------------------------------");
using var httpClient3= new HttpClient();
var httpRequestMessage3 = new HttpRequestMessage();
httpRequestMessage3.Method = HttpMethod.Post;
httpRequestMessage3.RequestUri = new Uri("https://postman-echo.com/post");
httpRequestMessage3.Headers.Add("User-Agent", "Mozilla/5.0 (X11; Linux x86_64; rv:12.0) Gecko/20100101 Firefox/12.0");

var content3 =new MultipartFormDataContent();
//upload 1.txt
Stream filestream = File.OpenRead("1.txt");
var fileUpload = new StreamContent(filestream); //past
content3.Add(fileUpload,"fileupload","abc.xyz");
//
content3.Add(new StringContent("value1"), "key1");
httpRequestMessage3.Content = content3;

var httpResponseMessage3 = await httpClient3.SendAsync(httpRequestMessage3);

ShowHeaders(httpResponseMessage3.Headers);

var html4 = await httpResponseMessage3.Content.ReadAsStringAsync();
Console.WriteLine(html4);

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