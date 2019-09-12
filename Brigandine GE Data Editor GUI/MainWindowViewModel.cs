using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using BrigandineGEDataEditor;
using BrigandineGEDataEditorGUI.Data_Type_Header_ViewModels;
using BrigandineGEDataEditorGUI.Data_Type_Header_ViewModels.Base;
using BrigandineGEDataEditorGUI.Data_Type_ViewModels.Base;
using Microsoft.Win32;

namespace BrigandineGEDataEditorGUI
{
    public class MainWindowViewModel : BaseViewModel
    {
        private static ObservableCollection<BaseDataTypeHeaderViewModel> LoadSlpsFile(MemoryAccessor memoryAccessor)
        {
            if(memoryAccessor == null)
                return null;
            var dataTypeHeaderViewModel = new ObservableCollection<BaseDataTypeHeaderViewModel>
                                          {
                                              new AttackDataHeaderViewModel(memoryAccessor),
                                              new CastleDataHeaderViewModel(memoryAccessor),
                                              new ClassDataHeaderViewModel(memoryAccessor),
                                              new DefaultKnightHeaderViewModel(memoryAccessor),
                                              new ItemDataHeaderViewModel(memoryAccessor),
                                              new SkillDataHeaderViewModel(memoryAccessor),
                                              new SpecialAttackDataHeaderViewModel(memoryAccessor),
                                              new SpellDataHeaderViewModel(memoryAccessor)
                                          };

            // Work In Progress
            //dataTypeHeaderViewModel.Add(new MonsterInSummonDataHeaderViewModel(memoryAccessor));
            //dataTypeHeaderViewModel.Add(new MonsterDataHeaderViewModel(memoryAccessor));
            //dataTypeHeaderViewModel.Add(new StatGrowthDataHeaderViewModel(memoryAccessor));

            return dataTypeHeaderViewModel;
        }
        // Dummy class so that the different DataType names are displayed even before a SLPS_026 file is loaded
        #region DummyDataTypeHeaderViewModel

        private class DummyDataTypeHeaderViewModel : BaseDataTypeHeaderViewModel
        {
            public DummyDataTypeHeaderViewModel(string name) : base(null) => Name = name;
            public override string Name { get; }

            // This is what displayed if set to anything but Empty.
            public override string ToString() => string.Empty;
            public override void SetAccessor() => throw new NotImplementedException();
        }

        private static ObservableCollection<BaseDataTypeHeaderViewModel> SetupDummyDataTypeHeaders()
        {
            var dataTypeHeaderViewModel = new ObservableCollection<BaseDataTypeHeaderViewModel>
                                          {
                                              new DummyDataTypeHeaderViewModel("AttackDataHeaderViewModel"),
                                              new DummyDataTypeHeaderViewModel("CastleDataHeaderViewModel"),
                                              new DummyDataTypeHeaderViewModel("ClassDataHeaderViewModel"),
                                              new DummyDataTypeHeaderViewModel("DefaultKnightHeaderViewModel"),
                                              new DummyDataTypeHeaderViewModel("ItemDataHeaderViewModel"),
                                              new DummyDataTypeHeaderViewModel("SkillDataHeaderViewModel"),
                                              new DummyDataTypeHeaderViewModel("SpecialAttackDataHeaderViewModel"),
                                              new DummyDataTypeHeaderViewModel("SpellDataHeaderViewModel")
                                          };

            // Work In Progress
            //dataTypeHeaderViewModel.Add(new DataTypeHeaderAndTypeInfo() { DataTypeHeaderViewModel = new DummyDataTypeHeaderViewModel("MonsterInSummonDataHeaderViewModel") });
            //dataTypeHeaderViewModel.Add(new DataTypeHeaderAndTypeInfo() { DataTypeHeaderViewModel = new DummyDataTypeHeaderViewModel("MonsterDataHeaderViewModel") });
            //dataTypeHeaderViewModel.Add(new DataTypeHeaderAndTypeInfo() { DataTypeHeaderViewModel = new DummyDataTypeHeaderViewModel("StatGrowthDataHeaderViewModel") });
            return dataTypeHeaderViewModel;
        }
        #endregion
        private MemoryAccessor memoryAccessor;
        private string fileToMap;
        public MainWindowViewModel()
        {
            LoadDefaultDataCommand = new Command(LoadDefaultData, () => true);
            OpenAndLoadFileCommand = new Command(OpenAndLoadFile, () => true);
            UnloadWithoutSaveCommand = new Command(UnloadWithoutSave, () => true);
            UnloadAndSaveCommand = new Command(UnloadAndSave, () => true);
            SaveToFileCommand = new Command(SaveToFile, () => true);
            DataTypeHeaderViewModel = SetupDummyDataTypeHeaders();
        }

        private void LoadDefaultData()
        {
            memoryAccessor = MemoryAccessor.CreateAccessor();
            DataTypeHeaderViewModel = LoadSlpsFile(memoryAccessor);
        }
        private void OpenAndLoadFile() 
        {
            var openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                fileToMap = openFileDialog.FileName;
                if(fileToMap != null)
                {
                    memoryAccessor = MemoryAccessor.CreateAccessor(fileToMap);
                    DataTypeHeaderViewModel = LoadSlpsFile(memoryAccessor);
                }
            }
        }

        private void UnloadWithoutSave()
        {
            DataTypeHeaderViewModel = SetupDummyDataTypeHeaders();
            memoryAccessor.Dispose();
        }

        private void UnloadAndSave()
        {

            foreach (var baseDataTypeHeaderViewModel in DataTypeHeaderViewModel)
            {
                baseDataTypeHeaderViewModel.SetAccessor();
            }
            if (!memoryAccessor.UsingDefaultData)
            {
                memoryAccessor.SaveAllDataTypesIntoMemoryMappedFile();
            }
            else if (MessageBox.Show("Can not save default data back to resource.\n" +
                                     "Would you still like to unload the data.", "", MessageBoxButton.YesNo) ==
                     MessageBoxResult.No)
                return;
            UnloadWithoutSave();
        }

        private void SaveToFile()
        {
            if(memoryAccessor == null) return;
            var saveDialog = new SaveFileDialog { CheckFileExists = true };
            if (saveDialog.ShowDialog() == true)
            {
                var file = File.Open(saveDialog.FileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                try
                {
                    memoryAccessor.SaveAllDataTypesIntoMemoryMappedFile(file);
                }
                catch (Exception e)
                {
                    // TODO Put this comment in ReadMe.md
                    // Use Case:
                    // If you save the changes to a file you can load it later and save it to a real file.
                    if (MessageBox.Show(e.Message + "\n" +
                                        "Do you want to use an empty file? This file will not have the data or needed to run or any changed text.",
                                        "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        if (file.Length > MemoryAccessor.FileSize)
                        {
                            file.Dispose();
                            File.Delete(saveDialog.FileName);
                            file = File.Create(saveDialog.FileName);
                        }

                        var emptyBytes = new byte[MemoryAccessor.FileSize];
                        file.Write(emptyBytes, 0, emptyBytes.Length);
                        file.Flush(true);
                        memoryAccessor.SaveAllDataTypesIntoMemoryMappedFile(file);
                    }
                }
            }
        }
        public Command LoadDefaultDataCommand { get; set; }
        public Command OpenAndLoadFileCommand { get; set; }
        public Command UnloadWithoutSaveCommand { get; set; }
        public Command UnloadAndSaveCommand { get; set; }
        public Command SaveToFileCommand { get; set; }
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