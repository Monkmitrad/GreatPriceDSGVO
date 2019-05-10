﻿using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace GreatPriceDSGVO
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeGrid();
        }

        private void InitializeGrid()
        {
            //Create 5 columns with 5 rows
            ColumnDefinition colDef;
            RowDefinition rowDef;
            StackPanel stackP;
            TextBlock textB;
            Button btn;
            int cellIndex = 0;
            contentGrid.Margin = new Thickness(5);

            for (int colIndex = 0; colIndex < 5; colIndex++)
            {
                //Define new Column to add
                colDef = new ColumnDefinition
                {
                    Width = GridLength.Auto
                };

                //Add header and column definition to Grid
                contentGrid.ColumnDefinitions.Add(colDef);
                for (int rowIndex = 0; rowIndex < 6; rowIndex++)
                {
                    //Define new Row to add
                    rowDef = new RowDefinition
                    {
                        Height = GridLength.Auto
                    };

                    //Add row definition to Grid
                    contentGrid.RowDefinitions.Add(rowDef);

                    //create stackpanel and define which row to add the stackpanel to
                    stackP = new StackPanel();
                    stackP.SetValue(Grid.RowProperty, rowIndex);
                    stackP.SetValue(Grid.ColumnProperty, colIndex);
                    stackP.HorizontalAlignment = HorizontalAlignment.Center;

                    //Check if first row, if yes add header
                    if (rowIndex == 0)
                    {
                        textB = new TextBlock
                        {
                            Text = "Kategorie " + (colIndex + 1),
                            FontSize = 26,
                            FontWeight = FontWeights.Bold
                        };

                        //add your control to the stackpanel
                        stackP.Children.Add(textB);
                        stackP.Margin = new Thickness(5);
                    }
                    else
                    {
                        //create Button that will be added to new row
                        btn = new QuestionButton
                        {
                            Name = "button" + cellIndex.ToString(),
                            Content = "Button " + cellIndex.ToString(),
                            VerticalAlignment = VerticalAlignment.Center,
                            HorizontalAlignment = HorizontalAlignment.Center,
                            ClickMode = ClickMode.Press,
                            Margin = new Thickness(20),
                            FontSize = 32,
                            myPosition = new Position(colIndex, rowIndex),
                            isClicked = false
                        };
                        btn.Click += new RoutedEventHandler(OnClick);
                        cellIndex++;

                        //add your control to the stackpanel
                        stackP.Children.Add(btn);
                    }

                    //add the stackpanel to the grid
                    contentGrid.Children.Add(stackP);
                }
            }
        }
        void OnClick(object sender, RoutedEventArgs e)
        {
            QuestionButton obj = (QuestionButton)sender;
            OutputText(obj.myPosition.Output());
            if (obj.isClicked == true)
            {
                obj.IsEnabled = false;
            }
            else
            {
                obj.isClicked = true;
                obj.IsEnabled = false;
            }
            CheckFinished();
        }

        /// <summary>
        /// Checks if all buttons in contentGrid are clicked
        /// </summary>
        void CheckFinished()
        {
            List<QuestionButton> btnList = new List<QuestionButton>();

            for (int colIndex = 0; colIndex < 5; colIndex++)
            {
                //we don't have to check the header for buttons
                for (int rowIndex = 1; rowIndex < 5; rowIndex++)
                {
                    StackPanel currentElement = GetGridElement(contentGrid, rowIndex, colIndex);
                    foreach (var item in currentElement.Children)
                    {
                        if (item.GetType() == typeof(QuestionButton))
                        {
                            QuestionButton currentButton = (QuestionButton)item;
                            if (currentButton.isClicked == false)
                            {
                                btnList.Add(currentButton);
                            }
                        }
                    }
                }
            }

            //check if all buttons were clicked
            if (btnList.Count == 0)
            {
                OutputText("Spiel beendet");
            }

        }

        /// <summary>
        /// returns the content of a grid in a specific row and column
        /// </summary>
        /// <param name="g">Grid which has to be searched</param>
        /// <param name="rowIndex">row Index of the Item</param>
        /// <param name="colIndex">column Index of the Item</param>
        /// <returns></returns>
        StackPanel GetGridElement(Grid g, int rowIndex, int colIndex)
        {
            StackPanel sp;
            for (int i = 0; i < g.Children.Count; i++)
            {
                UIElement e = g.Children[i];
                if (e.GetType() == typeof(StackPanel))
                {
                    sp = (StackPanel)e;
                }
                else
                {
                    continue;
                }
                if (Grid.GetRow(sp) == rowIndex && Grid.GetColumn(sp) == colIndex)
                {
                    return sp;
                }
            }
            return null;
        }

        /// <summary>
        /// Displays text in the output label
        /// </summary>
        /// <param name="text">text that should be displayed</param>
        public void OutputText(string text)
        {
            outputLabel.Content = text;
        }
    }
}
