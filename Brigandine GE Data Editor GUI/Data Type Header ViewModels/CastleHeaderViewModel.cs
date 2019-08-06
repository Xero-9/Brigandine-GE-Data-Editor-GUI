using System.Collections.ObjectModel;
using BrigandineGEDataEditor;
using BrigandineGEDataEditorGUI.Data_Type_Header_ViewModels.Base;
using BrigandineGEDataEditorGUI.Data_Type_View_Models;

namespace BrigandineGEDataEditorGUI.Data_Type_Header_ViewModels
{
    public class CastleDataHeaderViewModel : BaseDataTypeHeaderViewModel
    {
        private ObservableCollection<CastleDataViewModel> dataTypeCollectionViewModel;

        public ObservableCollection<CastleDataViewModel> DataTypeCollectionViewModel
        {
            get => dataTypeCollectionViewModel;
            set => SetAndNotifyIfChanged(ref dataTypeCollectionViewModel, value);
        }

        public CastleDataHeaderViewModel(MemoryAccessor memoryAccessor)
        {
            DataTypeCollectionViewModel = new ObservableCollection<CastleDataViewModel>();
            for (int index = 0; index < memoryAccessor.Castles.Length; index++)
            {
                ref var data = ref memoryAccessor.Castles[index];
                DataTypeCollectionViewModel.Add(new CastleDataViewModel(ref data, memoryAccessor, data.GetAddress(index)));
            }
        }
    }
}