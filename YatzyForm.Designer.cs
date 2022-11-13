namespace yatzy_project;

partial class YatzyForm
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
            this.diceWindow = new System.Windows.Forms.Panel();
            this.throwDice_btn = new System.Windows.Forms.Button();
            this.allowedNumberOfThrows = new System.Windows.Forms.Label();
            this.diceResultsWindow = new System.Windows.Forms.Panel();
            this.diceButton1 = new System.Windows.Forms.PictureBox();
            this.diceButton2 = new System.Windows.Forms.PictureBox();
            this.diceButton3 = new System.Windows.Forms.PictureBox();
            this.diceButton4 = new System.Windows.Forms.PictureBox();
            this.diceButton5 = new System.Windows.Forms.PictureBox();
            this.diceResultsWindow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.diceButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.diceButton2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.diceButton3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.diceButton4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.diceButton5)).BeginInit();
            this.SuspendLayout();
            // 
            // diceWindow
            // 
            this.diceWindow.Visible = false;
            this.diceWindow.Dock = System.Windows.Forms.DockStyle.Top;
            this.diceWindow.Location = new System.Drawing.Point(0, 0);
            this.diceWindow.Name = "diceWindow";
            this.diceWindow.Size = new System.Drawing.Size(654, 404);
            this.diceWindow.TabIndex = 0;
            this.diceWindow.Paint += new System.Windows.Forms.PaintEventHandler(this.diceWindow_Paint);
            // 
            // throwDice_btn
            // 
            this.throwDice_btn.Location = new System.Drawing.Point(482, 484);
            this.throwDice_btn.Name = "throwDice_btn";
            this.throwDice_btn.Size = new System.Drawing.Size(98, 46);
            this.throwDice_btn.TabIndex = 1;
            this.throwDice_btn.Text = "Heitä";
            this.throwDice_btn.UseVisualStyleBackColor = true;
            this.throwDice_btn.Click += new System.EventHandler(this.throwDice_btn_Click);
            // 
            // allowedNumberOfThrows
            // 
            this.allowedNumberOfThrows.AutoSize = true;
            this.allowedNumberOfThrows.Font = new System.Drawing.Font("Arial", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.allowedNumberOfThrows.Location = new System.Drawing.Point(586, 490);
            this.allowedNumberOfThrows.Name = "allowedNumberOfThrows";
            this.allowedNumberOfThrows.Size = new System.Drawing.Size(31, 33);
            this.allowedNumberOfThrows.TabIndex = 2;
            this.allowedNumberOfThrows.Text = "3";
            // 
            // diceResultsWindow
            // 
            this.diceResultsWindow.Controls.Add(this.diceButton1);
            this.diceResultsWindow.Controls.Add(this.diceButton2);
            this.diceResultsWindow.Controls.Add(this.diceButton3);
            this.diceResultsWindow.Controls.Add(this.diceButton4);
            this.diceResultsWindow.Controls.Add(this.diceButton5);
            this.diceResultsWindow.Location = new System.Drawing.Point(9, 457);
            this.diceResultsWindow.Name = "diceResultsWindow";
            this.diceResultsWindow.Size = new System.Drawing.Size(470, 100);
            this.diceResultsWindow.TabIndex = 3;
            this.diceResultsWindow.Paint += new System.Windows.Forms.PaintEventHandler(this.highlightSelected_Paint);
            // 
            // diceButton1
            // 
            this.diceButton1.Enabled = false;
            this.diceButton1.Location = new System.Drawing.Point(13, 12);
            this.diceButton1.Name = "diceButton1";
            this.diceButton1.Size = new System.Drawing.Size(75, 75);
            this.diceButton1.TabIndex = 0;
            this.diceButton1.TabStop = false;
            this.diceButton1.Click += new System.EventHandler(this.diceButton1_Click);
            this.diceButton1.Paint += new System.Windows.Forms.PaintEventHandler(this.diceButton1_Paint);
            // 
            // diceButton2
            // 
            this.diceButton2.Enabled = false;
            this.diceButton2.Location = new System.Drawing.Point(105, 12);
            this.diceButton2.Name = "diceButton2";
            this.diceButton2.Size = new System.Drawing.Size(75, 75);
            this.diceButton2.TabIndex = 0;
            this.diceButton2.TabStop = false;
            this.diceButton2.Click += new System.EventHandler(this.diceButton2_Click);
            this.diceButton2.Paint += new System.Windows.Forms.PaintEventHandler(this.diceButton2_Paint);
            // 
            // diceButton3
            // 
            this.diceButton3.Enabled = false;
            this.diceButton3.Location = new System.Drawing.Point(197, 12);
            this.diceButton3.Name = "diceButton3";
            this.diceButton3.Size = new System.Drawing.Size(75, 75);
            this.diceButton3.TabIndex = 0;
            this.diceButton3.TabStop = false;
            this.diceButton3.Click += new System.EventHandler(this.diceButton3_Click);
            this.diceButton3.Paint += new System.Windows.Forms.PaintEventHandler(this.diceButton3_Paint);
            // 
            // diceButton4
            // 
            this.diceButton4.Enabled = false;
            this.diceButton4.Location = new System.Drawing.Point(289, 12);
            this.diceButton4.Name = "diceButton4";
            this.diceButton4.Size = new System.Drawing.Size(75, 75);
            this.diceButton4.TabIndex = 0;
            this.diceButton4.TabStop = false;
            this.diceButton4.Click += new System.EventHandler(this.diceButton4_Click);
            this.diceButton4.Paint += new System.Windows.Forms.PaintEventHandler(this.diceButton4_Paint);
            // 
            // diceButton5
            // 
            this.diceButton5.Enabled = false;
            this.diceButton5.Location = new System.Drawing.Point(381, 12);
            this.diceButton5.Name = "diceButton5";
            this.diceButton5.Size = new System.Drawing.Size(75, 75);
            this.diceButton5.TabIndex = 0;
            this.diceButton5.TabStop = false;
            this.diceButton5.Click += new System.EventHandler(this.diceButton5_Click);
            this.diceButton5.Paint += new System.Windows.Forms.PaintEventHandler(this.diceButton5_Paint);
            // 
            // YatzyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 651);
            this.Controls.Add(this.diceResultsWindow);
            this.Controls.Add(this.allowedNumberOfThrows);
            this.Controls.Add(this.throwDice_btn);
            this.Controls.Add(this.diceWindow);
            this.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "YatzyForm";
            this.Text = "Yatzy";
            this.diceResultsWindow.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.diceButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.diceButton2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.diceButton3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.diceButton4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.diceButton5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private Panel diceWindow;
    private Button throwDice_btn;
    private Label allowedNumberOfThrows;
    private Panel diceResultsWindow;
    private PictureBox diceButton1;
    private PictureBox diceButton2;
    private PictureBox diceButton3;
    private PictureBox diceButton4;
    private PictureBox diceButton5;
    
}
