using BlackJackGame.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BlackJackGame.Commands
{
    public class NextCardCommand : ICommand
    {
        private GameViewModel viewModel;

        public NextCardCommand(GameViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        #region ICommand Members

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return !viewModel.GameOver;
        }

        public void Execute(object parameter)
        {
            MessageBox.Show("Next Card Button Pressed");
            viewModel.NextCard();
        }
        #endregion
    }
}
