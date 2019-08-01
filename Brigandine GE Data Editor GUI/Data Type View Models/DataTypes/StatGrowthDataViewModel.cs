using BrigandineGEDataEditor;
using BrigandineGEDataEditor.DataTypes;
using BrigandineGEDataEditorGUI.Data_Type_View_Models.Base;

namespace BrigandineGEDataEditorGUI.Data_Type_View_Models {
    public class StatGrowthDataViewModel : BaseDataTypeViewModel
    {
        public StatGrowthDataViewModel() { }

        public StatGrowthDataViewModel(ref StatGrowthData data, MemoryAccessor memoryAccessor)
        {
            statGrowthData      = data;
            this.memoryAccessor = memoryAccessor;
        }

        private MemoryAccessor memoryAccessor;
        private StatGrowthData statGrowthData;
        public override string ToString()
        {
            return $"{HPGrowth} {MPGrowth} {STRGrowth} {INTGrowth} {AGIGrowth}";
        }

        public byte HPGrowth
        {
            get => statGrowthData.HPGrowth;
            set => SetAndNotifyIfChanged(ref statGrowthData.HPGrowth, value);
        }
        public byte MPGrowth
        {
            get => statGrowthData.MPGrowth;
            set => SetAndNotifyIfChanged(ref statGrowthData.MPGrowth, value);
        }

        public byte STRGrowth
        {
            get => statGrowthData.STRGrowth;
            set => SetAndNotifyIfChanged(ref statGrowthData.STRGrowth, value);
        }

        public byte INTGrowth
        {
            get => statGrowthData.INTGrowth;
            set => SetAndNotifyIfChanged(ref statGrowthData.INTGrowth, value);
        }

        public byte AGIGrowth
        {
            get => statGrowthData.AGIGrowth;
            set => SetAndNotifyIfChanged(ref statGrowthData.AGIGrowth, value);
        }
    }
}