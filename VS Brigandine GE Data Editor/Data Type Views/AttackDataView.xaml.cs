using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using VS_Brigandine_GE_Data_Editor.Data_Type_View_Models;

namespace VS_Brigandine_GE_Data_Editor.Data_Type_Views
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
