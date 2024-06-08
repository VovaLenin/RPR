using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace RPR
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

    
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.RowCount = dataGridView1.RowCount + 1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView2.RowCount = dataGridView2.RowCount + 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount>= 1)
            {
                dataGridView1.RowCount = dataGridView1.RowCount - 1;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView2.RowCount >= 1)
            {
                dataGridView2.RowCount = dataGridView2.RowCount - 1;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовый документ (*.txt)|*.txt|Все файлы (*.*)|*.*";
          
                      
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(saveFileDialog.FileName, false, Encoding.Unicode);
                try
                {
                    List<int> col_n = new List<int>();
                    foreach (DataGridViewColumn col in dataGridView1.Columns)
                        if (col.Visible)
                        {
                            //sw.Write(col.HeaderText + "\t");
                            col_n.Add(col.Index);
                        }
                    //sw.WriteLine();
                    int x = dataGridView1.RowCount;
                    if (dataGridView1.AllowUserToAddRows) x--;

                    for (int i = 0; i < x; i++)
                    {
                        for (int y = 0; y < col_n.Count; y++)
                            sw.Write(dataGridView1[col_n[y], i].Value + ";");
                        sw.Write(" \r\n");
                    }
                          
                    sw.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                }

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовый документ (*.txt)|*.txt|Все файлы (*.*)|*.*";


            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(saveFileDialog.FileName, false, Encoding.Unicode);
                try
                {
                    List<int> col_n = new List<int>();
                    foreach (DataGridViewColumn col in dataGridView2.Columns)
                        if (col.Visible)
                        {
                            //sw.Write(col.HeaderText + "\t");
                            col_n.Add(col.Index);
                        }
                    //sw.WriteLine();
                    int x = dataGridView2.RowCount;
                    if (dataGridView2.AllowUserToAddRows) x--;

                    for (int i = 0; i < x; i++)
                    {
                        for (int y = 0; y < col_n.Count; y++)
                            sw.Write(dataGridView2[col_n[y], i].Value + ";");
                        sw.Write(" \r\n");
                    }

                    sw.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                }

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

            dataGridView1.Rows.Clear();

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовый документ (*.txt)|*.txt|Все файлы (*.*)|*.*";

            openFileDialog.ShowDialog();
            string[] data = File.ReadAllLines(openFileDialog.FileName);

            for (int i = 0; i < data.Length; i++)
            {
                dataGridView1.Rows.Add(data[i].Split(';'));
            }

        }

        private void button8_Click(object sender, EventArgs e)
        {

            dataGridView2.Rows.Clear();

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовый документ (*.txt)|*.txt|Все файлы (*.*)|*.*";

            openFileDialog.ShowDialog();
            string[] data = File.ReadAllLines(openFileDialog.FileName);

            for (int i = 0; i < data.Length; i++)
            {
                dataGridView2.Rows.Add(data[i].Split(';'));
            }

        }

        private void button9_Click(object sender, EventArgs e)
        {
            int NU = dataGridView1.RowCount;
            int NV = dataGridView2.RowCount;
            int[] Uzli;
            Uzli = new int[NU];
            for (int i=0; i<NU; ++i)
            {
                Uzli[i] = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value);
            }
            int[] NN;
            NN = new int[NV];
            int[] NK;
            NK = new int[NV];

            for (int i=0; i<NV; ++i)
            {
                NN[i] = Convert.ToInt32(dataGridView2.Rows[i].Cells[1].Value);
                NK[i] = Convert.ToInt32(dataGridView2.Rows[i].Cells[2].Value);
            }
            int k = NN[0];
            int kp = -1;
            
            for (int i=0; i<NV; ++i)
            {
                if (NN[i]==k)
                {
                    kp = NK[i];
                }

                if (NK[i] == k)
                {
                    kp = NN[i];
                }

                int m = 0;
                for (int l=0; l<NU;++l)
                {
                    if (kp==Uzli[l])
                    {
                        m = 1;
                    }
                }

                if (m != 0)
                {
                    for (int j = 0; j < NV; ++j)
                    {
                        if (NN[j] == kp)
                        {
                            NN[j] = k;
                        }
                        if (NK[j] == kp)
                        {
                            NK[j] = k;
                        }
                    }
                    for (int d = 0; d < NU; ++d)
                    {
                        if (Uzli[d] == kp)
                        {
                            Uzli[d] = k;
                        }
                    }

                }
            }

            int priznak = 0;
            for (int i = 0; i < NV; ++i)
            {
                if (NN[i] != k)
                {
                    priznak = 1;
                }
                if (NK[i] != k)
                {
                    priznak = 1;
                }
            }

            for (int i=0; i<NU; ++i)
            {
                if (Uzli[i]!= k)
                {
                    priznak = 2;
                }
            }

            if (priznak==0)
            {
                label3.Text = "Сеть связна";
                label3.ForeColor = Color.Green;
            }
            if (priznak == 1)
            {
                label3.Text = "Сеть несвязна. В сети есть висячие ветви";
                label3.ForeColor = Color.Red;
            }
            if (priznak == 2)
            {
                label3.Text = "Сеть несвязна. В сети есть висячие узлы";
                label3.ForeColor = Color.Red;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            
            // формирование матрицы проводимостей из нулевых значений
            int NU = dataGridView1.RowCount;

            for (int i =0; i < NU; ++i)
            {
                for (int j=0; j < NU; ++j)
                {
                    Global.Y[i, j] = new Complex(0, 0);
                }
            }
            // учет параметров узлов в диагональных элементах матрицы проводимостей
            for (int i=0; i<NU;++i)
            {
                Complex YU = new Complex(Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value) * 0.000001, Convert.ToDouble(dataGridView1.Rows[i].Cells[5].Value)*0.000001);
                Global.Y[i, i] = Global.Y[i, i] + YU;
            }
            // учет параметров ветвей в диагональных и недиагональных элементах матрицы проводимостей
            for (int i=0;i< dataGridView2.RowCount; ++i)
            {
                Complex ZV = new Complex(Convert.ToDouble(dataGridView2.Rows[i].Cells[3].Value), Convert.ToDouble(dataGridView2.Rows[i].Cells[4].Value) );
                Complex kt = new Complex(Convert.ToDouble(dataGridView2.Rows[i].Cells[5].Value),0);
                int NN = Convert.ToInt16(dataGridView2.Rows[i].Cells[1].Value)-1;
                int NK = Convert.ToInt16(dataGridView2.Rows[i].Cells[2].Value)-1;

                //учет сопротивления ветвей в диагональных элементах матрицы проводимостей
                Global.Y[NN, NN] = Global.Y[NN,NN] + ZV.Obr;
                Global.Y[NK, NK] = Global.Y[NK, NK] + kt * kt * ZV.Obr;
                //учет сопротивления ветвей в недиагональных элементах матрицы проводимостей

                Global.Y[NN, NK] = Global.Y[NN, NK] - kt * ZV.Obr;
                Global.Y[NK, NN] = Global.Y[NK, NN] - kt * ZV.Obr;

            }

            // вывод матрицы проводимостей
            dataGridView3.RowCount = NU;
            dataGridView3.ColumnCount = NU;
            for (int i = 0; i < NU; ++i)
            {
                for (int j = 0; j < NU; ++j)
                {
                    dataGridView3.Rows[i].Cells[j].Value = Global.Y[i, j].Re.ToString("0.###") + "+ j(" + Global.Y[i, j].Im.ToString("0.###")+")";
                }
            }
            // формирование матрицы сопротивлений
            if (checkBox1.Checked)
            {
                MatrixComplex Y1 = new MatrixComplex(NU, NU);
                for (int i = 0; i < NU; ++i)
                {
                    for (int j = 0; j < NU; ++j)
                    {
                       Y1[i, j] = Global.Y[i, j];
                    }
                }

                Complex  ONE = new Complex(-1, 0);
                for (int k = 0; k<NU; ++k)
                {
                    for (int i = 0; i<NU; ++i)
                    {
                        for(int j =0; j<NU; ++j)
                        {
                            if ((i==k)&(j==k))
                            {
                                Global.Z[i, j] = Y1[i, j].Obr;
                            }

                            if ((i == k) & (j != k))
                            {
                                Global.Z[i, j] =  ONE* Y1[i, j]* Y1[k, k].Obr;
                            }

                            if ((i != k) & (j == k))
                            {
                                Global.Z[i, j] = Y1[i, k] * Y1[k, k].Obr;
                            }
                            if ((i != k) & (j != k))
                            {
                                Global.Z[i, j] = Y1[i, j] - (Y1[k,j]* Y1[i,k])* Y1[k,k].Obr;
                            }
                        }                       
                    }
                    for (int i = 0; i < NU; ++i)
                    {
                        for (int j = 0; j < NU; ++j)
                        {
                            Y1[i, j] = Global.Z[i, j];
                        }
                    }
                }
                dataGridView5.RowCount = NU;
                dataGridView5.ColumnCount = NU;
                for (int i = 0; i < NU; ++i)
                {
                    for (int j = 0; j < NU; ++j)
                    {
                        dataGridView5.Rows[i].Cells[j].Value = Y1[i, j].Re.ToString("0.###") + "+ j(" + Y1[i, j].Im.ToString("0.###") + ")";
                    }
                }

            }

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            dataGridView4.RowCount = 2;
            dataGridView4.ColumnCount = 1;
            int index_VE = 1;
            int index_PID = 1;
            int index_0 = 0;
            for (int i=0; i<dataGridView3.RowCount; ++i)
            {
                
                for (int j=0; j<=i; ++j)
                {
                    if (dataGridView3.Rows[i].Cells[j].Value.ToString() != "0+ j(0)")
                    {
                        dataGridView4.Rows[0].Cells[index_VE - 1].Value = dataGridView3.Rows[i].Cells[j].Value;
                        ++index_VE;
                        ++dataGridView4.ColumnCount;
                        index_0 = 1;
                    }
                    else if ((dataGridView3.Rows[i].Cells[j].Value.ToString() == "0+ j(0)") & (index_0 == 1 ))
                    {
                        dataGridView4.Rows[0].Cells[index_VE - 1].Value = dataGridView3.Rows[i].Cells[j].Value;
                        ++index_VE;
                        ++dataGridView4.ColumnCount;
                    }
                }
                dataGridView4.Rows[1].Cells[index_PID - 1].Value = (index_VE-1).ToString();
                ++index_PID;
                index_0 = 0;

            }

        }

        private void button12_Click(object sender, EventArgs e)
        {
            dataGridView4.RowCount = 1;
            dataGridView4.ColumnCount = 1;
            int index_VE = 1;
            for (int j = 0; j < dataGridView3.RowCount; ++j)
            {
                dataGridView4.Rows[0].Cells[index_VE - 1].Value = (0).ToString();
                ++dataGridView4.ColumnCount;
                dataGridView4.Rows[0].Cells[index_VE].Value = (j+1).ToString();
                ++dataGridView4.ColumnCount;
                index_VE = index_VE + 2;

                for (int i = 0; i < dataGridView3.RowCount; ++i)
                {
                    if (dataGridView3.Rows[i].Cells[j].Value.ToString() != "0+ j(0)")
                    {
                        dataGridView4.Rows[0].Cells[index_VE-1 ].Value = (i+1).ToString();
                        ++dataGridView4.ColumnCount;
                        dataGridView4.Rows[0].Cells[index_VE].Value = dataGridView3.Rows[i].Cells[j].Value;
                        ++dataGridView4.ColumnCount;
                        index_VE = index_VE + 2;

                    }
                }
            }
            dataGridView4.Rows[0].Cells[index_VE - 1].Value = 0.ToString();
            ++dataGridView4.ColumnCount;
            dataGridView4.Rows[0].Cells[index_VE].Value = 0.ToString();
            ++dataGridView4.ColumnCount;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            dataGridView4.RowCount = 3;
            dataGridView4.ColumnCount = 1;
            int index_VE = 1;
            int index_CIP = 1;
            for (int j = 0; j < dataGridView3.RowCount; ++j)
            {
                dataGridView4.Rows[2].Cells[index_CIP - 1].Value = (index_VE).ToString();
                ++index_CIP;

                for (int i = 0; i < dataGridView3.RowCount; ++i)
                {
                    if (dataGridView3.Rows[i].Cells[j].Value.ToString() != "0+ j(0)")
                    {
                        dataGridView4.Rows[0].Cells[index_VE - 1].Value = dataGridView3.Rows[i].Cells[j].Value;
                        dataGridView4.Rows[1].Cells[index_VE - 1].Value = (i+1).ToString();
                        ++index_VE;
                        ++dataGridView4.ColumnCount;
                    }                                 
                }
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            dataGridView4.RowCount = 2;
            dataGridView4.ColumnCount = 1;
            int index_VE = 1;
            int n = dataGridView3.RowCount;
            for (int j = 0; j < dataGridView3.RowCount; ++j)
            {
                for (int i = 0; i < dataGridView3.RowCount; ++i)
                {
                    if (dataGridView3.Rows[i].Cells[j].Value.ToString() != "0+ j(0)")
                    {
                        dataGridView4.Rows[0].Cells[index_VE - 1].Value = dataGridView3.Rows[i].Cells[j].Value;
                        dataGridView4.Rows[1].Cells[index_VE - 1].Value = ((i+1)+ j*n).ToString();
                        ++index_VE;
                        ++dataGridView4.ColumnCount;
                    }
                }
            }
        }

        private void dataGridView6_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {
            int NU = dataGridView1.RowCount;
            MatrixComplex U = new MatrixComplex(NU,1);
            MatrixComplex U_new = new MatrixComplex(NU,1);
            MatrixComplex S = new MatrixComplex(NU, 1);
            MatrixComplex kt = new MatrixComplex(dataGridView2.RowCount,1);
            for (int i = 0; i < NU; ++i)
            {
                 U[i, 0] = new Complex(Convert.ToDouble(dataGridView1.Rows[i].Cells[1].Value), 0);
                 S[i, 0] = new Complex(Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value), Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value));
            }
            U_new[0, 0] = U[0, 0];
            double err = Convert.ToDouble(textBox1.Text);
            int limit_iter = Convert.ToInt16(textBox2.Text);
            
            for (int i = 0; i< dataGridView2.RowCount; ++i)
            {
                int NUK = Convert.ToInt16(dataGridView2.Rows[i].Cells[2].Value);
                kt[NUK-1, 0] = new Complex(Convert.ToInt16(dataGridView2.Rows[i].Cells[5].Value),0);
            }
                     
            // начало итерационного процесса

            int iter = 0; //кол-во итераций
            double[] eps = new double[NU];
            int eps_marker = 0;
            do
            {
                for (int i=1; i<NU; ++i)
                {
                    U_new[i,0] = U[0,0] / kt[i,0];
                    Complex ZP = new Complex(0, 0);
                    Complex U_PR = new Complex(0, 0);
                    for (int j = 0; j < NU; ++j)
                    {
                        if (j < i)
                        {
                            U_PR =  U_new[j, 0].Inverse;
                        }
                        else
                        {
                            U_PR =  U[j, 0].Inverse;
                        }
                        ZP = ZP + (Global.Z[i, j] * S[j,0 ] / U_PR);
                    }
                    U_new[i, 0] = U_new[i, 0] - ZP;

                }

               eps_marker = 0;
               for (int i=1; i< NU; ++i)
                {
                    double a = U[i, 0].Abs;
                    double b = U_new[i, 0].Abs;
                    eps[i] = Math.Abs(a - b);
                    if (eps[i]> err)
                    {
                        eps_marker = 1;
                    }
                } 

               if (eps_marker == 1)
                {
                   for (int i = 0; i < NU; ++i)
                    {
                        U[i, 0] = U_new[i, 0];
                    }
                }

                ++iter;
            } while ((eps_marker!=0)^(iter>limit_iter));

            dataGridView6.RowCount = NU;
            for (int i = 0; i < NU; ++i)
            {
                dataGridView6.Rows[i].Cells[0].Value = i.ToString();
                dataGridView6.Rows[i].Cells[1].Value = U_new[i, 0].ToString();
                dataGridView6.Rows[i].Cells[2].Value = eps[i].ToString();
            }
            label9.Text = iter.ToString();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {
            int NU = dataGridView1.RowCount;
            MatrixComplex U = new MatrixComplex(NU, 1);
            MatrixComplex U_new = new MatrixComplex(NU, 1);
            MatrixComplex S = new MatrixComplex(NU, 1);
            MatrixComplex kt = new MatrixComplex(dataGridView2.RowCount, 1);
            for (int i = 0; i < NU; ++i)
            {
                U[i, 0] = new Complex(Convert.ToDouble(dataGridView1.Rows[i].Cells[1].Value), 0);
                S[i, 0] = new Complex(Convert.ToDouble(dataGridView1.Rows[i].Cells[2].Value), Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value));
            }
            U_new[0, 0] = U[0, 0];
            double err = Convert.ToDouble(textBox4.Text);
            int limit_iter = Convert.ToInt16(textBox3.Text);

            for (int i = 0; i < dataGridView2.RowCount; ++i)
            {
                int NUK = Convert.ToInt16(dataGridView2.Rows[i].Cells[2].Value);
                kt[NUK - 1, 0] = new Complex(Convert.ToInt16(dataGridView2.Rows[i].Cells[5].Value), 0);
            }

            MatrixComplex W = new MatrixComplex(NU, 1);
            MatrixComplex DU = new MatrixComplex(NU, 1);
            MatrixComplex DW = new MatrixComplex(NU, NU);
            MatrixComplex DWOBR = new MatrixComplex(NU, NU);
            //заполняем матрицы нулевыми значениями
            for (int i=0; i < NU; ++i)
            {
                W[i, 0] = new Complex(0, 0);
                DU[i, 0] = new Complex(0, 0);
                for (int  j=0; j<NU; ++j)
                {
                    DW[i, j] = new Complex(0, 0);
                    DWOBR[i, j] = new Complex(0, 0);
                }
            }


            for (int i=1; i<NU; ++i)
            {
                for (int j = 1; j < NU; ++j)
                {
                    DW[i, j] = Global.Y[i, j];
                }
            }

            // метод Ньютона

            // произведение напряжения базисного узла и суммы проводимостей
            Complex U1Y = new Complex(0, 0);
            for (int i=0; i<NU; ++i)
            {
                U1Y = U1Y + Global.Y[0, i];
            }
            U1Y = U[0, 0] * U1Y;



            // начало итерационного процесса
            int iter = 0; //кол-во итераций
            double[] eps = new double[NU];
            int eps_marker = 0;
            do
            {

                //формирование матрицы небалансов токов

                for (int i = 1; i < NU; ++i)
                {
                    W[i, 0] = new Complex(0, 0);
                    for (int j = 0; j < NU; ++j)
                    {
                        W[i, 0] = W[i, 0] + Global.Y[i, j] * U[j, 0];
                    }
                    W[i, 0] = W[i, 0] - S[i, 0] / U[i, 0];
                    W[i, 0] = W[i, 0]-  U1Y;
                }

                // формирование матрицы Якоби
                for (int i = 1; i < NU; ++i)
                {
                    DW[i, i] = DW[i, i] + S[i, 0] / (U[i, 0] * U[i, 0]);
                }


                // обращение матрицы Якоби
                Complex ONE = new Complex(-1, 0);
                for (int k = 1; k < NU; ++k)
                {
                    for (int i = 1; i < NU; ++i)
                    {
                        for (int j = 1; j < NU; ++j)
                        {
                            if ((i == k) & (j == k))
                            {
                                DWOBR[i, j] = DW[i, j].Obr;
                            }

                            if ((i == k) & (j != k))
                            {
                                DWOBR[i, j] = ONE * DW[i, j] * DW[k, k].Obr;
                            }

                            if ((i != k) & (j == k))
                            {
                                DWOBR[i, j] = DW[i, k] * DW[k, k].Obr;
                            }
                            if ((i != k) & (j != k))
                            {
                                DWOBR[i, j] = DW[i, j] - (DW[k, j] * DW[i, k]) * DW[k, k].Obr;
                            }
                        }
                    }
                    for (int i = 1; i < NU; ++i)
                    {
                        for (int j = 1; j < NU; ++j)
                        {
                            DW[i, j] = DWOBR[i, j];
                        }
                    }
                }

                // Обределяем небаланс напряжений
                DU = DW * W;
                U_new = U - DU;



                // проверка погрешности и лимита итераций
                eps_marker = 0;
                for (int i = 1; i < NU; ++i)
                {
                    eps[i] = DU[i,0].Abs;
                    if (eps[i] > err)
                    {
                        eps_marker = 1;
                    }
                }

                if (eps_marker == 1)
                {
                    for (int i = 0; i < NU; ++i)
                    {
                        U[i, 0] = U_new[i, 0];
                    }
                }

                ++iter;


            } while ((eps_marker != 0) ^ (iter > limit_iter));
            
            dataGridView7.RowCount = NU;
            for (int i = 0; i < NU; ++i)
            {
                dataGridView7.Rows[i].Cells[0].Value = i.ToString();
                dataGridView7.Rows[i].Cells[1].Value = U_new[i, 0].ToString();
                dataGridView7.Rows[i].Cells[2].Value = eps[i].ToString();
            }
            label12.Text = iter.ToString();






        }
    }
}
