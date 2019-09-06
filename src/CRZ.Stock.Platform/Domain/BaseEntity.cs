using System;
using CRZ.Framework.Domain;

namespace CRZ.Stock.Platform.Domain
{
    public abstract class BaseEntity : IEntity<long>
    {
        public long Id { get; protected set; }

        public DateTimeOffset CreatedAt { get; protected set; }

        public DateTimeOffset UpdatedAt { get; protected set; }

        protected BaseEntity()
        { }
    }
}
