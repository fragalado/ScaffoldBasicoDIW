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

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

//using ScaffoldingDIW.Models;

//public class Program
//{
//    public static void Main(string[] args)
//    {
//        using (var db = new GestorBibliotecaPersonalContext())
//        {
//            // Creating a new item and saving it to the database
//            var newItem = new Prueba();
//            newItem.Nombre = "Francisco Jose";
//            newItem.Apellidos = "Gallego Dorado";
//            db.Pruebas.Add(newItem);
//            var count = db.SaveChanges();
//            Console.WriteLine("{0} records saved to database", count);
//            // Retrieving and displaying data
//            Console.WriteLine();
//            Console.WriteLine("All items in the database:");
//            foreach (var item in db.Pruebas)
//            {
//                Console.WriteLine("{0} | {1}", item.Nombre, item.Apellidos);
//            }
//        }
//    }
//}
