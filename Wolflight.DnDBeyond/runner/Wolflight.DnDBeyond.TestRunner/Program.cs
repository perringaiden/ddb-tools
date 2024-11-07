using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text.Json;
using Wolflight.DMScreen.Character.Processors;
using Wolflight.DnDBeyond.Communication;

public class Program
{
    static async Task Main(string[] args)
    {

        bool localLoad = true;
        int characterID = 135682948;

        // Fighter Base - 135682948
        // Warlock 5 - 127317564

        IHost host = BuildHost();

        JsonDocument characterDocument;

        if (localLoad)
        {
            characterDocument = JsonDocument.Parse(new FileStream(".\\fighter.json", FileMode.Open));
        }
        else
        {
            characterDocument = await Retrieve(host, characterID, null);
        }

        //await Save(characterDocument, ".\\fighter.json");

        Wolflight.DnDBeyond.Data.Json.JsonCharacter? character = Wolflight.DnDBeyond.Data.Json.JsonDeserializer.DeserializeCharacter(characterDocument);

        //CharacterSheet character = host.Services.GetRequiredService<ICharacterReader>().ReadCharacter(characterDocument);
        //Console.WriteLine(character.Attributes.Strength.CurrentValue);

        Console.ReadKey();
    }

    private static IHost BuildHost()
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

            containerBuilder.RegisterType<CharacterRetriever>().As<ICharacterRetriever>();
            containerBuilder.RegisterType<CharacterReader>().As<ICharacterReader>();
        });

        return hostBuilder.Build();
    }

    private static async Task<JsonDocument> Retrieve(IHost host, int ID, string? token)
    {
        return await host
               .Services
               .GetRequiredService<ICharacterRetriever>()
               .Retrieve(ID, token);
    }

    private static async Task Save(JsonDocument characterJson, string filename)
    {
        FileStream fileStream;
        Utf8JsonWriter streamWriter;

        fileStream = new FileStream(filename, FileMode.OpenOrCreate);
        streamWriter = new Utf8JsonWriter(fileStream, options: new JsonWriterOptions { Indented = true });

        characterJson.WriteTo(streamWriter);
        await streamWriter.FlushAsync();
    }


}