using System.Collections.ObjectModel;
using System.Linq;
using BrigandineGEDataEditor;
using BrigandineGEDataEditorGUI.Data_Type_Header_ViewModels.Base;
using BrigandineGEDataEditorGUI.Data_Type_ViewModels;

namespace BrigandineGEDataEditorGUI.Data_Type_Header_ViewModels
{
    public class DefaultKnightHeaderViewModel : BaseDataTypeHeaderViewModel
    {
        private ObservableCollection<DefaultKnightDataViewModel> dataTypeCollectionViewModel;

        public ObservableCollection<DefaultKnightDataViewModel> DataTypeCollectionViewModel
        {
            get => dataTypeCollectionViewModel;
            set => SetAndNotifyIfChanged(ref dataTypeCollectionViewModel, value);
        }

        public DefaultKnightHeaderViewModel(MemoryAccessor memoryAccessor) : base(memoryAccessor)
        {
            DataTypeCollectionViewModel = new ObservableCollection<DefaultKnightDataViewModel>();
            for (int index = 0; index < memoryAccessor.DefaultKnights.Length; index++)
            {
                ref var data = ref memoryAccessor.DefaultKnights[index];
                DataTypeCollectionViewModel.Add(new DefaultKnightDataViewModel(ref data, memoryAccessor, data.GetAddress(index)));
            }
        }

        public override void SetAccessor() => MemoryAccessor.DefaultKnights = DataTypeCollectionViewModel.Select(a => a.DefaultKnightData).ToArray();
    }
}