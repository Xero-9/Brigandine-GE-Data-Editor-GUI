using System;
using System.Windows.Input;

namespace BrigandineGEDataEditorGUI.Data_Type_ViewModels.Base
{

    public class Command : ICommand
    {
        readonly Action targetExecuteMethod;
        readonly Func<bool> targetCanExecuteMethod;

        public Command(Action executeMethod) => targetExecuteMethod = executeMethod;

        public Command(Action executeMethod, Func<bool> canExecuteMethod)
        {
            targetExecuteMethod = executeMethod;
            targetCanExecuteMethod = canExecuteMethod;
        }

        public void RaiseCanExecuteChanged() => CanExecuteChanged(this, EventArgs.Empty);

        bool ICommand.CanExecute(object parameter) => targetCanExecuteMethod?.Invoke() ?? targetExecuteMethod != null;

        // Beware - should use weak references if command instance lifetime 
      //   is longer than lifetime of UI objects that get hooked up to command
 
      // Prism commands solve this in their implementation 
        public event EventHandler CanExecuteChanged = delegate { };

        void ICommand.Execute(object parameter) => targetExecuteMethod?.Invoke();
    }
}