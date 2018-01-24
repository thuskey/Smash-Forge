﻿namespace Smash_Forge.GUI.Menus
{
    partial class ColorEditor
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.colorTempTrackBar = new System.Windows.Forms.TrackBar();
            this.colorTempTB = new System.Windows.Forms.TextBox();
            this.tempLabel = new System.Windows.Forms.Label();
            this.useColorTempCB = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.blueTrackBar = new System.Windows.Forms.TrackBar();
            this.greenTrackBar = new System.Windows.Forms.TrackBar();
            this.greenTB = new System.Windows.Forms.TextBox();
            this.redTB = new System.Windows.Forms.TextBox();
            this.valueTB = new System.Windows.Forms.TextBox();
            this.satTB = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.colorButton = new System.Windows.Forms.Button();
            this.colorTrackBar = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            this.hueTrackBar = new System.Windows.Forms.TrackBar();
            this.satTrackBar = new System.Windows.Forms.TrackBar();
            this.valueTrackBar = new System.Windows.Forms.TrackBar();
            this.redTrackBar = new System.Windows.Forms.TrackBar();
            this.label7 = new System.Windows.Forms.Label();
            this.hueTB = new System.Windows.Forms.TextBox();
            this.blueTB = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colorTempTrackBar)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.blueTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hueTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.satTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.valueTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.redTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.colorTempTrackBar);
            this.groupBox1.Controls.Add(this.colorTempTB);
            this.groupBox1.Controls.Add(this.tempLabel);
            this.groupBox1.Controls.Add(this.useColorTempCB);
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Location = new System.Drawing.Point(24, 25);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox1.Size = new System.Drawing.Size(638, 583);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Color";
            // 
            // colorTempTrackBar
            // 
            this.colorTempTrackBar.Enabled = false;
            this.colorTempTrackBar.Location = new System.Drawing.Point(258, 485);
            this.colorTempTrackBar.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.colorTempTrackBar.Maximum = 10000;
            this.colorTempTrackBar.Name = "colorTempTrackBar";
            this.colorTempTrackBar.Size = new System.Drawing.Size(358, 90);
            this.colorTempTrackBar.TabIndex = 9;
            this.colorTempTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.colorTempTrackBar.Scroll += new System.EventHandler(this.colorTempTrackBar_Scroll);
            // 
            // colorTempTB
            // 
            this.colorTempTB.Enabled = false;
            this.colorTempTB.Location = new System.Drawing.Point(150, 500);
            this.colorTempTB.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.colorTempTB.Name = "colorTempTB";
            this.colorTempTB.Size = new System.Drawing.Size(92, 31);
            this.colorTempTB.TabIndex = 8;
            this.colorTempTB.TextChanged += new System.EventHandler(this.colorTempTB_TextChanged);
            // 
            // tempLabel
            // 
            this.tempLabel.AutoSize = true;
            this.tempLabel.Enabled = false;
            this.tempLabel.Location = new System.Drawing.Point(20, 506);
            this.tempLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.tempLabel.Name = "tempLabel";
            this.tempLabel.Size = new System.Drawing.Size(100, 25);
            this.tempLabel.TabIndex = 7;
            this.tempLabel.Text = "Temp (K)";
            // 
            // useColorTempCB
            // 
            this.useColorTempCB.AutoSize = true;
            this.useColorTempCB.Location = new System.Drawing.Point(24, 460);
            this.useColorTempCB.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.useColorTempCB.Name = "useColorTempCB";
            this.useColorTempCB.Size = new System.Drawing.Size(267, 29);
            this.useColorTempCB.TabIndex = 6;
            this.useColorTempCB.Text = "Use Color Temperature";
            this.useColorTempCB.UseVisualStyleBackColor = true;
            this.useColorTempCB.CheckedChanged += new System.EventHandler(this.useColorTempCB_CheckedChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 132F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 364F));
            this.tableLayoutPanel1.Controls.Add(this.blueTrackBar, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.greenTrackBar, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.greenTB, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.redTB, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.valueTB, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.satTB, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.colorButton, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.colorTrackBar, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.hueTrackBar, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.satTrackBar, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.valueTrackBar, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.redTrackBar, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.hueTB, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.blueTB, 1, 6);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 37);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(604, 406);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // blueTrackBar
            // 
            this.blueTrackBar.Location = new System.Drawing.Point(246, 354);
            this.blueTrackBar.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.blueTrackBar.Maximum = 100;
            this.blueTrackBar.Name = "blueTrackBar";
            this.blueTrackBar.Size = new System.Drawing.Size(352, 46);
            this.blueTrackBar.TabIndex = 24;
            this.blueTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.blueTrackBar.Scroll += new System.EventHandler(this.blueTrackBar_Scroll);
            // 
            // greenTrackBar
            // 
            this.greenTrackBar.Location = new System.Drawing.Point(246, 296);
            this.greenTrackBar.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.greenTrackBar.Maximum = 100;
            this.greenTrackBar.Name = "greenTrackBar";
            this.greenTrackBar.Size = new System.Drawing.Size(352, 46);
            this.greenTrackBar.TabIndex = 23;
            this.greenTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.greenTrackBar.Scroll += new System.EventHandler(this.greenTrackBar_Scroll);
            // 
            // greenTB
            // 
            this.greenTB.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.greenTB.Location = new System.Drawing.Point(138, 303);
            this.greenTB.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.greenTB.Name = "greenTB";
            this.greenTB.Size = new System.Drawing.Size(92, 31);
            this.greenTB.TabIndex = 21;
            this.greenTB.TextChanged += new System.EventHandler(this.greenTB_TextChanged);
            // 
            // redTB
            // 
            this.redTB.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.redTB.Location = new System.Drawing.Point(138, 245);
            this.redTB.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.redTB.Name = "redTB";
            this.redTB.Size = new System.Drawing.Size(92, 31);
            this.redTB.TabIndex = 20;
            this.redTB.TextChanged += new System.EventHandler(this.redTB_TextChanged);
            // 
            // valueTB
            // 
            this.valueTB.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.valueTB.Location = new System.Drawing.Point(138, 187);
            this.valueTB.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.valueTB.Name = "valueTB";
            this.valueTB.Size = new System.Drawing.Size(92, 31);
            this.valueTB.TabIndex = 19;
            this.valueTB.TextChanged += new System.EventHandler(this.valueTB_TextChanged);
            // 
            // satTB
            // 
            this.satTB.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.satTB.Location = new System.Drawing.Point(138, 129);
            this.satTB.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.satTB.Name = "satTB";
            this.satTB.Size = new System.Drawing.Size(92, 31);
            this.satTB.TabIndex = 18;
            this.satTB.TextChanged += new System.EventHandler(this.satTB_TextChanged);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 306);
            this.label6.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 25);
            this.label6.TabIndex = 15;
            this.label6.Text = "Green";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Color";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 74);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Hue";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 132);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Saturation";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 190);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "Value";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // colorButton
            // 
            this.colorButton.Location = new System.Drawing.Point(138, 6);
            this.colorButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.colorButton.Name = "colorButton";
            this.colorButton.Size = new System.Drawing.Size(96, 44);
            this.colorButton.TabIndex = 5;
            this.colorButton.UseVisualStyleBackColor = true;
            // 
            // colorTrackBar
            // 
            this.colorTrackBar.Location = new System.Drawing.Point(246, 6);
            this.colorTrackBar.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.colorTrackBar.Maximum = 500;
            this.colorTrackBar.Name = "colorTrackBar";
            this.colorTrackBar.Size = new System.Drawing.Size(352, 46);
            this.colorTrackBar.TabIndex = 4;
            this.colorTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.colorTrackBar.Scroll += new System.EventHandler(this.colorTrackBar_Scroll);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 248);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 25);
            this.label5.TabIndex = 6;
            this.label5.Text = "Red";
            // 
            // hueTrackBar
            // 
            this.hueTrackBar.Location = new System.Drawing.Point(246, 64);
            this.hueTrackBar.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.hueTrackBar.Maximum = 360;
            this.hueTrackBar.Name = "hueTrackBar";
            this.hueTrackBar.Size = new System.Drawing.Size(352, 46);
            this.hueTrackBar.TabIndex = 7;
            this.hueTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.hueTrackBar.Value = 360;
            this.hueTrackBar.Scroll += new System.EventHandler(this.hueTrackBar_Scroll);
            // 
            // satTrackBar
            // 
            this.satTrackBar.Location = new System.Drawing.Point(246, 122);
            this.satTrackBar.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.satTrackBar.Name = "satTrackBar";
            this.satTrackBar.Size = new System.Drawing.Size(352, 46);
            this.satTrackBar.TabIndex = 8;
            this.satTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.satTrackBar.Scroll += new System.EventHandler(this.satTrackBar_Scroll);
            // 
            // valueTrackBar
            // 
            this.valueTrackBar.Location = new System.Drawing.Point(246, 180);
            this.valueTrackBar.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.valueTrackBar.Name = "valueTrackBar";
            this.valueTrackBar.Size = new System.Drawing.Size(352, 46);
            this.valueTrackBar.TabIndex = 9;
            this.valueTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.valueTrackBar.Scroll += new System.EventHandler(this.valueTrackBar_Scroll);
            // 
            // redTrackBar
            // 
            this.redTrackBar.LargeChange = 250;
            this.redTrackBar.Location = new System.Drawing.Point(246, 238);
            this.redTrackBar.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.redTrackBar.Maximum = 100;
            this.redTrackBar.Name = "redTrackBar";
            this.redTrackBar.Size = new System.Drawing.Size(352, 46);
            this.redTrackBar.TabIndex = 10;
            this.redTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.redTrackBar.Scroll += new System.EventHandler(this.redTrackBar_Scroll);
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 364);
            this.label7.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 25);
            this.label7.TabIndex = 16;
            this.label7.Text = "Blue";
            // 
            // hueTB
            // 
            this.hueTB.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.hueTB.Location = new System.Drawing.Point(138, 71);
            this.hueTB.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.hueTB.Name = "hueTB";
            this.hueTB.Size = new System.Drawing.Size(92, 31);
            this.hueTB.TabIndex = 17;
            this.hueTB.TextChanged += new System.EventHandler(this.hueTB_TextChanged);
            // 
            // blueTB
            // 
            this.blueTB.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.blueTB.Location = new System.Drawing.Point(138, 361);
            this.blueTB.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.blueTB.Name = "blueTB";
            this.blueTB.Size = new System.Drawing.Size(92, 31);
            this.blueTB.TabIndex = 22;
            this.blueTB.TextChanged += new System.EventHandler(this.blueTB_TextChanged);
            // 
            // ColorEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 623);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "ColorEditor";
            this.Text = "ColorEditor";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colorTempTrackBar)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.blueTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hueTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.satTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.valueTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.redTrackBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TrackBar colorTempTrackBar;
        private System.Windows.Forms.TextBox colorTempTB;
        private System.Windows.Forms.Label tempLabel;
        private System.Windows.Forms.CheckBox useColorTempCB;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TrackBar blueTrackBar;
        private System.Windows.Forms.TrackBar greenTrackBar;
        private System.Windows.Forms.TextBox greenTB;
        private System.Windows.Forms.TextBox redTB;
        private System.Windows.Forms.TextBox valueTB;
        private System.Windows.Forms.TextBox satTB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button colorButton;
        private System.Windows.Forms.TrackBar colorTrackBar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TrackBar hueTrackBar;
        private System.Windows.Forms.TrackBar satTrackBar;
        private System.Windows.Forms.TrackBar valueTrackBar;
        private System.Windows.Forms.TrackBar redTrackBar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox hueTB;
        private System.Windows.Forms.TextBox blueTB;
    }
}