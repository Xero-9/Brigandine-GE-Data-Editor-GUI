using BrigandineGEDataEditor;
using BrigandineGEDataEditor.DataTypes;
using BrigandineGEDataEditor.Enums;
using BrigandineGEDataEditorGUI.Data_Type_ViewModels.Base;

namespace BrigandineGEDataEditorGUI.Data_Type_ViewModels
{
    public class ClassDataViewModel : BaseDataTypeViewModel
    {
        public ClassDataViewModel()
        {
            
        }
        public ClassDataViewModel(ref ClassData data, MemoryAccessor memoryAccessor, int address)
        {
            Address = address;
            ClassData          = data;
            this.memoryAccessor = memoryAccessor;
        }

        private readonly MemoryAccessor memoryAccessor;
        private ClassData     classData;
        public ref ClassData ClassData => ref classData;

        public override string ToString() => Name;

        //TODO Create special string like control type for handling getting and setting strings from memory accessor.
        public string Name => $"{memoryAccessor.DereferenceString(ClassData.Name)}";
        public string NameWithAddress => $"{Name}  at {MemoryAccessor.AdjustAddress(ClassData.Name):X}";
        public byte Move
        {
            get => ClassData.Move;
            set => SetAndNotifyIfChanged(ref ClassData.Move, value);
        }

        public MoveTypeEnum MoveType
        {
            get => ClassData.MoveType;
            set => SetAndNotifyIfChanged(ref ClassData.MoveType, value);
        }

        public byte Defense
        {
            get => ClassData.Defense;
            
            set => SetAndNotifyIfChanged(ref ClassData.Defense, value);
        }

        public AttackEnum PrimaryAttack
        {
            get => ClassData.Attacks.PrimaryAttack;
            
            set => SetAndNotifyIfChanged(ref ClassData.Attacks.primaryAttack, value);
        }
        public AttackEnum SecondaryAttack
        {
            get => ClassData.Attacks.SecondaryAttack;
            
            set => SetAndNotifyIfChanged(ref ClassData.Attacks.secondaryAttack, value);
        }
        public AttackEnum SecondaryAttack2
        {
            get => ClassData.Attacks.SecondaryAttack2;
            
            set => SetAndNotifyIfChanged(ref ClassData.Attacks.secondaryAttack2, value);
        }

        public ClassData.SpecialAttack SpecialAttacks
        {
            get => ClassData.SpecialAttacks;
            set => SetAndNotifyIfChanged(ref ClassData.SpecialAttacks, value);
        }
        public SpecialAttacksEnum FirstAttack
        {
            get => ClassData.SpecialAttacks.FirstAttack;
            set => SetAndNotifyIfChanged(ref ClassData.SpecialAttacks.firstAttack, value);
        }
        public SpecialAttacksEnum SecondAttack
        {
            get => ClassData.SpecialAttacks.SecondAttack;
            set => SetAndNotifyIfChanged(ref ClassData.SpecialAttacks.secondAttack, value);
        }
        public MagicEnum Spells
        {
            get => ClassData.Spells;
            
            set => SetAndNotifyIfChanged(ref ClassData.Spells, value);
        }

        public FighterSkillEnum FirstSkill
        {
            get => ClassData.Skills.FirstSkill;
            
            set => SetAndNotifyIfChanged(ref ClassData.Skills.firstSkill, value);
        }
        public FighterSkillEnum SecondSkill
        {
            get => ClassData.Skills.SecondSkill;
            
            set => SetAndNotifyIfChanged(ref ClassData.Skills.secondSill, value);
        }

        public Elements Element => ClassData.Element.GetElements();

        public byte AddHp
        {
            get => ClassData.Add_HP;

            set => SetAndNotifyIfChanged(ref ClassData.Add_HP, value);
        }

        public byte AddMp
        {
            
            get => ClassData.Add_MP;

            set => SetAndNotifyIfChanged(ref ClassData.Add_MP, value);
        }
        public byte Focus
        {
            
            get => ClassData.Focus;

            set => SetAndNotifyIfChanged(ref ClassData.Focus, value);
        }
        public byte Star
        {

            get => ClassData.Star;
            set => SetAndNotifyIfChanged(ref ClassData.Star, value);
        }
        public ushort ExpRequiredToLvl
        {
            get => ClassData.ExpRequiredToLvl;
            set => SetAndNotifyIfChanged(ref ClassData.ExpRequiredToLvl, value);
        }

        private uint[ ] unknown;
        public uint[] Unknown
        {
            get
            {
                if (unknown == null)
                {
                    unknown = new uint[5];
                    for (int i = 0; i < unknown.Length; i++)
                    {
                        unknown[i] = ClassData.Unknowns[i];
                    }
                }

                return unknown;
            }
            set => SetAndNotifyIfChanged(ref unknown, value);
        }

        public override int Address { get; }
    }
}
