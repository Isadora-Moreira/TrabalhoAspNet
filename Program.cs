using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
using TrabalhoASPNet.Models;

var builder = WebApplication.CreateBuilder(args);

// Configurando o contexto do banco de dados
builder.Services.AddDbContext<Contexto>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("conexao")));

// Adicionando suporte a controladores com views
builder.Services.AddControllersWithViews();

// Adicionando suporte à sessão
builder.Services.AddSession(); // Adicione esta linha

var app = builder.Build();

// Configuração de WebSockets
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseWebSockets(); // Habilitar WebSockets no ambiente de desenvolvimento
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// Redireciona para HTTPS
app.UseHttpsRedirection();

// Permite o uso de arquivos estáticos (CSS, JS, etc.)
app.UseStaticFiles();

// Definir o pipeline de roteamento
app.UseRouting();

// Habilitando o uso de sessão
app.UseSession(); // Adicione esta linha

// Configuração da Cultura para aceitar ponto como separador decimal
var defaultCulture = new CultureInfo("en-US");
var localizationOptions = new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture(defaultCulture),
    SupportedCultures = new List<CultureInfo> { defaultCulture },
    SupportedUICultures = new List<CultureInfo> { defaultCulture }
};

// Aplicando a cultura ao middleware de requisições
app.UseRequestLocalization(localizationOptions);

// Autorização
app.UseAuthorization();

// Definir o padrão de rotas para os controladores
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Executa o aplicativo
app.Run();