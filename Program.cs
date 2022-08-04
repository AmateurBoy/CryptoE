
using CryptoE.Controllers;
using CryptoE.Data.DTO;
using CryptoE.Data.Entitys;
using CryptoE.TelegramBot;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuthorization();
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddCors(options => options.AddDefaultPolicy(
    builder => builder.AllowAnyOrigin()));
var app = builder.Build();
app.UseStaticFiles();
app.UseCors();
app.UseRouting();

app.UseAuthorization();
app.MapControllerRoute("Default", "{controller=Home}/{action=Redirect}/{id?}");

//app.MapControllerRoute(
//     name: "resMethod",
//    pattern: "?from={of:string}&to={to:string}&amount={aount:int}&isForward={algoritm:bool}",
//    defaults: new { controller = "Home", action="result" }
//    );

app.UseEndpoints(endpoints =>
{
    
    endpoints.MapDefaultControllerRoute();
    endpoints.MapRazorPages();
});
BotController.Main();

TelegramController.APItest();
app.Run();


    //

    
    



