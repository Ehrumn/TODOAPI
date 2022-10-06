namespace Todo.Domain.Entities;

public abstract class Entity : IEquatable<Entity>
{
    public Guid Id { get; private set; }

    public bool Equals(Entity? other) => Id == other.Id;

    public Entity() => Id = Guid.NewGuid();
}
