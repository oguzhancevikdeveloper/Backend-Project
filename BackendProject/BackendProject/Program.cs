using BackendProject.Data;
using BackendProject.Models;
using BackendProject.Repositories;
using BackendProject.Repositories.Form;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MSSQL")));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IFormRepository, FormRepository>();

builder.Services.AddAuthentication("Cookies")
    .AddCookie("Cookies", options =>
    {
        options.LoginPath = "/User/Login";  // Giriş yapılmamışsa yönlendirilecek sayfa
    });
builder.Services.AddAuthorization();
builder.Services.AddRazorPages();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    var applicationDbContext = serviceProvider.GetRequiredService<ApplicationDbContext>();
    applicationDbContext.Database.Migrate();

    // Eğer FormFields veritabanında varsa, veriyi eklemiyoruz
    if (!applicationDbContext.Forms.Any()) // Forms tablosunda herhangi bir form yoksa
    {
        var forms = new List<Form>
        {
            new Form
            {
                Name = "Form 1",
                CreatedAt = DateTime.Now.ToString(),
                Description = "Form 1 Açıklaması",
                CreatedBy = 1, // Sabit bir kullanıcı ID'si, gerçek uygulamada oturumdaki kullanıcı kullanılır.
                Fields = new List<FormField>
                {
                    new FormField { Name = "Alan 1", Required = true, DataType = "STRING" },
                    new FormField { Name = "Alan 2", Required = false, DataType = "NUMBER" }
                }
            },
            new Form
            {
                Name = "Form 2",
                CreatedAt = DateTime.Now.ToString(),
                Description = "Form 2 Açıklaması",
                CreatedBy = 2,
                Fields = new List<FormField>
                {
                    new FormField { Name = "Alan 1", Required = true, DataType = "NUMBER" },
                    new FormField { Name = "Alan 2", Required = true, DataType = "STRING" },
                    new FormField { Name = "Alan 3", Required = false, DataType = "STRING" }
                }
            },
            new Form
            {
                Name = "Form 3",
                CreatedAt = DateTime.Now.ToString(),
                Description = "Form 3 Açıklaması",
                CreatedBy = 3,
                Fields = new List<FormField>
                {
                    new FormField { Name = "Alan 1", Required = false, DataType = "STRING" }
                }
            },
            new Form
            {
                Name = "Form 4",
                CreatedAt = DateTime.Now.ToString(),
                Description = "Form 4 Açıklaması",
                CreatedBy = 4,
                Fields = new List<FormField>
                {
                    new FormField { Name = "Alan 1", Required = true, DataType = "STRING" },
                    new FormField { Name = "Alan 2", Required = true, DataType = "NUMBER" },
                    new FormField { Name = "Alan 3", Required = false, DataType = "STRING" }
                }
            },
            new Form
            {
                Name = "Form 5",
                CreatedAt = DateTime.Now.ToString(),
                Description = "Form 5 Açıklaması",
                CreatedBy = 5,
                Fields = new List<FormField>
                {
                    new FormField { Name = "Alan 1", Required = false, DataType = "STRING" },
                    new FormField { Name = "Alan 2", Required = true, DataType = "NUMBER" }
                }
            }
        };

        // Veritabanına ekleme
        await applicationDbContext.Forms.AddRangeAsync(forms);
        await applicationDbContext.SaveChangesAsync();
    }
}

app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
