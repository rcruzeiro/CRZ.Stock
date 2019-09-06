using System;
using CRZ.Framework.Domain;

namespace CRZ.Stock.Platform.Domain
{
    public abstract class BaseValueObject : IValueObject<long>
    {
        public long Id { get; protected set; }

        public DateTimeOffset CreatedAt { get; protected set; }

        protected BaseValueObject()
        { }
    }
}
