using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
namespace mvc1.Models
{
    public static class Populadb
    {

        public static void IncluiDadosDB(IApplicationBuilder app)
        {

            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();


                IncluiDadosDB(context);
                // Seed the database.
            };

            // IncluiDadosDB(
            // app.ApplicationServices.GetRequiredService<AppDbContext>());
        }

        public static void IncluiDadosDB(AppDbContext context)
        {


            System.Console.WriteLine("Aplicando Migrations....");
            try
            {
                context.Database.Migrate();
                if (!context.Produtos.Any())
                {
                    System.Console.WriteLine("Criando dados....");
                    context.Produtos.AddRange(
                        new Produto("Luvas de goleiro", "Futebol", 25),
                        new Produto("Bola de Basquete", "Basquete", 48.95m),
                        new Produto("Bola de futebol", "Futebol", 19.50m),
                        new Produto("Meias Grandes", "Futebol", 50),
                        new Produto("Cesta para quadra", "Basquete", 25)
                    );
                    context.SaveChanges();
                }
                else
                {
                    System.Console.WriteLine("Banco de dados já existe....");
                }
            }
            catch (Exception err)
            {
                System.Console.WriteLine(err.Message);
                System.Console.WriteLine(err.InnerException);
            }


        }

    }
}