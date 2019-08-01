using System.Collections.ObjectModel;
using System.Linq;
using BrigandineGEDataEditor;
using BrigandineGEDataEditorGUI.Data_Type_View_Models.Base;
using Microsoft.Win32;

namespace BrigandineGEDataEditorGUI.Data_Type_View_Models
{
    public class MainWindowViewModel : BaseViewModel
    {
        private MemoryAccessor memoryAccessor;
        private string fileToMap;
        public MainWindowViewModel()
        {
            OpenFileCommand = new Command(OpenFileDialog, () => true);
            LoadAndReadFileCommand = new Command(LoadAndReadFile, () => true);
            OnCloseCommand = new Command(DisposeOfMappedFiles, () => true);
            // TODO DELETE THE LINES BELOW SO THE FILE IS NOT AUTOLOADED FROM DIRECTORY. THIS IS FOR QUICK TESTING
            fileToMap = @"C:\Users\Dave\Documents\Visual Studio 2017\Projects\VS Brigandine GE Data Editor\SLPS_026";
            LoadAndReadFile();
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

                DataTypeViewModels = new ObservableCollection<BaseDataTypeCollectionViewModel>();
                DataTypeViewModels.Add(new DataTypeCollectionViewModel<AttackDataViewModel>(memoryAccessor
                                                                                            .AttackDatas
                                                                                            .Select(a => new AttackDataViewModel(ref a, memoryAccessor))));
                DataTypeViewModels.Add(new DataTypeCollectionViewModel<CastleDataViewModel>(memoryAccessor
                                                                                            .Castles
                                                                                            .Select(c => new CastleDataViewModel(ref c, memoryAccessor))));
                DataTypeViewModels.Add(new DataTypeCollectionViewModel<ClassDataViewModel>(memoryAccessor
                                                                                           .FighterDefaults
                                                                                           .Select(c => new ClassDataViewModel(ref c, memoryAccessor))));
                DataTypeViewModels.Add(new DataTypeCollectionViewModel<DefaultKnightDataViewModel>(memoryAccessor
                                                                                           .DefaultKnights
                                                                                           .Select(c => new DefaultKnightDataViewModel(ref c, memoryAccessor))));
                DataTypeViewModels.Add(new DataTypeCollectionViewModel<ItemDataViewModel>(memoryAccessor
                                                                                           .ItemsDatas
                                                                                           .Select(i => new ItemDataViewModel(ref i, memoryAccessor))));
                DataTypeViewModels.Add(new DataTypeCollectionViewModel<MonsterInSummonDataViewModel>(memoryAccessor.MonsterInSummonDatas
                                                                                           .Select(c => new MonsterInSummonDataViewModel(ref c, memoryAccessor))));
                DataTypeViewModels.Add(new DataTypeCollectionViewModel<SkillDataViewModel>(memoryAccessor.SkillsData
                                                                                                                   .Select(s => new SkillDataViewModel(ref s, memoryAccessor))));
                DataTypeViewModels.Add(new DataTypeCollectionViewModel<SpellDataViewModel>(memoryAccessor.Spells
                                                                                                                   .Select(c => new SpellDataViewModel(ref c, memoryAccessor))));
#if Work_In_Progress
                DataTypeViewModels.Add(new DataTypeCollectionViewModel<StatGrowthDataViewModel>(memoryAccessor.StatGrowths
                                                                                                                   .Select(c => new StatGrowthDataViewModel(ref c, memoryAccessor))));
                DataTypeViewModels.Add(new DataTypeCollectionViewModel<MonsterDataViewModel>(memoryAccessor.MonsterInSummonDatas
                                                                                                                   .Select(m => new MonsterDataViewModel(ref m, memoryAccessor))));
#endif
            }
        }

        public Command OpenFileCommand { get; set; }
        public Command LoadAndReadFileCommand { get; set; }
        public Command OnCloseCommand { get; set; }
        private BaseDataTypeCollectionViewModel selectedDataTypeViewModelCollection;

        public BaseDataTypeCollectionViewModel SelectedDataTypeViewModelCollection
        {
            get => selectedDataTypeViewModelCollection;
            set => SetAndNotifyIfChanged(ref selectedDataTypeViewModelCollection, value);
        }

        private DataTypeCollectionViewModel<AttackDataViewModel> attackDataTypeCollectionViewModel;

        public DataTypeCollectionViewModel<AttackDataViewModel> AttackDataTypeCollectionViewModel
        {
            get => attackDataTypeCollectionViewModel;
            set => SetAndNotifyIfChanged(ref attackDataTypeCollectionViewModel, value);
        }
        private ObservableCollection<BaseDataTypeCollectionViewModel> dataTypeViewModels;
        public ObservableCollection<BaseDataTypeCollectionViewModel> DataTypeViewModels
        {
            get => dataTypeViewModels;
            set => SetAndNotifyIfChanged(ref dataTypeViewModels, value);
        }

        private BaseViewModel selectedBaseDataTypeViewModel;

        public BaseViewModel SelectedBaseDataTypeViewModel
        {
            get => selectedBaseDataTypeViewModel;
            set => SetAndNotifyIfChanged(ref selectedBaseDataTypeViewModel, value);
        }
    }
}