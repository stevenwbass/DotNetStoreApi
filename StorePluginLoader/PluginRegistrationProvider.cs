using System.Configuration;

namespace StorePluginLoader;

public class PluginRegistrationProvider : IPluginRegistrationProvider {
    private readonly string[] _pluginFolders;
    public PluginRegistrationProvider(string[] pluginFolders) {
        _pluginFolders = pluginFolders;
    }

    void IPluginRegistrationProvider.RegisterPlugins()
    {
        foreach (var pluginFolder in _pluginFolders) {
            
        }
    }
}