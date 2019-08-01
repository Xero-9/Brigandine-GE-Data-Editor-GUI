using BrigandineGEDataEditor;
using BrigandineGEDataEditor.DataTypes;
using BrigandineGEDataEditorGUI.Data_Type_View_Models.Base;

namespace BrigandineGEDataEditorGUI.Data_Type_View_Models {
    public class SkillDataViewModel : BaseDataTypeViewModel
    {
        public SkillDataViewModel() { }

        public SkillDataViewModel(ref SkillData data, MemoryAccessor memoryAccessor)
        {
            SkillData           = data;
            this.memoryAccessor = memoryAccessor;
        }

        private MemoryAccessor memoryAccessor;
        private SkillData      SkillData;

        public override string ToString()
        {
            return Name;
        }

        //TODO Create special string like control type for handling getting and setting strings from memory accessor.
        public string Name
        {
            get => memoryAccessor.DereferenceString(SkillData.Name);
            //set => SetAndNotifyIfChanged(ref attackData.Name, value);
        }

        public string Description
        {
            get => memoryAccessor.DereferenceString(SkillData.Description);
            //set => SetAndNotifyIfChanged(ref SkillData.Description, value);
        }
    }
}