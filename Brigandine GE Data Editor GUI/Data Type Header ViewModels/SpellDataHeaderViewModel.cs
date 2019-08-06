using System.Collections.ObjectModel;
using BrigandineGEDataEditor;
using BrigandineGEDataEditorGUI.Data_Type_Header_ViewModels.Base;
using BrigandineGEDataEditorGUI.Data_Type_View_Models;

namespace BrigandineGEDataEditorGUI.Data_Type_Header_ViewModels
{
    public class SpellDataHeaderViewModel : BaseDataTypeHeaderViewModel
    {
        private ObservableCollection<SpellDataViewModel> dataTypeCollectionViewModel;

        public ObservableCollection<SpellDataViewModel> DataTypeCollectionViewModel
        {
            get => dataTypeCollectionViewModel;
            set => SetAndNotifyIfChanged(ref dataTypeCollectionViewModel, value);
        }

        public SpellDataHeaderViewModel(MemoryAccessor memoryAccessor)
        {
            DataTypeCollectionViewModel = new ObservableCollection<SpellDataViewModel>();
            for (int index = 0; index < memoryAccessor.Spells.Length; index++)
            {
                ref var data = ref memoryAccessor.Spells[index];
                DataTypeCollectionViewModel.Add(new SpellDataViewModel(ref data, memoryAccessor, data.GetAddress(index)));
            }
        }
    }
}