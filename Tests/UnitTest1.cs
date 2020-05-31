using DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework.Internal;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestDatabase(IServiceCollection s)
        {
            s.AddDbContext<ForumContext>(options => 
                    options.UseLazyLoadingProxies().UseSqlServer(""));
        }
    }
}
