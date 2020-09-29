using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3
{
    public partial class Form1 : Form
    {
        int n = 6;
        public Form1()
        {
            InitializeComponent();
            dataGridView1.RowCount = n;
            dataGridView1.ColumnCount = n;
        }

        private void установитьРазмерМатрицыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetMatrixSize setMatrixSize = new SetMatrixSize();
            setMatrixSize.ShowDialog();
            if (setMatrixSize.DialogResult == DialogResult.OK)
                n = setMatrixSize.trackBar1.Value*2;
            dataGridView1.RowCount = n;
            dataGridView1.ColumnCount = n;
        }

        private void рассчитатьВозможностьЗамощенияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int[][] matrix = new int[n][];
            for (int i = 0; i < n; i++)
                matrix[i] = new int[n];

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    if (dataGridView1[j, i] == null)
                        matrix[i][j] = 0;
                    else
                        matrix[i][j] = dataGridView1[j, i].Value == null?0:int.Parse(dataGridView1[j,i].Value.ToString());
                }

            DominoTable dominoTable = new DominoTable(matrix, n);
            bool result = dominoTable.Cover();
            MessageBox.Show(result.ToString());
        }
    }
}
