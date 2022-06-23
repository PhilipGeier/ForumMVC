using Autofac;
using Autofac.Core;
using Forum.Db.Sql;
using Forum.Logic;
using Forum.Services;

namespace AutofacDI;

public class AutofacModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        base.Load(builder);
        builder.RegisterType<BasicUserService>().As<IUserService>();


        builder.RegisterType<SqlDbFactory<>>();
        
#if DEBUG
        builder.RegisterType<DevDatabaseService>().As<IDatabaseService>();
#else
        builder.RegisterType<AppSettingsDatabaseService>().As<IDatabaseService>();
#endif
    }
}