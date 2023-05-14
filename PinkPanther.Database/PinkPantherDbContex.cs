using Microsoft.EntityFrameworkCore;

namespace PinkPanther.Database
{
    public class PinkPantherDbContex : DbContext
    {


        public PinkPantherDbContex(DbContextOptions options) : base(options)
        {

        }
    }
}
