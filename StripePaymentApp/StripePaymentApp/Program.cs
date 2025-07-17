using Stripe;
using StripePaymentApp.Services; // Replace with your actual namespace

var builder = WebApplication.CreateBuilder(args);

// ?? Configure Stripe API Key from appsettings.json
StripeConfiguration.ApiKey = builder.Configuration["Stripe:SecretKey"];

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<StripeService>(); // Register your Stripe service

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts(); // Enables HTTP Strict Transport Security
}

app.UseHttpsRedirection();  // Redirect HTTP -> HTTPS
app.UseStaticFiles();       // Enable wwwroot static files (e.g., stripe.js)

app.UseRouting();

app.UseAuthorization();     // Only needed if you use [Authorize]

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Payment}/{action=Index}/{id?}");

app.Run();
