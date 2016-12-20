namespace NetAdmin.Common.Abstractions
{
    public interface IEntity<TId>
    {
        TId Id { get; set; }
    }
}