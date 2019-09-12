using BrigandineGEDataEditor;
using BrigandineGEDataEditor.DataTypes;
using BrigandineGEDataEditorGUI.Data_Type_ViewModels.Base;

namespace BrigandineGEDataEditorGUI.Data_Type_ViewModels {
    public class SkillDataViewModel : BaseDataTypeViewModel
    {
        public SkillDataViewModel() { }

        public SkillDataViewModel(ref SkillData data, MemoryAccessor memoryAccessor, int address)
        {
            Address = address;
            skillData           = data;
            this.memoryAccessor = memoryAccessor;
        }

        private readonly MemoryAccessor memoryAccessor;
        private SkillData      skillData;
        public ref SkillData SkillData => ref skillData;
        public override string ToString() => Name;

        //TODO Create special string like control type for handling getting and setting strings from memory accessor.
        public string Name => $"{memoryAccessor.DereferenceString(skillData.Name)}";
        public string NameWithAddress => $"{Name}  at {MemoryAccessor.AdjustAddress(skillData.Name):X}";
        public string Description => $"{memoryAccessor.DereferenceString(skillData.Description)}";
        public override int Address { get; }
    }
}