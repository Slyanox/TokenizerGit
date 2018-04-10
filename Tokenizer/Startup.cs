using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Tokenizer.Startup))]
namespace Tokenizer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
