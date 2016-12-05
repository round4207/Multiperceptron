namespace MultiPerceptron
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.trainingSetBtn = new System.Windows.Forms.Button();
            this.testSetBtn = new System.Windows.Forms.Button();
            this.topologyField = new System.Windows.Forms.TextBox();
            this.iterationField = new System.Windows.Forms.NumericUpDown();
            this.biasField = new System.Windows.Forms.TextBox();
            this.biasWeightField = new System.Windows.Forms.TextBox();
            this.learningField = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.validateBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.trainingFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.testFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.windowField = new System.Windows.Forms.TextBox();
            this.vdfdg = new System.Windows.Forms.Label();
            this.trainingLabel = new System.Windows.Forms.Label();
            this.testLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.threadField = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.defaultWeightField = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.iterationField)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.threadField)).BeginInit();
            this.SuspendLayout();
            // 
            // trainingSetBtn
            // 
            this.trainingSetBtn.Location = new System.Drawing.Point(109, 22);
            this.trainingSetBtn.Name = "trainingSetBtn";
            this.trainingSetBtn.Size = new System.Drawing.Size(100, 23);
            this.trainingSetBtn.TabIndex = 0;
            this.trainingSetBtn.Text = "training set";
            this.trainingSetBtn.UseVisualStyleBackColor = true;
            this.trainingSetBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // testSetBtn
            // 
            this.testSetBtn.Location = new System.Drawing.Point(109, 59);
            this.testSetBtn.Name = "testSetBtn";
            this.testSetBtn.Size = new System.Drawing.Size(100, 23);
            this.testSetBtn.TabIndex = 1;
            this.testSetBtn.Text = "test set";
            this.testSetBtn.UseVisualStyleBackColor = true;
            this.testSetBtn.Click += new System.EventHandler(this.button2_Click);
            // 
            // topologyField
            // 
            this.topologyField.Location = new System.Drawing.Point(109, 285);
            this.topologyField.Name = "topologyField";
            this.topologyField.Size = new System.Drawing.Size(100, 20);
            this.topologyField.TabIndex = 5;
            // 
            // iterationField
            // 
            this.iterationField.Location = new System.Drawing.Point(109, 249);
            this.iterationField.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.iterationField.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.iterationField.Name = "iterationField";
            this.iterationField.Size = new System.Drawing.Size(100, 20);
            this.iterationField.TabIndex = 6;
            this.iterationField.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // biasField
            // 
            this.biasField.Location = new System.Drawing.Point(109, 137);
            this.biasField.Name = "biasField";
            this.biasField.Size = new System.Drawing.Size(100, 20);
            this.biasField.TabIndex = 7;
            this.biasField.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.double_KeyPress);
            // 
            // biasWeightField
            // 
            this.biasWeightField.Location = new System.Drawing.Point(109, 164);
            this.biasWeightField.Name = "biasWeightField";
            this.biasWeightField.Size = new System.Drawing.Size(100, 20);
            this.biasWeightField.TabIndex = 8;
            this.biasWeightField.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.double_KeyPress);
            // 
            // learningField
            // 
            this.learningField.Location = new System.Drawing.Point(109, 223);
            this.learningField.Name = "learningField";
            this.learningField.Size = new System.Drawing.Size(100, 20);
            this.learningField.TabIndex = 9;
            this.learningField.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.double_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Bias Value";
            // 
            // validateBtn
            // 
            this.validateBtn.Location = new System.Drawing.Point(109, 367);
            this.validateBtn.Name = "validateBtn";
            this.validateBtn.Size = new System.Drawing.Size(100, 23);
            this.validateBtn.TabIndex = 11;
            this.validateBtn.Text = "VALIDATE ME";
            this.validateBtn.UseVisualStyleBackColor = true;
            this.validateBtn.Click += new System.EventHandler(this.button3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 167);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Bias Weight";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 226);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Learning Rate";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 251);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Iterations";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 288);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Topology";
            // 
            // trainingFileDialog
            // 
            this.trainingFileDialog.FileName = "openFileDialog1";
            // 
            // testFileDialog
            // 
            this.testFileDialog.FileName = "openFileDialog1";
            // 
            // windowField
            // 
            this.windowField.Location = new System.Drawing.Point(109, 96);
            this.windowField.Name = "windowField";
            this.windowField.Size = new System.Drawing.Size(100, 20);
            this.windowField.TabIndex = 16;
            this.windowField.Visible = false;
            this.windowField.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.integer_KeyPress);
            // 
            // vdfdg
            // 
            this.vdfdg.AutoSize = true;
            this.vdfdg.Location = new System.Drawing.Point(10, 99);
            this.vdfdg.Name = "vdfdg";
            this.vdfdg.Size = new System.Drawing.Size(85, 13);
            this.vdfdg.TabIndex = 17;
            this.vdfdg.Text = "Window Amount";
            this.vdfdg.Visible = false;
            // 
            // trainingLabel
            // 
            this.trainingLabel.Location = new System.Drawing.Point(10, 27);
            this.trainingLabel.Name = "trainingLabel";
            this.trainingLabel.Size = new System.Drawing.Size(93, 18);
            this.trainingLabel.TabIndex = 0;
            this.trainingLabel.Text = "Training loc";
            // 
            // testLabel
            // 
            this.testLabel.AutoSize = true;
            this.testLabel.Location = new System.Drawing.Point(10, 64);
            this.testLabel.Name = "testLabel";
            this.testLabel.Size = new System.Drawing.Size(45, 13);
            this.testLabel.TabIndex = 20;
            this.testLabel.Text = "Test loc";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 111);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "(including Y)";
            this.label7.Visible = false;
            // 
            // threadField
            // 
            this.threadField.Location = new System.Drawing.Point(109, 327);
            this.threadField.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.threadField.Name = "threadField";
            this.threadField.Size = new System.Drawing.Size(100, 20);
            this.threadField.TabIndex = 22;
            this.threadField.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 329);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "# of Threads";
            // 
            // defaultWeightField
            // 
            this.defaultWeightField.Location = new System.Drawing.Point(109, 197);
            this.defaultWeightField.Name = "defaultWeightField";
            this.defaultWeightField.Size = new System.Drawing.Size(100, 20);
            this.defaultWeightField.TabIndex = 24;
            this.defaultWeightField.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.double_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 200);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 13);
            this.label8.TabIndex = 25;
            this.label8.Text = "Default Weight";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(223, 397);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.defaultWeightField);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.threadField);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.testLabel);
            this.Controls.Add(this.trainingLabel);
            this.Controls.Add(this.vdfdg);
            this.Controls.Add(this.windowField);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.validateBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.learningField);
            this.Controls.Add(this.biasWeightField);
            this.Controls.Add(this.biasField);
            this.Controls.Add(this.iterationField);
            this.Controls.Add(this.topologyField);
            this.Controls.Add(this.testSetBtn);
            this.Controls.Add(this.trainingSetBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.iterationField)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.threadField)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button trainingSetBtn;
        private System.Windows.Forms.Button testSetBtn;
        private System.Windows.Forms.TextBox topologyField;
        private System.Windows.Forms.NumericUpDown iterationField;
        private System.Windows.Forms.TextBox biasField;
        private System.Windows.Forms.TextBox biasWeightField;
        private System.Windows.Forms.TextBox learningField;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button validateBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.OpenFileDialog trainingFileDialog;
        private System.Windows.Forms.OpenFileDialog testFileDialog;
        private System.Windows.Forms.TextBox windowField;
        private System.Windows.Forms.Label vdfdg;
        private System.Windows.Forms.Label trainingLabel;
        private System.Windows.Forms.Label testLabel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown threadField;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox defaultWeightField;
        private System.Windows.Forms.Label label8;
    }
}

