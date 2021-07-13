using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ppedv.Musicplayer.Data.EfCore.Tests
{
    [TestClass]
    public class EfContextTests
    {
        [TestMethod]
        public void Can_create_DB()
        {
            var con = new EfContext();
            con.Database.EnsureDeleted();

            Assert.IsTrue(con.Database.EnsureCreated());
        }
    }
}
