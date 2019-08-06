using BrigandineGEDataEditor;
using BrigandineGEDataEditor.DataTypes;
using BrigandineGEDataEditor.Enums;
using BrigandineGEDataEditorGUI.Data_Type_View_Models.Base;

namespace BrigandineGEDataEditorGUI.Data_Type_View_Models {
    public class MonsterDataViewModel : BaseDataTypeViewModel
    {
        public MonsterDataViewModel() { }

        public MonsterDataViewModel(ref MonsterData data, MemoryAccessor memoryAccessor, int address)
        {
            Address = address;
            monsterData         = data;
            this.memoryAccessor = memoryAccessor;
        }

        private MemoryAccessor memoryAccessor;
        private MonsterData    monsterData;

        public override string ToString()
        {
            return Name;
        }

        ////TODO Create special string like control type for handling getting and setting strings from memory accessor.
        public string Name
        {
            get => $"{memoryAccessor.DereferenceString(monsterData.Name)}";
            //set => SetAndNotifyIfChanged(ref MonsterDataView.Name, value);
        }
        public string NameWithAddress => $"{Name}  at {MemoryAccessor.AdjustAddress(monsterData.Name):X}";
        public CountryEnum Country
        {
            get => monsterData.Country;
            set => SetAndNotifyIfChanged(ref monsterData.Country, value);
        }

        public byte MonsterSlotNumber
        {
            get => monsterData.MonsterSlotNumber;
            set => SetAndNotifyIfChanged(ref monsterData.MonsterSlotNumber, value);
        }

        public byte Class
        {
            get => monsterData.Class;
            set => SetAndNotifyIfChanged(ref monsterData.Class, value);
        }

        public byte Level
        {
            get => monsterData.Level;
            set => SetAndNotifyIfChanged(ref monsterData.Level, value);
        }

        public ushort HP
        {
            get => monsterData.HP;
            set => SetAndNotifyIfChanged(ref monsterData.HP, value);
        }

        public ushort MP
        {
            get => monsterData.MP;
            set => SetAndNotifyIfChanged(ref monsterData.MP, value);
        }

        public byte STR
        {
            get => monsterData.STR;
            set => SetAndNotifyIfChanged(ref monsterData.STR, value);
        }

        public byte INT
        {
            get => monsterData.INT;
            set => SetAndNotifyIfChanged(ref monsterData.INT, value);
        }

        public byte AGI
        {
            get => monsterData.AGI;
            set => SetAndNotifyIfChanged(ref monsterData.AGI, value);
        }

        public byte ItemEquipped
        {
            get => monsterData.ItemEquipped;
            set => SetAndNotifyIfChanged(ref monsterData.ItemEquipped, value);
        }

        public override int Address { get; }
    }
}