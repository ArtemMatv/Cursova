using DAL;
using DAL.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework.Internal;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestDatabase()
        {
            ForumContext context = new ForumContext();

            User u = context.Users.Find(1);
            Post p = context.Posts.Find(1);
            Role r = context.Roles.Find(1);
            Topic t = context.Topics.Find(1);

            Assert.AreEqual(u.RoleId, r.Id);
            Assert.AreEqual(p.UserId, u.Id);
            Assert.AreEqual(p.Topic.Id, t.Id);
            Assert.AreEqual(r.Name, "Admin");
        }
    }
}
