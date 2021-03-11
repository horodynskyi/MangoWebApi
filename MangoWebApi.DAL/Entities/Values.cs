using MangoWebApi.DAL.Interfaces;

namespace MangoWebApi.DAL.Entities
{
    public class Values : IEntity<int>
    {
        public int Id { get; set; }
        public string value { get; set; }
        public string slug { get; set; }
        int atribute_id { get; set; }

    }
}
