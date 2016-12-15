namespace NetAdmin.DataAccess
{
    public interface IUserRepository :
        IInsertable<User>,
        IUpdatable<User>,
        IDeletable<User>,
        IObtainable<User>
    {

    }
}