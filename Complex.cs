using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPR
{
    public class Complex
    {
        private double re;
        private double im;

        public double Re { get => re; set => re = value; }
        public double Im { get => im; set => im = value; }

        public double Angle
        {

            get {
                if (re > 0) return Math.Atan(im / re);
                else if ((re < 0) && (im > 0)) return Math.Atan(im / re) + Math.PI;
                else return Math.Atan(im / re) - Math.PI;
                
            }
          
            }
        public double AngleGrad
        {
            get {
                if (re > 0) return Math.Atan(im / re) * 180 / Math.PI;
                else if ((re < 0) && (im > 0)) return (Math.Atan(im / re) + Math.PI) * 180 / Math.PI;
                else return (Math.Atan(im / re) - Math.PI) * 180 / Math.PI;
            }
           
            
    }
        public double Abs
        {
            get => Math.Pow((re * re + im * im),1.0/2);
        }

        /// <summary>
        /// Y=1/Z
        /// </summary>

        public Complex Obr

        {
            get => new Complex(Re/(Re*Re+Im*Im), -Im / (Re * Re + Im * Im));
        }

        /// <summary>
        /// Получение сопряженного
        /// </summary>
        public Complex Inverse
        {
            get => new Complex(Re, -Im);
        }
        /// <summary>
        /// Комплексное число
        /// </summary>
        /// <param name="r">Действительная часть</param>
        /// <param name="i">Мнимая часть</param>
        public Complex(double r, double i)
        {
            re = r;
            im = i;
        }



        public static Complex operator +(Complex a, Complex b)
        {
            return new Complex(a.Re + b.Re, a.Im + b.Im);
        }
        public static Complex operator *(Complex a, Complex b)
        {
            return new Complex(a.Re * b.Re - a.Im * b.Im, a.Re * b.Im + b.Re * a.Im);
        }
        public static Complex operator -(Complex a, Complex b)
        {
            return new Complex(a.Re - b.Re, a.Im - b.Im);
        }
        public static Complex operator /(Complex a, Complex b)
        {
            return new Complex((a.Re*b.Re+a.Im*b.Im)/(b.Re*b.Re+b.Im*b.Im), (a.Im*b.Re-a.Re*b.Im) / (b.Re * b.Re + b.Im * b.Im));
        }

        public override string ToString()
        {
            if (Im < 0)
            {
                return Math.Round(Re, 4).ToString() + " - j" + Math.Abs(Math.Round(Im, 4)).ToString();
            }
            return Math.Round(Re, 4).ToString() + " + j" + Math.Round(Im,4).ToString();
        } 


    }
}
