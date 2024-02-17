using Microsoft.EntityFrameworkCore;

namespace Color_Selection_API.Model
{
    public class colorcls :DbContext
    {

        public colorcls(DbContextOptions<colorcls> options) : base(options)
        {
        }
        public DbSet<Color> colores { get; set;}

    }
}
