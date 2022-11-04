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
            this.diceWindow = new System.Windows.Forms.GroupBox();
            this.throwDice_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // diceWindow
            // 
            this.diceWindow.Dock = System.Windows.Forms.DockStyle.Top;
            this.diceWindow.Location = new System.Drawing.Point(0, 0);
            this.diceWindow.Name = "diceWindow";
            this.diceWindow.Size = new System.Drawing.Size(654, 404);
            this.diceWindow.TabIndex = 0;
            this.diceWindow.TabStop = false;
            this.diceWindow.Paint += new System.Windows.Forms.PaintEventHandler(this.diceWindow_Paint);
            // 
            // throwDice_btn
            // 
            this.throwDice_btn.Location = new System.Drawing.Point(505, 484);
            this.throwDice_btn.Name = "throwDice_btn";
            this.throwDice_btn.Size = new System.Drawing.Size(98, 46);
            this.throwDice_btn.TabIndex = 1;
            this.throwDice_btn.Text = "Heitä";
            this.throwDice_btn.UseVisualStyleBackColor = true;
            this.throwDice_btn.Click += new System.EventHandler(this.throwDice_btn_Click);
            // 
            // YatzyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 651);
            this.Controls.Add(this.throwDice_btn);
            this.Controls.Add(this.diceWindow);
            this.Font = new System.Drawing.Font("Helvetica", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "YatzyForm";
            this.Text = "Yatzy";
            this.ResumeLayout(false);

    }

    #endregion

    private GroupBox diceWindow;
    private Button throwDice_btn;
}
