using System.Collections.ObjectModel;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Windows;
using BrigandineGEDataEditor;
using BrigandineGEDataEditor.DataTypes;
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

        private static ObservableCollection<BaseDataTypeHeaderViewModel> SetupDummyDataTypeHeaders()
        {
            var dataTypeHeaderViewModel = new ObservableCollection<BaseDataTypeHeaderViewModel>();
            dataTypeHeaderViewModel.Add(new DummyDataTypeHeaderViewModel("AttackDataHeaderViewModel"));
            dataTypeHeaderViewModel.Add(new DummyDataTypeHeaderViewModel("CastleDataHeaderViewModel"));
            dataTypeHeaderViewModel.Add(new DummyDataTypeHeaderViewModel("ClassDataHeaderViewModel"));
            dataTypeHeaderViewModel.Add(new DummyDataTypeHeaderViewModel("DefaultKnightHeaderViewModel"));
            dataTypeHeaderViewModel.Add(new DummyDataTypeHeaderViewModel("ItemDataHeaderViewModel"));
            dataTypeHeaderViewModel.Add(new DummyDataTypeHeaderViewModel("MonsterInSummonDataHeaderViewModel"));
            dataTypeHeaderViewModel.Add(new DummyDataTypeHeaderViewModel("SkillDataHeaderViewModel"));
            dataTypeHeaderViewModel.Add(new DummyDataTypeHeaderViewModel("SpecialAttackDataHeaderViewModel"));
            dataTypeHeaderViewModel.Add(new DummyDataTypeHeaderViewModel("SpellDataHeaderViewModel"));
            return dataTypeHeaderViewModel;
        }
        #endregion
        private MemoryAccessor memoryAccessor;
        private string fileToMap;
        public MainWindowViewModel()
        {
            OpenAndLoadFileCommand = new Command(OpenAndLoadFile, () => true);
            UnloadFileCommand = new Command(UnloadFile, () => true);
            OnCloseCommand = new Command(DisposeOfMappedFiles, () => true);
            SaveAsCommand = new Command(SaveAs, () => true);

            DataTypeHeaderViewModel = SetupDummyDataTypeHeaders();
            // TODO DELETE THE LINES BELOW SO THE FILE IS NOT AUTOLOADED FROM DIRECTORY. THIS IS FOR QUICK TESTING
            //fileToMap = @"C:\Users\Dave\Documents\Visual Studio 2017\Projects\Brigandine GE Data Editor GUI\SLPS_026";
            //LoadAndReadFile();


        }

        private void DisposeOfMappedFiles() => MemoryAccessor.DisposeAllMappedFiles();
        private void OpenAndLoadFile() 
        {
            var openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                fileToMap = openFileDialog.FileName;
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
        }

        private void UnloadFile()
        {
            DataTypeHeaderViewModel = SetupDummyDataTypeHeaders();
            memoryAccessor.Dispose();
        }

        private void SaveAllDataTypesIntoMemoryMappedFile(string path)
        {
            using(var memoryMappedFile = MemoryMappedFile.CreateFromFile(path))
            {
                using(var accessor = memoryMappedFile.CreateViewAccessor())
                {
                    accessor.WriteArray(new AttackData().GetAddress(0), memoryAccessor.Attacks, 0, memoryAccessor.Attacks.Length);
                    accessor.WriteArray(new CastleData().GetAddress(0), memoryAccessor.Castles, 0, memoryAccessor.Castles.Length);
                    accessor.WriteArray(new ClassData ().GetAddress(0), memoryAccessor.Classes, 0, memoryAccessor.Castles.Length);
                    accessor.WriteArray(new DefaultKnightData().GetAddress(0), memoryAccessor.DefaultKnights, 0, memoryAccessor.DefaultKnights.Length);
                    accessor.WriteArray(new ItemData().GetAddress(0), memoryAccessor.Items, 0, memoryAccessor.Items.Length);
                    accessor.WriteArray(new MonsterInSummonData().GetAddress(0), memoryAccessor.MonstersInSummon, 0, memoryAccessor.MonstersInSummon.Length);
                    accessor.WriteArray(new SkillData().GetAddress(0), memoryAccessor.Skills, 0, memoryAccessor.Skills.Length);
                    accessor.WriteArray(new SpellData().GetAddress(0), memoryAccessor.Spells, 0, memoryAccessor.Spells.Length);
                    accessor.WriteArray(new SpecialAttackData().GetAddress(0), memoryAccessor.SpecialAttacks, 0, memoryAccessor.SpecialAttacks.Length);

// Work In Progress
                    #if Work_In_Progress
                        accessor.WriteArray(new MonsterData().GetAddress(0), memoryAccessor.Monsters, 0, memoryAccessor.Attacks.Length);
                        accessor.WriteArray(new StatGrowthData().GetAddress(0), memoryAccessor.StatGrowths, 0, memoryAccessor.Attacks.Length);
                    #endif

                }
            }
        }
        // TODO Finish Implementing.
        private void SaveAs()
        {
            
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.CheckFileExists = true;
            if(saveFileDialog.ShowDialog() == true)
            {
               
            }
            MessageBox.Show("Done Saving File");
        }
        public Command SaveAsCommand { get; set; }
        public Command OpenAndLoadFileCommand { get; set; }
        public Command UnloadFileCommand { get; set; }
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