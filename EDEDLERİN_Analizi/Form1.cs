using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EDEDLERİN_Analizi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// İstifadəçinin daxil etdiyi ədədi tam ədədə çevirmək üçün istifadə olunur.
        /// Əgər çevrilə bilməzsə, false qaytarır.
        /// </summary>
        private bool TryGetInput(out int result)
        {
            return int.TryParse(txtInput.Text, out result);
        }
        private void EdedAnalizApp_Load(object sender, EventArgs e)
        {
            txtInput.Focus();
            txtInput.ForeColor = System.Drawing.Color.DarkRed;
            //txtInput.BackColor = System.Drawing.Color.LightYellow;
            txtInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            //txtInput.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            txtInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            label1.Text = "Nəticə burada göstəriləcək.";
            label1.ForeColor = System.Drawing.Color.Blue;
            //label1.BackColor = System.Drawing.Color.LightGray;
            //label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            //label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;


        }
        /// <summary>
        /// Kvadrat və ya kub olub olmadığını yoxlayır.
        /// </summary>

        private void btnKvadratKub_Click(object sender, EventArgs e)
        {
            if (!TryGetInput(out int number))
            {
                MessageBox.Show("Zəhmət olmasa düzgün tam ədəd daxil edin.");
                return;
            }

            bool isSquare = false;
            bool isCube = false;

            for (int i = 1; i <= number; i++)
            {
                if (i * i == number)
                    isSquare = true;
                if (i * i * i == number)
                    isCube = true;
            }

            if (isSquare && isCube)
                label1.Text = "Bu ədəd həm kvadrat, həm də kubdur.";
            else if (isSquare)
                label1.Text = "Bu ədəd kvadratdır.";
            else if (isCube)
                label1.Text = "Bu ədəd kubdur.";
            else
                label1.Text = "Bu ədəd nə kvadrat, nə də kubdur.";
        }

        /// <summary>
        /// Ədədin 5-ə bölünüb bölünmədiyini yoxlayır.
        /// </summary>
        private void btnBolunme5_Click(object sender, EventArgs e)
        {
            
            if (!TryGetInput(out int number))
            {
                MessageBox.Show("Zəhmət olmasa düzgün tam ədəd daxil edin.");
                return;
            }

            label1.Text = number % 5 == 0 ? "5-ə tam bölünür." : "5-ə qalıqla bölünür.";
        }

        /// <summary>
        /// Ədədin rəqəmləri cəmini hesablayır.
        /// </summary>
        private void btnReqemCemi_Click(object sender, EventArgs e)
        {
            if(!TryGetInput(out int number))
            {
                MessageBox.Show("Zəhmət olmasa düzgün tam ədəd daxil edin.");
                return;
            }
            number = Math.Abs(number);
            int sum = 0;
            while (number > 0)
            {
                sum += number % 10;
                number /= 10;
            }
            label1.Text = $"Rəqəmlərin cəmi:"+ sum;
        }
        /// <summary>
        /// Ədədin tərsini çap edir.
        /// </summary>
        private void btnTersi_Click(object sender, EventArgs e)
        {
            if (!TryGetInput(out int number))
            {
                MessageBox.Show("Zəhmət olmasa düzgün tam ədəd daxil edin.");
                return;
            }
            bool isNegative = number < 0;
            number = Math.Abs(number);

            int reversed = 0;
            while (number > 0)
            {
                reversed = reversed * 10 + number % 10;
                number /= 10;   
            }
            label1.Text = "Ədədin tərsi: " + (isNegative ? "-" + reversed : reversed.ToString());

        }

        /// <summary>
        /// Ədədin sadə və ya mürəkkəb olduğunu müəyyən edir.
        /// </summary>
        private void btnSadelik_Click(object sender, EventArgs e)
        {
            if (!TryGetInput(out int number) || number <=1)
            {
                MessageBox.Show("Zəhmət olmasa 2 və yuxarı tam ədəd daxil edin.");
                return;
            }
            bool isPrime = true;
            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                {
                    isPrime = false;
                    break;
                }
            }

            label1.Text = isPrime ? $"{number} sadə ədəddir." : $"{number} mürəkkəb ədəddir.";
        }
        /// <summary>
        /// Ədədin faktorialını hesablayır.
        /// </summary>
        private void btnFaktorial_Click(object sender, EventArgs e)
        {
            if (!TryGetInput(out int number) || number < 0)
            {
                MessageBox.Show("Zəhmət olmasa 0 və ya müsbət tam ədəd daxil edin.");
                return;
            }

            long factorial = 1;
            for (int i = 2; i <= number; i++)
            {
                factorial *= i;

            }

            label1.Text = $"{number}! = {factorial}"; 
        }
    }
}

