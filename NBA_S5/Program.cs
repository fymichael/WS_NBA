var builder = WebApplication.CreateBuilder(args);

// Configurez les services dans la méthode ConfigureServices
builder.Services.AddControllers();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Statistics}/{action=Index}/{idEquipe?}"
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Statistics}/{action=Index}"
);

app.Run();
