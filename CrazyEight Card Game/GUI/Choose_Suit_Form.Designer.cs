namespace GUI
{
    partial class Choose_Suit_Form
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.PlayCard = new System.Windows.Forms.Button();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.pbSpades = new System.Windows.Forms.PictureBox();
            this.pbHearts = new System.Windows.Forms.PictureBox();
            this.pbDiamonds = new System.Windows.Forms.PictureBox();
            this.pbClubs = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSpades)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHearts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDiamonds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbClubs)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "You chose an Eight! \r\nYou get to choose the Suit\r\n";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pbSpades);
            this.groupBox1.Controls.Add(this.radioButton4);
            this.groupBox1.Controls.Add(this.pbHearts);
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.pbDiamonds);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.pbClubs);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Location = new System.Drawing.Point(13, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(159, 116);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "“Choose a Suit";
            // 
            // PlayCard
            // 
            this.PlayCard.Location = new System.Drawing.Point(15, 176);
            this.PlayCard.Name = "PlayCard";
            this.PlayCard.Size = new System.Drawing.Size(157, 23);
            this.PlayCard.TabIndex = 2;
            this.PlayCard.Text = "Play card";
            this.PlayCard.UseVisualStyleBackColor = true;
            this.PlayCard.Click += new System.EventHandler(this.PlayCard_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(38, 20);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(56, 16);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Clubs";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(38, 42);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(80, 16);
            this.radioButton2.TabIndex = 2;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Diamonds";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(38, 64);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(59, 16);
            this.radioButton3.TabIndex = 4;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Hearts";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(38, 86);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(66, 16);
            this.radioButton4.TabIndex = 6;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "Spades";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // pbSpades
            // 
            this.pbSpades.Image = global::GUI.Properties.Resources.spades;
            this.pbSpades.Location = new System.Drawing.Point(15, 86);
            this.pbSpades.Name = "pbSpades";
            this.pbSpades.Size = new System.Drawing.Size(17, 16);
            this.pbSpades.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSpades.TabIndex = 7;
            this.pbSpades.TabStop = false;
            // 
            // pbHearts
            // 
            this.pbHearts.Image = global::GUI.Properties.Resources.hearts;
            this.pbHearts.Location = new System.Drawing.Point(15, 64);
            this.pbHearts.Name = "pbHearts";
            this.pbHearts.Size = new System.Drawing.Size(17, 16);
            this.pbHearts.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbHearts.TabIndex = 5;
            this.pbHearts.TabStop = false;
            // 
            // pbDiamonds
            // 
            this.pbDiamonds.Image = global::GUI.Properties.Resources.diamonds;
            this.pbDiamonds.Location = new System.Drawing.Point(15, 42);
            this.pbDiamonds.Name = "pbDiamonds";
            this.pbDiamonds.Size = new System.Drawing.Size(17, 16);
            this.pbDiamonds.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbDiamonds.TabIndex = 3;
            this.pbDiamonds.TabStop = false;
            // 
            // pbClubs
            // 
            this.pbClubs.Image = global::GUI.Properties.Resources.clubs;
            this.pbClubs.Location = new System.Drawing.Point(15, 20);
            this.pbClubs.Name = "pbClubs";
            this.pbClubs.Size = new System.Drawing.Size(17, 16);
            this.pbClubs.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbClubs.TabIndex = 1;
            this.pbClubs.TabStop = false;
            // 
            // Choose_Suit_Form
            // 
            this.ClientSize = new System.Drawing.Size(184, 211);
            this.ControlBox = false;
            this.Controls.Add(this.PlayCard);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximumSize = new System.Drawing.Size(200, 250);
            this.MinimumSize = new System.Drawing.Size(200, 250);
            this.Name = "Choose_Suit_Form";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Choose a Suit";
            this.TopMost = true;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSpades)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHearts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDiamonds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbClubs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button PlayCard;
        private System.Windows.Forms.PictureBox pbSpades;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.PictureBox pbHearts;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.PictureBox pbDiamonds;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.PictureBox pbClubs;
        private System.Windows.Forms.RadioButton radioButton1;
    }
}
