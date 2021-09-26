namespace Core.Common.Domain
{
    public abstract class Entity<TPrimaryKey>
    {
        public TPrimaryKey Id { get; protected set; }

        protected Entity(TPrimaryKey id)
        {
            Id = id;
        }
    }
}