using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace BrigandineGEDataEditorGUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        // Original: http://www.devcoons.com/how-to-make-a-single-file-application-in-wpf-c-merging-dlls/
        // In App.g.cs the static Main calls this constructor first.
        public App()
        {
            var assemblies        = new Dictionary<string, Assembly>();
            var executingAssembly = Assembly.GetExecutingAssembly();
            var resources         = executingAssembly.GetManifestResourceNames().Where(n => n.EndsWith(".dll"));

            foreach (string resource in resources)
            {
                using (var stream = executingAssembly.GetManifestResourceStream(resource))
                {
                    if (stream == null)
                        continue;

                    var bytes = new byte[stream.Length];
                    stream.Read(bytes, 0, bytes.Length);
                    try
                    {
                        assemblies.Add(resource, Assembly.Load(bytes));
                    }
                    catch (Exception)
                    {
                        // ignored
                    }
                }
            }

            AppDomain.CurrentDomain.AssemblyResolve += (s, e) =>
            {
                var assemblyName = new AssemblyName(e.Name);
                var path         = string.Format("{0}.dll", assemblyName.Name);
                return assemblies.ContainsKey(path) ? assemblies[path] : null;
            };
        }
    }
}
