using System.Collections.ObjectModel;
using System.Linq;
using BrigandineGEDataEditor;
using BrigandineGEDataEditorGUI.Data_Type_Header_ViewModels.Base;
using BrigandineGEDataEditorGUI.Data_Type_ViewModels;

namespace BrigandineGEDataEditorGUI.Data_Type_Header_ViewModels
{
    public class SpecialAttackDataHeaderViewModel : BaseDataTypeHeaderViewModel
    {
        private ObservableCollection<SpecialAttackDataViewModel> dataTypeCollectionViewModel;

        public ObservableCollection<SpecialAttackDataViewModel> DataTypeCollectionViewModel
        {
            get => dataTypeCollectionViewModel;
            set => SetAndNotifyIfChanged(ref dataTypeCollectionViewModel, value);
        }

        public SpecialAttackDataHeaderViewModel(MemoryAccessor memoryAccessor) : base(memoryAccessor)
        {
            DataTypeCollectionViewModel = new ObservableCollection<SpecialAttackDataViewModel>();
            for (int index = 0; index < memoryAccessor.SpecialAttacks.Length; index++)
            {
                ref var data = ref memoryAccessor.SpecialAttacks[index];
                DataTypeCollectionViewModel.Add(new SpecialAttackDataViewModel(ref data, memoryAccessor, data.GetAddress(index)));
            }
        }
        public override void SetAccessor() => MemoryAccessor.SpecialAttacks = DataTypeCollectionViewModel.Select(a => a.SpecialAttackData).ToArray();
    }
}