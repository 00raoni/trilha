namespace trilha_net.Infra.CrossCutting.Models
{
    public abstract class Entity
    {
        protected Entity()
        {

        }
        public Guid Id { get; protected set; }
        public DateTime CreatedAtUtc { get; protected set; }
        public DateTime? UpdatedAtUtc { get; protected set; }
        public DateTime? DeletedAtUtc { get; protected set; }

        //public abstract bool IsValid();
        public Entity GenerateId(Guid? id = null)
        {
            Id = id ?? Guid.NewGuid();
            CreatedAtUtc = DateTime.UtcNow;
            return this;
        }

        public void SetCreatedAtUtc(DateTime dateTime)
        {
            CreatedAtUtc = dateTime;
        }        

        public void SetUpdatedAtUtc(DateTime dateTime)
        {
            UpdatedAtUtc = dateTime;
        }
        public void SetDeletedAtUtc(DateTime dateTime)
        {
            DeletedAtUtc = dateTime;
        }
        /// <summary>
        /// Indica está com tracking do Entity Framework.
        /// </summary>
        /// <returns></returns>
        public bool IsTracked()
        {
            return CreatedAtUtc > DateTime.MinValue;
        }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 907) + Id.GetHashCode();
        }

        public override string ToString()
        {
            return GetType().Name + "[Id = " + Id + " ]";
        }        
    }
}
