using System.Collections.ObjectModel;
using BrigandineGEDataEditor;
using BrigandineGEDataEditorGUI.Data_Type_Header_ViewModels.Base;
using BrigandineGEDataEditorGUI.Data_Type_View_Models;

namespace BrigandineGEDataEditorGUI.Data_Type_Header_ViewModels
{
    public class ItemDataHeaderViewModel : BaseDataTypeHeaderViewModel
    {
        private ObservableCollection<ItemDataViewModel> dataTypeCollectionViewModel;

        public ObservableCollection<ItemDataViewModel> DataTypeCollectionViewModel
        {
            get => dataTypeCollectionViewModel;
            set => SetAndNotifyIfChanged(ref dataTypeCollectionViewModel, value);
        }

        public ItemDataHeaderViewModel(MemoryAccessor memoryAccessor)
        {
            DataTypeCollectionViewModel = new ObservableCollection<ItemDataViewModel>();
            for (int index = 0; index < memoryAccessor.Items.Length; index++)
            {
                ref var data = ref memoryAccessor.Items[index];
                DataTypeCollectionViewModel.Add(new ItemDataViewModel(ref data, memoryAccessor, data.GetAddress(index)));
            }
        }
    }
}