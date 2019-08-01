using System.Collections.ObjectModel;
using BrigandineGEDataEditor;
using BrigandineGEDataEditor.DataTypes;
using BrigandineGEDataEditor.Enums;
using BrigandineGEDataEditorGUI.Data_Type_View_Models.Base;

namespace BrigandineGEDataEditorGUI.Data_Type_View_Models
{
    public class ItemDataViewModel : BaseDataTypeViewModel
    {
        public ItemDataViewModel ()
        {
            itemData.Type = ItemTypeEnum.Amulet;
        }
        public ItemDataViewModel (ref ItemData data, MemoryAccessor memoryAccessor)
        {
            itemData          = data;
            this.memoryAccessor = memoryAccessor;
        }

        private MemoryAccessor memoryAccessor;
        private ItemData itemData;

        public override string ToString()
        {
            return Name;
        }

        //TODO Create special string like control type for handling getting and setting strings from memory accessor.
        public string Name
        {
            get => $"{memoryAccessor.DereferenceString(itemData.Name)}";
            //set => SetAndNotifyIfChanged(ref attackData.Name, value);
        }
        public string NameWithAddress => $"{Name}  at {MemoryAccessor.AdjustAddress(itemData.Name):X}";
        public ItemTypeEnum Type
        {
            get => itemData.Type;
            set => SetAndNotifyIfChanged(ref itemData.Type, value);
        }

        public byte AttackStr
        {
            get => itemData.AttackStr;
            set => SetAndNotifyIfChanged(ref itemData.AttackStr, value);
        }

        public byte Int
        {
            get => itemData.Int;
            set => SetAndNotifyIfChanged(ref itemData.Int, value);
        }

        public byte Hit
        {
            get => itemData.Hit;
            set => SetAndNotifyIfChanged(ref itemData.Hit, value);
        }

        public byte AvoidAgi
        {
            get => itemData.Avoid_Agi;
            set => SetAndNotifyIfChanged(ref itemData.Avoid_Agi, value);
        }

        public byte DefShieldBlock
        {
            get => itemData.Def_ShieldBlock;
            set => SetAndNotifyIfChanged(ref itemData.Def_ShieldBlock, value);
        }

        public byte HP
        {
            get => itemData.HP;
            set => SetAndNotifyIfChanged(ref itemData.HP, value);
        }

        public byte MP
        {
            get => itemData.MP;
            set => SetAndNotifyIfChanged(ref itemData.MP, value);
        }

        public byte MoveUp
        {
            get => itemData.MovUp;
            set => SetAndNotifyIfChanged(ref itemData.MovUp, value);
        }

        public byte RunePowerRuneCost
        {
            get => itemData.RunePwr_RuneCost;
            set => SetAndNotifyIfChanged(ref itemData.RunePwr_RuneCost, value);
        }

        public byte RuneArea
        {
            get => itemData.RuneArea;
            set => SetAndNotifyIfChanged(ref itemData.RuneArea, value);
        }

        public Elements AttackElements
        {
            get => itemData.AtkElement.GetElements();
            //set => SetAndNotifyIfChanged(ref itemData.AtkElement, value);
        }

        public Elements ResistElements
        {
            get => itemData.ResistElement.GetElements();
            //set => SetAndNotifyIfChanged(ref itemData.ResistElement, value);
        }
    }
}
