using BrigandineGEDataEditor;
using BrigandineGEDataEditor.DataTypes;
using BrigandineGEDataEditor.Enums;
using BrigandineGEDataEditorGUI.Data_Type_ViewModels.Base;

namespace BrigandineGEDataEditorGUI.Data_Type_ViewModels {
    public class MonsterDataViewModel : BaseDataTypeViewModel
    {
        public MonsterDataViewModel() { }

        public MonsterDataViewModel(ref MonsterData data, MemoryAccessor memoryAccessor, int address)
        {
            Address = address;
            monsterData         = data;
            this.memoryAccessor = memoryAccessor;
        }

        private readonly MemoryAccessor memoryAccessor;
        private MonsterData    monsterData;
        public ref MonsterData MonsterData => ref monsterData;
        public override string ToString() => Name;

        ////TODO Create special string like control type for handling getting and setting strings from memory accessor.
        public string Name => $"{memoryAccessor.DereferenceString(monsterData.Name)}";
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

        public ushort Hp
        {
            get => monsterData.Hp;
            set => SetAndNotifyIfChanged(ref monsterData.Hp, value);
        }

        public ushort Mp
        {
            get => monsterData.Mp;
            set => SetAndNotifyIfChanged(ref monsterData.Mp, value);
        }

        public byte Str
        {
            get => monsterData.Str;
            set => SetAndNotifyIfChanged(ref monsterData.Str, value);
        }

        public byte Int
        {
            get => monsterData.Int;
            set => SetAndNotifyIfChanged(ref monsterData.Int, value);
        }

        public byte Agi
        {
            get => monsterData.Agi;
            set => SetAndNotifyIfChanged(ref monsterData.Agi, value);
        }

        public byte ItemEquipped
        {
            get => monsterData.ItemEquipped;
            set => SetAndNotifyIfChanged(ref monsterData.ItemEquipped, value);
        }

        public override int Address { get; }
    }
}