using BrigandineGEDataEditor;
using BrigandineGEDataEditor.DataTypes;
using BrigandineGEDataEditor.Enums;
using BrigandineGEDataEditorGUI.Data_Type_View_Models.Base;

namespace BrigandineGEDataEditorGUI.Data_Type_View_Models {
    public class SpellDataViewModel : BaseDataTypeViewModel
    {
        public SpellDataViewModel() { }

        public SpellDataViewModel(ref unsafeSpellData data, MemoryAccessor memoryAccessor)
        {
            spellData           = data;
            this.memoryAccessor = memoryAccessor;
        }

        private MemoryAccessor memoryAccessor;
        private unsafeSpellData      spellData;

        public override string ToString()
        {
            return Name;
        }

        //TODO Create special string like control type for handling getting and setting strings from memory accessor.
        public string Name
        {
            get => $"{memoryAccessor.DereferenceString(spellData.Name)}";
            //set => SetAndNotifyIfChanged(ref attackData.Name, value);
        }
        public string NameWithAddress => $"{Name}  at {MemoryAccessor.AdjustAddress(spellData.Name):X}";
        public string Description
        {
            get => $"{memoryAccessor.DereferenceString(spellData.Description)} at {MemoryAccessor.AdjustAddress(spellData.Description):X}";
            //set => SetAndNotifyIfChanged(ref spellData.Description, value);
        }

        public ushort MPCost
        {
            get => spellData.MPCost;
            set => SetAndNotifyIfChanged(ref spellData.MPCost, value);
        }

        public byte Range
        {
            get => spellData.Range;
            set => SetAndNotifyIfChanged(ref spellData.Range, value);
        }

        public byte Damage
        {
            get => spellData.Damage;
            set => SetAndNotifyIfChanged(ref spellData.Damage, value);
        }

        public Elements Elements
        {
            get => spellData.Element.GetElements();
            //set => SetAndNotifyIfChanged(ref spellData.Element, value);
        }

        public byte GroundAndSky
        {
            get => spellData.GroundAndSky;
            set => SetAndNotifyIfChanged(ref spellData.GroundAndSky, value);
        }

        public byte Unknown1
        {
            get => spellData.Unknown1;
            set => SetAndNotifyIfChanged(ref spellData.Unknown1, value);
        }

        public byte AOE
        {
            get => spellData.AOE;
            set => SetAndNotifyIfChanged(ref spellData.AOE, value);
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
                            unknown[i] = spellData.Unknown[i];
                        }
                    }
                }
                return unknown;
            }
            set => SetAndNotifyIfChanged(ref unknown, value);
        }
    }
}