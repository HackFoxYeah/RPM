using System;
using System.Collections.Generic;
using System.Data;

namespace Пример_таблицы_WPF;

static class VisualArray
{
    /// <summary>
    /// Реализует визуализацию даннных на DataGrid из передаваемого списка структуры PcInfo.
    /// </summary>
    /// <param name="pcList">Список содержащий экземпляры структуры PcInfo.</param>
    /// <returns>Представление таблицы.</returns>
    public static DataTable ToDataTable(this List<Int32> list)
    {
        DataTable tempDataGrid = new();
        const int GridLength = 26;

        for (int i = 0; i < GridLength; i++)
        {
            tempDataGrid.Columns.Add("#" + (i + 1), typeof(int));
        }

        DataRow row = tempDataGrid.NewRow();

        for (int i = 0, j = 0; i < list.Count; i++, j++)
        {
            if (i % GridLength == 0 && i != 0)
            {
                tempDataGrid.Rows.Add(row);
                row = tempDataGrid.NewRow();
                j = 0;
                row[j] = list[i];
            }
            else
                row[j] = list[i];
        }

        tempDataGrid.Rows.Add(row);

        return tempDataGrid;
    }
}