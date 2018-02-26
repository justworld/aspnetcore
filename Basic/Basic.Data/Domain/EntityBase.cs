using System;

namespace Basic.Data.Domain
{
    [Serializable]
    public abstract partial class EntityBase
    {
        public virtual int Id { get; set; }
    }
}
