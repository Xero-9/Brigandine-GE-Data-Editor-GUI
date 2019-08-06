using BrigandineGEDataEditor;
using BrigandineGEDataEditor.DataTypes;
using BrigandineGEDataEditor.Enums;
using BrigandineGEDataEditorGUI.Data_Type_View_Models.Base;

namespace BrigandineGEDataEditorGUI.Data_Type_View_Models
{
    public class DefaultKnightDataViewModel : BaseDataTypeViewModel
    {
        public DefaultKnightDataViewModel()
        {
            
        }
        public DefaultKnightDataViewModel(ref DefaultKnightData data, MemoryAccessor memoryAccessor, int address)
        {
            Address = address;
            defaultKnightData          = data;
            this.memoryAccessor = memoryAccessor;
        }

        private MemoryAccessor memoryAccessor;
        private DefaultKnightData defaultKnightData;

        public override string ToString()
        {
            return Name;
        }

        //TODO Create special string like control type for handling getting and setting strings from memory accessor.
        private string name;
        public string Name
        {
            get => $"{defaultKnightData.Name.GetText(memoryAccessor)}";
            set
            {
                name = value;
                defaultKnightData.Name.SetText(memoryAccessor, ref name);
                    NotifyPropertyChanged(nameof(Name));
            }
        }

        public string NameWithAddress => $"{Name}  at {MemoryAccessor.AdjustAddress(defaultKnightData.Name):X}";
        public ClassEnum Class
        {
            get => defaultKnightData.Class;
            set => SetAndNotifyIfChanged(ref defaultKnightData.Class, value);
        }

        public byte Level
        {
            get => defaultKnightData.Level;
            set => SetAndNotifyIfChanged(ref defaultKnightData.Level, value);
        }

        public ushort XP
        {
            get => defaultKnightData.XP;
            
            set => SetAndNotifyIfChanged(ref defaultKnightData.XP, value);
        }

        public ushort HP
        {
            get => defaultKnightData.HP;
            
            set => SetAndNotifyIfChanged(ref defaultKnightData.HP, value);
        }

        public ushort MP
        {
            get => defaultKnightData.MP;
            set => SetAndNotifyIfChanged(ref defaultKnightData.MP, value);
        }

        public byte STR
        {
            get => defaultKnightData.STR;
            
            set => SetAndNotifyIfChanged(ref defaultKnightData.STR, value);
        }

        public byte INT
        {
            get => defaultKnightData.INT;
            
            set => SetAndNotifyIfChanged(ref defaultKnightData.INT, value);
        }

        public byte AGI
        {
            get => defaultKnightData.AGI;
            
            set => SetAndNotifyIfChanged(ref defaultKnightData.AGI, value);
        }

        public byte RunePwrGrowth_RuneArea
        {
            get => defaultKnightData.RunePwrGrowth_RuneArea;
            
            set => SetAndNotifyIfChanged(ref defaultKnightData.RunePwrGrowth_RuneArea, value);
        }

        public ushort RunePwr
        {
            get => defaultKnightData.RunePwr;
            
            set => SetAndNotifyIfChanged(ref defaultKnightData.RunePwr, value);
        }

        public byte[] Monsters
        {
            get => defaultKnightData.Monsters.ToArray();
            //set => SetAndNotifyIfChanged(ref defaultKnightData.Monsters, value);
        }

        public byte[] Unknown1 => defaultKnightData.Unknown1.ToArray();
        public byte[] Unknown2 => defaultKnightData.Unknown2.ToArray();
        public byte[] Unknown3 => defaultKnightData.Unknown3.ToArray();
        public byte Unknown4 => defaultKnightData.Unknown4;
        public byte Unknown5 => defaultKnightData.Unknown5;
        public CountryEnum Country
        {
            get => defaultKnightData.Country;
            set => SetAndNotifyIfChanged(ref defaultKnightData.Country, value);
        }
        public CastlesEnum Castle
        {
            get => defaultKnightData.Castle;
            set => SetAndNotifyIfChanged(ref defaultKnightData.Castle, value);
        }

        public override int Address { get; }
    }
}
