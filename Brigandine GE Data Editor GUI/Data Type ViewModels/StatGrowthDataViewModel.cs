using BrigandineGEDataEditor;
using BrigandineGEDataEditor.DataTypes;
using BrigandineGEDataEditorGUI.Data_Type_ViewModels.Base;

namespace BrigandineGEDataEditorGUI.Data_Type_ViewModels {
    public class StatGrowthDataViewModel : BaseDataTypeViewModel
    {
        public StatGrowthDataViewModel() { }

        public StatGrowthDataViewModel(ref StatGrowthData data, MemoryAccessor memoryAccessor, int address)
        {
            Address = address;
            statGrowthData      = data;
            this.memoryAccessor = memoryAccessor;
        }

        // ReSharper disable once NotAccessedField.Local
        private MemoryAccessor memoryAccessor;
        private StatGrowthData statGrowthData;
        public ref StatGrowthData StatGrowthData => ref statGrowthData;
        public override string ToString() => $"{HpGrowth} {MpGrowth} {StrGrowth} {IntGrowth} {AgiGrowth}";

        public byte HpGrowth
        {
            get => statGrowthData.HPGrowth;
            set => SetAndNotifyIfChanged(ref statGrowthData.HPGrowth, value);
        }
        public byte MpGrowth
        {
            get => statGrowthData.MPGrowth;
            set => SetAndNotifyIfChanged(ref statGrowthData.MPGrowth, value);
        }

        public byte StrGrowth
        {
            get => statGrowthData.STRGrowth;
            set => SetAndNotifyIfChanged(ref statGrowthData.STRGrowth, value);
        }

        public byte IntGrowth
        {
            get => statGrowthData.INTGrowth;
            set => SetAndNotifyIfChanged(ref statGrowthData.INTGrowth, value);
        }

        public byte AgiGrowth
        {
            get => statGrowthData.AGIGrowth;
            set => SetAndNotifyIfChanged(ref statGrowthData.AGIGrowth, value);
        }

        public override int Address { get; }
    }
}