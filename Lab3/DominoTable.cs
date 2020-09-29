using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class DominoTable
    {
        int[][] table;
        int rows;
        bool[][] coverTable;
        List<Domino> dominos;
        public DominoTable(int[][] table, int n)
        {
            dominos = new List<Domino>();
            this.table = table;
            rows = n;

            for (int i = 0; i < 7; i++)
                for (int j = i; j < 7; j++)
                    dominos.Add(new Domino(i, j));
            coverTable = new bool[rows][];

            for (int i = 0; i < rows; i++)
            {
                coverTable[i] = new bool[rows];
                for (int j = 0; j < rows; j++)
                    coverTable[i][j] = false;
            }
        }



        public bool Cover()
        {
            bool result = true;
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < rows; j++)
                    result = result && (coverTable[i][j] || (CoverUp(i, j) || CoverDown(i, j) || CoverLeft(i, j) || CoverRight(i, j)));
            return result;
        }

        bool CoverUp(int row, int column)
        {
            if (coverTable[row][column])
                return true;
            if (row == 0 || coverTable[row - 1][column])
                return false;
          
            foreach(Domino domino in dominos)
            {
                if (domino.Cover(table[row][column], table[row - 1][column]))
                    coverTable[row][column] = coverTable[row - 1][column] = true;
            }
            if (coverTable[row][column])
            {
                if (!Cover())
                {
                    foreach (Domino domino in dominos)
                    {
                        domino.Uncover(table[row][column], table[row - 1][column]);
                    }
                    coverTable[row][column] = coverTable[row - 1][column] = false;
                }
            }

            return coverTable[row][column];

        }

        bool CoverDown(int row, int column)
        {
            if (coverTable[row][column])
                return true;
            if (row == rows-1 || coverTable[row + 1][column])
                return false;

            foreach (Domino domino in dominos)
            {
                if (domino.Cover(table[row][column], table[row + 1][column]))
                    coverTable[row][column] = coverTable[row + 1][column] = true;
            }

            if (coverTable[row][column])
            {
                if (!Cover())
                {
                    foreach (Domino domino in dominos)
                    {
                        domino.Uncover(table[row][column], table[row + 1][column]);
                    }
                    coverTable[row][column] = coverTable[row + 1][column] = false;
                }
            }

            return coverTable[row][column];
        }

        bool CoverLeft(int row, int column)
        {
            if (coverTable[row][column])
                return true;
            if (column == 0 || coverTable[row][column - 1])
                return false;

            foreach (Domino domino in dominos)
            {
                if (domino.Cover(table[row][column], table[row][column - 1]))
                    coverTable[row][column] = coverTable[row][column - 1] = true;
            }
            if (coverTable[row][column])
            {
                if (!Cover())
                {
                    foreach (Domino domino in dominos)
                    {
                        domino.Uncover(table[row][column], table[row][column - 1]);
                    }
                    coverTable[row][column] = coverTable[row][column - 1] = false;
                }
            }
            return coverTable[row][column];
        }

        bool CoverRight(int row, int column)
        {
            if (coverTable[row][column])
                return true;
            if (column ==rows-1 || coverTable[row][column + 1])
                return false;

            foreach (Domino domino in dominos)
            {
                if (domino.Cover(table[row][column], table[row][column + 1]))
                    coverTable[row][column] = coverTable[row][column + 1] = true;
            }
            if (coverTable[row][column])
            {
                if (!Cover())
                {
                    foreach (Domino domino in dominos)
                    {
                        domino.Uncover(table[row][column], table[row][column + 1]);
                    }
                    coverTable[row][column] = coverTable[row][column + 1] = false;
                }
            }

            return coverTable[row][column];
        }


    }
}
