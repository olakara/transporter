
using Serilog;
using Transporter.Web;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using OpenTelemetry.Metrics;

var builder = WebApplication.CreateBuilder(args);

// Configure Serilog
builder.Host.UseSerilog((context, services, configuration) => 
    configuration.ReadFrom.Configuration(context.Configuration));

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddHealthChecks();

// Configure OpenTelemetry
var otlpEndpoint = builder.Configuration["OpenTelemetry:OtlpExporter:Endpoint"];
var enableConsoleTracing = builder.Configuration.GetValue<bool>("OpenTelemetry:Tracing:ConsoleExporter:Enabled");
var enableConsoleMetrics = builder.Configuration.GetValue<bool>("OpenTelemetry:Metrics:ConsoleExporter:Enabled");
var enableOtlpTracing = builder.Configuration.GetValue<bool>("OpenTelemetry:Tracing:OtlpExporter:Enabled");
var enableOtlpMetrics = builder.Configuration.GetValue<bool>("OpenTelemetry:Metrics:OtlpExporter:Enabled");

builder.Services.AddOpenTelemetry()
    .ConfigureResource(resource => resource
        .AddService(
            builder.Configuration["OpenTelemetry:ServiceName"] ?? "Transporter.Web",
            builder.Configuration["OpenTelemetry:ServiceVersion"] ?? "1.0.0"))
    .WithTracing(tracing =>
    {
        tracing.AddAspNetCoreInstrumentation()
               .AddHttpClientInstrumentation();
        
        if (enableConsoleTracing)
            tracing.AddConsoleExporter();
        
        if (enableOtlpTracing && !string.IsNullOrEmpty(otlpEndpoint))
            tracing.AddOtlpExporter(options => options.Endpoint = new Uri(otlpEndpoint));
    })
    .WithMetrics(metrics =>
    {
        metrics.AddAspNetCoreInstrumentation()
               .AddHttpClientInstrumentation()
               .AddRuntimeInstrumentation();
        
        if (enableConsoleMetrics)
            metrics.AddConsoleExporter();
        
        if (enableOtlpMetrics && !string.IsNullOrEmpty(otlpEndpoint))
            metrics.AddOtlpExporter(options => options.Endpoint = new Uri(otlpEndpoint));
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapHealthChecks("/health");

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

// Ensure Serilog flushes logs on shutdown
Log.CloseAndFlush();
