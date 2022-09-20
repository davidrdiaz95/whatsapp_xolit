using NetCore.AutoRegisterDi;
using System.Reflection;
using Xolit.Whatsapp.DataAccess.Models;
using Xolit.Whatsapp.DataAccess.Repositories;
using Xolit.Whatsapp.DataAccess.Repositories.Imp;
using Xolit.Whatsapp.DataTransferObjects.Models;
using Xolit.Whatsapp.Domain.Mappers;
using static Xolit.Whatsapp.Contracts.Mappers.IMapper;

namespace Xolit.Whatsapp.Extensions
{
    public static class  DependencyInjectionSetupExtensions
    {
        public static void RegisterServiceLayerDi(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddScoped(typeof(IMapper<ConversationDTO, Conversation>), typeof(ConversationMapper));
            services.AddScoped(typeof(IMapper<MessageConversationDTO, MessageConversation>), typeof(MessageConversationMapper));

            var assemblyDomain = AppDomain.CurrentDomain.Load("Xolit.Whatsapp.Domain");
            var assemblyContracts = AppDomain.CurrentDomain.Load("Xolit.Whatsapp.Contracts");

            services.RegisterAssemblyPublicNonGenericClasses(new Assembly[] { assemblyDomain, assemblyContracts })
                .Where(c => c.Name.EndsWith("Command"))
                .AsPublicImplementedInterfaces();

            services.RegisterAssemblyPublicNonGenericClasses(new Assembly[] { assemblyDomain, assemblyContracts })
                .Where(c => c.Name.EndsWith("Invoker"))
                .AsPublicImplementedInterfaces();

            services.RegisterAssemblyPublicNonGenericClasses(new Assembly[] { assemblyDomain, assemblyContracts })
                .Where(c => c.Name.EndsWith("Service"))
                .AsPublicImplementedInterfaces();

            services.RegisterAssemblyPublicNonGenericClasses(new Assembly[] { assemblyDomain, assemblyContracts })
                .Where(c => c.Name.EndsWith("Mapper"))
                .AsPublicImplementedInterfaces();

            services.RegisterAssemblyPublicNonGenericClasses(new Assembly[] { assemblyDomain, assemblyContracts })
                .Where(c => c.Name.Contains("QueryObject"))
                .AsPublicImplementedInterfaces();
        }
    }
}
