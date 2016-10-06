using System;
using System.Windows.Input;
using FI_Dev.ViewModels;

namespace FI_Dev.Commands
{
    internal class SentenceUpdateCommand : ICommand
    {
        public SentenceUpdateCommand(WordsCounterViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        private readonly WordsCounterViewModel _viewModel;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return _viewModel.CanUpdate;
        }

        public void Execute(object parameter)
        {
            _viewModel.SaveChanges();
        }
    }
}