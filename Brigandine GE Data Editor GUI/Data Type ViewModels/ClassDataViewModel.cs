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
        public ClassDataViewModel(ref ClassData data, MemoryAccessor memoryAccessor, int address)
        {
            Address = address;
            classData          = data;
            this.memoryAccessor = memoryAccessor;
        }

        private MemoryAccessor memoryAccessor;
        private ClassData     classData;

        public override string ToString()
        {
            return Name;
        }

        //TODO Create special string like control type for handling getting and setting strings from memory accessor.
        public string Name
        {
            get => $"{memoryAccessor.DereferenceString(classData.Name)}";
            //set => SetAndNotifyIfChanged(ref attacks.Name, value);
        }
        public string NameWithAddress => $"{Name}  at {MemoryAccessor.AdjustAddress(classData.Name):X}";
        public byte Move
        {
            get => classData.Move;
            set => SetAndNotifyIfChanged(ref classData.Move, value);
        }

        public MoveTypeEnum MoveType
        {
            get => classData.MoveType;
            set => SetAndNotifyIfChanged(ref classData.MoveType, value);
        }

        public byte Defense
        {
            get => classData.Defense;
            
            set => SetAndNotifyIfChanged(ref classData.Defense, value);
        }

        public AttackEnum PrimaryAttack
        {
            get => classData.Attacks.PrimaryAttack;
            
            set => SetAndNotifyIfChanged(ref classData.Attacks.primaryAttack, value);
        }
        public AttackEnum SecondaryAttack
        {
            get => classData.Attacks.SecondaryAttack;
            
            set => SetAndNotifyIfChanged(ref classData.Attacks.secondaryAttack, value);
        }
        public AttackEnum SecondaryAttack2
        {
            get => classData.Attacks.SecondaryAttack2;
            
            set => SetAndNotifyIfChanged(ref classData.Attacks.secondaryAttack2, value);
        }

        public ClassData.SpecialAttack SpecialAttacks
        {
            get => classData.SpecialAttacks;
            set => SetAndNotifyIfChanged(ref classData.SpecialAttacks, value);
        }
        public SpecialAttacksEnum FirstAttack
        {
            get => classData.SpecialAttacks.FirstAttack;
            set => SetAndNotifyIfChanged(ref classData.SpecialAttacks.firstAttack, value);
        }
        public SpecialAttacksEnum SecondAttack
        {
            get => classData.SpecialAttacks.SecondAttack;
            set => SetAndNotifyIfChanged(ref classData.SpecialAttacks.secondAttack, value);
        }
        public MagicEnum Spells
        {
            get => classData.Spells;
            
            set => SetAndNotifyIfChanged(ref classData.Spells, value);
        }

        public FighterSkillEnum FirstSkill
        {
            get => classData.Skills.FirstSkill;
            
            set => SetAndNotifyIfChanged(ref classData.Skills.firstSkill, value);
        }
        public FighterSkillEnum SecondSkill
        {
            get => classData.Skills.SecondSkill;
            
            set => SetAndNotifyIfChanged(ref classData.Skills.secondSill, value);
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
                            unknown[i] = classData.Unknowns[i];
                        }
                    }
                }
                return unknown;
            }
            set => SetAndNotifyIfChanged(ref unknown, value);
        }

        public override int Address { get; }
    }
}
