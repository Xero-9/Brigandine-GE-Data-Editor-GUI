using BrigandineGEDataEditor;
using BrigandineGEDataEditor.DataTypes;
using BrigandineGEDataEditorGUI.Data_Type_View_Models.Base;

namespace BrigandineGEDataEditorGUI.Data_Type_View_Models {
    public class MonsterInSummonDataViewModel : BaseDataTypeViewModel
    {
        public MonsterInSummonDataViewModel() { }

        public MonsterInSummonDataViewModel(ref MonsterInSummonData data, MemoryAccessor memoryAccessor)
        {
            MonsterInSummonData = data;
            this.memoryAccessor = memoryAccessor;
        }

        private MemoryAccessor      memoryAccessor;
        private MonsterInSummonData MonsterInSummonData;

        public override string ToString()
        {
            return Name;
        }

        //TODO Create special string like control type for handling getting and setting strings from memory accessor.
        public string Name
        {
            get => memoryAccessor.DereferenceString(MonsterInSummonData.Name);
            //set => SetAndNotifyIfChanged(ref attackData.Name, value);
        }

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

        public ushort BaseHP
        {
            get => MonsterInSummonData.BaseHP;
            set => SetAndNotifyIfChanged(ref MonsterInSummonData.BaseHP, value);
        }

        public ushort BashMP
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
    }
}