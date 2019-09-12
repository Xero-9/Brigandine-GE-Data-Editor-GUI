using System.Collections.ObjectModel;
using System.Linq;
using BrigandineGEDataEditor;
using BrigandineGEDataEditorGUI.Data_Type_Header_ViewModels.Base;
using BrigandineGEDataEditorGUI.Data_Type_ViewModels;

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

        public CastleDataHeaderViewModel(MemoryAccessor memoryAccessor) : base(memoryAccessor)
        {
            DataTypeCollectionViewModel = new ObservableCollection<CastleDataViewModel>();
            for (int index = 0; index < memoryAccessor.Castles.Length; index++)
            {
                ref var data = ref memoryAccessor.Castles[index];
                DataTypeCollectionViewModel.Add(new CastleDataViewModel(ref data, memoryAccessor, data.GetAddress(index)));
            }
        }

        public override void SetAccessor() => MemoryAccessor.Castles = DataTypeCollectionViewModel.Select(a => a.CastleData).ToArray();
    }
}