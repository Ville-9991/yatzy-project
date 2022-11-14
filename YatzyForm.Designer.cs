﻿namespace yatzy_project;

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
            this.acceptResults_btn = new System.Windows.Forms.Button();
            this.upperRecordContainer_Panel = new System.Windows.Forms.Panel();
            this.valisummaLabel = new System.Windows.Forms.Label();
            this.bonusLabel = new System.Windows.Forms.Label();
            this.ykkoset_resultsLabel = new System.Windows.Forms.Label();
            this.kakkoset_resultsLabel = new System.Windows.Forms.Label();
            this.kolmoset_resultsLabel = new System.Windows.Forms.Label();
            this.neloset_resultsLabel = new System.Windows.Forms.Label();
            this.viitoset_resultsLabel = new System.Windows.Forms.Label();
            this.kuutoset_resultsLabel = new System.Windows.Forms.Label();
            this.valisumma_resultsLabel = new System.Windows.Forms.Label();
            this.bonus_resultsLabel = new System.Windows.Forms.Label();
            this.upperCategories_Panel = new System.Windows.Forms.Panel();
            this.ykkosetLabel = new System.Windows.Forms.Label();
            this.kakkosetLabel = new System.Windows.Forms.Label();
            this.kolmosetLabel = new System.Windows.Forms.Label();
            this.nelosetLabel = new System.Windows.Forms.Label();
            this.viitosetLabel = new System.Windows.Forms.Label();
            this.kuutosetLabel = new System.Windows.Forms.Label();
            this.bottomRecordContainer_Panel = new System.Windows.Forms.Panel();
            this.pari_resultsLabel = new System.Windows.Forms.Label();
            this.kaksi_paria_resultsLabel = new System.Windows.Forms.Label();
            this.kolme_samaa_resultsLabel = new System.Windows.Forms.Label();
            this.nelja_samaa_resultsLabel = new System.Windows.Forms.Label();
            this.pieni_suora_resultsLabel = new System.Windows.Forms.Label();
            this.iso_suora_resultsLabel = new System.Windows.Forms.Label();
            this.tayskasi_resultsLabel = new System.Windows.Forms.Label();
            this.sattuma_resultsLabel = new System.Windows.Forms.Label();
            this.yatzy_resultsLabel = new System.Windows.Forms.Label();
            this.summa_resultsLabel = new System.Windows.Forms.Label();
            this.pariLabel = new System.Windows.Forms.Label();
            this.kaksi_pariaLabel = new System.Windows.Forms.Label();
            this.kolme_samaaLabel = new System.Windows.Forms.Label();
            this.nelja_samaaLabel = new System.Windows.Forms.Label();
            this.pieni_suoraLabel = new System.Windows.Forms.Label();
            this.iso_suoraLabel = new System.Windows.Forms.Label();
            this.tayskasiLabel = new System.Windows.Forms.Label();
            this.sattumaLabel = new System.Windows.Forms.Label();
            this.summaLabel = new System.Windows.Forms.Label();
            this.combinationsPanel = new System.Windows.Forms.Panel();
            this.bottomCategories_Panel = new System.Windows.Forms.Panel();
            this.yatzyLabel = new System.Windows.Forms.Label();
            this.diceResultsWindow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.diceButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.diceButton2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.diceButton3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.diceButton4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.diceButton5)).BeginInit();
            this.upperRecordContainer_Panel.SuspendLayout();
            this.upperCategories_Panel.SuspendLayout();
            this.bottomRecordContainer_Panel.SuspendLayout();
            this.combinationsPanel.SuspendLayout();
            this.bottomCategories_Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // diceWindow
            // 
            this.diceWindow.Location = new System.Drawing.Point(0, 0);
            this.diceWindow.Name = "diceWindow";
            this.diceWindow.Size = new System.Drawing.Size(654, 404);
            this.diceWindow.TabIndex = 0;
            this.diceWindow.Visible = false;
            this.diceWindow.Paint += new System.Windows.Forms.PaintEventHandler(this.diceWindow_Paint);
            // 
            // throwDice_btn
            // 
            this.throwDice_btn.Font = new System.Drawing.Font("Helvetica", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.throwDice_btn.Location = new System.Drawing.Point(482, 454);
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
            this.allowedNumberOfThrows.Location = new System.Drawing.Point(586, 460);
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
            // acceptResults_btn
            // 
            this.acceptResults_btn.Font = new System.Drawing.Font("Helvetica", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.acceptResults_btn.Location = new System.Drawing.Point(482, 506);
            this.acceptResults_btn.Name = "acceptResults_btn";
            this.acceptResults_btn.Size = new System.Drawing.Size(98, 57);
            this.acceptResults_btn.TabIndex = 1;
            this.acceptResults_btn.Text = "Hyväksy tulos";
            this.acceptResults_btn.UseVisualStyleBackColor = true;
            // 
            // upperRecordContainer_Panel
            // 
            this.upperRecordContainer_Panel.Controls.Add(this.upperCategories_Panel);
            this.upperRecordContainer_Panel.Controls.Add(this.bonus_resultsLabel);
            this.upperRecordContainer_Panel.Controls.Add(this.valisumma_resultsLabel);
            this.upperRecordContainer_Panel.Controls.Add(this.kuutoset_resultsLabel);
            this.upperRecordContainer_Panel.Controls.Add(this.viitoset_resultsLabel);
            this.upperRecordContainer_Panel.Controls.Add(this.neloset_resultsLabel);
            this.upperRecordContainer_Panel.Controls.Add(this.kolmoset_resultsLabel);
            this.upperRecordContainer_Panel.Controls.Add(this.kakkoset_resultsLabel);
            this.upperRecordContainer_Panel.Controls.Add(this.ykkoset_resultsLabel);
            this.upperRecordContainer_Panel.Controls.Add(this.bonusLabel);
            this.upperRecordContainer_Panel.Controls.Add(this.valisummaLabel);
            this.upperRecordContainer_Panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.upperRecordContainer_Panel.Location = new System.Drawing.Point(0, 0);
            this.upperRecordContainer_Panel.Name = "upperRecordContainer_Panel";
            this.upperRecordContainer_Panel.Size = new System.Drawing.Size(507, 288);
            this.upperRecordContainer_Panel.TabIndex = 23;
            // 
            // valisummaLabel
            // 
            this.valisummaLabel.AutoSize = true;
            this.valisummaLabel.Font = new System.Drawing.Font("Helvetica", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.valisummaLabel.Location = new System.Drawing.Point(12, 213);
            this.valisummaLabel.Name = "valisummaLabel";
            this.valisummaLabel.Size = new System.Drawing.Size(160, 32);
            this.valisummaLabel.TabIndex = 27;
            this.valisummaLabel.Text = "Välisumma";
            // 
            // bonusLabel
            // 
            this.bonusLabel.AutoSize = true;
            this.bonusLabel.Font = new System.Drawing.Font("Helvetica", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.bonusLabel.Location = new System.Drawing.Point(12, 245);
            this.bonusLabel.Name = "bonusLabel";
            this.bonusLabel.Size = new System.Drawing.Size(439, 32);
            this.bonusLabel.TabIndex = 28;
            this.bonusLabel.Text = "Bonus (63 pistettä tai enemmän)";
            // 
            // ykkoset_resultsLabel
            // 
            this.ykkoset_resultsLabel.AutoSize = true;
            this.ykkoset_resultsLabel.Font = new System.Drawing.Font("Helvetica", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ykkoset_resultsLabel.Location = new System.Drawing.Point(467, 11);
            this.ykkoset_resultsLabel.Name = "ykkoset_resultsLabel";
            this.ykkoset_resultsLabel.Size = new System.Drawing.Size(29, 32);
            this.ykkoset_resultsLabel.TabIndex = 38;
            this.ykkoset_resultsLabel.Text = "0";
            // 
            // kakkoset_resultsLabel
            // 
            this.kakkoset_resultsLabel.AutoSize = true;
            this.kakkoset_resultsLabel.Font = new System.Drawing.Font("Helvetica", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.kakkoset_resultsLabel.Location = new System.Drawing.Point(467, 43);
            this.kakkoset_resultsLabel.Name = "kakkoset_resultsLabel";
            this.kakkoset_resultsLabel.Size = new System.Drawing.Size(29, 32);
            this.kakkoset_resultsLabel.TabIndex = 37;
            this.kakkoset_resultsLabel.Text = "0";
            // 
            // kolmoset_resultsLabel
            // 
            this.kolmoset_resultsLabel.AutoSize = true;
            this.kolmoset_resultsLabel.Font = new System.Drawing.Font("Helvetica", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.kolmoset_resultsLabel.Location = new System.Drawing.Point(467, 75);
            this.kolmoset_resultsLabel.Name = "kolmoset_resultsLabel";
            this.kolmoset_resultsLabel.Size = new System.Drawing.Size(29, 32);
            this.kolmoset_resultsLabel.TabIndex = 36;
            this.kolmoset_resultsLabel.Text = "0";
            // 
            // neloset_resultsLabel
            // 
            this.neloset_resultsLabel.AutoSize = true;
            this.neloset_resultsLabel.Font = new System.Drawing.Font("Helvetica", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.neloset_resultsLabel.Location = new System.Drawing.Point(467, 107);
            this.neloset_resultsLabel.Name = "neloset_resultsLabel";
            this.neloset_resultsLabel.Size = new System.Drawing.Size(29, 32);
            this.neloset_resultsLabel.TabIndex = 35;
            this.neloset_resultsLabel.Text = "0";
            // 
            // viitoset_resultsLabel
            // 
            this.viitoset_resultsLabel.AutoSize = true;
            this.viitoset_resultsLabel.Font = new System.Drawing.Font("Helvetica", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.viitoset_resultsLabel.Location = new System.Drawing.Point(467, 139);
            this.viitoset_resultsLabel.Name = "viitoset_resultsLabel";
            this.viitoset_resultsLabel.Size = new System.Drawing.Size(29, 32);
            this.viitoset_resultsLabel.TabIndex = 34;
            this.viitoset_resultsLabel.Text = "0";
            // 
            // kuutoset_resultsLabel
            // 
            this.kuutoset_resultsLabel.AutoSize = true;
            this.kuutoset_resultsLabel.Font = new System.Drawing.Font("Helvetica", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.kuutoset_resultsLabel.Location = new System.Drawing.Point(467, 171);
            this.kuutoset_resultsLabel.Name = "kuutoset_resultsLabel";
            this.kuutoset_resultsLabel.Size = new System.Drawing.Size(29, 32);
            this.kuutoset_resultsLabel.TabIndex = 33;
            this.kuutoset_resultsLabel.Text = "0";
            // 
            // valisumma_resultsLabel
            // 
            this.valisumma_resultsLabel.AutoSize = true;
            this.valisumma_resultsLabel.Font = new System.Drawing.Font("Helvetica", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.valisumma_resultsLabel.Location = new System.Drawing.Point(467, 213);
            this.valisumma_resultsLabel.Name = "valisumma_resultsLabel";
            this.valisumma_resultsLabel.Size = new System.Drawing.Size(29, 32);
            this.valisumma_resultsLabel.TabIndex = 32;
            this.valisumma_resultsLabel.Text = "0";
            // 
            // bonus_resultsLabel
            // 
            this.bonus_resultsLabel.AutoSize = true;
            this.bonus_resultsLabel.Font = new System.Drawing.Font("Helvetica", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.bonus_resultsLabel.Location = new System.Drawing.Point(467, 245);
            this.bonus_resultsLabel.Name = "bonus_resultsLabel";
            this.bonus_resultsLabel.Size = new System.Drawing.Size(29, 32);
            this.bonus_resultsLabel.TabIndex = 31;
            this.bonus_resultsLabel.Text = "0";
            // 
            // upperCategories_Panel
            // 
            this.upperCategories_Panel.Controls.Add(this.ykkosetLabel);
            this.upperCategories_Panel.Controls.Add(this.kakkosetLabel);
            this.upperCategories_Panel.Controls.Add(this.kolmosetLabel);
            this.upperCategories_Panel.Controls.Add(this.nelosetLabel);
            this.upperCategories_Panel.Controls.Add(this.viitosetLabel);
            this.upperCategories_Panel.Controls.Add(this.kuutosetLabel);
            this.upperCategories_Panel.Location = new System.Drawing.Point(0, 0);
            this.upperCategories_Panel.Name = "upperCategories_Panel";
            this.upperCategories_Panel.Size = new System.Drawing.Size(201, 216);
            this.upperCategories_Panel.TabIndex = 39;
            // 
            // ykkosetLabel
            // 
            this.ykkosetLabel.AutoSize = true;
            this.ykkosetLabel.Font = new System.Drawing.Font("Helvetica", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ykkosetLabel.Location = new System.Drawing.Point(12, 12);
            this.ykkosetLabel.Name = "ykkosetLabel";
            this.ykkosetLabel.Size = new System.Drawing.Size(120, 32);
            this.ykkosetLabel.TabIndex = 36;
            this.ykkosetLabel.Text = "Ykköset";
            // 
            // kakkosetLabel
            // 
            this.kakkosetLabel.AutoSize = true;
            this.kakkosetLabel.Font = new System.Drawing.Font("Helvetica", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.kakkosetLabel.Location = new System.Drawing.Point(12, 44);
            this.kakkosetLabel.Name = "kakkosetLabel";
            this.kakkosetLabel.Size = new System.Drawing.Size(135, 32);
            this.kakkosetLabel.TabIndex = 35;
            this.kakkosetLabel.Text = "Kakkoset";
            // 
            // kolmosetLabel
            // 
            this.kolmosetLabel.AutoSize = true;
            this.kolmosetLabel.Font = new System.Drawing.Font("Helvetica", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.kolmosetLabel.Location = new System.Drawing.Point(12, 76);
            this.kolmosetLabel.Name = "kolmosetLabel";
            this.kolmosetLabel.Size = new System.Drawing.Size(139, 32);
            this.kolmosetLabel.TabIndex = 31;
            this.kolmosetLabel.Text = "Kolmoset";
            // 
            // nelosetLabel
            // 
            this.nelosetLabel.AutoSize = true;
            this.nelosetLabel.Font = new System.Drawing.Font("Helvetica", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.nelosetLabel.Location = new System.Drawing.Point(12, 108);
            this.nelosetLabel.Name = "nelosetLabel";
            this.nelosetLabel.Size = new System.Drawing.Size(115, 32);
            this.nelosetLabel.TabIndex = 32;
            this.nelosetLabel.Text = "Neloset";
            // 
            // viitosetLabel
            // 
            this.viitosetLabel.AutoSize = true;
            this.viitosetLabel.Font = new System.Drawing.Font("Helvetica", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.viitosetLabel.Location = new System.Drawing.Point(12, 140);
            this.viitosetLabel.Name = "viitosetLabel";
            this.viitosetLabel.Size = new System.Drawing.Size(116, 32);
            this.viitosetLabel.TabIndex = 33;
            this.viitosetLabel.Text = "Viitoset";
            // 
            // kuutosetLabel
            // 
            this.kuutosetLabel.AutoSize = true;
            this.kuutosetLabel.Font = new System.Drawing.Font("Helvetica", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.kuutosetLabel.Location = new System.Drawing.Point(12, 172);
            this.kuutosetLabel.Name = "kuutosetLabel";
            this.kuutosetLabel.Size = new System.Drawing.Size(133, 32);
            this.kuutosetLabel.TabIndex = 34;
            this.kuutosetLabel.Text = "Kuutoset";
            // 
            // bottomRecordContainer_Panel
            // 
            this.bottomRecordContainer_Panel.Controls.Add(this.bottomCategories_Panel);
            this.bottomRecordContainer_Panel.Controls.Add(this.summaLabel);
            this.bottomRecordContainer_Panel.Controls.Add(this.summa_resultsLabel);
            this.bottomRecordContainer_Panel.Controls.Add(this.yatzy_resultsLabel);
            this.bottomRecordContainer_Panel.Controls.Add(this.sattuma_resultsLabel);
            this.bottomRecordContainer_Panel.Controls.Add(this.tayskasi_resultsLabel);
            this.bottomRecordContainer_Panel.Controls.Add(this.iso_suora_resultsLabel);
            this.bottomRecordContainer_Panel.Controls.Add(this.pieni_suora_resultsLabel);
            this.bottomRecordContainer_Panel.Controls.Add(this.nelja_samaa_resultsLabel);
            this.bottomRecordContainer_Panel.Controls.Add(this.kolme_samaa_resultsLabel);
            this.bottomRecordContainer_Panel.Controls.Add(this.kaksi_paria_resultsLabel);
            this.bottomRecordContainer_Panel.Controls.Add(this.pari_resultsLabel);
            this.bottomRecordContainer_Panel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomRecordContainer_Panel.Location = new System.Drawing.Point(0, 294);
            this.bottomRecordContainer_Panel.Name = "bottomRecordContainer_Panel";
            this.bottomRecordContainer_Panel.Size = new System.Drawing.Size(507, 357);
            this.bottomRecordContainer_Panel.TabIndex = 24;
            // 
            // pari_resultsLabel
            // 
            this.pari_resultsLabel.AutoSize = true;
            this.pari_resultsLabel.Font = new System.Drawing.Font("Helvetica", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.pari_resultsLabel.Location = new System.Drawing.Point(466, 13);
            this.pari_resultsLabel.Name = "pari_resultsLabel";
            this.pari_resultsLabel.Size = new System.Drawing.Size(29, 32);
            this.pari_resultsLabel.TabIndex = 42;
            this.pari_resultsLabel.Text = "0";
            // 
            // kaksi_paria_resultsLabel
            // 
            this.kaksi_paria_resultsLabel.AutoSize = true;
            this.kaksi_paria_resultsLabel.Font = new System.Drawing.Font("Helvetica", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.kaksi_paria_resultsLabel.Location = new System.Drawing.Point(466, 45);
            this.kaksi_paria_resultsLabel.Name = "kaksi_paria_resultsLabel";
            this.kaksi_paria_resultsLabel.Size = new System.Drawing.Size(29, 32);
            this.kaksi_paria_resultsLabel.TabIndex = 40;
            this.kaksi_paria_resultsLabel.Text = "0";
            // 
            // kolme_samaa_resultsLabel
            // 
            this.kolme_samaa_resultsLabel.AutoSize = true;
            this.kolme_samaa_resultsLabel.Font = new System.Drawing.Font("Helvetica", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.kolme_samaa_resultsLabel.Location = new System.Drawing.Point(466, 77);
            this.kolme_samaa_resultsLabel.Name = "kolme_samaa_resultsLabel";
            this.kolme_samaa_resultsLabel.Size = new System.Drawing.Size(29, 32);
            this.kolme_samaa_resultsLabel.TabIndex = 33;
            this.kolme_samaa_resultsLabel.Text = "0";
            // 
            // nelja_samaa_resultsLabel
            // 
            this.nelja_samaa_resultsLabel.AutoSize = true;
            this.nelja_samaa_resultsLabel.Font = new System.Drawing.Font("Helvetica", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.nelja_samaa_resultsLabel.Location = new System.Drawing.Point(466, 109);
            this.nelja_samaa_resultsLabel.Name = "nelja_samaa_resultsLabel";
            this.nelja_samaa_resultsLabel.Size = new System.Drawing.Size(29, 32);
            this.nelja_samaa_resultsLabel.TabIndex = 34;
            this.nelja_samaa_resultsLabel.Text = "0";
            // 
            // pieni_suora_resultsLabel
            // 
            this.pieni_suora_resultsLabel.AutoSize = true;
            this.pieni_suora_resultsLabel.Font = new System.Drawing.Font("Helvetica", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.pieni_suora_resultsLabel.Location = new System.Drawing.Point(466, 141);
            this.pieni_suora_resultsLabel.Name = "pieni_suora_resultsLabel";
            this.pieni_suora_resultsLabel.Size = new System.Drawing.Size(29, 32);
            this.pieni_suora_resultsLabel.TabIndex = 35;
            this.pieni_suora_resultsLabel.Text = "0";
            // 
            // iso_suora_resultsLabel
            // 
            this.iso_suora_resultsLabel.AutoSize = true;
            this.iso_suora_resultsLabel.Font = new System.Drawing.Font("Helvetica", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.iso_suora_resultsLabel.Location = new System.Drawing.Point(466, 173);
            this.iso_suora_resultsLabel.Name = "iso_suora_resultsLabel";
            this.iso_suora_resultsLabel.Size = new System.Drawing.Size(29, 32);
            this.iso_suora_resultsLabel.TabIndex = 36;
            this.iso_suora_resultsLabel.Text = "0";
            // 
            // tayskasi_resultsLabel
            // 
            this.tayskasi_resultsLabel.AutoSize = true;
            this.tayskasi_resultsLabel.Font = new System.Drawing.Font("Helvetica", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.tayskasi_resultsLabel.Location = new System.Drawing.Point(466, 205);
            this.tayskasi_resultsLabel.Name = "tayskasi_resultsLabel";
            this.tayskasi_resultsLabel.Size = new System.Drawing.Size(29, 32);
            this.tayskasi_resultsLabel.TabIndex = 41;
            this.tayskasi_resultsLabel.Text = "0";
            // 
            // sattuma_resultsLabel
            // 
            this.sattuma_resultsLabel.AutoSize = true;
            this.sattuma_resultsLabel.Font = new System.Drawing.Font("Helvetica", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.sattuma_resultsLabel.Location = new System.Drawing.Point(466, 237);
            this.sattuma_resultsLabel.Name = "sattuma_resultsLabel";
            this.sattuma_resultsLabel.Size = new System.Drawing.Size(29, 32);
            this.sattuma_resultsLabel.TabIndex = 38;
            this.sattuma_resultsLabel.Text = "0";
            // 
            // yatzy_resultsLabel
            // 
            this.yatzy_resultsLabel.AutoSize = true;
            this.yatzy_resultsLabel.Font = new System.Drawing.Font("Helvetica", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.yatzy_resultsLabel.Location = new System.Drawing.Point(466, 269);
            this.yatzy_resultsLabel.Name = "yatzy_resultsLabel";
            this.yatzy_resultsLabel.Size = new System.Drawing.Size(29, 32);
            this.yatzy_resultsLabel.TabIndex = 39;
            this.yatzy_resultsLabel.Text = "0";
            // 
            // summa_resultsLabel
            // 
            this.summa_resultsLabel.AutoSize = true;
            this.summa_resultsLabel.Font = new System.Drawing.Font("Helvetica", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.summa_resultsLabel.Location = new System.Drawing.Point(466, 311);
            this.summa_resultsLabel.Name = "summa_resultsLabel";
            this.summa_resultsLabel.Size = new System.Drawing.Size(29, 32);
            this.summa_resultsLabel.TabIndex = 37;
            this.summa_resultsLabel.Text = "0";
            // 
            // pariLabel
            // 
            this.pariLabel.AutoSize = true;
            this.pariLabel.Font = new System.Drawing.Font("Helvetica", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.pariLabel.Location = new System.Drawing.Point(5, 8);
            this.pariLabel.Name = "pariLabel";
            this.pariLabel.Size = new System.Drawing.Size(66, 32);
            this.pariLabel.TabIndex = 24;
            this.pariLabel.Text = "Pari";
            // 
            // kaksi_pariaLabel
            // 
            this.kaksi_pariaLabel.AutoSize = true;
            this.kaksi_pariaLabel.Font = new System.Drawing.Font("Helvetica", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.kaksi_pariaLabel.Location = new System.Drawing.Point(5, 40);
            this.kaksi_pariaLabel.Name = "kaksi_pariaLabel";
            this.kaksi_pariaLabel.Size = new System.Drawing.Size(160, 32);
            this.kaksi_pariaLabel.TabIndex = 25;
            this.kaksi_pariaLabel.Text = "Kaksi paria";
            // 
            // kolme_samaaLabel
            // 
            this.kolme_samaaLabel.AutoSize = true;
            this.kolme_samaaLabel.Font = new System.Drawing.Font("Helvetica", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.kolme_samaaLabel.Location = new System.Drawing.Point(5, 72);
            this.kolme_samaaLabel.Name = "kolme_samaaLabel";
            this.kolme_samaaLabel.Size = new System.Drawing.Size(190, 32);
            this.kolme_samaaLabel.TabIndex = 26;
            this.kolme_samaaLabel.Text = "Kolme samaa";
            // 
            // nelja_samaaLabel
            // 
            this.nelja_samaaLabel.AutoSize = true;
            this.nelja_samaaLabel.Font = new System.Drawing.Font("Helvetica", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.nelja_samaaLabel.Location = new System.Drawing.Point(5, 104);
            this.nelja_samaaLabel.Name = "nelja_samaaLabel";
            this.nelja_samaaLabel.Size = new System.Drawing.Size(173, 32);
            this.nelja_samaaLabel.TabIndex = 27;
            this.nelja_samaaLabel.Text = "Neljä samaa";
            // 
            // pieni_suoraLabel
            // 
            this.pieni_suoraLabel.AutoSize = true;
            this.pieni_suoraLabel.Font = new System.Drawing.Font("Helvetica", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.pieni_suoraLabel.Location = new System.Drawing.Point(5, 136);
            this.pieni_suoraLabel.Name = "pieni_suoraLabel";
            this.pieni_suoraLabel.Size = new System.Drawing.Size(164, 32);
            this.pieni_suoraLabel.TabIndex = 28;
            this.pieni_suoraLabel.Text = "Pieni suora";
            // 
            // iso_suoraLabel
            // 
            this.iso_suoraLabel.AutoSize = true;
            this.iso_suoraLabel.Font = new System.Drawing.Font("Helvetica", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.iso_suoraLabel.Location = new System.Drawing.Point(5, 168);
            this.iso_suoraLabel.Name = "iso_suoraLabel";
            this.iso_suoraLabel.Size = new System.Drawing.Size(137, 32);
            this.iso_suoraLabel.TabIndex = 29;
            this.iso_suoraLabel.Text = "Iso suora";
            // 
            // tayskasiLabel
            // 
            this.tayskasiLabel.AutoSize = true;
            this.tayskasiLabel.Font = new System.Drawing.Font("Helvetica", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.tayskasiLabel.Location = new System.Drawing.Point(5, 200);
            this.tayskasiLabel.Name = "tayskasiLabel";
            this.tayskasiLabel.Size = new System.Drawing.Size(129, 32);
            this.tayskasiLabel.TabIndex = 30;
            this.tayskasiLabel.Text = "Täyskäsi";
            // 
            // sattumaLabel
            // 
            this.sattumaLabel.AutoSize = true;
            this.sattumaLabel.Font = new System.Drawing.Font("Helvetica", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.sattumaLabel.Location = new System.Drawing.Point(5, 232);
            this.sattumaLabel.Name = "sattumaLabel";
            this.sattumaLabel.Size = new System.Drawing.Size(121, 32);
            this.sattumaLabel.TabIndex = 31;
            this.sattumaLabel.Text = "Sattuma";
            // 
            // summaLabel
            // 
            this.summaLabel.AutoSize = true;
            this.summaLabel.Font = new System.Drawing.Font("Helvetica", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.summaLabel.Location = new System.Drawing.Point(11, 311);
            this.summaLabel.Name = "summaLabel";
            this.summaLabel.Size = new System.Drawing.Size(112, 32);
            this.summaLabel.TabIndex = 23;
            this.summaLabel.Text = "Summa";
            // 
            // combinationsPanel
            // 
            this.combinationsPanel.Controls.Add(this.bottomRecordContainer_Panel);
            this.combinationsPanel.Controls.Add(this.upperRecordContainer_Panel);
            this.combinationsPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.combinationsPanel.Location = new System.Drawing.Point(677, 0);
            this.combinationsPanel.Name = "combinationsPanel";
            this.combinationsPanel.Size = new System.Drawing.Size(507, 651);
            this.combinationsPanel.TabIndex = 4;
            this.combinationsPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.combinationsPanel_Paint);
            // 
            // bottomCategories_Panel
            // 
            this.bottomCategories_Panel.Controls.Add(this.pariLabel);
            this.bottomCategories_Panel.Controls.Add(this.kaksi_pariaLabel);
            this.bottomCategories_Panel.Controls.Add(this.kolme_samaaLabel);
            this.bottomCategories_Panel.Controls.Add(this.nelja_samaaLabel);
            this.bottomCategories_Panel.Controls.Add(this.pieni_suoraLabel);
            this.bottomCategories_Panel.Controls.Add(this.iso_suoraLabel);
            this.bottomCategories_Panel.Controls.Add(this.tayskasiLabel);
            this.bottomCategories_Panel.Controls.Add(this.sattumaLabel);
            this.bottomCategories_Panel.Controls.Add(this.yatzyLabel);
            this.bottomCategories_Panel.Location = new System.Drawing.Point(0, 5);
            this.bottomCategories_Panel.Name = "bottomCategories_Panel";
            this.bottomCategories_Panel.Size = new System.Drawing.Size(201, 303);
            this.bottomCategories_Panel.TabIndex = 43;
            // 
            // yatzyLabel
            // 
            this.yatzyLabel.AutoSize = true;
            this.yatzyLabel.Font = new System.Drawing.Font("Helvetica", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.yatzyLabel.Location = new System.Drawing.Point(12, 264);
            this.yatzyLabel.Name = "yatzyLabel";
            this.yatzyLabel.Size = new System.Drawing.Size(84, 32);
            this.yatzyLabel.TabIndex = 33;
            this.yatzyLabel.Text = "Yatzy";
            // 
            // YatzyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 651);
            this.Controls.Add(this.combinationsPanel);
            this.Controls.Add(this.diceResultsWindow);
            this.Controls.Add(this.allowedNumberOfThrows);
            this.Controls.Add(this.acceptResults_btn);
            this.Controls.Add(this.throwDice_btn);
            this.Controls.Add(this.diceWindow);
            this.Font = new System.Drawing.Font("Helvetica", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
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
            this.upperRecordContainer_Panel.ResumeLayout(false);
            this.upperRecordContainer_Panel.PerformLayout();
            this.upperCategories_Panel.ResumeLayout(false);
            this.upperCategories_Panel.PerformLayout();
            this.bottomRecordContainer_Panel.ResumeLayout(false);
            this.bottomRecordContainer_Panel.PerformLayout();
            this.combinationsPanel.ResumeLayout(false);
            this.bottomCategories_Panel.ResumeLayout(false);
            this.bottomCategories_Panel.PerformLayout();
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
    private Button acceptResults_btn;
    private Panel upperRecordContainer_Panel;
    private Panel upperCategories_Panel;
    private Label ykkosetLabel;
    private Label kakkosetLabel;
    private Label kolmosetLabel;
    private Label nelosetLabel;
    private Label viitosetLabel;
    private Label kuutosetLabel;
    private Label bonus_resultsLabel;
    private Label valisumma_resultsLabel;
    private Label ykkoset_resultsLabel;
    private Label kakkoset_resultsLabel;
    private Label kolmoset_resultsLabel;
    private Label neloset_resultsLabel;
    private Label viitoset_resultsLabel;
    private Label kuutoset_resultsLabel;
    private Label bonusLabel;
    private Label valisummaLabel;
    private Panel bottomRecordContainer_Panel;
    private Panel bottomCategories_Panel;
    private Label pariLabel;
    private Label kaksi_pariaLabel;
    private Label kolme_samaaLabel;
    private Label nelja_samaaLabel;
    private Label pieni_suoraLabel;
    private Label iso_suoraLabel;
    private Label tayskasiLabel;
    private Label sattumaLabel;
    private Label yatzyLabel;
    private Label summaLabel;
    private Label yatzy_resultsLabel;
    private Label pari_resultsLabel;
    private Label kaksi_paria_resultsLabel;
    private Label kolme_samaa_resultsLabel;
    private Label nelja_samaa_resultsLabel;
    private Label pieni_suora_resultsLabel;
    private Label iso_suora_resultsLabel;
    private Label tayskasi_resultsLabel;
    private Label sattuma_resultsLabel;
    private Label summa_resultsLabel;
    private Panel combinationsPanel;
}
