using Newtonsoft.Json;
using System.Net;
using System.Text;

/*
//kiem tra he thong ho tro HttpListener
if (HttpListener.IsSupported)
{
    Console.WriteLine("Support HttpListener");
}
else
{
    Console.WriteLine("Not Support HttpListener");
    throw new Exception("Not Support HttpListener");
}

var server = new HttpListener();

server.Prefixes.Add("http://*:8080/");

server.Start();
Console.WriteLine("Server Http Start");

do
{
    var context = await server.GetContextAsync();
    Console.WriteLine("Client connected");
    var response = context.Response;
    var outputStream = response.OutputStream;

    response.Headers.Add("content-type", "text/html");

    var html = "<h1>Heloooooooooooo</h1>";
    var bytes = Encoding.UTF8.GetBytes(html);
    await outputStream.WriteAsync(bytes, 0, bytes.Length);
    outputStream.Close();
} 
while (server.IsListening);

*/


var server = new MyHttpServer(new string[] { "http://*:8080/" });
await server.Start();

class MyHttpServer
{
    private HttpListener listener;
    public MyHttpServer(string[] prifixes)
    {
        if (!HttpListener.IsSupported)
        {
            throw new Exception("HttpListener is not support");
        }
        listener = new HttpListener();
        foreach (string prifix in prifixes) listener.Prefixes.Add(prifix);

    }

    public async Task Start()
    {
        listener.Start();
        Console.WriteLine("Http Server Start");
        do
        {
            Console.WriteLine(DateTime.Now.ToLongTimeString() + " Waiting a client connect");
            var context = await listener.GetContextAsync();

            await ProcessRequest(context);

            Console.WriteLine(DateTime.Now.ToLongTimeString() + " client connected");

        } while (listener.IsListening);
    }

    async Task ProcessRequest(HttpListenerContext context)
    {
        HttpListenerRequest request = context.Request;
        HttpListenerResponse response = context.Response;

        Console.WriteLine($"{request.HttpMethod} {request.RawUrl} {request.Url.AbsolutePath}");

        var outputStream = response.OutputStream;

        switch (request.Url.AbsolutePath)
        {
            case "/":
                {
                    var buffer = Encoding.UTF8.GetBytes("Xin chaooooooo");
                    response.ContentLength64 = buffer.Length;
                    await outputStream.WriteAsync(buffer, 0, buffer.Length);
                }
                break;
            case "/json":
                {
                    response.Headers.Add("Content-Type", "application/json");

                    var product = new
                    {
                        Name = "Mac",
                        Price = 20000
                    };
                    var json = JsonConvert.SerializeObject(product);
                    var buffer = Encoding.UTF8.GetBytes(json);
                    response.ContentLength64 = buffer.Length;
                    await outputStream.WriteAsync(buffer, 0, buffer.Length);
                }

                break;
            case "/anh2.png":
                {
                    response.Headers.Add("Content-Type", "image/png");

                    var buffer = await File.ReadAllBytesAsync("2.png");
                    response.ContentLength64 = buffer.Length;
                    await outputStream.WriteAsync(buffer, 0, buffer.Length);
                }

                break;
            default:
                {
                    response.StatusCode = (int)HttpStatusCode.NotFound;

                    var buffer = Encoding.UTF8.GetBytes("404 NOT FOUND");
                    response.ContentLength64 = buffer.Length;
                    await outputStream.WriteAsync(buffer, 0, buffer.Length);
                }

                break;
        }

        outputStream.Close();
    }
}