using System.Collections.ObjectModel;
using BrigandineGEDataEditor;
using BrigandineGEDataEditorGUI.Data_Type_Header_ViewModels.Base;
using BrigandineGEDataEditorGUI.Data_Type_ViewModels;

namespace BrigandineGEDataEditorGUI.Data_Type_Header_ViewModels
{
    
    public class MonsterInSummonDataHeaderViewModel : BaseDataTypeHeaderViewModel
    {
        private ObservableCollection<MonsterInSummonDataViewModel> dataTypeCollectionViewModel;

        public ObservableCollection<MonsterInSummonDataViewModel> DataTypeCollectionViewModel
        {
            get => dataTypeCollectionViewModel;
            set => SetAndNotifyIfChanged(ref dataTypeCollectionViewModel, value);
        }

        public MonsterInSummonDataHeaderViewModel(MemoryAccessor memoryAccessor) : base(memoryAccessor)
        {
            //DataTypeCollectionViewModel = new ObservableCollection<MonsterInSummonDataViewModel>();
            //for (int index = 0; index < memoryAccessor.MonstersInSummon.Length; index++)
            //{
            //    ref var data = ref memoryAccessor.MonstersInSummon[index];
            //    DataTypeCollectionViewModel.Add(new MonsterInSummonDataViewModel(ref data, memoryAccessor, data.GetAddress(index)));
            //}
        }

        public override void SetAccessor()
        {
            //memoryAccessor.MonstersInSummon = DataTypeCollectionViewModel.Select(a => a.MonsterInSummonData).ToArray();
        }
    }
}