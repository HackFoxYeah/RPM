using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using static practWork_8.CargoShip;

namespace practWork_8
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            BTNDef.Click += delegate (object sender, RoutedEventArgs e)
            {
                _cargoShipList.Add(new CargoShip("Маруся", 120, 50, 500, 600, 3600, 390000, FuelType.steam));
                _cargoShipList.Add(new CargoShip("Победа", 120, 50, 350, 600, 3600, 390000, FuelType.steam));
                _cargoShipList.Add(new CargoShip("ГеннаКот", 120, 50, 500, 600, 3600, 390000, FuelType.steam));
                ShowInfo(sender, e);
            };
        }

        private List<CargoShip> _cargoShipList = new();

        /// <summary>
        /// Вспомогательный метод для валидации данных.
        /// </summary>
        /// <param name="textBoxes">Текстбоксы для валидации.</param>
        private void BTNAddShip_Click(object sender, RoutedEventArgs e)
        {
            List<TextBox> list = new()
            {
                 tbEnginePwr,
                 tbCargoCap,
                 tbLoadCap,
                 tbLength,
                 tbWeigth,
                 tbWidth,
                 tbName
            };
            for (int i = 0; i < list.Count; i++)
            {
                list[i].BorderBrush = Brushes.Gray;
            }
            list.Remove(tbName);

            try
            {
                string name = tbName.Text,
                       temp = tbFuelType.Text.ToLower();

                int width = int.Parse(tbWidth.Text),
                   length = int.Parse(tbLength.Text),
                   weigth = int.Parse(tbWeigth.Text),
                  loadCap = int.Parse(tbLoadCap.Text),
                 cargoCap = int.Parse(tbCargoCap.Text),
              enginePower = int.Parse(tbEnginePwr.Text);

                var fuelType = temp.ToLower() switch
                {
                    "пар" => FuelType.steam,
                    "дизель" => FuelType.diesel,
                    "ядерное топливо" => FuelType.nuclearPower,
                    _ => default,
                };

                _cargoShipList.Add(new CargoShip(name, length, width, loadCap, cargoCap, enginePower, weigth, fuelType));
                ShowInfo(sender, e);
            }
            catch (Exception)
            {
                if (tbName.Text is "")
                {
                    tbName.BorderBrush = Brushes.Red;
                }

                for (int i = 0; i < list.Count; i++)
                {
                    if (int.TryParse(list[i].Text, out _))
                        list[i].BorderBrush = Brushes.Red;
                }
            }
        }

        private void BTNDeleteShip_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                textBoxNumber.BorderBrush = Brushes.Gray;

                int number = int.Parse(textBoxNumber.Text) - 1;
                _cargoShipList.Remove(_cargoShipList[number]);

                ShowInfo(sender, e);
            }
            catch (Exception)
            {
                textBoxNumber.BorderBrush = Brushes.Red;
                return;
            }
        }

        private void BTNdoCompare_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                tbFirstCPR.BorderBrush = Brushes.Gray;
                tbSecondCPR.BorderBrush = Brushes.Gray;

                int first = int.Parse(tbFirstCPR.Text) - 1,
                   second = int.Parse(tbSecondCPR.Text) - 1;

                if (_cargoShipList[first] > _cargoShipList[second])
                    tbInfo.Text += $"  >>>  Первый корабль имеет более высокую грузоподъёмность.\n\n";
                else if (_cargoShipList[first] < _cargoShipList[second])
                    tbInfo.Text += $"  >>>  Второй корабль имеет более высокую грузоподъёмность.\n\n";
                else
                    tbInfo.Text += $"  >>>  Корабли имеют одинаковую грузоподъёмность.\n\n";
            }
            catch (Exception)
            {
                if (!int.TryParse(tbFirstCPR.Text, out _))
                    tbFirstCPR.BorderBrush = Brushes.Red;
                if (!int.TryParse(tbSecondCPR.Text, out _))
                    tbSecondCPR.BorderBrush = Brushes.Red;

                return;
            }
        }

        private void ShowInfo(object sender, RoutedEventArgs e)
        {
            string fuelType = "пар";
            int number = 1;
            tbInfo.Text = string.Empty;
            
            foreach (var item in _cargoShipList)
            {
                if (item.FType == FuelType.nuclearPower)
                    fuelType = "ядерное топливо";
                else if (item.FType == FuelType.diesel)
                    fuelType = "дизель";

                tbInfo.Text += $"\n  >>>  Характеристики корабля №{number++}\n" +
                               $"{null,-7}Название - \"{item.Name}\", вес - {item.Weigth}\n" +
                               $"{null,-7}Длина - {item.Length}, ширина - {item.Width}\n" +
                               $"{null,-7}Грузовместимость - {item.CargoCapacity}, грузоподъёмность - {item.LoadCapacity}\n" +
                               $"{null,-7}Тип топлива - {fuelType}, мощность двигателя - {item.EnginePower}\n\n";
            }
        }
    }
}