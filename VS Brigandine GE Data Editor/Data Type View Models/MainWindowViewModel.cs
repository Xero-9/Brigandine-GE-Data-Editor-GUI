using System.Collections.ObjectModel;
using Memory_Map_Builder;
using Microsoft.Win32;
using VS_Brigandine_GE_Data_Editor.Data_Type_View_Models.Base;
using VS_Brigandine_GE_Data_Editor.Data_Type_Views;

namespace VS_Brigandine_GE_Data_Editor.Data_Type_View_Models
{
    public class MainWindowViewModel : BaseViewModel
    {
        private MemoryAccessor memoryAccessor;
        private string fileToMap;
        public MainWindowViewModel()
        {
            OpenFileCommand = new Command(OpenFileDialog, () => true);
            LoadAndReadFileCommand = new Command(LoadAndReadFile, () => true);

            // TODO DELETE THIS LINE SO THE FILE IS NOT AUTOLOADED FROM DIRECTORY.
            fileToMap = @"C:\Users\David\Documents\Visual Studio 2017\Projects\VS Brigandine GE Data Editor\SLPS_026";
            LoadAndReadFile();
        }

        private void OpenFileDialog()
        {
            var openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                fileToMap = openFileDialog.FileName;
            }
        }

        private void LoadAndReadFile()
        {
            if(fileToMap != null)
            {
                memoryAccessor = MemoryAccessor.CreateAccessor(fileToMap);

                if(memoryAccessor == null)
                    return;
                AttackDataViewModel = new AttackDataViewModel(memoryAccessor);
//                attackDataViewModels = new ObservableCollection<AttackDataViewModel>();
//                foreach (var attackData in memoryAccessor.AttackDatas)
//                {
//                    attackDataViewModels.Add(new AttackDataViewModel(memoryAccessor));
//                }
//                NotifyPropertyChanged(nameof(AttackDataViewModels));
            }
        }

        private AttackDataViewModel attackDataViewModel;

        public AttackDataViewModel AttackDataViewModel
        {
            get => attackDataViewModel;
            set => SetAndNotifyIfChanged(ref attackDataViewModel, value);
        }

//        private ObservableCollection<AttackDataViewModel> attackDataViewModels;
//        public ObservableCollection<AttackDataViewModel> AttackDataViewModels
//        {
//            get => attackDataViewModels;
//            set => SetAndNotifyIfChanged(ref attackDataViewModels, value);
//        }
        public Command OpenFileCommand { get; set; }
        public Command LoadAndReadFileCommand { get; set; }
    }
}