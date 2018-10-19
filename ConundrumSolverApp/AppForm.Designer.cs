namespace ApplicationForm
{
    partial class AppForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtBoxInput = new System.Windows.Forms.TextBox();
            this.btnSolve = new System.Windows.Forms.Button();
            this.listSolvedWords = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDefinitions = new System.Windows.Forms.TextBox();
            this.lblTimer = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Input:";
            // 
            // txtBoxInput
            // 
            this.txtBoxInput.Location = new System.Drawing.Point(58, 6);
            this.txtBoxInput.Name = "txtBoxInput";
            this.txtBoxInput.Size = new System.Drawing.Size(100, 20);
            this.txtBoxInput.TabIndex = 1;
            // 
            // btnSolve
            // 
            this.btnSolve.Location = new System.Drawing.Point(164, 6);
            this.btnSolve.Name = "btnSolve";
            this.btnSolve.Size = new System.Drawing.Size(75, 23);
            this.btnSolve.TabIndex = 2;
            this.btnSolve.Text = "Solve";
            this.btnSolve.UseVisualStyleBackColor = true;
            this.btnSolve.Click += new System.EventHandler(this.btnSolve_Click);
            // 
            // listSolvedWords
            // 
            this.listSolvedWords.FormattingEnabled = true;
            this.listSolvedWords.Location = new System.Drawing.Point(58, 43);
            this.listSolvedWords.Name = "listSolvedWords";
            this.listSolvedWords.Size = new System.Drawing.Size(181, 251);
            this.listSolvedWords.TabIndex = 3;
            this.listSolvedWords.SelectedIndexChanged += new System.EventHandler(this.listSolvedWords_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Words:";
            // 
            // txtDefinitions
            // 
            this.txtDefinitions.Location = new System.Drawing.Point(245, 43);
            this.txtDefinitions.Multiline = true;
            this.txtDefinitions.Name = "txtDefinitions";
            this.txtDefinitions.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDefinitions.Size = new System.Drawing.Size(201, 251);
            this.txtDefinitions.TabIndex = 6;
            this.txtDefinitions.Text = "Select a word to see its definitions";
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.Location = new System.Drawing.Point(245, 11);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(0, 13);
            this.lblTimer.TabIndex = 7;
            // 
            // AppForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 306);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.txtDefinitions);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listSolvedWords);
            this.Controls.Add(this.btnSolve);
            this.Controls.Add(this.txtBoxInput);
            this.Controls.Add(this.label1);
            this.Name = "AppForm";
            this.Text = "Conundrum Solver";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBoxInput;
        private System.Windows.Forms.Button btnSolve;
        private System.Windows.Forms.ListBox listSolvedWords;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDefinitions;
        private System.Windows.Forms.Label lblTimer;
    }
}

