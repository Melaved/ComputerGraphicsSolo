namespace ComputerGraphicsSolo
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            splitContainer1 = new SplitContainer();
            rastrPictureBox = new PictureBox();
            algorithmGroupBox = new GroupBox();
            fillingRadioButton = new RadioButton();
            simpleDDAradioButton = new RadioButton();
            panel1 = new Panel();
            fillColorButton = new Button();
            thicknessButton = new Button();
            lineColorButton = new Button();
            performButton = new Button();
            clearButton = new Button();
            colorDialog1 = new ColorDialog();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)rastrPictureBox).BeginInit();
            algorithmGroupBox.SuspendLayout();
            panel1.SuspendLayout();
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
            splitContainer1.Panel1.Controls.Add(rastrPictureBox);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(algorithmGroupBox);
            splitContainer1.Panel2.Controls.Add(panel1);
            splitContainer1.Size = new Size(625, 450);
            splitContainer1.SplitterDistance = 422;
            splitContainer1.TabIndex = 0;
            // 
            // rastrPictureBox
            // 
            rastrPictureBox.Dock = DockStyle.Fill;
            rastrPictureBox.Location = new Point(0, 0);
            rastrPictureBox.Name = "rastrPictureBox";
            rastrPictureBox.Size = new Size(422, 450);
            rastrPictureBox.TabIndex = 0;
            rastrPictureBox.TabStop = false;
            rastrPictureBox.MouseClick += rastrPictureBox_MouseClick;
            rastrPictureBox.MouseDown += rastrPictureBox_MouseDown;
            rastrPictureBox.MouseUp += rastrPictureBox_MouseUp;
            // 
            // algorithmGroupBox
            // 
            algorithmGroupBox.Controls.Add(fillingRadioButton);
            algorithmGroupBox.Controls.Add(simpleDDAradioButton);
            algorithmGroupBox.Dock = DockStyle.Top;
            algorithmGroupBox.Location = new Point(0, 0);
            algorithmGroupBox.Name = "algorithmGroupBox";
            algorithmGroupBox.Size = new Size(199, 158);
            algorithmGroupBox.TabIndex = 1;
            algorithmGroupBox.TabStop = false;
            algorithmGroupBox.Text = "Выберите алгоритм";
            // 
            // fillingRadioButton
            // 
            fillingRadioButton.AutoSize = true;
            fillingRadioButton.Location = new Point(6, 47);
            fillingRadioButton.Name = "fillingRadioButton";
            fillingRadioButton.Size = new Size(70, 19);
            fillingRadioButton.TabIndex = 1;
            fillingRadioButton.TabStop = true;
            fillingRadioButton.Text = "Заливка";
            fillingRadioButton.UseVisualStyleBackColor = true;
            // 
            // simpleDDAradioButton
            // 
            simpleDDAradioButton.AutoSize = true;
            simpleDDAradioButton.Location = new Point(6, 22);
            simpleDDAradioButton.Name = "simpleDDAradioButton";
            simpleDDAradioButton.Size = new Size(108, 19);
            simpleDDAradioButton.TabIndex = 0;
            simpleDDAradioButton.TabStop = true;
            simpleDDAradioButton.Text = "Обычный ЦДА";
            simpleDDAradioButton.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(fillColorButton);
            panel1.Controls.Add(thicknessButton);
            panel1.Controls.Add(lineColorButton);
            panel1.Controls.Add(performButton);
            panel1.Controls.Add(clearButton);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(199, 450);
            panel1.TabIndex = 0;
            // 
            // fillColorButton
            // 
            fillColorButton.Location = new Point(7, 295);
            fillColorButton.Name = "fillColorButton";
            fillColorButton.Size = new Size(92, 34);
            fillColorButton.TabIndex = 4;
            fillColorButton.Text = "Цвет заливки";
            fillColorButton.UseVisualStyleBackColor = true;
            fillColorButton.Click += fillColorButton_Click;
            // 
            // thicknessButton
            // 
            thicknessButton.Location = new Point(105, 335);
            thicknessButton.Name = "thicknessButton";
            thicknessButton.Size = new Size(89, 42);
            thicknessButton.TabIndex = 3;
            thicknessButton.Text = "Толщина линии";
            thicknessButton.UseVisualStyleBackColor = true;
            thicknessButton.Click += thicknessButton_Click;
            // 
            // lineColorButton
            // 
            lineColorButton.Location = new Point(7, 335);
            lineColorButton.Name = "lineColorButton";
            lineColorButton.Size = new Size(92, 42);
            lineColorButton.TabIndex = 2;
            lineColorButton.Text = "Цвет линии";
            lineColorButton.UseVisualStyleBackColor = true;
            lineColorButton.Click += lineColorButton_Click;
            // 
            // performButton
            // 
            performButton.Location = new Point(5, 395);
            performButton.Name = "performButton";
            performButton.Size = new Size(94, 42);
            performButton.TabIndex = 1;
            performButton.Text = "Выполнить";
            performButton.UseVisualStyleBackColor = true;
            performButton.Click += performButton_Click;
            // 
            // clearButton
            // 
            clearButton.Location = new Point(105, 395);
            clearButton.Name = "clearButton";
            clearButton.Size = new Size(89, 42);
            clearButton.TabIndex = 0;
            clearButton.Text = "Очистить";
            clearButton.UseVisualStyleBackColor = true;
            clearButton.Click += clearButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(625, 450);
            Controls.Add(splitContainer1);
            Name = "Form1";
            Text = "Растровые алгоритмы";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)rastrPictureBox).EndInit();
            algorithmGroupBox.ResumeLayout(false);
            algorithmGroupBox.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private GroupBox algorithmGroupBox;
        private RadioButton fillingRadioButton;
        private RadioButton simpleDDAradioButton;
        private Panel panel1;
        private Button clearButton;
        private PictureBox rastrPictureBox;
        private Button performButton;
        private Button lineColorButton;
        private ColorDialog colorDialog1;
        private Button thicknessButton;
        private Button fillColorButton;
    }
}
