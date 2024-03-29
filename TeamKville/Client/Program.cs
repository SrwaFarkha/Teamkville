using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TeamKville.Client;
using Syncfusion.Blazor;
using Blazored.Modal;
using Microsoft.Extensions.Azure;
using Blazored.LocalStorage;
using Blazored.Toast;
using Blazored.Toast.Services;
using TeamKville.Shared;

Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mgo+DSMBaFt+QHFqVkNrWU5CaV1CX2BZfVlyTWlaeE4BCV5EYF5SRHJfRF1gTXZQcU1rUHs=;Mgo+DSMBPh8sVXJ1S0d+X1RPc0BEQmFJfFBmRmldd1Rzc0U3HVdTRHRcQlljT35Qck1gXnZednA=;ORg4AjUWIQA/Gnt2VFhhQlJBfVpdW3xLflF1VWBTe1Z6d1JWESFaRnZdQV1nSXhTdUFrWnhXdnRR;MTYzNzcwOEAzMjMxMmUzMTJlMzMzNUNMUHZrSnNtT3A1S3NYL2wrMnQyT0U4RUsrcHlybnpIRWRNNDlaeUV4d2s9;MTYzNzcwOUAzMjMxMmUzMTJlMzMzNVNnN2JJd0dVV3NQeldEakZhQlRVc2I5UkNvZ1p0Vis5Y3ZMQWpWc1FTSlE9;NRAiBiAaIQQuGjN/V0d+XU9Hc1RHQmVWfFN0RnNadVp4flZBcC0sT3RfQF5jTX5VdkZnUXxWcHdQQg==;MTYzNzcxMUAzMjMxMmUzMTJlMzMzNWx1cUpnWlVvZElVY3FYL1VISE9PczIxZE55TnRKT0o4UjUxeW1oYmwxYW89;MTYzNzcxMkAzMjMxMmUzMTJlMzMzNWcvS21rb29TUmQrVjU3U0NVcG5haDQ4WnQwTkVVZnhIek1JQUp3UGp0MkU9;Mgo+DSMBMAY9C3t2VFhhQlJBfVpdW3xLflF1VWBTe1Z6d1JWESFaRnZdQV1nSXhTdUFrWndfcXRR;MTYzNzcxNEAzMjMxMmUzMTJlMzMzNWFqVGxTamQ1NHNJWGFnUFpqditKU1I4WkZoNzdvTnhlWUFTR291WlNYQVU9;MTYzNzcxNUAzMjMxMmUzMTJlMzMzNVJCdUtIejFYUXdMa2Rjb1lucVZrUE5JWVFUNCtYSC9YRUhlV1J2dHBaVHc9;MTYzNzcxNkAzMjMxMmUzMTJlMzMzNWx1cUpnWlVvZElVY3FYL1VISE9PczIxZE55TnRKT0o4UjUxeW1oYmwxYW89");
var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");





builder.Services.AddHttpClient("TeamKville.Server", client => {
	client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
	client.DefaultRequestHeaders.Add("X-API-KEY", SharedClass.apiKey);
});
builder.Services.AddSyncfusionBlazor();
builder.Services.AddBlazoredModal();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddBlazoredToast();
builder.Services.AddScoped<ToastService>();

// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("TeamKville.Server"));

builder.Services.AddMsalAuthentication(options =>
{
    builder.Configuration.Bind("AzureAd", options.ProviderOptions.Authentication);
    options.ProviderOptions.DefaultAccessTokenScopes.Add("https://graph.microsoft.com/User.Read");
});

builder.Services.AddMicrosoftGraphClient("https://graph.microsoft.com/User.Read");


await builder.Build().RunAsync();
