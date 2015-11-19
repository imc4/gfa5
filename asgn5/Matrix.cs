using System;
using System.Collections.Generic;
using System.Text;

namespace asgn5v1
{
    /// <summary>
    /// Matrix definitions/helpers for transformations
    /// - multiply 2 matrices together
    /// - translate in x/y/z
    /// - reflect in x/y/z
    /// - scale in x/y/z
    /// - rotate by radians
    /// - shear by amount
    /// </summary>
    class Matrix
    {
        /// <summary>
        /// Multiplies two matrixes together
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static double[,] multiply(double[,] left, double[,] right)
        {
            double temp;
            double[,] result =
            {
                { 0, 0, 0, 0 },
                { 0, 0, 0, 0 },
                { 0, 0, 0, 0 },
                { 0, 0, 0, 0 }
            };

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    temp = 0.0d;
                    for (int k = 0; k < 4; k++)
                    {
                        temp += left[i, k] * right[k, j];
                    }
                    result[i, j] = temp;
                }
            }

            return result;
        }
        /// <summary>
        /// translates matrix in x, y, or z direction
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <returns></returns>                             
        public static double[,] translate(double x = 0, double y = 0, double z = 0)
        {
            double[,] matrix =
            {
                { 1, 0, 0, 0 },
                { 0, 1, 0, 0 },
                { 0, 0, 1, 0 },
                { x, y, z, 1 }
            };

            return matrix;
        }

        /// <summary>
        /// reflects over specified axis
        /// x, y, or z should be either 1 or -1
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        public static double[,] reflect(double x = 1, double y = 1, double z = 1)
        {
            double[,] matrix =
            {
                { x, 0, 0, 0 },
                { 0, y, 0, 0 },
                { 0, 0, z, 0 },
                { 0, 0, 0, 1 }
            };

            return matrix;
        }

        /// <summary>
        /// scales in x, y, or z
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        public static double[,] scale(double x = 1, double y = 1, double z = 1)
        {
            double[,] matrix =
            {
                { x, 0, 0, 0 },
                { 0, y, 0, 0 },
                { 0, 0, z, 0 },
                { 0, 0, 0, 1 }
            };

            return matrix;
        }

        /// <summary>
        /// Rotates by user specified radians
        /// </summary>
        /// <param name="type">Rotate axis direction</param>
        /// <param name="rad">Rotate by radian amount</param>
        /// <returns></returns>
        public static double[,] rotate(char type, double rad = .05)
        {
            double[,] matrix =
            {
                { 1, 0, 0, 0 },
                { 0, 1, 0, 0 },
                { 0, 0, 1, 0 },
                { 0, 0, 0, 1 }
            };

            switch (type)
            {
                case 'x':
                    double[,] tempx = 
                    {
                        { 1, 0, 0, 0 },
                        { 0, Math.Cos(rad), -Math.Sin(rad), 0 },
                        { 0, Math.Sin(rad), Math.Cos(rad), 0 },
                        { 0, 0, 0, 1 }
                    };
                    matrix = tempx;
                    break;

                case 'y':
                    double[,] tempy = 
                    {
                        { Math.Cos(rad), 0, Math.Sin(rad), 0 },
                        { 0, 1, 0, 0 },
                        { -Math.Sin(rad), 0, Math.Cos(rad), 0 },
                        { 0, 0, 0, 1 }
                    };
                    matrix = tempy;
                    break;

                case 'z':
                    double[,] tempz = 
                    {
                        { Math.Cos(rad), Math.Sin(rad), 0, 0 },
                        { -Math.Sin(rad), Math.Cos(rad), 0, 0 },
                        { 0, 0, 1, 0 },
                        { 0, 0, 0, 1 }
                    };
                    matrix = tempz;
                    break;
            }
            
            return matrix;
        }

        /// <summary>
        /// Shears on x with respect to y by the amount specified
        /// </summary>
        /// <param name="amount">percentage of shear</param>
        /// <returns></returns>
        public static double[,] shear(double amount = 0)
        {
            double[,] matrix =
            {
                { 1, 0, 0, 0 },
                { amount, 1, 0, 0 },
                { 0, 0, 1, 0 },
                { 0, 0, 0, 1 }
            };          

            return matrix;
        }
    }    
}
