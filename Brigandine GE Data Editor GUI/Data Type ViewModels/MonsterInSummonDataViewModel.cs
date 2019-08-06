using BrigandineGEDataEditor;
using BrigandineGEDataEditor.DataTypes;
using BrigandineGEDataEditorGUI.Data_Type_View_Models.Base;

namespace BrigandineGEDataEditorGUI.Data_Type_View_Models {
    public class MonsterInSummonDataViewModel : BaseDataTypeViewModel
    {
        public MonsterInSummonDataViewModel() { }

        public MonsterInSummonDataViewModel(ref MonsterInSummonData data, MemoryAccessor memoryAccessor, int address)
        {
            Address = address;
            monsterInSummonData = data;
            this.memoryAccessor = memoryAccessor;
        }

        private MemoryAccessor      memoryAccessor;
        private MonsterInSummonData monsterInSummonData;

        public override string ToString()
        {
            return Name;
        }

        //TODO Create special string like control type for handling getting and setting strings from memory accessor.
        public string Name
        {
            get => $"{memoryAccessor.DereferenceString(monsterInSummonData.Name)}";
            //set => SetAndNotifyIfChanged(ref attacks.Name, value);
        }
        public string NameWithAddress => $"{Name}  at {MemoryAccessor.AdjustAddress(monsterInSummonData.Name):X}";
        public byte Level
        {
            get => monsterInSummonData.Level;
            set => SetAndNotifyIfChanged(ref monsterInSummonData.Level, value);
        }

        public byte Exp
        {
            get => monsterInSummonData.Exp;
            set => SetAndNotifyIfChanged(ref monsterInSummonData.Exp, value);
        }

        public ushort BaseHP
        {
            get => monsterInSummonData.BaseHP;
            set => SetAndNotifyIfChanged(ref monsterInSummonData.BaseHP, value);
        }

        public ushort BaseMP
        {
            get => monsterInSummonData.BaseMP;
            set => SetAndNotifyIfChanged(ref monsterInSummonData.BaseMP, value);
        }

        public byte Str
        {
            get => monsterInSummonData.Str;
            set => SetAndNotifyIfChanged(ref monsterInSummonData.Str, value);
        }

        public byte Int
        {
            get => monsterInSummonData.Int;
            set => SetAndNotifyIfChanged(ref monsterInSummonData.Int, value);
        }

        public byte Agi
        {
            get => monsterInSummonData.Hit;
            set => SetAndNotifyIfChanged(ref monsterInSummonData.Hit, value);
        }

        public byte RuneCost
        {
            get => monsterInSummonData.RuneCost;
            set => SetAndNotifyIfChanged(ref monsterInSummonData.RuneCost, value);
        }

        public ushort ManaCost
        {
            get => monsterInSummonData.ManaCost;
            set => SetAndNotifyIfChanged(ref monsterInSummonData.ManaCost, value);
        }

        public override int Address { get; }
    }
}