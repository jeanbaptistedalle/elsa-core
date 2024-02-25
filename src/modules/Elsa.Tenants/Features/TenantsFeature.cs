using Elsa.Features.Abstractions;
using Elsa.Features.Attributes;
using Elsa.Features.Services;
using Elsa.Identity.Providers;
using Elsa.Tenants.Accessors;
using Elsa.Tenants.Contracts;
using Elsa.Tenants.Options;
using Elsa.Tenants.Providers;
using Elsa.Tenants.Services;
using Elsa.Workflows.Runtime.Features;
using Microsoft.Extensions.DependencyInjection;

namespace Elsa.Tenants.Features;

/// <summary>
/// Configures liquid functionality.
/// </summary>
[DependsOn(typeof(WorkflowRuntimeFeature))]
public class TenantsFeature : FeatureBase
{
    /// <inheritdoc />
    public TenantsFeature(IModule serviceConfiguration) : base(serviceConfiguration)
    {
    }

    /// <summary>
    /// Configures the Tenants options.
    /// </summary>
    public Action<TenantsOptions> TenantsOptions { get; set; } = _ => { };

    /// <summary>
    /// A delegate that creates an instance of an implementation of <see cref="ITenantsProvider"/>.
    /// </summary>
    public Func<IServiceProvider, ITenantsProvider> TenantsProvider { get; set; } = sp => sp.GetRequiredService<ConfigurationTenantsProvider>();

    /// <inheritdoc />
    public override void Apply()
    {
        Services.Configure(TenantsOptions);

        Services
            .AddScoped<ITenantAccessor, TenantAccessor>()
            .AddScoped<ITenantServiceScopeFactory, TenantServiceScopeFactory>()
            .AddSingleton<ConfigurationTenantsProvider>()
            .AddScoped(TenantsProvider);
    }

    /// <summary>
    /// Configures the feature to use <see cref="ConfigurationBasedUserProvider"/>.
    /// </summary>
    public TenantsFeature UseConfigurationBasedTenantsProvider()
    {
        TenantsProvider = sp => sp.GetRequiredService<ConfigurationTenantsProvider>();
        return this;
    }

    /// <summary>
    /// Configures the feature to use <see cref="ConfigurationBasedUserProvider"/>.
    /// </summary>
    public TenantsFeature UseExternalTenantResolverMiddleware()
    {
        return this;
    }
}