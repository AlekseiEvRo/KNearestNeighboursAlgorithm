namespace KNN
{
    partial class MainForm
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
            pictureBox = new PictureBox();
            panel1 = new Panel();
            NeighbourCounter = new NumericUpDown();
            label4 = new Label();
            CalculateButton = new Button();
            RemoveAllTrianglesButton = new Button();
            RemoveAllRectanglesButton = new Button();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NeighbourCounter).BeginInit();
            SuspendLayout();
            // 
            // pictureBox
            // 
            pictureBox.Location = new Point(12, 12);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(1284, 994);
            pictureBox.TabIndex = 0;
            pictureBox.TabStop = false;
            pictureBox.MouseDown += pictureBox_MouseDown;
            // 
            // panel1
            // 
            panel1.Controls.Add(NeighbourCounter);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(CalculateButton);
            panel1.Controls.Add(RemoveAllTrianglesButton);
            panel1.Controls.Add(RemoveAllRectanglesButton);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(1302, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(590, 994);
            panel1.TabIndex = 1;
            // 
            // NeighbourCounter
            // 
            NeighbourCounter.Location = new Point(51, 355);
            NeighbourCounter.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            NeighbourCounter.Name = "NeighbourCounter";
            NeighbourCounter.Size = new Size(139, 23);
            NeighbourCounter.TabIndex = 7;
            NeighbourCounter.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(17, 357);
            label4.Name = "label4";
            label4.Size = new Size(28, 15);
            label4.TabIndex = 6;
            label4.Text = "K = ";
            // 
            // CalculateButton
            // 
            CalculateButton.Location = new Point(15, 286);
            CalculateButton.Name = "CalculateButton";
            CalculateButton.Size = new Size(175, 52);
            CalculateButton.TabIndex = 5;
            CalculateButton.Text = "Выполнить расчёт класса";
            CalculateButton.UseVisualStyleBackColor = true;
            CalculateButton.Click += CalculateButton_Click;
            // 
            // RemoveAllTrianglesButton
            // 
            RemoveAllTrianglesButton.Location = new Point(15, 186);
            RemoveAllTrianglesButton.Name = "RemoveAllTrianglesButton";
            RemoveAllTrianglesButton.Size = new Size(175, 52);
            RemoveAllTrianglesButton.TabIndex = 4;
            RemoveAllTrianglesButton.Text = "Убрать все треугольники";
            RemoveAllTrianglesButton.UseVisualStyleBackColor = true;
            RemoveAllTrianglesButton.Click += RemoveAllTrianglesButton_Click;
            // 
            // RemoveAllRectanglesButton
            // 
            RemoveAllRectanglesButton.Location = new Point(15, 128);
            RemoveAllRectanglesButton.Name = "RemoveAllRectanglesButton";
            RemoveAllRectanglesButton.Size = new Size(175, 52);
            RemoveAllRectanglesButton.TabIndex = 3;
            RemoveAllRectanglesButton.Text = "Убрать все квадраты";
            RemoveAllRectanglesButton.UseVisualStyleBackColor = true;
            RemoveAllRectanglesButton.Click += RemoveAllRectanglesButton_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(18, 94);
            label3.Name = "label3";
            label3.Size = new Size(126, 15);
            label3.TabIndex = 2;
            label3.Text = "СКМ - поставить круг";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 65);
            label2.Name = "label2";
            label2.Size = new Size(172, 15);
            label2.TabIndex = 1;
            label2.Text = "ПКМ - поставить треугольник";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 33);
            label1.Name = "label1";
            label1.Size = new Size(144, 15);
            label1.TabIndex = 0;
            label1.Text = "ЛКМ - поставить квадрат";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1904, 1011);
            Controls.Add(panel1);
            Controls.Add(pictureBox);
            Name = "MainForm";
            Text = "MainForm";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)NeighbourCounter).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox;
        private Panel panel1;
        private Button CalculateButton;
        private Button RemoveAllTrianglesButton;
        private Button RemoveAllRectanglesButton;
        private Label label3;
        private Label label2;
        private Label label1;
        private NumericUpDown NeighbourCounter;
        private Label label4;
    }
}