using BrigandineGEDataEditor;
using BrigandineGEDataEditorGUI.Data_Type_ViewModels.Base;

namespace BrigandineGEDataEditorGUI.Data_Type_Header_ViewModels.Base
{
    public abstract class BaseDataTypeHeaderViewModel : BaseViewModel
    {
        protected BaseDataTypeHeaderViewModel(MemoryAccessor memoryAccessor) => MemoryAccessor = memoryAccessor;
        public virtual string Name => GetType().Name;
        public abstract void SetAccessor();
        internal MemoryAccessor MemoryAccessor { get; private set; }
    }

}