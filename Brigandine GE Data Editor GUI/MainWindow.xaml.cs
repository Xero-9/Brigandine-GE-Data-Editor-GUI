using System.ComponentModel;
using BrigandineGEDataEditor;

namespace BrigandineGEDataEditorGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }

        // This is needed so I don't have to include Microsoft.Xaml.Behaviors.dll and can
        // pack the entire project into a single file.
        protected override void OnClosing(CancelEventArgs e)
        {
            MemoryAccessor.DisposeAllMappedFiles();
            base.OnClosing(e);
        }
    }
}
