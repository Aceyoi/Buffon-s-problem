using System.Windows.Forms;

namespace Buffon_s_problem
{

    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private double buffon_dpi(int N, int M)
        {
            listBox1.Items.Clear();
            double l = 1.0;
            double a = 2.0;
            List<double> md = new List<double>(M); // Список для хранения отклонений

            Random random = new Random();

            for (int j = 0; j < M; ++j)
            {
                int sum_p = 0;
                for (int i = 0; i < N; ++i)
                {
                    double y = random.NextDouble() * a; // Случайное расстояние до линии
                    double q = random.NextDouble() * Math.PI; // Случайный угол
                    if (y <= l * Math.Sin(q))
                    {
                        sum_p++;
                    }
                    double mpi = (double)N / (sum_p == 0 ? 1 : sum_p); // Оценка числа π 
                    double deviation = Math.Abs(mpi - Math.PI); // Отклонение от эталона
                    listBox1.Items.Add($"В {j + 1} эксперименте на {i + 1} попытке броска получилось число {mpi} с отклонением: {deviation:F6}");
                }

                double finalMpi = (double)N / sum_p; // Оценка числа π
                md.Add(Math.Abs(finalMpi - Math.PI)); // Отклонение от эталона
            }

            double d = 0.0;
            for (int j = 0; j < M; ++j)
            {
                d += md[j];
            }
            d /= M;
            return d;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int N = int.Parse(textBox1.Text);
            int M = int.Parse(textBox2.Text);

            double result = buffon_dpi(N, M);

            textBox3.Text = result.ToString();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
