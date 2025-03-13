namespace Attacco_difesa
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
            progressBarG1 = new ProgressBar();
            buttonStart = new Button();
            progressBarG2 = new ProgressBar();
            labelName1 = new Label();
            labelRole1 = new Label();
            labelRole2 = new Label();
            labelName2 = new Label();
            labelFerita1 = new Label();
            labelFerita2 = new Label();
            listBoxAttaccanti = new ListBox();
            listBoxDifensori = new ListBox();
            labelAtt1 = new Label();
            labelAtt2 = new Label();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // progressBarG1
            // 
            progressBarG1.BackColor = Color.Chartreuse;
            progressBarG1.Location = new Point(68, 117);
            progressBarG1.Name = "progressBarG1";
            progressBarG1.Size = new Size(179, 23);
            progressBarG1.TabIndex = 0;
            // 
            // buttonStart
            // 
            buttonStart.Location = new Point(713, 12);
            buttonStart.Name = "buttonStart";
            buttonStart.Size = new Size(75, 23);
            buttonStart.TabIndex = 1;
            buttonStart.Text = "START";
            buttonStart.UseVisualStyleBackColor = true;
            buttonStart.Click += button1_Click;
            // 
            // progressBarG2
            // 
            progressBarG2.Location = new Point(412, 117);
            progressBarG2.Name = "progressBarG2";
            progressBarG2.Size = new Size(179, 23);
            progressBarG2.TabIndex = 2;
            // 
            // labelName1
            // 
            labelName1.AutoSize = true;
            labelName1.Location = new Point(68, 54);
            labelName1.Name = "labelName1";
            labelName1.Size = new Size(12, 15);
            labelName1.TabIndex = 3;
            labelName1.Text = "-";
            // 
            // labelRole1
            // 
            labelRole1.AutoSize = true;
            labelRole1.Location = new Point(68, 86);
            labelRole1.Name = "labelRole1";
            labelRole1.Size = new Size(12, 15);
            labelRole1.TabIndex = 4;
            labelRole1.Text = "-";
            // 
            // labelRole2
            // 
            labelRole2.AutoSize = true;
            labelRole2.Location = new Point(412, 86);
            labelRole2.Name = "labelRole2";
            labelRole2.Size = new Size(12, 15);
            labelRole2.TabIndex = 6;
            labelRole2.Text = "-";
            // 
            // labelName2
            // 
            labelName2.AutoSize = true;
            labelName2.Location = new Point(412, 54);
            labelName2.Name = "labelName2";
            labelName2.Size = new Size(12, 15);
            labelName2.TabIndex = 5;
            labelName2.Text = "-";
            // 
            // labelFerita1
            // 
            labelFerita1.AutoSize = true;
            labelFerita1.Location = new Point(253, 125);
            labelFerita1.Name = "labelFerita1";
            labelFerita1.Size = new Size(12, 15);
            labelFerita1.TabIndex = 7;
            labelFerita1.Text = "-";
            // 
            // labelFerita2
            // 
            labelFerita2.AutoSize = true;
            labelFerita2.Location = new Point(607, 125);
            labelFerita2.Name = "labelFerita2";
            labelFerita2.Size = new Size(12, 15);
            labelFerita2.TabIndex = 8;
            labelFerita2.Text = "-";
            // 
            // listBoxAttaccanti
            // 
            listBoxAttaccanti.FormattingEnabled = true;
            listBoxAttaccanti.ItemHeight = 15;
            listBoxAttaccanti.Location = new Point(412, 284);
            listBoxAttaccanti.Name = "listBoxAttaccanti";
            listBoxAttaccanti.Size = new Size(134, 154);
            listBoxAttaccanti.TabIndex = 9;
            // 
            // listBoxDifensori
            // 
            listBoxDifensori.FormattingEnabled = true;
            listBoxDifensori.ItemHeight = 15;
            listBoxDifensori.Location = new Point(624, 284);
            listBoxDifensori.Name = "listBoxDifensori";
            listBoxDifensori.Size = new Size(134, 154);
            listBoxDifensori.TabIndex = 10;
            // 
            // labelAtt1
            // 
            labelAtt1.AutoSize = true;
            labelAtt1.Location = new Point(209, 160);
            labelAtt1.Name = "labelAtt1";
            labelAtt1.Size = new Size(12, 15);
            labelAtt1.TabIndex = 11;
            labelAtt1.Text = "-";
            // 
            // labelAtt2
            // 
            labelAtt2.AutoSize = true;
            labelAtt2.Location = new Point(553, 160);
            labelAtt2.Name = "labelAtt2";
            labelAtt2.Size = new Size(12, 15);
            labelAtt2.TabIndex = 12;
            labelAtt2.Text = "-";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(68, 160);
            label1.Name = "label1";
            label1.Size = new Size(91, 15);
            label1.TabIndex = 13;
            label1.Text = "Attacco sferrato";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(412, 160);
            label2.Name = "label2";
            label2.Size = new Size(91, 15);
            label2.TabIndex = 14;
            label2.Text = "Attacco sferrato";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(labelAtt2);
            Controls.Add(labelAtt1);
            Controls.Add(listBoxDifensori);
            Controls.Add(listBoxAttaccanti);
            Controls.Add(labelFerita2);
            Controls.Add(labelFerita1);
            Controls.Add(labelRole2);
            Controls.Add(labelName2);
            Controls.Add(labelRole1);
            Controls.Add(labelName1);
            Controls.Add(progressBarG2);
            Controls.Add(buttonStart);
            Controls.Add(progressBarG1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ProgressBar progressBarG1;
        private Button buttonStart;
        private ProgressBar progressBarG2;
        private Label labelName1;
        private Label labelRole1;
        private Label labelRole2;
        private Label labelName2;
        private Label labelFerita1;
        private Label labelFerita2;
        private ListBox listBoxAttaccanti;
        private ListBox listBoxDifensori;
        private Label labelAtt1;
        private Label labelAtt2;
        private Label label1;
        private Label label2;
    }
}
