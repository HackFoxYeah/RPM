using System;
using System.Collections.Generic;
using System.Windows;
using Пример_таблицы_WPF;

namespace practicalWorkdNo10;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    List<int> list = new List<int>();

    private void btCT_Click(object sender, RoutedEventArgs e)
    {
        const int MaxNumberOfCells = 312;
        list = new List<int>();

        try
        {
            int min = int.Parse(tbMin.Text),
                max = int.Parse(tbMax.Text),
                ae = int.Parse(tbAE.Text);

            if (ae > MaxNumberOfCells)
            {
                MessageBox.Show("Максимальное количество ячеек (чисел) - 312!", "Внимание!");
                return;
            }
                

            Random rnd = new();

            for (int i = 0; i < ae; i++)
            {
                list.Add(rnd.Next(min, max));
            }

            dataGrid.ItemsSource = list.ToDataTable().DefaultView;
        }
        catch (Exception ex)
        {
            MessageBox.Show("Ошибка: \n" + ex.Message, "Внимание!");
            return;
        }
    }
    
    private void btDBS_Click(object sender, RoutedEventArgs e)
    {
        int sum = 0,
            taskNum = 7;

        for (int i = 0; i < list.Count; i++)
        {
            if (list[i] % taskNum == 0)
            {
                sum += list[i];
            }
        }

        tbRes.Text = sum.ToString();
    }
}