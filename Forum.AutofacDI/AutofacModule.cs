using Autofac;
using Forum.Db.Sql;
using Forum.Logic;
using Forum.Services;

namespace Forum.AutofacDI;

public class AutofacModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        base.Load(builder);
        builder.RegisterType<BasicUserService>().As<IUserService>();
        builder.RegisterType<BasicPostService>().As<IPostService>();

        builder.RegisterType<ImplSqlDbFactory>().As<ISqlDbFactory>();
        

        builder.RegisterType<DevDatabaseService>().As<IDatabaseService>();
    }
}