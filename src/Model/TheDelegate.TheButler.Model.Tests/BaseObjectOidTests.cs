using System;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using DevExpress.Xpo.Metadata;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheDelegate.TheButler.Model.Base;
using FluentAssertions;

namespace TheDelegate.TheButler.Model.Tests
{
    [TestClass]
    public class BaseObjectOidTests
    {
        [TestMethod]
        public void Ctor_GivenSession_DoesNotThrow()
        {
            Action act = () =>
            {
                var session = CreateSession();

                BaseObject sut = new TestPersistentObject(session);
            };

            act.ShouldNotThrow();
        }

        [TestMethod]
        public void ChangeNotification_IsWorking()
        {
            Session session = CreateSession();

            TestPersistentObject sut = new TestPersistentObject(session);

            const string expected = "ABC";

            int counter = 0;
            sut.Changed += (s, e) =>
            {
                e.NewValue.Should().Be(expected);
                counter++;
            };

            sut.TestProperty = expected;

            if (counter <= 0)
                Assert.Fail("Changed Notfication didn't fire");
        }

        private Session CreateSession()
        {
            IDataStore store = new InMemoryDataStore();

            XPDictionary dictionary = new ReflectionDictionary();
            new ReflectionClassInfo(typeof (BaseObject), dictionary);

            IDataLayer layer = new SimpleDataLayer(dictionary, store);

            Session session = new Session(layer);
            return session;
        }
    }

    public class TestPersistentObject : BaseObject
    {
        private string _TestProperty;

        public TestPersistentObject(Session session) : base(session)
        {
        }

        public string TestProperty
        {
            get { return _TestProperty; }
            set { SetProperty(ref _TestProperty, value, "TestProperty"); }
        }
    }

}
