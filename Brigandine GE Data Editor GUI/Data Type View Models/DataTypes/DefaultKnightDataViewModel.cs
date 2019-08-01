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
            classData          = data;
            this.memoryAccessor = memoryAccessor;
        }

        private MemoryAccessor memoryAccessor;
        private unsafeDefaultKnightData classData;

        public override string ToString()
        {
            return Name;
        }

        //TODO Create special string like control type for handling getting and setting strings from memory accessor.
        public string Name
        {
            get => memoryAccessor.DereferenceString(classData.Name);
            //set => SetAndNotifyIfChanged(ref attackData.Name, value);
        }

        public byte Class
        {
            get => classData.Class;
            set => SetAndNotifyIfChanged(ref classData.Class, value);
        }

        public byte Level
        {
            get => classData.Level;
            set => SetAndNotifyIfChanged(ref classData.Level, value);
        }

        public ushort XP
        {
            get => classData.XP;
            
            set => SetAndNotifyIfChanged(ref classData.XP, value);
        }

        public ushort HP
        {
            get => classData.HP;
            
            set => SetAndNotifyIfChanged(ref classData.HP, value);
        }

        public ushort MP
        {
            get => classData.MP;
            set => SetAndNotifyIfChanged(ref classData.MP, value);
        }

        public byte STR
        {
            get => classData.STR;
            
            set => SetAndNotifyIfChanged(ref classData.STR, value);
        }

        public byte INT
        {
            get => classData.INT;
            
            set => SetAndNotifyIfChanged(ref classData.INT, value);
        }

        public byte AGI
        {
            get => classData.AGI;
            
            set => SetAndNotifyIfChanged(ref classData.AGI, value);
        }

        public byte RunePwrGrowth_RuneArea
        {
            get => classData.RunePwrGrowth_RuneArea;
            
            set => SetAndNotifyIfChanged(ref classData.RunePwrGrowth_RuneArea, value);
        }

        public ushort RunePwr
        {
            get => classData.RunePwr;
            
            set => SetAndNotifyIfChanged(ref classData.RunePwr, value);
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
                            monsters[i] = classData.Monsters[i];
                        }
                    }
                }
                return monsters;
            }
            set => SetAndNotifyIfChanged(ref monsters, value);
        }

        public byte StartingClass
        {
            get => classData.StartingClass;

            set => SetAndNotifyIfChanged(ref classData.StartingClass, value);
        }

        public byte Weapon
        {
            
            get => classData.Weapon;

            set => SetAndNotifyIfChanged(ref classData.Weapon, value);
        }
        public byte Item
        {
            
            get => classData.Item;

            set => SetAndNotifyIfChanged(ref classData.Item, value);
        }
        public int Unknown
        {

            get => classData.Unk;
            set => SetAndNotifyIfChanged(ref classData.Unk, value);
        }
        public byte Team
        {
            get => classData.Team;
            set => SetAndNotifyIfChanged(ref classData.Team, value);
        }
        public byte Town
        {
            get => classData.Town;
            set => SetAndNotifyIfChanged(ref classData.Town, value);
        }
        
    }
}
