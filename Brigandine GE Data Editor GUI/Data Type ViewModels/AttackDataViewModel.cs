using System;
using BrigandineGEDataEditor;
using BrigandineGEDataEditor.DataTypes;
using BrigandineGEDataEditor.Enums;
using BrigandineGEDataEditorGUI.Data_Type_View_Models.Base;

namespace BrigandineGEDataEditorGUI.Data_Type_View_Models
{
    public class AttackDataViewModel : BaseDataTypeViewModel
    {
        public AttackDataViewModel()
        {
            
        }
        public AttackDataViewModel(ref AttackData data, MemoryAccessor memoryAccessor, int address)
        {
            attackData          = data;
            Address = address;
            this.memoryAccessor = memoryAccessor;
        }

        private MemoryAccessor memoryAccessor;
        private AttackData     attackData;

        public override string ToString()
        {
            return Name;
        }

        //TODO Create special string like control type for handling getting and setting strings from memory accessor.
        public string Name
        {
            get => $"{memoryAccessor.DereferenceString(attackData.Name)}";
            //set => SetAndNotifyIfChanged(ref attackData.Name, value);
        }

        public string NameWithAddress => $"{Name}  at {MemoryAccessor.AdjustAddress(attackData.Name):X}";
        public string Description
        {
            get => $"{memoryAccessor.DereferenceString(attackData.Description)}";
            //set => SetAndNotifyIfChanged(ref description, value);
        }

        public byte Hit
        {
            get => attackData.Hit;
            set => SetAndNotifyIfChanged(ref attackData.Hit, value);
        }

        public byte RangeMin
        {
            get => attackData.RangeMin;
            set => SetAndNotifyIfChanged(ref attackData.RangeMin, value);
        }

        public byte RangeMax
        {
            get => attackData.RangeMax;
            set => SetAndNotifyIfChanged(ref attackData.RangeMax, value);
        }

        public byte Damage
        {
            get => attackData.Damage;
            set => SetAndNotifyIfChanged(ref attackData.Damage, value);
        }

        public Elements Element
        {
            get => attackData.Element.GetElements();
            //set => SetAndNotifyIfChanged(ref attackData.Element, value);
        }

        public byte GroundOrSky
        {
            get => attackData.GroundOrSky;
            set => SetAndNotifyIfChanged(ref attackData.GroundOrSky, value);
        }

        public byte Unknown
        {
            get => attackData.Unknown1;
            set => SetAndNotifyIfChanged(ref attackData.Unknown1, value);
        }

        public byte UsableAfterMove
        {
            get => attackData.UsableAfterMove;
            set => SetAndNotifyIfChanged(ref attackData.UsableAfterMove, value);
        }

        public byte[] Unknowns
        {
            get
            {
                var bytes = new byte[3];
                for (int i = 0; i < 3; i++)
                {
                    bytes[i] = attackData.Unknowns[i];
                }

                return bytes;
            }
        }

        public override int Address { get; }
    }
}
