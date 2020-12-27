using System;
using Flunt.Notifications;

namespace todo_clean.shared.entities
{
    public abstract class BaseEntity : Notifiable
    {
        public Guid id { get; private set; }
        public DateTime createAt { get; private set; }
        public DateTime updateAt { get; private set; }

        protected BaseEntity(DateTime createAt, Guid? id = null)
        {
            this.id = id ?? Guid.NewGuid();
            this.createAt = createAt;
            this.updateAt = DateTime.Now;
        }
    }
}