using System.Collections.ObjectModel;
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
        public AttackDataViewModel(ref AttackData data, MemoryAccessor memoryAccessor)
        {
            attackData          = data;
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
            get => memoryAccessor.DereferenceString(attackData.Name);
            //set => SetAndNotifyIfChanged(ref attackData.Name, value);
        }

        public string Description
        {
            get => memoryAccessor.DereferenceString(attackData.Description);
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

        public byte Unk
        {
            get => attackData.Unk;
            set => SetAndNotifyIfChanged(ref attackData.Unk, value);
        }

        public byte UsableAfterMove
        {
            get => attackData.UsableAfterMove;
            set => SetAndNotifyIfChanged(ref attackData.UsableAfterMove, value);
        }

        public byte Unk5
        {
            get => attackData.Unk5;
            set => SetAndNotifyIfChanged(ref attackData.Unk5, value);
        }

        public byte Unk6
        {
            get => attackData.Unk6;
            set => SetAndNotifyIfChanged(ref attackData.Unk6, value);
        }

        public byte Unk7
        {
            get => attackData.Unk7;
            set => SetAndNotifyIfChanged(ref attackData.Unk7, value);
        }
    }
}
