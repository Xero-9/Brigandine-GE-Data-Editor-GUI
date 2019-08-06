using System.Collections.ObjectModel;
using BrigandineGEDataEditor;
using BrigandineGEDataEditorGUI.Data_Type_Header_ViewModels.Base;
using BrigandineGEDataEditorGUI.Data_Type_View_Models;

namespace BrigandineGEDataEditorGUI.Data_Type_Header_ViewModels
{
    public class DefaultKnightHeaderViewModel : BaseDataTypeHeaderViewModel
    {
        public DefaultKnightHeaderViewModel()
        {
            
        }
        private ObservableCollection<DefaultKnightDataViewModel> dataTypeCollectionViewModel;

        public ObservableCollection<DefaultKnightDataViewModel> DataTypeCollectionViewModel
        {
            get => dataTypeCollectionViewModel;
            set => SetAndNotifyIfChanged(ref dataTypeCollectionViewModel, value);
        }

        public DefaultKnightHeaderViewModel(MemoryAccessor memoryAccessor)
        {
            DataTypeCollectionViewModel = new ObservableCollection<DefaultKnightDataViewModel>();
            for (int index = 0; index < memoryAccessor.DefaultKnights.Length; index++)
            {
                ref var data = ref memoryAccessor.DefaultKnights[index];
                DataTypeCollectionViewModel.Add(new DefaultKnightDataViewModel(ref data, memoryAccessor, data.GetAddress(index)));
            }
        }
    }
}