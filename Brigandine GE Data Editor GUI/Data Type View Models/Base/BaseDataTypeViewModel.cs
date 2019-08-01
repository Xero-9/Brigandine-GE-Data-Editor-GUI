using System;
using System.Runtime.CompilerServices;
using BrigandineGEDataEditor;

namespace BrigandineGEDataEditorGUI.Data_Type_View_Models.Base
{
    public abstract class BaseDataTypeViewModel : BaseViewModel
    {
        public BaseDataTypeViewModel()
        {
            
        }
        /// <summary>
        /// Called from the base constructor to initialize the data type view model and sets HasBeenInitialized. To ensure that the view
        /// models are properly initialized this function must return true or an error is thrown.
        /// </summary>
        /// <param name="memoryAccessor"></param>
        /// <returns>Has to return true or initialization will fail and an exception will be thrown</returns>
        //private protected abstract bool Initialize(MemoryAccessor memoryAccessor);

        //public bool HasBeenInitialized { get; }
        //public BaseDataTypeViewModel(MemoryAccessor memoryAccessor)
        //{
        //    HasBeenInitialized = Initialize(memoryAccessor);

        //    if (!HasBeenInitialized)
        //        throw new Exception(
        //            $"{GetType().Name} has not been properly initialized, make sure the Initialize function returns true.");
        //}
    }
}