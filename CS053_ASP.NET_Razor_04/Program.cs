using CS053_ASP.NET_Razor_04.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSingleton<ProductListService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();


/*
 * Partial View : la file cshtml khong co @page
 * - chia nho page thanh cac file nho
 * - su dung lai cac thanh phan (tranh trung lap code)
 * 
 * Component ~ Partial View ~ DI = Mini Razor Page
 * */