using System.Collections.ObjectModel;
using BrigandineGEDataEditor;
using BrigandineGEDataEditorGUI.Data_Type_Header_ViewModels.Base;
using BrigandineGEDataEditorGUI.Data_Type_View_Models;

namespace BrigandineGEDataEditorGUI.Data_Type_Header_ViewModels
{
    public class SkillDataHeaderViewModel : BaseDataTypeHeaderViewModel
    {
        private ObservableCollection<SkillDataViewModel> dataTypeCollectionViewModel;

        public ObservableCollection<SkillDataViewModel> DataTypeCollectionViewModel
        {
            get => dataTypeCollectionViewModel;
            set => SetAndNotifyIfChanged(ref dataTypeCollectionViewModel, value);
        }

        public SkillDataHeaderViewModel(MemoryAccessor memoryAccessor)
        {
            DataTypeCollectionViewModel = new ObservableCollection<SkillDataViewModel>();
            for (int index = 0; index < memoryAccessor.Skills.Length; index++)
            {
                ref var data = ref memoryAccessor.Skills[index];
                DataTypeCollectionViewModel.Add(new SkillDataViewModel(ref data, memoryAccessor, data.GetAddress(index)));
            }
        }
    }
}