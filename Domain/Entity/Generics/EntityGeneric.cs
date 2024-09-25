namespace Domain.Entity.Generics
{
    public class EntityGeneric
    {
        public Guid Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public bool Deleted { get; private set; } = false;

        public void MarkAsDeleted()
        {
            Deleted = true;
        }

        public void MarkAsUpdated()
        {
            Deleted = false;
        }
    }
}
