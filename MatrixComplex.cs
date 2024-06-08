using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPR
{
    public class MatrixComplex
    {
        private Complex[,] _matrix;
        private int n, m;

        public Complex this[int i, int j] { get => _matrix[i, j]; set => _matrix[i, j] = value; }
        public Complex[,] Matrix { get => _matrix; set => _matrix = value; }
        public int N { get => n; }
        public int M { get => m; }

        
        public MatrixComplex(int _n, int _m)
        {
            n = _n;
            m = _m;
            _matrix = new Complex[n, m];
        }

        public Matrix Abs()
        {
            Matrix matr = new Matrix(n, m);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    matr[i, j] = this[i, j].Abs;
                }
            }
            return matr;
        }

        public MatrixComplex Inverse()
        {
            MatrixComplex mc = new MatrixComplex(n, m);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j< m; j++)
                {
                    mc[i, j] = this[i, j].Inverse;
                }
            }
            return mc;
        }

        /// <summary>
        /// Сложение матриц
        /// </summary>
        /// <param name="m1">Первая матрица</param>
        /// <param name="m2">Вторая матрица</param>
        /// <returns></returns>
        public static MatrixComplex operator +(MatrixComplex m1, MatrixComplex m2)
        {
            if (m1.N != m2.N || m1.M != m2.M)
            {
                throw new Exception("Размеры матрицы не совпадают");
            }
            MatrixComplex mr = new MatrixComplex(m1.N, m1.M);
            for (int i = 0; i < m1.N; i++)
            {
                for (int j = 0; j < m1.M; j++)
                {
                    mr[i, j] =  m1[i,j] + m2[i, j];
                }
            }
            return mr;
        }

        public static MatrixComplex operator -(MatrixComplex m1, MatrixComplex m2)
        {
            if (m1.N != m2.N || m1.M != m2.M)
            {
                throw new Exception("Размеры матрицы не совпадают");
            }
            MatrixComplex mr = new MatrixComplex(m1.N, m1.M);
            for (int i = 0; i < m1.N; i++)
            {
                for (int j = 0; j < m1.M; j++)
                {
                    mr[i, j] = m1[i, j] - m2[i, j];
                }
            }
            return mr;
        }




















        /// <summary>
        /// /////////////////кросовер   d учитывает шахматный порядок  (надо обратить внимание на базисный узел)
        /// </summary>
        /// <param name="mas"></param>
        /// <param name="masLength"></param>
        /// <param name="stobec1"></param>
        /// <param name="stobec2"></param>
        /// <returns></returns>

        public static MatrixComplex Cross(MatrixComplex mas, int masLength,int[] ind)
        {
            int d = 0;
            MatrixComplex mas_temp = new MatrixComplex(masLength, 10);
            for (int i = 0; i < masLength; i = i + 1)
            {
                mas_temp[i, 0] = mas[i, 0];
                mas_temp[i, 1] = mas[i, 1];


                if (d == 0)
                {

                    mas_temp[i, 2] = mas[i, 0];
                    mas_temp[i, 3] = mas[i, 2];

                }
                else
                {

                    mas_temp[i, 2] = mas[i, 2];
                    mas_temp[i, 3] = mas[i, 0];
                }

                if (d == 0)
                {

                    mas_temp[i, 4] = mas[i, 0];
                    mas_temp[i, 5] = mas[i, 3];

                }
                else
                {

                    mas_temp[i, 4] = mas[i, 3];
                    mas_temp[i, 5] = mas[i, 0];
                }
                if (d == 0)
                {

                    mas_temp[i, 6] = mas[i, 1];
                    mas_temp[i, 7] = mas[i, 2];

                }
                else
                {

                    mas_temp[i, 6] = mas[i, 2];
                    mas_temp[i, 7] = mas[i, 1];

                }

                if (d == 0)
                {

                    mas_temp[i, 8] = mas[i, 1];
                    mas_temp[i, 9] = mas[i, 3];
                    d = 1;
                }
                else
                {

                    mas_temp[i, 8] = mas[i, 3];
                    mas_temp[i, 9] = mas[i, 1];
                    d = 0;
                }
                    

            }
            for (int i = 0; i < masLength; i++)
            {
                if (ind[i] == 999)
                {
                    for (int j = 0; j < 10; j++)
                        mas_temp[i, j] = mas[i, 0];
                }
            }

            return mas_temp;
        }

/// <summary>
/// /////// вычистение матрицы приспособленности/////////////
/// </summary>
/// <param name="mas"></param>
/// <param name="masLength"></param>
/// <param name="stobec1"></param>
/// <param name="stobec2"></param>
/// <returns></returns>

        public static Matrix SDMCount( int CountHR , MatrixComplex HR, int k, MatrixComplex Y,MatrixComplex S, MatrixComplex S1)
        {
            Matrix sdm_temp = new Matrix(CountHR, 2);
            for (int i = 0; i < CountHR; i++)
            {
                sdm_temp[i, 0] = 0;
            }
            for (int q = 0; q < CountHR; q++)
            {

                MatrixComplex HRindD = new MatrixComplex(k, k);
                for (int i = 0; i < k; i++)
                {
                    for (int j = 0; j < k; j++)
                    {
                        HRindD[i, j] = new Complex(0, 0);
                    }
                }
                MatrixComplex HRind = new MatrixComplex(k, 1);
                MatrixComplex SP = new MatrixComplex(k, 1);
                MatrixComplex S3 = new MatrixComplex(k, 1);

                for (int i = 0; i < k; i++)
                {

                    HRind[i, 0] = HR[i, q].Inverse;
                    HRindD[i, i] = HR[i, q];

                }
                S3 = HRindD * Y.Inverse() * HRind;
                SP = S1 + S3 + S;

                for (int i = 0; i < k; i++)
                {
                    sdm_temp[q, 0] = sdm_temp[q, 0] + Convert.ToDouble(SP[i, 0].Abs);
                }
                sdm_temp[q, 1] = q;
            }
            return sdm_temp;
        }


        /// <summary>
        /// /////мутация пока с базисным
        /// </summary>
        /// <param name="HR"></param>
        /// <param name="k"></param>
        /// <param name="veroyatnost"></param>
        /// <param name="velichina"></param>
        /// <returns></returns>


        public static MatrixComplex Mutation(MatrixComplex HR, int k, double veroyatnost, double velichinaModul, double velichinaGrad, int[] ind)
        {
            Random rndM = new Random();
            Random rndv = new Random();
           double ddd = 0;

            double sluch = new double();
            for (int i = 0; i < k; i++)
            {
                for (int j = 2; j < 10; j++)
                {
                    if (ind[i] == 999) sluch = 1;
                    else sluch = rndM.NextDouble();
                    if (sluch < veroyatnost)
                    {


                        ddd = Convert.ToDouble(rndv.Next(-(int)(velichinaModul * 10000), (int)(velichinaModul * 10000))) / 10000;
                                 
                        HR[i, j] = new Complex(((HR[i, j].Abs + ddd) * Math.Cos(HR[i, j].AngleGrad * Math.PI / 180)), ((HR[i, j].Abs + ddd) * Math.Sin(HR[i, j].AngleGrad * Math.PI / 180)));
                    }
                    else
                        HR[i, j] = HR[i, j];


                    if (ind[i] == 999) sluch = 1;
                    else sluch = rndM.NextDouble();
                    if (sluch < veroyatnost)
                    {
                        ddd = Convert.ToDouble(rndv.Next(-(int)(velichinaGrad * 10000), (int)(velichinaGrad * 10000))) / 10000;
                        HR[i, j] = new Complex(HR[i, j].Abs * Math.Cos((HR[i, j].AngleGrad + ddd) * Math.PI / 180), HR[i, j].Abs * Math.Sin((HR[i, j].AngleGrad + ddd) * Math.PI / 180));
                    }
                    else
                        HR[i, j] = HR[i, j];


                }
            }       
            return HR;
        }










        /// <summary>
        /// Умножение матриц
        /// </summary>
        /// <param name="m1">Первая матрица</param>
        /// <param name="m2">Вторая матрица</param>
        /// <returns></returns>
        public static MatrixComplex operator *(MatrixComplex m1, MatrixComplex m2)
        {
            if (m1.M != m2.N)
            {
                throw new Exception("Матрицы должна быть внутренне согласованными");
            }
            MatrixComplex nm = new MatrixComplex(m1.N, m2.M);                 //Инициализируем новую матрицу
            for (int i = 0; i < m1.N; i++)
            {
                for (int j = 0; j < m2.M; j++)
                {
                    Complex elem = new Complex(0,0);
                    for (int k = 0; k < m2.N; k++)
                    {
                        elem += m1[i, k] * m2[k, j];
                    }
                    nm[i, j] = elem;
                }
            }
            return nm;
        }

       
    }
}
