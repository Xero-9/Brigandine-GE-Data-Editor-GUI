using BrigandineGEDataEditor;
using BrigandineGEDataEditor.DataTypes;
using BrigandineGEDataEditorGUI.Data_Type_ViewModels.Base;

namespace BrigandineGEDataEditorGUI.Data_Type_ViewModels {
    public class SpellDataViewModel : BaseDataTypeViewModel
    {
        public SpellDataViewModel() { }

        public SpellDataViewModel(ref SpellData data, MemoryAccessor memoryAccessor, int address)
        {
            Address = address;
            spellData           = data;
            this.memoryAccessor = memoryAccessor;
        }

        private readonly MemoryAccessor memoryAccessor;
        private SpellData      spellData;
        public ref SpellData SpellData => ref spellData;
        public override string ToString() => Name;

        //TODO Create special string like control type for handling getting and setting strings from memory accessor.
        public string Name => $"{memoryAccessor.DereferenceString(spellData.Name)}";
        public string NameWithAddress => $"{Name}  at {MemoryAccessor.AdjustAddress(spellData.Name):X}";
        public string Description => $"{memoryAccessor.DereferenceString(spellData.Description)}";

        public ushort MpCost
        {
            get => spellData.MPCost;
            set => SetAndNotifyIfChanged(ref spellData.MPCost, value);
        }

        public byte Range
        {
            get => spellData.Range;
            set => SetAndNotifyIfChanged(ref spellData.Range, value);
        }

        public byte Damage
        {
            get => spellData.Damage;
            set => SetAndNotifyIfChanged(ref spellData.Damage, value);
        }

        public Elements Elements => spellData.Element.GetElements();

        public byte GroundAndSky
        {
            get => spellData.GroundAndSky;
            set => SetAndNotifyIfChanged(ref spellData.GroundAndSky, value);
        }

        public byte Unknown1
        {
            get => spellData.Unknown1;
            set => SetAndNotifyIfChanged(ref spellData.Unknown1, value);
        }

        public byte Aoe
        {
            get => spellData.AOE;
            set => SetAndNotifyIfChanged(ref spellData.AOE, value);
        }
        private byte[ ] unknown;
        public byte[] Unknown
        {
            get
            {
                if (unknown == null)
                {
                    unknown = new byte[5];
                    for (int i = 0; i < unknown.Length; i++)
                    {
                        unknown[i] = spellData.Unknowns[i];
                    }
                }

                return unknown;
            }
            set => SetAndNotifyIfChanged(ref unknown, value);
        }

        public override int Address { get; }
    }
}