using BrigandineGEDataEditor;
using BrigandineGEDataEditor.DataTypes;
using BrigandineGEDataEditor.Enums;
using BrigandineGEDataEditorGUI.Data_Type_View_Models.Base;

namespace BrigandineGEDataEditorGUI.Data_Type_View_Models
{
    public class CastleDataViewModel : BaseDataTypeViewModel
    {
        public CastleDataViewModel()
        {
            
        }
        public CastleDataViewModel(ref CastleData data, MemoryAccessor memoryAccessor, int address)
        {
            Address = address;
            castleData = data;
            this.memoryAccessor = memoryAccessor;
        }

        private MemoryAccessor   memoryAccessor;
        private CastleData castleData;

        public override string ToString()
        {
            return Name;
        }

        //TODO Create special string like control type for handling getting and setting strings from memory accessor.
        public string Name
        {
            get => $"{memoryAccessor.DereferenceString(castleData.Name)}";
            //set => SetAndNotifyIfChanged(ref attacks.Name, value);
        }
        public string NameWithAddress => $"{Name}  at {MemoryAccessor.AdjustAddress(castleData.Name):X}";
        public byte MovesFlag
        {
            get => castleData.MovesFlag;
            set => SetAndNotifyIfChanged(ref castleData.MovesFlag, value);
        }
        private byte[ ] castlesConnectedTo = null;
        public byte[ ] CastlesConnectedTo
        {
            get
            {
                unsafe
                {
                    if (castlesConnectedTo == null)
                    {
                        castlesConnectedTo = new byte[3];
                        for (int i = 0; i < castlesConnectedTo.Length; i++)
                        {
                            castlesConnectedTo[i] = castleData.CastlesConnectedTo[i];
                        }
                    }
                }
                return castlesConnectedTo;
            }
            // TODO Implement Special Set Method
            //set => SetAndNotifyIfChanged(ref castleData.RangeMin, value);
        }

        public byte PrefixForCity
        {
            get => castleData.PrefixForCity;
            set => SetAndNotifyIfChanged(ref castleData.PrefixForCity, value);
        }

        public CountryEnum Country
        {
            get => castleData.Country;
            set => SetAndNotifyIfChanged(ref castleData.Country, value);
        }

        public ushort ManaPerMonth
        {
            get => castleData.ManaPerMonth;
            set => SetAndNotifyIfChanged(ref castleData.ManaPerMonth, value);
        }


        private byte[ ] monstersThatCanBeSummoned = null;

        public byte[ ] MonstersThatCanBeSummoned
        {
            get
            {
                unsafe
                {
                    if (monstersThatCanBeSummoned == null)
                    {
                        monstersThatCanBeSummoned = new byte[16];
                        for (int i = 0; i < monstersThatCanBeSummoned.Length; i++)
                        {
                            monstersThatCanBeSummoned[i] = castleData.MonsterCanSummon[i];
                        }
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