var builder = WebApplication.CreateBuilder(args);

// luu tru trong bo nho
//builder.Services.AddDistributedMemoryCache(); 


// luu tru trong sqlserver
builder.Services.AddDistributedSqlServerCache((option) =>    
{
    option.ConnectionString = "Data Source=localhost,1433;Initial Catalog=webdb;User ID=SA;Password=password123;TrustServerCertificate=True;";
    option.SchemaName = "dbo";
    option.TableName = "Session";
});
builder.Services.AddSession((option) =>
{
    option.Cookie.Name = "testtt";
    option.IdleTimeout = new TimeSpan(0, 30, 0); // 30 phut
});

var app = builder.Build();

app.UseSession();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("/", async context =>
    {
        int? count;
        count = context.Session.GetInt32("count"); // read session

        if (count == null)
        {
            count = 0;
        }


        count += 1;
        context.Session.SetInt32("count", count.Value); // save session
        await context.Response.WriteAsync($"So lan truy cap readwritesession cap la: {count}");
        await context.Response.WriteAsync("tests");
    });

    endpoints.MapGet("/readwritesession", async context =>
    {
        int? count;
        count = context.Session.GetInt32("count"); // read session

        if (count == null)
        {
            count = 0;
        }


        count += 1;
        context.Session.SetInt32("count", count.Value); // save session
        await context.Response.WriteAsync($"So lan truy cap readwritesession cap la: {count}");

    });
});

//app.MapGet("/", () => "Hello World!");

app.Run();



//dotnet sql-cache create "Data Source=localhost,1433;Initial Catalog=webdb;User ID=SA;Password=password123;TrustServerCertificate=True;" dbo Session
//Data Source=localhost,1433;Initial Catalog=webdb;User ID=SA;Password=password123