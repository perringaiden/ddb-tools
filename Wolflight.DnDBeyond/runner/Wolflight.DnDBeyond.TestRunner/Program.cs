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

            containerBuilder.RegisterType<Wolflight.DnDBeyond.Character.Communication.CharacterRetriever>()
                .As<Wolflight.DnDBeyond.Character.Communication.ICharacterRetriever>();
        });

        IHost host = hostBuilder.Build();

        Wolflight.DnDBeyond.Character.Communication.ICharacterRetriever retriever = host.Services.GetRequiredService<Wolflight.DnDBeyond.Character.Communication.ICharacterRetriever>();

        JsonDocument characterDocument = await retriever.Retrieve(127317564, "");

        Console.WriteLine(characterDocument.RootElement.ToString());
    }

}