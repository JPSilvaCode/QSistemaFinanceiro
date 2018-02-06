using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QSistemaFinanceiro.Startup))]
namespace QSistemaFinanceiro
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
