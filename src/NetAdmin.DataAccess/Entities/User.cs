namespace NetAdmin.DataAccess
{
    public class User : IEntity
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public byte[] Password { get; set; }
        public byte[] Salt { get; set; }
    }
}