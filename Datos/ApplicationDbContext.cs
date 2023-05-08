using CrudNet7MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudNet7MVC.Datos
{
    public class ApplicationDbContext : DbContext 
    {

        public ApplicationDbContext(DbContextOptions <ApplicationDbContext> options) : base(options)  //ctor
        {
            
        }

        //Agregar los modelos aqui simpre
        public DbSet<Contacto> Contacto { get; set; } 

    }
}
