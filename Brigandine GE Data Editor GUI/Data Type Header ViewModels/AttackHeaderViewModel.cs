using System.Collections.ObjectModel;
using BrigandineGEDataEditor;
using BrigandineGEDataEditorGUI.Data_Type_Header_ViewModels.Base;
using BrigandineGEDataEditorGUI.Data_Type_View_Models;

namespace BrigandineGEDataEditorGUI.Data_Type_Header_ViewModels
{
    public class AttackDataHeaderViewModel : BaseDataTypeHeaderViewModel
    {
        private ObservableCollection<AttackDataViewModel> dataTypeCollectionViewModel;
        public ObservableCollection<AttackDataViewModel> DataTypeCollectionViewModel
        {
            get => dataTypeCollectionViewModel;
            set => SetAndNotifyIfChanged(ref dataTypeCollectionViewModel, value);
        }
        public AttackDataHeaderViewModel(MemoryAccessor memoryAccessor)
        {
            DataTypeCollectionViewModel = new ObservableCollection<AttackDataViewModel>();
            for (int index = 0; index < memoryAccessor.Attacks.Length; index++)
            {
                ref var data = ref memoryAccessor.Attacks[index];
                DataTypeCollectionViewModel.Add(new AttackDataViewModel(ref data, memoryAccessor, data.GetAddress(index)));
            }
        }

        
    }
}