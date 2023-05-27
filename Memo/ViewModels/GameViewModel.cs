using Memo.Models;
using Memo.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


namespace Memo.ViewModels
{
    internal class GameViewModel : ViewModel
    {
        #region Field Observable Collection
        private ObservableCollection<ObservableCollection<FieldModel>> f = new();
        public ObservableCollection<ObservableCollection<FieldModel>> F { get => f; set => Set(ref f, value); }
        #endregion

        #region Constructor
        public GameViewModel()
        {
            StartGame();
        }
        #endregion

        #region Methods

        #region StartGame
        public void StartGame()
        {
            GenerateField();
        }
        #endregion

        #region GenerateField
        public void GenerateField()
        {
            f.Clear();
            for (int i = 0; i < 15; i++)
            {
                ObservableCollection<FieldModel> row = new();
                for (int j = 0; j < 15; j++)
                {
                    row.Add(new FieldModel() { I = i, J = j });
                }
                f.Add(row);
            }
        }
        #endregion

        #endregion
    }
}
