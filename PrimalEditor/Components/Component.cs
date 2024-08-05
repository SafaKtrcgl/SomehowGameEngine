using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Text;

namespace PrimalEditor.Components
{
    interface IMultiSelectionComponent { }

    [DataContract]
    abstract class Component: ViewModelBase
    {
        [DataMember]
        public GameEntity Owner { get; private set; }

        public Component(GameEntity owner)
        {
            Debug.Assert(owner != null);
            Owner = owner;
        }
    }

    abstract class MultiSelectionComponent<T> : ViewModelBase, IMultiSelectionComponent where T : Component
    {

    }
}
