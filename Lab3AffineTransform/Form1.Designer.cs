namespace Lab3AffineTransform
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            splitContainer1 = new SplitContainer();
            pictureBox1 = new PictureBox();
            buttonDrawAxes = new Button();
            buttonDrawKv = new Button();
            buttonClear = new Button();
            buttonRight = new Button();
            buttonLeft = new Button();
            buttonUp = new Button();
            buttonDown = new Button();
            buttonReflectX = new Button();
            buttonReflectY = new Button();
            buttonScale = new Button();
            buttonRotate = new Button();
            buttonStartRotate = new Button();
            buttonStartScale = new Button();
            buttonStartStop = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            buttonStartScaleDown = new Button();
            buttonStartScaleUp = new Button();
            buttonStartMoveLeft = new Button();
            buttonStartMoveUp = new Button();
            buttonStartMoveDown = new Button();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(pictureBox1);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(buttonStartMoveDown);
            splitContainer1.Panel2.Controls.Add(buttonStartMoveUp);
            splitContainer1.Panel2.Controls.Add(buttonStartMoveLeft);
            splitContainer1.Panel2.Controls.Add(buttonStartScaleUp);
            splitContainer1.Panel2.Controls.Add(buttonStartScaleDown);
            splitContainer1.Panel2.Controls.Add(buttonDrawAxes);
            splitContainer1.Panel2.Controls.Add(buttonDrawKv);
            splitContainer1.Panel2.Controls.Add(buttonClear);
            splitContainer1.Panel2.Controls.Add(buttonRight);
            splitContainer1.Panel2.Controls.Add(buttonLeft);
            splitContainer1.Panel2.Controls.Add(buttonUp);
            splitContainer1.Panel2.Controls.Add(buttonDown);
            splitContainer1.Panel2.Controls.Add(buttonReflectX);
            splitContainer1.Panel2.Controls.Add(buttonReflectY);
            splitContainer1.Panel2.Controls.Add(buttonScale);
            splitContainer1.Panel2.Controls.Add(buttonRotate);
            splitContainer1.Panel2.Controls.Add(buttonStartRotate);
            splitContainer1.Panel2.Controls.Add(buttonStartScale);
            splitContainer1.Panel2.Controls.Add(buttonStartStop);
            splitContainer1.Size = new Size(797, 595);
            splitContainer1.SplitterDistance = 599;
            splitContainer1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(599, 595);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // buttonDrawAxes
            // 
            buttonDrawAxes.Location = new Point(3, 12);
            buttonDrawAxes.Name = "buttonDrawAxes";
            buttonDrawAxes.Size = new Size(188, 23);
            buttonDrawAxes.TabIndex = 0;
            buttonDrawAxes.Text = "Нарисовать оси";
            buttonDrawAxes.UseVisualStyleBackColor = true;
            buttonDrawAxes.Click += buttonDrawAxes_Click;
            // 
            // buttonDrawKv
            // 
            buttonDrawKv.Location = new Point(3, 41);
            buttonDrawKv.Name = "buttonDrawKv";
            buttonDrawKv.Size = new Size(188, 23);
            buttonDrawKv.TabIndex = 1;
            buttonDrawKv.Text = "Нарисовать фигуру";
            buttonDrawKv.UseVisualStyleBackColor = true;
            buttonDrawKv.Click += buttonDrawKv_Click;
            // 
            // buttonClear
            // 
            buttonClear.Location = new Point(3, 70);
            buttonClear.Name = "buttonClear";
            buttonClear.Size = new Size(188, 23);
            buttonClear.TabIndex = 2;
            buttonClear.Text = "Очистить";
            buttonClear.UseVisualStyleBackColor = true;
            buttonClear.Click += buttonClear_Click;
            // 
            // buttonRight
            // 
            buttonRight.Location = new Point(3, 99);
            buttonRight.Name = "buttonRight";
            buttonRight.Size = new Size(188, 23);
            buttonRight.TabIndex = 3;
            buttonRight.Text = "По оси OX вправо";
            buttonRight.UseVisualStyleBackColor = true;
            buttonRight.Click += buttonRight_Click;
            // 
            // buttonLeft
            // 
            buttonLeft.Location = new Point(3, 128);
            buttonLeft.Name = "buttonLeft";
            buttonLeft.Size = new Size(188, 23);
            buttonLeft.TabIndex = 4;
            buttonLeft.Text = "По оси OX влево";
            buttonLeft.UseVisualStyleBackColor = true;
            buttonLeft.Click += buttonLeft_Click;
            // 
            // buttonUp
            // 
            buttonUp.Location = new Point(3, 157);
            buttonUp.Name = "buttonUp";
            buttonUp.Size = new Size(188, 23);
            buttonUp.TabIndex = 5;
            buttonUp.Text = "По оси OY вверх";
            buttonUp.UseVisualStyleBackColor = true;
            buttonUp.Click += buttonUp_Click;
            // 
            // buttonDown
            // 
            buttonDown.Location = new Point(3, 186);
            buttonDown.Name = "buttonDown";
            buttonDown.Size = new Size(188, 23);
            buttonDown.TabIndex = 6;
            buttonDown.Text = "По оси OY вниз";
            buttonDown.UseVisualStyleBackColor = true;
            buttonDown.Click += buttonDown_Click;
            // 
            // buttonReflectX
            // 
            buttonReflectX.Location = new Point(3, 215);
            buttonReflectX.Name = "buttonReflectX";
            buttonReflectX.Size = new Size(188, 23);
            buttonReflectX.TabIndex = 7;
            buttonReflectX.Text = "Отразить по X";
            buttonReflectX.UseVisualStyleBackColor = true;
            buttonReflectX.Click += buttonReflectX_Click;
            // 
            // buttonReflectY
            // 
            buttonReflectY.Location = new Point(3, 244);
            buttonReflectY.Name = "buttonReflectY";
            buttonReflectY.Size = new Size(188, 23);
            buttonReflectY.TabIndex = 8;
            buttonReflectY.Text = "Отразить по Y";
            buttonReflectY.UseVisualStyleBackColor = true;
            buttonReflectY.Click += buttonReflectY_Click;
            // 
            // buttonScale
            // 
            buttonScale.Location = new Point(3, 273);
            buttonScale.Name = "buttonScale";
            buttonScale.Size = new Size(188, 23);
            buttonScale.TabIndex = 9;
            buttonScale.Text = "Масштабировать";
            buttonScale.UseVisualStyleBackColor = true;
            buttonScale.Click += buttonScale_Click;
            // 
            // buttonRotate
            // 
            buttonRotate.Location = new Point(3, 302);
            buttonRotate.Name = "buttonRotate";
            buttonRotate.Size = new Size(188, 23);
            buttonRotate.TabIndex = 11;
            buttonRotate.Text = "Повернуть";
            buttonRotate.UseVisualStyleBackColor = true;
            buttonRotate.Click += buttonRotate_Click;
            // 
            // buttonStartRotate
            // 
            buttonStartRotate.Location = new Point(6, 331);
            buttonStartRotate.Name = "buttonStartRotate";
            buttonStartRotate.Size = new Size(188, 23);
            buttonStartRotate.TabIndex = 12;
            buttonStartRotate.Text = "Авто-поворот";
            buttonStartRotate.UseVisualStyleBackColor = true;
            buttonStartRotate.Click += buttonStartRotate_Click;
            // 
            // buttonStartScale
            // 
            buttonStartScale.Location = new Point(6, 360);
            buttonStartScale.Name = "buttonStartScale";
            buttonStartScale.Size = new Size(188, 23);
            buttonStartScale.TabIndex = 13;
            buttonStartScale.Text = "Авто-масштаб";
            buttonStartScale.UseVisualStyleBackColor = true;
            buttonStartScale.Click += buttonStartScale_Click;
            // 
            // buttonStartStop
            // 
            buttonStartStop.Location = new Point(6, 446);
            buttonStartStop.Name = "buttonStartStop";
            buttonStartStop.Size = new Size(185, 30);
            buttonStartStop.TabIndex = 14;
            buttonStartStop.Text = "Старт движения вправо";
            buttonStartStop.UseVisualStyleBackColor = true;
            buttonStartStop.Click += buttonStartStop_Click;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // buttonStartScaleDown
            // 
            buttonStartScaleDown.Location = new Point(6, 389);
            buttonStartScaleDown.Name = "buttonStartScaleDown";
            buttonStartScaleDown.Size = new Size(185, 22);
            buttonStartScaleDown.TabIndex = 15;
            buttonStartScaleDown.Text = "Авто уменьшение масштаба";
            buttonStartScaleDown.UseVisualStyleBackColor = true;
            buttonStartScaleDown.Click += buttonStartScaleDown_Click;
            // 
            // buttonStartScaleUp
            // 
            buttonStartScaleUp.Location = new Point(6, 417);
            buttonStartScaleUp.Name = "buttonStartScaleUp";
            buttonStartScaleUp.Size = new Size(185, 23);
            buttonStartScaleUp.TabIndex = 16;
            buttonStartScaleUp.Text = "Авто увеличение масштаба";
            buttonStartScaleUp.UseVisualStyleBackColor = true;
            buttonStartScaleUp.Click += buttonStartScaleUp_Click;
            // 
            // buttonStartMoveLeft
            // 
            buttonStartMoveLeft.Location = new Point(6, 481);
            buttonStartMoveLeft.Name = "buttonStartMoveLeft";
            buttonStartMoveLeft.Size = new Size(176, 23);
            buttonStartMoveLeft.TabIndex = 17;
            buttonStartMoveLeft.Text = "Старт движения влево";
            buttonStartMoveLeft.UseVisualStyleBackColor = true;
            buttonStartMoveLeft.Click += buttonStartMoveLeft_Click;
            // 
            // buttonStartMoveUp
            // 
            buttonStartMoveUp.Location = new Point(6, 510);
            buttonStartMoveUp.Name = "buttonStartMoveUp";
            buttonStartMoveUp.Size = new Size(176, 23);
            buttonStartMoveUp.TabIndex = 18;
            buttonStartMoveUp.Text = "Старт движения вверх";
            buttonStartMoveUp.UseVisualStyleBackColor = true;
            buttonStartMoveUp.Click += buttonStartMoveUp_Click;
            // 
            // buttonStartMoveDown
            // 
            buttonStartMoveDown.Location = new Point(6, 539);
            buttonStartMoveDown.Name = "buttonStartMoveDown";
            buttonStartMoveDown.Size = new Size(176, 23);
            buttonStartMoveDown.TabIndex = 19;
            buttonStartMoveDown.Text = "Старт движения вниз";
            buttonStartMoveDown.UseVisualStyleBackColor = true;
            buttonStartMoveDown.Click += buttonStartMoveDown_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(797, 595);
            Controls.Add(splitContainer1);
            Name = "Form1";
            Text = "Lab3 Affine Transformations";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private PictureBox pictureBox1;
        private Button buttonRight;
        private Button buttonLeft; // Кнопка движения влево
        private Button buttonUp; // Кнопка движения вверх
        private Button buttonClear;
        private Button buttonDrawKv;
        private Button buttonDrawAxes;
        private Button buttonStartStop;
        private Button buttonReflectX;
        private Button buttonReflectY;
        private Button buttonScale;
        private Button buttonRotate;
        private Button buttonStartRotate;
        private Button buttonStartScale;
        private System.Windows.Forms.Timer timer1;
        private Button buttonDown;
        private Button buttonStartMoveDown;
        private Button buttonStartMoveUp;
        private Button buttonStartMoveLeft;
        private Button buttonStartScaleUp;
        private Button buttonStartScaleDown;
    }
}
