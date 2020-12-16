using System;
using Flunt.Notifications;

namespace todo_clean.shared.entities
{
     public abstract class BaseEntity : Notifiable
    {
        protected BaseEntity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }
    }
}