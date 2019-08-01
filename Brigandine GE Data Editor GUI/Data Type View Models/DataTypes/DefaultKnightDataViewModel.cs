using System.Collections.ObjectModel;
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
        public DefaultKnightDataViewModel(ref unsafeDefaultKnightData data, MemoryAccessor memoryAccessor)
        {
            defaultKnightData          = data;
            this.memoryAccessor = memoryAccessor;
        }

        private MemoryAccessor memoryAccessor;
        private unsafeDefaultKnightData defaultKnightData;

        public override string ToString()
        {
            return Name;
        }

        //TODO Create special string like control type for handling getting and setting strings from memory accessor.
        public string Name
        {
            get => $"{memoryAccessor.DereferenceString(defaultKnightData.Name)}";
            //set => SetAndNotifyIfChanged(ref attackData.Name, value);
        }
        public string NameWithAddress => $"{Name}  at {MemoryAccessor.AdjustAddress(defaultKnightData.Name):X}";
        public byte Class
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

        private uint[ ] monsters = null;
        public uint[] Monsters
        {
            get
            {
                unsafe
                {
                    if (monsters == null)
                    {
                        monsters = new uint[7];
                        for (int i = 0; i < monsters.Length; i++)
                        {
                            monsters[i] = defaultKnightData.Monsters[i];
                        }
                    }
                }
                return monsters;
            }
            set => SetAndNotifyIfChanged(ref monsters, value);
        }

        public byte StartingClass
        {
            get => defaultKnightData.StartingClass;

            set => SetAndNotifyIfChanged(ref defaultKnightData.StartingClass, value);
        }

        public byte Weapon
        {
            
            get => defaultKnightData.Weapon;

            set => SetAndNotifyIfChanged(ref defaultKnightData.Weapon, value);
        }
        public byte Item
        {
            
            get => defaultKnightData.Item;

            set => SetAndNotifyIfChanged(ref defaultKnightData.Item, value);
        }
        public int Unknown
        {

            get => defaultKnightData.Unk;
            set => SetAndNotifyIfChanged(ref defaultKnightData.Unk, value);
        }
        public byte Team
        {
            get => defaultKnightData.Team;
            set => SetAndNotifyIfChanged(ref defaultKnightData.Team, value);
        }
        public byte Town
        {
            get => defaultKnightData.Town;
            set => SetAndNotifyIfChanged(ref defaultKnightData.Town, value);
        }
        
    }
}
