var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.MapControllerRoute(
    name: "RandomGenerator",
    pattern: "RandomObject",
    defaults: new { controller = "RandomGenerator", action = "Index" }
);

app.MapControllerRoute(
    name: "ReadFile",
    pattern: "ReadFile",
    defaults: new { controller = "ReadFile", action = "Index" }
);

app.MapControllerRoute(
    name: "Dockerize",
    pattern: "Dockerizw",
    defaults: new { controller = "Dockerize", action = "Index" }
);

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
