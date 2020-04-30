using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prac7
{
    public partial class NazarovPrac : Form
    {
        public NazarovPrac()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            double a = Convert.ToDouble(txtA.Text);
            double b = Convert.ToDouble(txtB.Text);
            double h = Convert.ToDouble(txtH.Text);
            double x = a;
            txtOtv.Text += "При a = " + txtA.Text + Environment.NewLine;
            txtOtv.Text += "При b= " + txtB.Text + Environment.NewLine;

            txtOtv.Text += "При  шаге h = " + txtH.Text + Environment.NewLine;
            Otvet(a, b, h, x);
        }
        void Otvet(double a, double b, double h, double x)
        {
            while (x == a)
            {
                double i = Math.Sin(x / 4);
                double k = i / 2;
                double fx = k + 1;
                txtOtv.Text += "x =" + Convert.ToString(x) + ";fx =" + Convert.ToString(fx) + Environment.NewLine;
                x = x + h;
            }
            while (x < a)
            {
                double i = Math.Sin(x / 4);
                double k = i / 2;
                double fx = k + 1;
                txtOtv.Text += "x =" + Convert.ToString(x) + ";fx =" + Convert.ToString(fx) + Environment.NewLine;
                x = x + h;
            }
            while (x < b)
            {
                double i = Math.Sin(x / 4);
                double k = i / 2;
                double fx = k + 1;
                txtOtv.Text += "x =" + Convert.ToString(x) + ";fx =" + Convert.ToString(fx) + Environment.NewLine;
                x = x + h;
            }
            while (x == b)
            {
                double i = Math.Sin(x / 4);
                double k = i / 2;
                double fx = k + 1;
                txtOtv.Text += "x =" + Convert.ToString(x) + ";fx =" + Convert.ToString(fx) + Environment.NewLine;
                x = x + h;
            }
            //Количество точек графика
            int count = (int)Math.Ceiling((b - a) / h) + 1;
            //Массив значений Х 
            double[] massX = new double[count];
            //Массив Y
            double[] massY1 = new double[count];
            double[] massY2 = new double[count];
            //Расчитываем точки для графиков функции
            for (int i = 0; i < count; i++)
            {
                //вычисляем значение Х
                massX[i] = a + h * i;
                //Вычисляем значение функций в точке Х
                massY1[i] = Math.Sin(1 / 2 * x / 4 * (massX[i]) + 1);
            }
            //Настраиваем оси графика
            chart1.ChartAreas[0].AxisX.Minimum = a;
            chart1.ChartAreas[0].AxisX.Maximum = b;
            //Определяем шаг сетки
            chart1.ChartAreas[0].AxisX.MajorGrid.Interval = h;
            // Добавляем вычисленные значения в графики
            chart1.Series[0].Points.DataBindXY(massX, massY1);

        }
    }
}
