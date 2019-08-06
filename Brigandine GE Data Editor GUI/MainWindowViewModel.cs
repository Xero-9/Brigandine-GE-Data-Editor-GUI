using System.Collections.ObjectModel;
using System.IO;
using BrigandineGEDataEditor;
using BrigandineGEDataEditorGUI.Data_Type_Header_ViewModels;
using BrigandineGEDataEditorGUI.Data_Type_Header_ViewModels.Base;
using BrigandineGEDataEditorGUI.Data_Type_View_Models.Base;
using Microsoft.Win32;

namespace BrigandineGEDataEditorGUI
{
    public class MainWindowViewModel : BaseViewModel
    {
        // Dummy class so that the different DataType names are displayed even before a SLPS_026 file is loaded
        #region DummyDataTypeHeaderViewModel

        private class DummyDataTypeHeaderViewModel : BaseDataTypeHeaderViewModel
        {
            public DummyDataTypeHeaderViewModel(string name)
            {
                Name = name;
            }
            public override string Name { get; }
            public override string ToString() => string.Empty;
        }

        #endregion
        private MemoryAccessor memoryAccessor;
        private string fileToMap;
        public MainWindowViewModel()
        {
            OpenFileCommand = new Command(OpenFileDialog, () => true);
            LoadAndReadFileCommand = new Command(LoadAndReadFile, () => true);
            OnCloseCommand = new Command(DisposeOfMappedFiles, () => true);
            SaveAsCommand = new Command(SaveAs, () => true);

            DataTypeHeaderViewModel = new ObservableCollection<BaseDataTypeHeaderViewModel>();
            DataTypeHeaderViewModel.Add(new DummyDataTypeHeaderViewModel("AttackDataHeaderViewModel"));
            DataTypeHeaderViewModel.Add(new DummyDataTypeHeaderViewModel("CastleDataHeaderViewModel"));
            DataTypeHeaderViewModel.Add(new DummyDataTypeHeaderViewModel("ClassDataHeaderViewModel"));
            DataTypeHeaderViewModel.Add(new DummyDataTypeHeaderViewModel("DefaultKnightHeaderViewModel"));
            DataTypeHeaderViewModel.Add(new DummyDataTypeHeaderViewModel("ItemDataHeaderViewModel"));
            DataTypeHeaderViewModel.Add(new DummyDataTypeHeaderViewModel("MonsterInSummonDataHeaderViewModel"));
            DataTypeHeaderViewModel.Add(new DummyDataTypeHeaderViewModel("SkillDataHeaderViewModel"));
            DataTypeHeaderViewModel.Add(new DummyDataTypeHeaderViewModel("SpecialAttackDataHeaderViewModel"));
            DataTypeHeaderViewModel.Add(new DummyDataTypeHeaderViewModel("SpellDataHeaderViewModel"));

            // TODO DELETE THE LINES BELOW SO THE FILE IS NOT AUTOLOADED FROM DIRECTORY. THIS IS FOR QUICK TESTING
            //fileToMap = @"C:\Users\Dave\Documents\Visual Studio 2017\Projects\Brigandine GE Data Editor GUI\SLPS_026";
            //LoadAndReadFile();


        }
        
        private void DisposeOfMappedFiles() => MemoryAccessor.DisposeAllMappedFiles();
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
                DataTypeHeaderViewModel = new ObservableCollection<BaseDataTypeHeaderViewModel>();
                DataTypeHeaderViewModel.Add(new AttackDataHeaderViewModel(memoryAccessor));
                DataTypeHeaderViewModel.Add(new CastleDataHeaderViewModel(memoryAccessor));
                DataTypeHeaderViewModel.Add(new ClassDataHeaderViewModel(memoryAccessor));
                DataTypeHeaderViewModel.Add(new DefaultKnightHeaderViewModel(memoryAccessor));
                DataTypeHeaderViewModel.Add(new ItemDataHeaderViewModel(memoryAccessor));
                DataTypeHeaderViewModel.Add(new MonsterInSummonDataHeaderViewModel(memoryAccessor));
                DataTypeHeaderViewModel.Add(new SkillDataHeaderViewModel(memoryAccessor));
                DataTypeHeaderViewModel.Add(new SpecialAttackDataHeaderViewModel(memoryAccessor));
                DataTypeHeaderViewModel.Add(new SpellDataHeaderViewModel(memoryAccessor));
                
                // Work In Progress
                //DataTypeHeaderViewModel.Add(new MonsterDataHeaderViewModel(memoryAccessor));
                //DataTypeHeaderViewModel.Add(new StatGrowthDataHeaderViewModel(memoryAccessor));
            }
        }
        
        // TODO Finish Implementing.
        private void SaveAs()
        {
            var saveFileDialog = new SaveFileDialog();
            if(saveFileDialog.ShowDialog() == true)
                using (var writer = new StreamWriter(saveFileDialog.FileName))
                {
                    //writer.Write();
                }
        }
        public Command SaveAsCommand { get; set; }
        public Command OpenFileCommand { get; set; }
        public Command LoadAndReadFileCommand { get; set; }
        public Command OnCloseCommand { get; set; }

        private ObservableCollection<BaseDataTypeHeaderViewModel> dataTypeHeaderViewModel;
        public ObservableCollection<BaseDataTypeHeaderViewModel> DataTypeHeaderViewModel
        {
            get => dataTypeHeaderViewModel;
            set => SetAndNotifyIfChanged(ref dataTypeHeaderViewModel, value);
        }

        private BaseDataTypeHeaderViewModel selectedBaseDataTypeHeaderViewModel;

        public BaseDataTypeHeaderViewModel SelectedBaseDataTypeHeaderViewModel
        {
            get => selectedBaseDataTypeHeaderViewModel;
            set => SetAndNotifyIfChanged(ref selectedBaseDataTypeHeaderViewModel, value);
        }
    }
}