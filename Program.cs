using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using CrushApp.Data.Services;

var builder = WebApplication.CreateBuilder(args);

// ✅ Get the API Base URL from appsettings.json
var apiBaseUrl = builder.Configuration["Api:BaseUrl"] ?? throw new InvalidOperationException("API base URL is missing.");

// ✅ Register services
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// ✅ Inject IUserService that talks to Azure Function API
builder.Services.AddHttpClient<IUserService, UserService>(client =>
{
    client.BaseAddress = new Uri(apiBaseUrl); // MUST be a full valid URI with trailing slash
});

var app = builder.Build();

// ✅ Configure middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts(); // Production HTTPS enforcement
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// ✅ Map Blazor endpoints
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
