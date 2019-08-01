using System.Collections.ObjectModel;
using BrigandineGEDataEditor;
using BrigandineGEDataEditor.DataTypes;
using BrigandineGEDataEditor.Enums;
using BrigandineGEDataEditorGUI.Data_Type_View_Models.Base;

namespace BrigandineGEDataEditorGUI.Data_Type_View_Models
{
    public class ClassDataViewModel : BaseDataTypeViewModel
    {
        public ClassDataViewModel()
        {
            
        }
        public ClassDataViewModel(ref unsafeClassData data, MemoryAccessor memoryAccessor)
        {
            classData          = data;
            this.memoryAccessor = memoryAccessor;
        }

        private MemoryAccessor memoryAccessor;
        private unsafeClassData     classData;

        public override string ToString()
        {
            return Name;
        }

        //TODO Create special string like control type for handling getting and setting strings from memory accessor.
        public string Name
        {
            get => $"{memoryAccessor.DereferenceString(classData.Name)}";
            //set => SetAndNotifyIfChanged(ref attackData.Name, value);
        }
        public string NameWithAddress => $"{Name}  at {MemoryAccessor.AdjustAddress(classData.Name):X}";
        public byte Move
        {
            get => classData.Move;
            set => SetAndNotifyIfChanged(ref classData.Move, value);
        }

        public MoveType MoveType
        {
            get => classData.MoveType;
            set => SetAndNotifyIfChanged(ref classData.MoveType, value);
        }

        public byte Defense
        {
            get => classData.Defense;
            
            set => SetAndNotifyIfChanged(ref classData.Defense, value);
        }

        public Attacks Attacks
        {
            get => classData.Attacks;
            
            set => SetAndNotifyIfChanged(ref classData.Attacks, value);
        }

        public SpecialAttacks SpecialAttacks
        {
            get => classData.SpecialAttacks;
            set => SetAndNotifyIfChanged(ref classData.SpecialAttacks, value);
        }

        public byte MagicWB
        {
            get => classData.MagicWB;
            
            set => SetAndNotifyIfChanged(ref classData.MagicWB, value);
        }

        public byte MagicBR
        {
            get => classData.MagicBR;
            
            set => SetAndNotifyIfChanged(ref classData.MagicBR, value);
        }

        public byte MagicRB
        {
            get => classData.MagicRB;
            
            set => SetAndNotifyIfChanged(ref classData.MagicRB, value);
        }

        public byte MagicG
        {
            get => classData.MagicG;
            
            set => SetAndNotifyIfChanged(ref classData.MagicG, value);
        }

        public Skills Skills
        {
            get => classData.Skills;
            
            set => SetAndNotifyIfChanged(ref classData.Skills, value);
        }

        public Elements Element
        {
            get => classData.Element.GetElements();
            //set => SetAndNotifyIfChanged(ref classData.Element, value);
        }

        public byte Add_HP
        {
            get => classData.Add_HP;

            set => SetAndNotifyIfChanged(ref classData.Add_HP, value);
        }

        public byte Add_MP
        {
            
            get => classData.Add_MP;

            set => SetAndNotifyIfChanged(ref classData.Add_MP, value);
        }
        public byte Focus
        {
            
            get => classData.Focus;

            set => SetAndNotifyIfChanged(ref classData.Focus, value);
        }
        public byte Star
        {

            get => classData.Star;
            set => SetAndNotifyIfChanged(ref classData.Star, value);
        }
        public ushort ExpRequiredToLvl
        {
            get => classData.ExpRequiredToLvl;
            set => SetAndNotifyIfChanged(ref classData.ExpRequiredToLvl, value);
        }

        private uint[ ] unknown = null;
        public uint[] Unknown
        {
            get
            {
                unsafe
                {
                    if (unknown == null)
                    {
                        unknown = new uint[5];
                        for (int i = 0; i < unknown.Length; i++)
                        {
                            unknown[i] = classData.Unkown[i];
                        }
                    }
                }
                return unknown;
            }
            set => SetAndNotifyIfChanged(ref unknown, value);
        }
    }
}
