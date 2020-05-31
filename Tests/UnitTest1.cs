using DAL;
using DAL.DataStructures;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework.Internal;
using System.Threading.Tasks;

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

        [TestMethod]
        public void TestRepository()
        {
            ForumContext context = new ForumContext();

            IRepository<User> repUser = new Repository<User>(context);
            IRepository<Post> repPost = new Repository<Post>(context);
            CheckRepository(repUser, repPost);
        }

        private static async Task CheckRepository(IRepository<User> repUser, IRepository<Post> repPost)
        {
            var u = await repUser.GetAllAsync().ConfigureAwait(false);


            foreach (var item in u)
            {
                Assert.AreEqual(item.IsBanned, false);
                Assert.AreNotEqual(item.UserName, null);
            }

            var p = await repPost.GetAsync(1).ConfigureAwait(false);

            Assert.AreEqual(p.Title, "г���� ������� �� ����� ��������");
        }

        [TestMethod]
        public void TestUnitOfWork()
        {
            ForumContext context = new ForumContext();

            IUnitOfWork<Topic, Post> unit = new UnitOfWork<Topic, Post>(context);
            CheckUnit(unit);
        }

        private static async Task CheckUnit(IUnitOfWork<Topic, Post> unit)
        {
            Assert.AreEqual((await unit.TRepository.GetAsync(1)).Id, (await unit.URepository.GetAsync(1)).TopicId);
        }
    }
}
