namespace MangoWebApi.DAL.Interfaces
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
