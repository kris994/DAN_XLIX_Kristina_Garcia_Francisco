using System;
using System.Windows.Input;

namespace DAN_XLIX_Kristina_Garcia_Francisco.Commands
{
    /// <summary>
    /// RelayCommand class
    /// </summary>
    public class RelayCommand : ICommand
    {
        #region Fields readonly
        private readonly Action<object> _execute;
        private readonly Predicate<object> _canExecute;
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="execute">action that is being executed</param>
        public RelayCommand(Action<object> execute) : this(execute, null)
        {

        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="execute">action that is being executed</param>
        /// <param name="canExecute">checks if it can execute the action</param>
        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            _execute = execute ?? throw new ArgumentNullException("execute");
            _canExecute = canExecute;
        }
        #endregion

        #region ICommand Members
        /// <summary>
        /// Checks if it can execute the action
        /// </summary>
        /// <param name="parameter">parameter that is being exectuted</param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }

        /// <summary>
        /// If the option to execute changed
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// Executes the action
        /// </summary>
        /// <param name="parameter">parameter that is being exectuted</param>
        public void Execute(object parameter)
        {
            _execute(parameter);
        }
        #endregion
    }
}
