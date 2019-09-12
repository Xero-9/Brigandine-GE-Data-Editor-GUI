using BrigandineGEDataEditor;
using BrigandineGEDataEditor.DataTypes;
using BrigandineGEDataEditorGUI.Data_Type_ViewModels.Base;

namespace BrigandineGEDataEditorGUI.Data_Type_ViewModels {
    public class MonsterInSummonDataViewModel : BaseDataTypeViewModel
    {
        public MonsterInSummonDataViewModel() { }

        public MonsterInSummonDataViewModel(ref MonsterInSummonData data, MemoryAccessor memoryAccessor, int address)
        {
            Address = address;
            MonsterInSummonData = data;
            this.memoryAccessor = memoryAccessor;
        }

        private readonly MemoryAccessor      memoryAccessor;
        private MonsterInSummonData monsterInSummonData;
        public ref MonsterInSummonData MonsterInSummonData => ref monsterInSummonData;
        public override string ToString() => Name;

        //TODO Create special string like control type for handling getting and setting strings from memory accessor.
        public string Name => $"{memoryAccessor.DereferenceString(MonsterInSummonData.Name)}";
        public string NameWithAddress => $"{Name}  at {MemoryAccessor.AdjustAddress(MonsterInSummonData.Name):X}";
        public byte Level
        {
            get => MonsterInSummonData.Level;
            set => SetAndNotifyIfChanged(ref MonsterInSummonData.Level, value);
        }

        public byte Exp
        {
            get => MonsterInSummonData.Exp;
            set => SetAndNotifyIfChanged(ref MonsterInSummonData.Exp, value);
        }

        public ushort BaseHp
        {
            get => MonsterInSummonData.BaseHP;
            set => SetAndNotifyIfChanged(ref MonsterInSummonData.BaseHP, value);
        }

        public ushort BaseMp
        {
            get => MonsterInSummonData.BaseMP;
            set => SetAndNotifyIfChanged(ref MonsterInSummonData.BaseMP, value);
        }

        public byte Str
        {
            get => MonsterInSummonData.Str;
            set => SetAndNotifyIfChanged(ref MonsterInSummonData.Str, value);
        }

        public byte Int
        {
            get => MonsterInSummonData.Int;
            set => SetAndNotifyIfChanged(ref MonsterInSummonData.Int, value);
        }

        public byte Agi
        {
            get => MonsterInSummonData.Hit;
            set => SetAndNotifyIfChanged(ref MonsterInSummonData.Hit, value);
        }

        public byte RuneCost
        {
            get => MonsterInSummonData.RuneCost;
            set => SetAndNotifyIfChanged(ref MonsterInSummonData.RuneCost, value);
        }

        public ushort ManaCost
        {
            get => MonsterInSummonData.ManaCost;
            set => SetAndNotifyIfChanged(ref MonsterInSummonData.ManaCost, value);
        }

        public override int Address { get; }
    }
}