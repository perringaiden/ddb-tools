using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text.Json;

public class Program
{
    static async Task Main(string[] args)
    {
        IHostBuilder hostBuilder = Host.CreateDefaultBuilder();

        hostBuilder.UseServiceProviderFactory(new AutofacServiceProviderFactory());

        hostBuilder.ConfigureContainer<ContainerBuilder>((containerBuilder) =>
        {
            ServiceCollection serviceCollection = new();

            serviceCollection.AddHttpClient();
            serviceCollection.AddLogging();

            containerBuilder.Populate(serviceCollection);

            containerBuilder.RegisterType<Wolflight.Utilities.Communication.HttpCommunicator>()
                .As<Wolflight.Utilities.Communication.IHttpCommunicator>()
                .SingleInstance();

            containerBuilder.RegisterType<Wolflight.DnDBeyond.Communication.CharacterRetriever>()
                .As<Wolflight.DnDBeyond.Communication.ICharacterRetriever>();

            containerBuilder.RegisterType<Wolflight.DnDBeyond.Data.Processors.CharacterReader>()
                .As<Wolflight.DnDBeyond.Data.Processors.ICharacterReader>();
        });

        IHost host = hostBuilder.Build();

        Wolflight.DnDBeyond.Communication.ICharacterRetriever retriever = host.Services.GetRequiredService<Wolflight.DnDBeyond.Communication.ICharacterRetriever>();

        JsonDocument characterDocument = await retriever.Retrieve(127317564, "");

        Wolflight.DnDBeyond.Data.Types.Character character = host.Services.GetRequiredService<Wolflight.DnDBeyond.Data.Processors.ICharacterReader>().ReadCharacter(characterDocument);

        //Console.WriteLine(characterDocument.RootElement.ToString());

        Console.WriteLine(character.Attributes.Strength.CurrentValue);
    }

}