using BrigandineGEDataEditor;
using BrigandineGEDataEditor.DataTypes;
using BrigandineGEDataEditorGUI.Data_Type_ViewModels.Base;

namespace BrigandineGEDataEditorGUI.Data_Type_ViewModels
{
    public class AttackDataViewModel : BaseDataTypeViewModel
    {
        public AttackDataViewModel()
        {
            
        }
        public AttackDataViewModel(ref AttackData data, MemoryAccessor memoryAccessor, int address)
        {
            AttackData = data;
            Address = address;
            this.memoryAccessor = memoryAccessor;
        }

        private readonly MemoryAccessor memoryAccessor;
        public AttackData AttackData;
        //public ref AttackData AttackData => ref attackData;

        public override string ToString() => Name;

        //TODO Create special string like control type for handling getting and setting strings from memory accessor.
        public string Name => $"{memoryAccessor.DereferenceString(AttackData.Name)}";
        public string NameWithAddress => $"{Name}  at {MemoryAccessor.AdjustAddress(AttackData.Name):X}";
        public string Description => $"{memoryAccessor.DereferenceString(AttackData.Description)}";

        public byte Hit
        {
            get => AttackData.Hit;
            set => SetAndNotifyIfChanged(ref AttackData.Hit, value);
        }

        public byte RangeMin
        {
            get => AttackData.RangeMin;
            set => SetAndNotifyIfChanged(ref AttackData.RangeMin, value);
        }

        public byte RangeMax
        {
            get => AttackData.RangeMax;
            set => SetAndNotifyIfChanged(ref AttackData.RangeMax, value);
        }

        public byte Damage
        {
            get => AttackData.Damage;
            set => SetAndNotifyIfChanged(ref AttackData.Damage, value);
        }

        public Elements Element => AttackData.Element.GetElements();

        public byte GroundOrSky
        {
            get => AttackData.GroundOrSky;
            set => SetAndNotifyIfChanged(ref AttackData.GroundOrSky, value);
        }

        public byte Unknown
        {
            get => AttackData.Unknown1;
            set => SetAndNotifyIfChanged(ref AttackData.Unknown1, value);
        }

        public byte UsableAfterMove
        {
            get => AttackData.UsableAfterMove;
            set => SetAndNotifyIfChanged(ref AttackData.UsableAfterMove, value);
        }

        public byte[] Unknowns
        {
            get
            {
                var bytes = new byte[3];
                for (int i = 0; i < 3; i++)
                {
                    bytes[i] = AttackData.Unknowns[i];
                }

                return bytes;
            }
        }

        public override int Address { get; }
    }
}
