using BrigandineGEDataEditor;
using BrigandineGEDataEditor.DataTypes;
using BrigandineGEDataEditorGUI.Data_Type_ViewModels.Base;

namespace BrigandineGEDataEditorGUI.Data_Type_ViewModels {
    public class SpecialAttackDataViewModel : BaseDataTypeViewModel
    {
        public SpecialAttackDataViewModel() { }

        public SpecialAttackDataViewModel(ref SpecialAttackData data, MemoryAccessor memoryAccessor, int address)
        {
            Address = address;
            specialAttackData   = data;
            this.memoryAccessor = memoryAccessor;
        }

        private readonly MemoryAccessor    memoryAccessor;
        private SpecialAttackData specialAttackData;
        public ref SpecialAttackData SpecialAttackData => ref specialAttackData;

        public override string ToString() => Name;

        //TODO Create special string like control type for handling getting and setting strings from memory accessor.
        public string Name => $"{memoryAccessor.DereferenceString(specialAttackData.Name)}";
        public string NameWithAddress => $"{Name}  at {MemoryAccessor.AdjustAddress(specialAttackData.Name):X}";
        public string Description => $"{memoryAccessor.DereferenceString(specialAttackData.Description)}";

        public byte Mp
        {
            get => specialAttackData.MP;
            set => SetAndNotifyIfChanged(ref specialAttackData.MP, value);
        }

        public byte Range  
        {
            get => specialAttackData.Range;
            set => SetAndNotifyIfChanged(ref specialAttackData.Range, value);
        }

        public byte Damage
        {
            get => specialAttackData.Damage;
            set => SetAndNotifyIfChanged(ref specialAttackData.Damage, value);
        }

        public byte Unknown1
        {
            get => specialAttackData.Unk1;
            set => SetAndNotifyIfChanged(ref specialAttackData.Unk1, value);
        }

        public Elements Elements => specialAttackData.Element.GetElements();

        public byte GroundOrSky
        {
            get => specialAttackData.GroundOrSky;
            set => SetAndNotifyIfChanged(ref specialAttackData.GroundOrSky, value);
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
                        unknown[i] = specialAttackData.Unknowns[i];
                    }
                }

                return unknown;
            }
            set => SetAndNotifyIfChanged(ref unknown, value);
        }

        public override int Address { get; }
    }
}