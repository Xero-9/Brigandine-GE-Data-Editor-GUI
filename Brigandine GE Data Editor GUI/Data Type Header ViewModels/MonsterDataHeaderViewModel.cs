using System.Collections.ObjectModel;
using BrigandineGEDataEditor;
using BrigandineGEDataEditorGUI.Data_Type_Header_ViewModels.Base;
using BrigandineGEDataEditorGUI.Data_Type_View_Models;

namespace BrigandineGEDataEditorGUI.Data_Type_Header_ViewModels
{
    public class MonsterDataHeaderViewModel : BaseDataTypeHeaderViewModel
    {
        private ObservableCollection<MonsterDataViewModel> dataTypeCollectionViewModel;

        public ObservableCollection<MonsterDataViewModel> DataTypeCollectionViewModel
        {
            get => dataTypeCollectionViewModel;
            set => SetAndNotifyIfChanged(ref dataTypeCollectionViewModel, value);
        }

        public MonsterDataHeaderViewModel(MemoryAccessor memoryAccessor)
        {
            //    DataTypeCollectionViewModel = new ObservableCollection<MonsterDataViewModel>();
            //    for (int index = 0; index < memoryAccessor.Monsters.Length; index++)
            //    {
            //        ref var data = ref memoryAccessor.Monsters[index];
            //        DataTypeCollectionViewModel.Add(new MonsterDataViewModel(ref data, memoryAccessor, data.GetAddress(index)));
            //    }
        }
    }
}