﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsForm
{
    public class OperacionesMatrices
    {
        public static double[,] InicializarMatriz(int filas, int columnas)
        {
            Random random = new Random();

            double[,] matriz = new double[filas, columnas];

            for (int i = 0; i < filas; i++)
            {
                for (int j = 0; j < columnas; j++)
                {
                    matriz[i, j] = random.Next(100);
                }
            }

            return matriz;
        }

        public static void MultiplicarMatricesSecuencial(double[,] matA, double[,] matB, double[,] resultado)
        {
            int matACols = matA.GetLength(1);
            int matBCols = matB.GetLength(1);
            int matARows = matA.GetLength(0);

            for (int i = 0; i < matARows; i++)
            {
                for (int j = 0; j < matBCols; j++)
                {
                    double temp = 0;
                    for (int k = 0; k < matACols; k++)
                    {
                        temp += matA[i, k] * matB[k, j];
                    }

                    resultado[i, j] += temp;
                }
            }
        }

        public static void MultiplicarMatricesParalelo(double[,] matA, double[,] matB, double[,] resultado)
        {
            int matACols = matA.GetLength(1);
            int matBCols = matB.GetLength(1);
            int matARows = matA.GetLength(0);

            Parallel.For(0, matARows, i =>
            {
                for (int j = 0; j < matBCols; j++)
                {
                    double temp = 0;
                    for (int k = 0; k < matACols; k++)
                    {
                        temp += matA[i, k] * matB[k, j];
                    }

                    resultado[i, j] += temp;
                }
            });
        }
    }
}
