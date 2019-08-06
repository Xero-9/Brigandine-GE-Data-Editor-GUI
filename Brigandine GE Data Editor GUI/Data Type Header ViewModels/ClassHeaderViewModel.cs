using System.Collections.ObjectModel;
using BrigandineGEDataEditor;
using BrigandineGEDataEditorGUI.Data_Type_Header_ViewModels.Base;
using BrigandineGEDataEditorGUI.Data_Type_View_Models;

namespace BrigandineGEDataEditorGUI.Data_Type_Header_ViewModels
{
    public class ClassDataHeaderViewModel : BaseDataTypeHeaderViewModel
    {
        private ObservableCollection<ClassDataViewModel> dataTypeCollectionViewModel;

        public ObservableCollection<ClassDataViewModel> DataTypeCollectionViewModel
        {
            get => dataTypeCollectionViewModel;
            set => SetAndNotifyIfChanged(ref dataTypeCollectionViewModel, value);
        }

        public ClassDataHeaderViewModel(MemoryAccessor memoryAccessor)
        {
            DataTypeCollectionViewModel = new ObservableCollection<ClassDataViewModel>();
            for (int index = 0; index < memoryAccessor.Classes.Length; index++)
            {
                ref var data = ref memoryAccessor.Classes[index];
                DataTypeCollectionViewModel.Add(new ClassDataViewModel(ref data, memoryAccessor, data.GetAddress(index)));
            }
        }
    }
}