using System;
using BLL;
using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProyectoFinalA2.Tests
{
    [TestClass]
    public class UserUnitTest
    {
        [TestMethod]
        public void Save()
        {
            RepositorioBase<Usuario> br = new RepositorioBase<Usuario>();
            bool ok = br.Save(GetUser());
            Assert.IsTrue(ok);
        }

        [TestMethod]
        public void Get()
        {
            RepositorioBase<Usuario> br = new RepositorioBase<Usuario>();
            Usuario user = br.Get(1);
            Assert.IsTrue(user != null);
        }

        [TestMethod]
        public void GetList()
        {
            RepositorioBase<Usuario> br = new RepositorioBase<Usuario>();
            bool ok = br.GetList(x => true).Count > 0;
            Assert.IsTrue(ok);
        }

        [TestMethod]
        public void Delete()
        {
            RepositorioBase<Usuario> br = new RepositorioBase<Usuario>();
            bool ok = br.Delete(1);
            Assert.IsTrue(ok);
        }

        #region AuxiliaryMethods
        private Usuario GetUser()
        {
            Usuario user = new Usuario();
            user.Name = "Luis";
            user.LastName = "Apell";
            user.UserName = "lluis";
            user.Password = "123456";
            user.CreatedAt = DateTime.Now;
            return user;
        }
        #endregion
    }
}
