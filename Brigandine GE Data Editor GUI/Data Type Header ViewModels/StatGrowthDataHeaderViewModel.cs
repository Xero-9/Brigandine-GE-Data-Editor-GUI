using System.Collections.ObjectModel;
using BrigandineGEDataEditor;
using BrigandineGEDataEditorGUI.Data_Type_Header_ViewModels.Base;
using BrigandineGEDataEditorGUI.Data_Type_ViewModels;

namespace BrigandineGEDataEditorGUI.Data_Type_Header_ViewModels
{
    public class StatGrowthDataHeaderViewModel : BaseDataTypeHeaderViewModel
    {
        private ObservableCollection<StatGrowthDataViewModel> dataTypeCollectionViewModel;

        public ObservableCollection<StatGrowthDataViewModel> DataTypeCollectionViewModel
        {
            get => dataTypeCollectionViewModel;
            set => SetAndNotifyIfChanged(ref dataTypeCollectionViewModel, value);
        }

        public StatGrowthDataHeaderViewModel(MemoryAccessor memoryAccessor) : base(memoryAccessor)
        {
            //DataTypeCollectionViewModel = new ObservableCollection<StatGrowthDataViewModel>();
            //for (int index = 0; index < memoryAccessor.StatGrowths.Length; index++)
            //{
            //    ref var data = ref memoryAccessor.StatGrowths[index];
            //    DataTypeCollectionViewModel.Add(new StatGrowthDataViewModel(ref data, memoryAccessor, data.GetAddress(index)));
            //}
        }

        public override void SetAccessor()
        {
            //memoryAccessor.StatGrowths = DataTypeCollectionViewModel.Select(a => a.StatGrowthData).ToArray();
        }
    }
}