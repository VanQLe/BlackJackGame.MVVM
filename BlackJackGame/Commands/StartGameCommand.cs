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
    public class StartGameCommand : ICommand
    {

        private GameViewModel viewModel;

        public StartGameCommand(GameViewModel viewModel)
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
            return viewModel.GameOver;
        }

        public void Execute(object parameter)
        {
            //MessageBox.Show("Start Card Button Pressed");
            viewModel.StartGame();
        }
        #endregion
    }
}
