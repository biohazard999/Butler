using System.ComponentModel;
using DevExpress.Xpo;
using TheDelegate.TheButler.Model.Annotations;

namespace TheDelegate.TheButler.Model.Base
{
    [NonPersistent]
    public abstract class BaseObject : XPBaseObject
    {
        public BaseObject(Session session)
            : base(session)
        {
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void SetProperty<T>(ref T propertyValueHolder, T newValue, string propertyName = null)
        {
            SetPropertyValue(propertyName, ref propertyValueHolder, newValue);
        }
    }
}
