using Autofac;

namespace NetAdmin.DataAccess
{
    public class RepositoriesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterAssemblyTypes(ThisAssembly)
                .Where(x => x.IsAssignableTo<IRepository>())
                .AsImplementedInterfaces();

            builder.RegisterType<NetAdminDbContext>()
                .AsSelf()
                .AsImplementedInterfaces();
        }
    }
}