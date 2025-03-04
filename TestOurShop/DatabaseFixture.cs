
using Microsoft.EntityFrameworkCore;

using Repository;

namespace TestProject
{
    public class DataBaseFixture : IDisposable
    {
        public AdoNetManageContext Context { get; private set; }
        public DataBaseFixture()
        {
            var options = new DbContextOptionsBuilder<AdoNetManageContext>()
                .UseSqlServer("Server=srv2\\pupils;Database=Test_Laiky&Batya;Trusted_Connection=True;TrustServerCertificate=True")
                .Options;

            Context = new AdoNetManageContext(options);
            Context.Database.EnsureDeleted();
            Context.Database.EnsureCreated();

        }

        public void Dispose()
        {
            Context.Database.EnsureDeleted();
            Context.Dispose();
        }
    }
}