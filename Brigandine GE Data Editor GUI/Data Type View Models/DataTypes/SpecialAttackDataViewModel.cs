using BrigandineGEDataEditor;
using BrigandineGEDataEditor.DataTypes;
using BrigandineGEDataEditor.Enums;
using BrigandineGEDataEditorGUI.Data_Type_View_Models.Base;

namespace BrigandineGEDataEditorGUI.Data_Type_View_Models {
    public class SpecialAttackDataViewModel : BaseDataTypeViewModel
    {
        public SpecialAttackDataViewModel() { }

        public SpecialAttackDataViewModel(ref unsafeSpecialAttackData data, MemoryAccessor memoryAccessor)
        {
            specialAttackData   = data;
            this.memoryAccessor = memoryAccessor;
        }

        private MemoryAccessor    memoryAccessor;
        private unsafeSpecialAttackData specialAttackData;

        public override string ToString()
        {
            return Name;
        }

        //TODO Create special string like control type for handling getting and setting strings from memory accessor.
        public string Name
        {
            get => $"{memoryAccessor.DereferenceString(specialAttackData.Name)}";
            //set => SetAndNotifyIfChanged(ref attackData.Name, value);
        }
        public string NameWithAddress => $"{Name}  at {MemoryAccessor.AdjustAddress(specialAttackData.Name):X}";
        public string Description
        {
            get =>
                $"{memoryAccessor.DereferenceString(specialAttackData.Description)} at {MemoryAccessor.AdjustAddress(specialAttackData.Description):X}";
            //set => SetAndNotifyIfChanged(ref SpecialAttackData.Description, value);
        }

        public byte MP
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

        public Elements Elements
        {
            get => specialAttackData.Element.GetElements();
            //set => SetAndNotifyIfChanged(ref SpecialAttackData.Element, value);
        }

        public byte GroundOrSky
        {
            get => specialAttackData.GroundOrSky;
            set => SetAndNotifyIfChanged(ref specialAttackData.GroundOrSky, value);
        }
        private byte[ ] unknown = null;
        public byte[] Unknown
        {
            get
            {
                unsafe
                {
                    if (unknown == null)
                    {
                        unknown = new byte[5];
                        for (int i = 0; i < unknown.Length; i++)
                        {
                            unknown[i] = specialAttackData.Unknown[i];
                        }
                    }
                }
                return unknown;
            }
            set => SetAndNotifyIfChanged(ref unknown, value);
        }
    }
}