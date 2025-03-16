

namespace ComputerGraphicsSolo
{
    public partial class Form1 : Form
    {
        public int xn;
        public int yn;
        public int xk;
        public int yk;
        private Bitmap myBitmap;
        private Color currentBorderColor;
        private int currentThickness = 1;
        private Color currentFillColor = Color.Black;
        private List<(Point, Point)> lines = new List<(Point, Point)>();

        public Form1()
        {
            InitializeComponent();
            myBitmap = new Bitmap(rastrPictureBox.Width, rastrPictureBox.Height);
            rastrPictureBox.Image = myBitmap;
        }

        private void rastrPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (simpleDDAradioButton.Checked == true)
            {
                xn = e.X;
                yn = e.Y;
            }
        }

        private void rastrPictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            xk = e.X;
            yk = e.Y;
            if (simpleDDAradioButton.Checked == true)
            {
                // ��������� �������
                lines.Add((new Point(xn, yn), new Point(xk, yk)));

                // ������ �������
                CDA(xn, yn, xk, yk, currentThickness);
                rastrPictureBox.Image = myBitmap;
            }
        }

        private void CDA(int xStart, int yStart, int xEnd, int yEnd, int thickness)
        {
            int index;
            int numberNodes;
            double xOutput;
            double yOutput;
            double dx;
            double dy;

            xn = xStart;
            yn = yStart;
            xk = xEnd;
            yk = yEnd;
            dx = xk - xn;
            dy = yk - yn;
            numberNodes = 200;
            xOutput = xn;
            yOutput = yn;

            for (index = 1; index <= numberNodes; index++)
            {
                DrawThickPixel((int)xOutput, (int)yOutput, currentBorderColor, thickness);
                xOutput += dx / numberNodes;
                yOutput += dy / numberNodes;
            }
        }
        private void DrawThickPixel(int x, int y, Color color, int thickness)
        {
            int halfThickness = thickness / 2;

            for (int i = -halfThickness; i <= halfThickness; i++)
            {
                for (int j = -halfThickness; j <= halfThickness; j++)
                {
                    int newX = x + i;
                    int newY = y + j;

                    // ���������, ����� �� ����� �� ������� �����������
                    if (newX >= 0 && newX < myBitmap.Width && newY >= 0 && newY < myBitmap.Height)
                    {
                        myBitmap.SetPixel(newX, newY, color);
                    }
                }
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            myBitmap = new Bitmap(rastrPictureBox.Width, rastrPictureBox.Height);
            rastrPictureBox.Image = myBitmap;
            lines.Clear(); // ������� ������ ��������
        }

        private void performButton_Click(object sender, EventArgs e)
        {
            performButton.Enabled = false;
            clearButton.Enabled = false;
            try
            {

                using (Graphics graphics = Graphics.FromHwnd(rastrPictureBox.Handle))
                {
                    if (simpleDDAradioButton.Checked == true)
                    {
                        CDA(10, 10, 10, 110, currentThickness);
                        CDA(10, 10, 110, 10, currentThickness);
                        CDA(10, 110, 110, 110, currentThickness);
                        CDA(110, 10, 110, 110, currentThickness);

                        CDA(150, 10, 150, 200, currentThickness);
                        CDA(250, 50, 150, 200, currentThickness);
                        CDA(150, 10, 250, 150, currentThickness);
                    }
                    else
                    {
                        if (fillingRadioButton.Checked == true)
                        {
                            // ������ ���������� ��������
                            xn = 160;
                            yn = 40;

                            // �������� ����������� ��������� ������� � ���������
                            FloodFill(xn, yn);
                        }
                    }

                    //�������� ���������� ����� mybitmap � ������� pictureBox
                    rastrPictureBox.Image = myBitmap;

                    // ��������� pictureBox
                    rastrPictureBox.Refresh();
                }
            }
            finally
            {
                performButton.Enabled = true;
                clearButton.Enabled = true;
            }
        }

        private void FloodFill(int x1, int y1)
        {
            try
            {
                Color targetColor = myBitmap.GetPixel(x1, y1);

                // ���� ��������� ����� ��� ��������� ��� �������� ��������, �������
                if (targetColor.ToArgb() == currentBorderColor.ToArgb() || targetColor.ToArgb() == currentFillColor.ToArgb())
                {
                    return;
                }

                Stack<(int, int)> stack = new Stack<(int, int)>();
                stack.Push((x1, y1));

                while (stack.Count > 0)
                {
                    var (x, y) = stack.Pop();

                    // ���������, ����� ���������� ���� � �������� �����������
                    if (x >= 0 && x < myBitmap.Width && y >= 0 && y < myBitmap.Height)
                    {
                        Color pixelColor = myBitmap.GetPixel(x, y);

                        // ���� ������� �� �������� � �� �������� ��������, ����������� ���
                        if (pixelColor.ToArgb() == targetColor.ToArgb())
                        {
                            myBitmap.SetPixel(x, y, currentFillColor);

                            // ��������� �������� ������� � ����
                            stack.Push((x + 1, y));
                            stack.Push((x - 1, y));
                            stack.Push((x, y + 1));
                            stack.Push((x, y - 1));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������ ��� �������: {ex.Message}", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //private void FloodFill(int x, int y)
        //{
        //    try
        //    {
        //        // ���������, ����� ���������� ���� � �������� �����������
        //        if (x < 0 || x >= myBitmap.Width || y < 0 || y >= myBitmap.Height)
        //        {
        //            return;
        //        }

        //        // �������� ���� �������� �������
        //        Color pixelColor = myBitmap.GetPixel(x, y);

        //        // ���� ������� ��� �������� ��� �������� ��������, �������
        //        if (pixelColor.ToArgb() == currentBorderColor.ToArgb() || pixelColor.ToArgb() == currentFillColor.ToArgb())
        //        {
        //            return;
        //        }

        //        // ����������� ������� �������
        //        myBitmap.SetPixel(x, y, currentFillColor);

        //        // ���������� �������� ����� ��� 4-� �������� ��������
        //        // ������
        //        FloodFill(x + 1, y);
        //        // �����
        //        FloodFill(x - 1, y);
        //        // �����
        //        FloodFill(x, y + 1);
        //        // ������
        //        FloodFill(x, y - 1);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"������ ��� �������: {ex.Message}", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private void lineColorButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = colorDialog1.ShowDialog();
            if (dialogResult == DialogResult.OK && simpleDDAradioButton.Checked)
            {
                currentBorderColor = colorDialog1.Color;
            }
        }

        private void thicknessButton_Click(object sender, EventArgs e)
        {
            using (var thicknessDialog = new Form())
            {
                thicknessDialog.Text = "�������� ������� �����";
                thicknessDialog.Size = new Size(200, 150);

                var trackBar = new TrackBar();
                trackBar.Minimum = 1;
                trackBar.Maximum = 10;
                trackBar.Value = currentThickness;
                trackBar.Location = new Point(20, 20);
                trackBar.Width = 150;

                var okButton = new Button();
                okButton.Text = "OK";
                okButton.Location = new Point(50, 70);
                okButton.Click += (s, ev) =>
                {
                    currentThickness = trackBar.Value;
                    thicknessDialog.Close();
                };

                thicknessDialog.Controls.Add(trackBar);
                thicknessDialog.Controls.Add(okButton);
                thicknessDialog.ShowDialog();
            }
        }

        private void fillColorButton_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                currentFillColor = colorDialog1.Color;
            }
        }

        private void rastrPictureBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (!simpleDDAradioButton.Checked && !fillingRadioButton.Checked)
            {
                MessageBox.Show("�� ������ �� ���� ��������.", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (fillingRadioButton.Checked == true)
            {
                // ���������, ����� ���������� ���� � �������� �����������
                if (e.X >= 0 && e.X < myBitmap.Width && e.Y >= 0 && e.Y < myBitmap.Height)
                {
                    // ��������� �������
                    FloodFill(e.X, e.Y);
                    rastrPictureBox.Image = myBitmap;
                }
                else
                {
                    MessageBox.Show("���������� ����� ��������� ��� �����������.", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
