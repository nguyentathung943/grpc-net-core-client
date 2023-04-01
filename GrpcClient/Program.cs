using GrpcClient;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Grpc.Net.Client;
using Grpc.Net.Client.Web;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration.GetValue<string>("BaseSampleAPIUrl")) });

//Add gRPC service
builder.Services.AddSingleton(services =>
{
    // Get the service address from appsettings.json

    var config = services.GetRequiredService<IConfiguration>();
    var backendUrl = builder.Configuration.GetValue<string>("BaseGrpcServerUrl");

    // Create a channel with a GrpcWebHandler that is addressed to the backend server.
    //
    // GrpcWebText is used because server streaming requires it. If server streaming is not used in your app
    // then GrpcWeb is recommended because it produces smaller messages.

    var httpHandler = new GrpcWebHandler(GrpcWebMode.GrpcWebText, new HttpClientHandler());
    return GrpcChannel.ForAddress(backendUrl, new GrpcChannelOptions
    {
        HttpHandler = httpHandler,
        MaxSendMessageSize = 100 * 1024 * 1024,
        MaxReceiveMessageSize = 100 * 1024 * 1024
    });
});



await builder.Build().RunAsync();
