using BrigandineGEDataEditorGUI.Data_Type_View_Models.Base;

namespace BrigandineGEDataEditorGUI.Data_Type_Header_ViewModels.Base
{
    public abstract class BaseDataTypeHeaderViewModel : BaseViewModel
    {
        public virtual string Name => GetType().Name;
    }
}