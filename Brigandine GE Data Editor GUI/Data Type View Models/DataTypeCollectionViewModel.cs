using System.Collections.Generic;
using System.Collections.ObjectModel;
using BrigandineGEDataEditorGUI.Data_Type_View_Models.Base;

namespace BrigandineGEDataEditorGUI.Data_Type_View_Models
{
    public abstract class BaseDataTypeCollectionViewModel : BaseViewModel
    {
        public abstract string Name { get; }
        public abstract BaseDataTypeViewModel CurrentSelectedDataProperty { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }

        public class DataTypeCollectionViewModel<TDataTypeViewModel> : BaseDataTypeCollectionViewModel
            where TDataTypeViewModel : BaseDataTypeViewModel
        {
            public DataTypeCollectionViewModel(IEnumerable<TDataTypeViewModel> viewModels)
            {
                DataTypeViewModels = new ObservableCollection<TDataTypeViewModel>(viewModels);
            }

            public ObservableCollection<TDataTypeViewModel> dataTypeViewModels;

            public ObservableCollection<TDataTypeViewModel> DataTypeViewModels
            {
                get => dataTypeViewModels;
                set => SetAndNotifyIfChanged(ref dataTypeViewModels, value);
            }

            private BaseDataTypeViewModel currentSelectedDataProperty;

            public override BaseDataTypeViewModel CurrentSelectedDataProperty
            {
                get => currentSelectedDataProperty;
                set => SetAndNotifyIfChanged(ref currentSelectedDataProperty, value);
            }

            public override string Name => typeof(TDataTypeViewModel).Name;
        }
}