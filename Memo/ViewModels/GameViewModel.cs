using Memo.Constants;
using Memo.Models;
using Memo.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Documents;

namespace Memo.ViewModels
{
    internal class GameViewModel : ViewModel
    {
        public bool StepFirst = true;
        public FieldModel selectedField = null;
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

        #region PointPlayer1
        private int pointPlayer1 = 0;
        public int PointPlayer1 { get => pointPlayer1; set => Set(ref pointPlayer1, value); }
        #endregion

        #region PointPlayer2
        private int pointPlayer2 = 0;
        public int PointPlayer2 { get => pointPlayer2; set => Set(ref pointPlayer2, value); }
        #endregion

        Random rnd = new();

        #region Methods

        #region StartGame
        public void StartGame()
        {
            GenerateField();
            GenerateTexture();
            PointPlayer1 = 0;
            PointPlayer2 = 0;
            StepFirst = true;
        }
        #endregion

        #region Restart
        public void RestartGame()
        {
            MessageBoxResult mbr = MessageBox.Show("Начать заново", "Конец игры", MessageBoxButton.YesNo);
            if (mbr == MessageBoxResult.Yes)
            {
                StartGame();
            }
            else
            {
                Application.Current.Shutdown();
            }
        }
        #endregion

        #region GenerateField
        public void GenerateField()
        {
            f.Clear();
            for (int i = 0; i < 4; i++)
            {
                ObservableCollection<FieldModel> row = new();
                for (int j = 0; j < 5; j++)
                {
                    row.Add(new FieldModel() { I = i, J = j });
                }
                f.Add(row);
            }
        }
        #endregion

        #region GenerateTexture
        public void GenerateTexture()
        {
            for (int i = 0; i < TexturesPaths.picture.Length; i++)
            {
                int added = 0;
                for (int j = 0; j < 2 + added; j++)
                {
                    int w = rnd.Next(0, 4);
                    int h = rnd.Next(0, 5);
                    if (F[w][h].texture != TexturesPaths.Empty)
                    {
                        added++;
                        continue;
                    }
                    F[w][h].texture = TexturesPaths.picture[i];
                }
            }
        }
        #endregion

        public bool FindOpened()
        {
            List<FieldModel> opened = new();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (F[i][j].texture == F[i][j].TexturePath && F[i][j].Enable)
                    {
                        opened.Add(F[i][j]);
                    }
                }
            }
            if (opened.Count == 2)
            {
                opened[0].TexturePath = TexturesPaths.Empty;
                opened[1].TexturePath = TexturesPaths.Empty;
                return true;
            }
            return false;
        }

        #region ClickField
        public void ClickField(FieldModel field)
        {
            if (FindOpened()) return;
            if (selectedField == null)
            {
                selectedField = field;
                selectedField.TexturePath = selectedField.texture;
            }
            else
            {
                if (field == selectedField)
                {
                    return;
                }
                if (selectedField.TexturePath == field.texture)
                {
                    field.TexturePath = field.texture;
                    selectedField.Enable = false;
                    field.Enable = false;
                    if (StepFirst)
                    {
                        PointPlayer1 += 1;
                    }
                    else
                    {
                        PointPlayer2 += 1;
                    }

                }
                else
                {
                    field.TexturePath = field.texture;
                    //selectedField.TexturePath = TexturesPaths.Empty;
                    StepFirst = !StepFirst;
                }
                selectedField = null;
                CheckWin();
            }
        }
        #endregion

        #region CheckWin
        public void CheckWin()
        {
            int count = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (!F[i][j].Enable)
                    {
                        count++;
                    }
                }
            }
            if (count == 20)
            {
                if (pointPlayer1 > pointPlayer2)
                {
                    MessageBox.Show("Player1 Win");
                    RestartGame();

                }
                else if (pointPlayer1 < pointPlayer2)
                {
                    MessageBox.Show("Player2 Win");
                    RestartGame();
                }
                else
                {
                    MessageBox.Show("Draw");
                    RestartGame();
                }
            }
        }
        #endregion

        #endregion
    }
}
