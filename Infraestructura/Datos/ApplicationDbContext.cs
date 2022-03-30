using Core.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Datos
{
    //la cadena de conexccion en appsettings


    //bbd kink
    //usuario: 'cbas_secoli1'
    //password: 'admin1234'
    //email: 'cbas.secoli@gmail.com
    //namebbd: 'globaltour
    //se instalo un Nuget para este llamado Pomelo.EntityFrameworkCore.MySql
    //servidor= db4free.net y el puerto es el 3306.

    //donde poner para ir a poner usuario y password 
    //https://www.db4free.net/phpMyAdmin/
    public class ApplicationDbContext : DbContext
    {
        //hara referencia a la cadena de conexion
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }


        //esto se creara en la bbd y lo en lazamos con Entidades o nuestro modelo
        public DbSet<Lugar> Lugar { get; set; }
    }
}
