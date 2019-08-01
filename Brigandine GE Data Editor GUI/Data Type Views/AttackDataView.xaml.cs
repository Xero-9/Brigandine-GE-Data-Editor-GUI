using System.Windows.Controls;
using BrigandineGEDataEditorGUI.Data_Type_View_Models;

namespace BrigandineGEDataEditorGUI.Data_Type_Views
{
    /// <summary>
    /// Interaction logic for AttackDataView.xaml
    /// </summary>
    public partial class AttackDataView : UserControl
    {
        public AttackDataView()
        {
            InitializeComponent();
        }

        public AttackDataView(AttackDataViewModel attackDataViewModel)
        {
            InitializeComponent();
            DataContext = attackDataViewModel;
        }
    }
}
