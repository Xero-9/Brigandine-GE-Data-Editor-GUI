using BrigandineGEDataEditor;
using BrigandineGEDataEditor.DataTypes;
using BrigandineGEDataEditor.Enums;
using BrigandineGEDataEditorGUI.Data_Type_ViewModels.Base;

namespace BrigandineGEDataEditorGUI.Data_Type_ViewModels
{
    public class CastleDataViewModel : BaseDataTypeViewModel
    {
        public CastleDataViewModel()
        {
            
        }
        public CastleDataViewModel(ref CastleData data, MemoryAccessor memoryAccessor, int address)
        {
            Address = address;
            CastleData = data;
            this.memoryAccessor = memoryAccessor;
        }

        private readonly MemoryAccessor   memoryAccessor;
        private CastleData castleData;
        public ref CastleData CastleData => ref castleData;
        public override string ToString() => Name;

        //TODO Create special string like control type for handling getting and setting strings from memory accessor.
        public string Name => $"{memoryAccessor.DereferenceString(CastleData.Name)}";
        public string NameWithAddress => $"{Name}  at {MemoryAccessor.AdjustAddress(CastleData.Name):X}";
        public byte MovesFlag
        {
            get => CastleData.MovesFlag;
            set => SetAndNotifyIfChanged(ref CastleData.MovesFlag, value);
        }
        private byte[ ] castlesConnectedTo;
        public byte[ ] CastlesConnectedTo
        {
            get
            {
                if (castlesConnectedTo == null)
                {
                    castlesConnectedTo = new byte[3];
                    for (int i = 0; i < castlesConnectedTo.Length; i++)
                    {
                        castlesConnectedTo[i] = CastleData.CastlesConnectedTo[i];
                    }
                }

                return castlesConnectedTo;
            }
            // TODO Implement Special Set Method
            //set => SetAndNotifyIfChanged(ref castleData.RangeMin, value);
        }

        public byte PrefixForCity
        {
            get => CastleData.PrefixForCity;
            set => SetAndNotifyIfChanged(ref CastleData.PrefixForCity, value);
        }

        public CountryEnum Country
        {
            get => CastleData.Country;
            set => SetAndNotifyIfChanged(ref CastleData.Country, value);
        }

        public ushort ManaPerMonth
        {
            get => CastleData.ManaPerMonth;
            set => SetAndNotifyIfChanged(ref CastleData.ManaPerMonth, value);
        }


        private byte[ ] monstersThatCanBeSummoned;

        public byte[ ] MonstersThatCanBeSummoned
        {
            get
            {
                if (monstersThatCanBeSummoned == null)
                {
                    monstersThatCanBeSummoned = new byte[16];
                    for (int i = 0; i < monstersThatCanBeSummoned.Length; i++)
                    {
                        monstersThatCanBeSummoned[i] = CastleData.MonsterCanSummon[i];
                    }
                }

                return monstersThatCanBeSummoned;
            }
            // TODO Implement Special Set Method
            //set => SetAndNotifyIfChanged(ref castleData.monstersThatCanBeSummoned, value);

        }

        public override int Address { get; }
    }
}