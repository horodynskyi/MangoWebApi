namespace MangoWebApi.DAL.Interfaces
{
    public interface IEntity<T>
    {
        T id { get; set; }
    }
}
