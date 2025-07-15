using Microsoft.Azure.Cosmos;
using CrushApp.Data.Services;
using CrushApp.Data.Mapping; // Assuming this is where UserProfile lives

var builder = WebApplication.CreateBuilder(args);

// ✅ Add Razor Pages & Blazor
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// ✅ Register AutoMapper
builder.Services.AddAutoMapper(typeof(UserProfile).Assembly);

// ✅ Cosmos DB Configuration
var cosmosEndpoint = builder.Configuration["CosmosDb:Endpoint"];
var cosmosKey = builder.Configuration["CosmosDb:Key"];
var cosmosDatabase = builder.Configuration["CosmosDb:DatabaseName"];

// ✅ Register Cosmos DB client as Singleton
builder.Services.AddSingleton(s =>
{
    return new CosmosClient(cosmosEndpoint, cosmosKey);
});

// ✅ Register custom user service
builder.Services.AddScoped<IUserService, CosmosUserService>();
builder.Services.AddScoped<UserSessionService>();


var app = builder.Build();

// ✅ Configure middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// ✅ Map Blazor endpoints
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
