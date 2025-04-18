using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Lab3AffineTransform
{
    public partial class Form1 : Form
    {
        int[,] osi = new int[4, 3];
        int[,] matr_preob = new int[3, 3];
        int k, l;
        bool autoRotate = false;
        bool autoScale = false;
        float currentScale = 1.0f;
        bool scaleUp = true;
        float angle = 0;
        bool moveRight = false;
        double[,] figure = new double[4, 2];
        bool autoMoveLeft = false;
        bool autoMoveUp = false;
        bool autoMoveDown = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Init_figure()
        {
            figure[0, 0] = -20; figure[0, 1] = -60;
            figure[1, 0] = -20; figure[1, 1] = 20;
            figure[2, 0] = 20; figure[2, 1] = 30;
            figure[3, 0] = 60; figure[3, 1] = 20;
        }


        private void Init_osi()
        {
            osi[0, 0] = -200; osi[0, 1] = 0; osi[0, 2] = 1;
            osi[1, 0] = 200; osi[1, 1] = 0; osi[1, 2] = 1;
            osi[2, 0] = 0; osi[2, 1] = 200; osi[2, 2] = 1;
            osi[3, 0] = 0; osi[3, 1] = -200; osi[3, 2] = 1;
        }

        private void Init_matr_preob(int k1, int l1)
        {
            matr_preob[0, 0] = 1; matr_preob[0, 1] = 0; matr_preob[0, 2] = 0;
            matr_preob[1, 0] = 0; matr_preob[1, 1] = 1; matr_preob[1, 2] = 0;
            matr_preob[2, 0] = k1; matr_preob[2, 1] = l1; matr_preob[2, 2] = 1;
        }

        private int[,] Multiply_matr(int[,] a, int[,] b)
        {
            int n = a.GetLength(0);
            int m = a.GetLength(1);
            int[,] r = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    r[i, j] = 0;
                    for (int ii = 0; ii < m; ii++)
                    {
                        r[i, j] += a[i, ii] * b[ii, j];
                    }
                }
            }
            return r;
        }

        private void Draw_Kv()
        {
            Init_matr_preob(k, l);

            Pen myPen = new Pen(Color.Blue, 2);
            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);

            Point[] points = new Point[4];
            for (int i = 0; i < 4; i++)
            {
                int x = (int)Math.Round(figure[i, 0]) + k;
                int y = (int)Math.Round(figure[i, 1]) + l;
                points[i] = new Point(x, y);
            }

            g.DrawPolygon(myPen, points);
            g.Dispose();
            myPen.Dispose();
        }


        private void Draw_osi()
        {
            Init_osi();
            Init_matr_preob(k, l);
            int[,] osi1 = Multiply_matr(osi, matr_preob);
            Pen myPen = new Pen(Color.Red, 1);
            Graphics g = pictureBox1.CreateGraphics();
            g.DrawLine(myPen, osi1[0, 0], osi1[0, 1], osi1[1, 0], osi1[1, 1]);
            g.DrawLine(myPen, osi1[2, 0], osi1[2, 1], osi1[3, 0], osi1[3, 1]);
            g.Dispose();
            myPen.Dispose();
        }

        private void buttonDrawAxes_Click(object sender, EventArgs e)
        {
            k = pictureBox1.Width / 2;
            l = pictureBox1.Height / 2;
            Draw_osi();
        }

        private void buttonDrawKv_Click(object sender, EventArgs e)
        {
            k = pictureBox1.Width / 2;
            l = pictureBox1.Height / 2;
            Init_figure();
            Draw_Kv();
        }

        private void buttonRight_Click(object sender, EventArgs e)
        {
            k += 5;
            buttonClear_Click(sender, e);
            Draw_Kv();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();
            g.Clear(pictureBox1.BackColor);
            g.Dispose();
        }

        private void buttonStartStop_Click(object sender, EventArgs e)
        {
            moveRight = !moveRight;
            buttonStartStop.Text = moveRight ? "Остановить движение вправо" : "Старт движения вправо";

            if (moveRight || autoRotate || autoScale)
            {
                timer1.Start();
            }
            else
            {
                timer1.Stop();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            buttonClear_Click(sender, e); // Очистить перед рисованием

            if (moveRight)  // Если флаг moveRight включен
            {
                k += 5; // Двигаем фигуру вправо
            }

            if (autoMoveLeft)
            {
                k -= 5; // Двигаем фигуру влево
            }

            if (autoMoveUp)
            {
                l -= 5; // Двигаем фигуру вверх
            }

            if (autoMoveDown)
            {
                l += 5; // Двигаем фигуру вниз
            }

            if (autoRotate)
            {
                angle += 5;
                angle %= 360;
                RotateFigure(angle);
            }

            if (autoScale)
            {
                float scale = scaleUp ? 1.05f : 0.95f;
                currentScale *= scale;

                if (currentScale > 1.5f) scaleUp = false;
                if (currentScale < 0.5f) scaleUp = true;

                ScaleFigure(currentScale);
            }

            Draw_Kv(); // Рисуем фигуру на новом месте
        }


        private void buttonReflectX_Click(object sender, EventArgs e)
        {
            buttonClear_Click(sender, e);
            for (int i = 0; i < figure.GetLength(0); i++)
                figure[i, 1] *= -1;
            Draw_Kv();
        }

        private void buttonReflectY_Click(object sender, EventArgs e)
        {
            buttonClear_Click(sender, e);
            for (int i = 0; i < figure.GetLength(0); i++)
                figure[i, 0] *= -1;
            Draw_Kv();
        }

        private void buttonScale_Click(object sender, EventArgs e)
        {
            buttonClear_Click(sender, e);
            ScaleFigure(1.2f);
            Draw_Kv();
        }

        private void ScaleFigure(float s)
        {
            double cx = 0, cy = 0;
            for (int i = 0; i < figure.GetLength(0); i++)
            {
                cx += figure[i, 0];
                cy += figure[i, 1];
            }
            cx /= figure.GetLength(0);
            cy /= figure.GetLength(0);

            for (int i = 0; i < figure.GetLength(0); i++)
            {
                figure[i, 0] = (figure[i, 0] - cx) * s + cx;
                figure[i, 1] = (figure[i, 1] - cy) * s + cy;
            }
        }



        private void buttonRotate_Click(object sender, EventArgs e)
        {
            buttonClear_Click(sender, e);
            angle += 10;
            RotateFigure(angle);
            Draw_Kv();
        }

        private void RotateFigure(float angleDeg)
        {
            double angleRad = angleDeg * Math.PI / 180;

            // Центр фигуры
            double cx = 0, cy = 0;
            for (int i = 0; i < figure.GetLength(0); i++)
            {
                cx += figure[i, 0];
                cy += figure[i, 1];
            }
            cx /= figure.GetLength(0);
            cy /= figure.GetLength(0);

            for (int i = 0; i < figure.GetLength(0); i++)
            {
                double x = figure[i, 0] - cx;
                double y = figure[i, 1] - cy;

                double xr = x * Math.Cos(angleRad) - y * Math.Sin(angleRad);
                double yr = x * Math.Sin(angleRad) + y * Math.Cos(angleRad);

                figure[i, 0] = xr + cx;
                figure[i, 1] = yr + cy;
            }
        }



        private void buttonStartRotate_Click(object sender, EventArgs e)
        {
            autoRotate = !autoRotate;
            buttonStartRotate.Text = autoRotate ? "Выключить Поворот" : "Авто Поворот";

            if (autoRotate || autoScale)
                timer1.Start();
            else
                timer1.Stop();
        }

        private void buttonStartScale_Click(object sender, EventArgs e)
        {
            autoScale = !autoScale;
            buttonStartScale.Text = autoScale ? "Выключить Масштаб" : "Авто Масштаб";

            if (autoRotate || autoScale)
                timer1.Start();
            else
                timer1.Stop();
        }

        private void buttonLeft_Click(object sender, EventArgs e)
        {
            k -= 5; // Двигаем фигуру влево
            buttonClear_Click(sender, e);
            Draw_Kv();
        }

        private void buttonUp_Click(object sender, EventArgs e)
        {
            l -= 5; // Двигаем фигуру вверх
            buttonClear_Click(sender, e);
            Draw_Kv();
        }

        private void buttonDown_Click(object sender, EventArgs e)
        {
            l += 5; // Двигаем фигуру вниз
            buttonClear_Click(sender, e);
            Draw_Kv();
        }

        private void buttonStartScaleDown_Click(object sender, EventArgs e)
        {
            autoScale = !autoScale;
            scaleUp = false; // Автоматическое уменьшение масштаба

            buttonStartScaleDown.Text = autoScale ? "Выключить авто-уменьшение масштаба" : "Авто-уменьшение масштаба";

            if (autoScale || autoRotate)
                timer1.Start();
            else
                timer1.Stop();
        }

        private void buttonStartScaleUp_Click(object sender, EventArgs e)
        {
            autoScale = !autoScale;
            scaleUp = true; // Автоматическое увеличение масштаба

            buttonStartScaleUp.Text = autoScale ? "Выключить авто-увеличение масштаба" : "Авто-увеличение масштаба";

            if (autoScale || autoRotate)
                timer1.Start();
            else
                timer1.Stop();
        }

        private void buttonStartMoveLeft_Click(object sender, EventArgs e)
        {
            autoMoveLeft = !autoMoveLeft;
            buttonStartMoveLeft.Text = autoMoveLeft ? "Остановить движение влево" : "Авто движение влево";

            if (autoMoveLeft || autoMoveUp || autoMoveDown || autoRotate || autoScale)
                timer1.Start();
            else
                timer1.Stop();
        }

        private void buttonStartMoveUp_Click(object sender, EventArgs e)
        {
            autoMoveUp = !autoMoveUp;
            buttonStartMoveUp.Text = autoMoveUp ? "Остановить движение вверх" : "Авто движение вверх";

            if (autoMoveLeft || autoMoveUp || autoMoveDown || autoRotate || autoScale)
                timer1.Start();
            else
                timer1.Stop();
        }

        private void buttonStartMoveDown_Click(object sender, EventArgs e)
        {
            autoMoveDown = !autoMoveDown;
            buttonStartMoveDown.Text = autoMoveDown ? "Остановить движение вниз" : "Авто движение вниз";

            if (autoMoveLeft || autoMoveUp || autoMoveDown || autoRotate || autoScale)
                timer1.Start();
            else
                timer1.Stop();
        }
    }
}


//using System;
//using System.Drawing;
//using System.Threading;
//using System.Windows.Forms;

//namespace Lab3AffineTransform
//{
//    public partial class Form1 : Form
//    {
//        int[,] figure = new int[4, 3];
//        int[,] osi = new int[4, 3];
//        int[,] matr_preob = new int[3, 3];
//        int k, l;
//        bool f = true;
//        bool autoRotate = false;
//        bool autoScale = false;
//        float currentScale = 1.0f;
//        bool scaleUp = true;
//        float angle = 0;
//        bool moveRight = false;
//        int[,] originalFigure;  // Сохраняем исходные координаты фигуры

//        public Form1()
//        {
//            InitializeComponent();
//        }

//        private void Init_figure()
//        {
//            figure[0, 0] = -20; figure[0, 1] = -60; figure[0, 2] = 1;
//            figure[1, 0] = -20; figure[1, 1] = 20; figure[1, 2] = 1;
//            figure[2, 0] = 20; figure[2, 1] = 30; figure[2, 2] = 1;
//            figure[3, 0] = 60; figure[3, 1] = 20; figure[3, 2] = 1;
//            originalFigure = (int[,])figure.Clone(); // Сохраняем исходные координаты
//        }

//        private void Init_osi()
//        {
//            osi[0, 0] = -200; osi[0, 1] = 0; osi[0, 2] = 1;
//            osi[1, 0] = 200; osi[1, 1] = 0; osi[1, 2] = 1;
//            osi[2, 0] = 0; osi[2, 1] = 200; osi[2, 2] = 1;
//            osi[3, 0] = 0; osi[3, 1] = -200; osi[3, 2] = 1;
//        }

//        private void Init_matr_preob(int k1, int l1)
//        {
//            matr_preob[0, 0] = 1; matr_preob[0, 1] = 0; matr_preob[0, 2] = 0;
//            matr_preob[1, 0] = 0; matr_preob[1, 1] = 1; matr_preob[1, 2] = 0;
//            matr_preob[2, 0] = k1; matr_preob[2, 1] = l1; matr_preob[2, 2] = 1;
//        }

//        private int[,] Multiply_matr(int[,] a, int[,] b)
//        {
//            int n = a.GetLength(0);
//            int m = a.GetLength(1);
//            int[,] r = new int[n, m];
//            for (int i = 0; i < n; i++)
//            {
//                for (int j = 0; j < m; j++)
//                {
//                    r[i, j] = 0;
//                    for (int ii = 0; ii < m; ii++)
//                    {
//                        r[i, j] += a[i, ii] * b[ii, j];
//                    }
//                }
//            }
//            return r;
//        }

//        private void Draw_Kv()
//        {
//            Init_matr_preob(k, l);
//            int[,] kv1 = Multiply_matr(figure, matr_preob);

//            Pen myPen = new Pen(Color.Blue, 2);
//            Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
//            g.DrawLine(myPen, kv1[0, 0], kv1[0, 1], kv1[1, 0], kv1[1, 1]);
//            g.DrawLine(myPen, kv1[1, 0], kv1[1, 1], kv1[2, 0], kv1[2, 1]);
//            g.DrawLine(myPen, kv1[2, 0], kv1[2, 1], kv1[3, 0], kv1[3, 1]);
//            g.DrawLine(myPen, kv1[3, 0], kv1[3, 1], kv1[0, 0], kv1[0, 1]);
//            g.Dispose();
//            myPen.Dispose();
//        }

//        private void Draw_osi()
//        {
//            Init_osi();
//            Init_matr_preob(k, l);
//            int[,] osi1 = Multiply_matr(osi, matr_preob);
//            Pen myPen = new Pen(Color.Red, 1);
//            Graphics g = pictureBox1.CreateGraphics();
//            g.DrawLine(myPen, osi1[0, 0], osi1[0, 1], osi1[1, 0], osi1[1, 1]);
//            g.DrawLine(myPen, osi1[2, 0], osi1[2, 1], osi1[3, 0], osi1[3, 1]);
//            g.Dispose();
//            myPen.Dispose();
//        }

//        private void buttonDrawAxes_Click(object sender, EventArgs e)
//        {
//            k = pictureBox1.Width / 2;
//            l = pictureBox1.Height / 2;
//            Draw_osi();
//        }

//        private void buttonDrawKv_Click(object sender, EventArgs e)
//        {
//            k = pictureBox1.Width / 2;
//            l = pictureBox1.Height / 2;
//            Init_figure();
//            Draw_Kv();
//        }

//        private void buttonRight_Click(object sender, EventArgs e)
//        {
//            k += 5;
//            buttonClear_Click(sender, e);
//            Draw_Kv();
//        }

//        private void buttonClear_Click(object sender, EventArgs e)
//        {
//            Graphics g = pictureBox1.CreateGraphics();
//            g.Clear(pictureBox1.BackColor);
//            g.Dispose();
//        }

//        private void buttonStartStop_Click(object sender, EventArgs e)
//        {
//            moveRight = !moveRight;
//            buttonStartStop.Text = moveRight ? "Остановить движение вправо" : "Старт движения вправо";

//            if (moveRight || autoRotate || autoScale)
//            {
//                timer1.Start();
//            }
//            else
//            {
//                timer1.Stop();
//            }
//        }

//        private void timer1_Tick(object sender, EventArgs e)
//        {
//            buttonClear_Click(sender, e); // Очистить перед рисованием

//            if (moveRight)  // Если флаг moveRight включен
//            {
//                k += 5; // Двигаем фигуру вправо
//            }

//            if (autoRotate)
//            {
//                angle += 5;
//                RotateFigure(angle);
//            }

//            if (autoScale)
//            {
//                float scale = scaleUp ? 1.05f : 0.95f;
//                currentScale *= scale;

//                if (currentScale > 1.5f) scaleUp = false;
//                if (currentScale < 0.5f) scaleUp = true;

//                ScaleFigure(currentScale);
//            }

//            Draw_Kv(); // Рисуем фигуру на новом месте
//        }

//        private void buttonReflectX_Click(object sender, EventArgs e)
//        {
//            buttonClear_Click(sender, e);
//            for (int i = 0; i < figure.GetLength(0); i++)
//                figure[i, 1] *= -1;
//            Draw_Kv();
//        }

//        private void buttonReflectY_Click(object sender, EventArgs e)
//        {
//            buttonClear_Click(sender, e);
//            for (int i = 0; i < figure.GetLength(0); i++)
//                figure[i, 0] *= -1;
//            Draw_Kv();
//        }

//        private void buttonScale_Click(object sender, EventArgs e)
//        {
//            buttonClear_Click(sender, e);
//            ScaleFigure(1.2f);
//            Draw_Kv();
//        }

//        private void ScaleFigure(float s)
//        {
//            for (int i = 0; i < figure.GetLength(0); i++)
//            {
//                figure[i, 0] = (int)(figure[i, 0] * s);
//                figure[i, 1] = (int)(figure[i, 1] * s);
//            }
//        }

//        private void buttonRotate_Click(object sender, EventArgs e)
//        {
//            buttonClear_Click(sender, e);
//            angle += 10;
//            RotateFigure(angle);
//            Draw_Kv();
//        }

//        private void RotateFigure(float angleDeg)
//        {
//            // Восстанавливаем оригинальные координаты
//            figure = (int[,])originalFigure.Clone();

//            double angleRad = angleDeg * Math.PI / 180;
//            for (int i = 0; i < figure.GetLength(0); i++)
//            {
//                int x = figure[i, 0];
//                int y = figure[i, 1];
//                figure[i, 0] = (int)(x * Math.Cos(angleRad) - y * Math.Sin(angleRad));
//                figure[i, 1] = (int)(x * Math.Sin(angleRad) + y * Math.Cos(angleRad));
//            }
//        }

//        private void buttonStartRotate_Click(object sender, EventArgs e)
//        {
//            autoRotate = !autoRotate;
//            buttonStartRotate.Text = autoRotate ? "Выключить Поворот" : "Авто Поворот";

//            if (autoRotate || autoScale)
//                timer1.Start();
//            else
//                timer1.Stop();
//        }

//        private void buttonStartScale_Click(object sender, EventArgs e)
//        {
//            autoScale = !autoScale;
//            buttonStartScale.Text = autoScale ? "Выключить Масштаб" : "Авто Масштаб";

//            if (autoRotate || autoScale)
//                timer1.Start();
//            else
//                timer1.Stop();
//        }
//    }
//}
