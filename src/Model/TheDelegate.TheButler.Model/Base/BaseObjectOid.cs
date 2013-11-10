using DevExpress.Xpo;

namespace TheDelegate.TheButler.Model.Base
{
    [NonPersistent]
    public abstract class BaseObjectOid : BaseObject
    {
        private int _Oid;

        protected BaseObjectOid(Session session) : base(session)
        {
        }

        [Key(AutoGenerate = true)]
        public int Oid
        {
            get { return _Oid; }
            set { SetProperty(ref _Oid, value, "Oid"); }
        }
    }
}