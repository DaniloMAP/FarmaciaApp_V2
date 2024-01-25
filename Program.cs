using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Adicionar a configuração do DbContext
builder.Services.AddDbContext<ApplicationDBContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Adicionar serviços ao container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Verifique se o ambiente não é de desenvolvimento
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Adicione a chamada para Seed para adicionar Fabricantes
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDBContext>();
    context.Database.Migrate(); // Certifique-se de que o banco de dados esteja criado/migrado

    // Chame o método Seed para adicionar os Fabricantes
    context.Seed();
}

app.Run();