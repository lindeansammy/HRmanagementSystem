using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfTeamProject.Helpers
{
    public class RelayCommand : ICommand
    {
        #region Props

        /// <summary>
        /// The action without parameter
        /// </summary>
        readonly Action _execute;

        /// <summary>
        /// The action with parameter
        /// </summary>
        readonly Action<object> _executes;

        /// <summary>
        /// Filter conditions
        /// </summary>
        readonly Predicate<object> _canExecute;
        #endregion

        #region Constructors

        /// <summary>
        /// Constructor that input method without parameter
        /// </summary>
        /// <param name="execute">method Name</param>
        public RelayCommand(Action execute):
            this(execute,null)
        {
        }

        /// <summary>
        /// Constructor that input method with parameter
        /// </summary>
        /// <param name="executes">method Name</param>
        public RelayCommand(Action<object> executes)
            :this(executes,null)
        {
        }

        /// <summary>
        /// Constructor that input method without parameter,
        /// and input condition.
        /// </summary>
        /// <param name="execute">method Name</param>
        /// <param name="canExecute">condition</param>
        public RelayCommand(Action execute, Predicate<object> canExecute)
        {
            _execute = execute ?? throw new ArgumentNullException("execute");
            _canExecute = canExecute;
        }

        /// <summary>
        /// Constructor that input method with parameter，
        /// and input condition
        /// </summary>
        /// <param name="executes">method Name</param>
        /// <param name="canExecute">condition</param>
        public RelayCommand(Action<object> executes, Predicate<object> canExecute)
        {
            _executes = executes ?? throw new ArgumentNullException("executes");
            _canExecute = canExecute;
        }
        #endregion
        
        #region we may not need to implement
        /// <summary>
        /// Occurs when changes occur that affect whether or not the command should execute
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        #endregion


        /// <summary>
        /// Determine whether method can execte. 
        /// </summary>
        /// <param name="parameter">data by command</param>
        /// <returns>True: can execute, otherwise, false;</returns>
        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }


        /// <summary>
        /// Execute method(void DataType).
        /// </summary>
        /// <param name="parameter">paramter form method that will execute.</param>
        public void Execute(object parameter)
        {
            if (_execute != null)
                _execute();
            else
                _executes(parameter);
        }
    }
}
