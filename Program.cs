using Microsoft.EntityFrameworkCore;
using CRMSystemNew.Data;
using CRMSystemNew.Services;

var builder = WebApplication.CreateBuilder(args);

// Services
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// Database - InMemory für zuverlässigen Test
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseInMemoryDatabase("CRMTest"));

// Eigenen Service registrieren
builder.Services.AddScoped<KundeService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage(); // Detaillierte Fehler in Development
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

// Database Initialization
using (var scope = app.Services.CreateScope())
{
    try
    {
        var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        db.Database.EnsureCreated();
        Console.WriteLine("Database erfolgreich initialisiert");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Database Fehler: {ex.Message}");
    }
}

app.Run();