using System;
using events;

namespace events .Models
{
    public abstract class BaseEntity
    {
        public DateTime CreatedAt {get;set;}
        public DateTime UpdatedAt {get;set;}
    }
}