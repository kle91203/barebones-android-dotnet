using Iot.Core;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

var builder = Host.CreateApplicationBuilder(args);
builder.AddIotServices();
builder.Logging.AddSimpleConsole(o => o.TimestampFormat = "HH:mm:ss ");
await builder.Build().RunAsync();

