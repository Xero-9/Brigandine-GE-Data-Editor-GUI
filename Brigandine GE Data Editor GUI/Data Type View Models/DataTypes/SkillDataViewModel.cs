using BrigandineGEDataEditor;
using BrigandineGEDataEditor.DataTypes;
using BrigandineGEDataEditorGUI.Data_Type_View_Models.Base;

namespace BrigandineGEDataEditorGUI.Data_Type_View_Models {
    public class SkillDataViewModel : BaseDataTypeViewModel
    {
        public SkillDataViewModel() { }

        public SkillDataViewModel(ref SkillData data, MemoryAccessor memoryAccessor)
        {
            skillData           = data;
            this.memoryAccessor = memoryAccessor;
        }

        private MemoryAccessor memoryAccessor;
        private SkillData      skillData;

        public override string ToString()
        {
            return Name;
        }

        //TODO Create special string like control type for handling getting and setting strings from memory accessor.
        public string Name
        {
            get => $"{memoryAccessor.DereferenceString(skillData.Name)}";
            //set => SetAndNotifyIfChanged(ref attackData.Name, value);
        }
        public string NameWithAddress => $"{Name}  at {MemoryAccessor.AdjustAddress(skillData.Name):X}";
        public string Description
        {
            get => $"{memoryAccessor.DereferenceString(skillData.Description)} at {MemoryAccessor.AdjustAddress(skillData.Description):X}";
            //set => SetAndNotifyIfChanged(ref SkillData.Description, value);
        }
    }
}