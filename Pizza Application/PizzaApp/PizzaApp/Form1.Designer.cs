namespace PizzaApp {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
                }
            base.Dispose(disposing);
            }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtOrderName = new System.Windows.Forms.TextBox();
            this.cmbSauce = new System.Windows.Forms.ComboBox();
            this.grpCrust = new System.Windows.Forms.GroupBox();
            this.rdoCrustGlutenFree = new System.Windows.Forms.RadioButton();
            this.rdoCrustThick = new System.Windows.Forms.RadioButton();
            this.rdoCrustThin = new System.Windows.Forms.RadioButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnOrder = new System.Windows.Forms.Button();
            this.grpTopping = new System.Windows.Forms.GroupBox();
            this.chkToppingi7 = new System.Windows.Forms.CheckBox();
            this.chkToppingTruffles = new System.Windows.Forms.CheckBox();
            this.chkToppingEggs = new System.Windows.Forms.CheckBox();
            this.chkToppingSushi = new System.Windows.Forms.CheckBox();
            this.chkToppingMorePineapples = new System.Windows.Forms.CheckBox();
            this.chkToppingPineapples = new System.Windows.Forms.CheckBox();
            this.chkToppingQUTSS = new System.Windows.Forms.CheckBox();
            this.chkToppingChickenFeet = new System.Windows.Forms.CheckBox();
            this.chkToppingTomatoes = new System.Windows.Forms.CheckBox();
            this.chkToppingPanadol = new System.Windows.Forms.CheckBox();
            this.chkToppingFeta = new System.Windows.Forms.CheckBox();
            this.chkToppingSteamedChicken = new System.Windows.Forms.CheckBox();
            this.chkToppingFriedSquid = new System.Windows.Forms.CheckBox();
            this.chkToppingWater = new System.Windows.Forms.CheckBox();
            this.chkToppingBananas = new System.Windows.Forms.CheckBox();
            this.chkToppingAlmonds = new System.Windows.Forms.CheckBox();
            this.grpCrust.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.grpTopping.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(368, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome to Moto Moto\'s Pizza";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Enabled = false;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(28, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Order name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Enabled = false;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(28, 208);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Sauce:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(206, 245);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "* incurs $2 surcharge";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(395, 283);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(268, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Choose your toppings. each topping after 4 costs $1.00";
            // 
            // txtOrderName
            // 
            this.txtOrderName.Location = new System.Drawing.Point(146, 137);
            this.txtOrderName.Name = "txtOrderName";
            this.txtOrderName.Size = new System.Drawing.Size(250, 20);
            this.txtOrderName.TabIndex = 1;
            this.txtOrderName.TextChanged += new System.EventHandler(this.txtOrderName_TextChanged);
            // 
            // cmbSauce
            // 
            this.cmbSauce.BackColor = System.Drawing.SystemColors.Window;
            this.cmbSauce.DisplayMember = " ";
            this.cmbSauce.Enabled = false;
            this.cmbSauce.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbSauce.FormattingEnabled = true;
            this.cmbSauce.Location = new System.Drawing.Point(146, 210);
            this.cmbSauce.Name = "cmbSauce";
            this.cmbSauce.Size = new System.Drawing.Size(250, 21);
            this.cmbSauce.TabIndex = 2;
            this.cmbSauce.SelectedIndexChanged += new System.EventHandler(this.cmbSauce_SelectedIndexChanged);
            // 
            // grpCrust
            // 
            this.grpCrust.BackColor = System.Drawing.Color.SteelBlue;
            this.grpCrust.Controls.Add(this.rdoCrustGlutenFree);
            this.grpCrust.Controls.Add(this.rdoCrustThick);
            this.grpCrust.Controls.Add(this.rdoCrustThin);
            this.grpCrust.Controls.Add(this.label3);
            this.grpCrust.Enabled = false;
            this.grpCrust.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpCrust.Location = new System.Drawing.Point(32, 256);
            this.grpCrust.Name = "grpCrust";
            this.grpCrust.Size = new System.Drawing.Size(370, 279);
            this.grpCrust.TabIndex = 3;
            this.grpCrust.TabStop = false;
            this.grpCrust.Text = "Crust";
            // 
            // rdoCrustGlutenFree
            // 
            this.rdoCrustGlutenFree.AutoSize = true;
            this.rdoCrustGlutenFree.Location = new System.Drawing.Point(34, 157);
            this.rdoCrustGlutenFree.Name = "rdoCrustGlutenFree";
            this.rdoCrustGlutenFree.Size = new System.Drawing.Size(113, 24);
            this.rdoCrustGlutenFree.TabIndex = 6;
            this.rdoCrustGlutenFree.TabStop = true;
            this.rdoCrustGlutenFree.Text = "Gluten free*";
            this.rdoCrustGlutenFree.UseVisualStyleBackColor = true;
            this.rdoCrustGlutenFree.CheckedChanged += new System.EventHandler(this.grpCrust_CheckedChanged);
            // 
            // rdoCrustThick
            // 
            this.rdoCrustThick.AutoSize = true;
            this.rdoCrustThick.Location = new System.Drawing.Point(34, 108);
            this.rdoCrustThick.Name = "rdoCrustThick";
            this.rdoCrustThick.Size = new System.Drawing.Size(64, 24);
            this.rdoCrustThick.TabIndex = 5;
            this.rdoCrustThick.TabStop = true;
            this.rdoCrustThick.Text = "Thick";
            this.rdoCrustThick.UseVisualStyleBackColor = true;
            this.rdoCrustThick.CheckedChanged += new System.EventHandler(this.grpCrust_CheckedChanged);
            // 
            // rdoCrustThin
            // 
            this.rdoCrustThin.AutoSize = true;
            this.rdoCrustThin.Location = new System.Drawing.Point(34, 57);
            this.rdoCrustThin.Name = "rdoCrustThin";
            this.rdoCrustThin.Size = new System.Drawing.Size(57, 24);
            this.rdoCrustThin.TabIndex = 4;
            this.rdoCrustThin.TabStop = true;
            this.rdoCrustThin.Text = "Thin";
            this.rdoCrustThin.UseVisualStyleBackColor = true;
            this.rdoCrustThin.CheckedChanged += new System.EventHandler(this.grpCrust_CheckedChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(408, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(682, 205);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // btnOrder
            // 
            this.btnOrder.Enabled = false;
            this.btnOrder.Location = new System.Drawing.Point(421, 541);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(269, 48);
            this.btnOrder.TabIndex = 23;
            this.btnOrder.Text = "Order";
            this.btnOrder.UseVisualStyleBackColor = true;
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // grpTopping
            // 
            this.grpTopping.Controls.Add(this.chkToppingi7);
            this.grpTopping.Controls.Add(this.chkToppingTruffles);
            this.grpTopping.Controls.Add(this.chkToppingEggs);
            this.grpTopping.Controls.Add(this.chkToppingSushi);
            this.grpTopping.Controls.Add(this.chkToppingMorePineapples);
            this.grpTopping.Controls.Add(this.chkToppingPineapples);
            this.grpTopping.Controls.Add(this.chkToppingQUTSS);
            this.grpTopping.Controls.Add(this.chkToppingChickenFeet);
            this.grpTopping.Controls.Add(this.chkToppingTomatoes);
            this.grpTopping.Controls.Add(this.chkToppingPanadol);
            this.grpTopping.Controls.Add(this.chkToppingFeta);
            this.grpTopping.Controls.Add(this.chkToppingSteamedChicken);
            this.grpTopping.Controls.Add(this.chkToppingFriedSquid);
            this.grpTopping.Controls.Add(this.chkToppingWater);
            this.grpTopping.Controls.Add(this.chkToppingBananas);
            this.grpTopping.Controls.Add(this.chkToppingAlmonds);
            this.grpTopping.Controls.Add(this.label5);
            this.grpTopping.Enabled = false;
            this.grpTopping.Location = new System.Drawing.Point(421, 223);
            this.grpTopping.Name = "grpTopping";
            this.grpTopping.Size = new System.Drawing.Size(669, 312);
            this.grpTopping.TabIndex = 7;
            this.grpTopping.TabStop = false;
            this.grpTopping.Text = "Toppings";
            // 
            // chkToppingi7
            // 
            this.chkToppingi7.AutoSize = true;
            this.chkToppingi7.Location = new System.Drawing.Point(31, 266);
            this.chkToppingi7.Name = "chkToppingi7";
            this.chkToppingi7.Size = new System.Drawing.Size(220, 17);
            this.chkToppingi7.TabIndex = 22;
            this.chkToppingi7.Text = "Intel Core i7-2600K Quad-Core Processor";
            this.chkToppingi7.UseVisualStyleBackColor = true;
            this.chkToppingi7.CheckedChanged += new System.EventHandler(this.chkToppingAlmonds_CheckedChanged);
            // 
            // chkToppingTruffles
            // 
            this.chkToppingTruffles.AutoSize = true;
            this.chkToppingTruffles.Location = new System.Drawing.Point(541, 197);
            this.chkToppingTruffles.Name = "chkToppingTruffles";
            this.chkToppingTruffles.Size = new System.Drawing.Size(61, 17);
            this.chkToppingTruffles.TabIndex = 21;
            this.chkToppingTruffles.Text = "Truffles";
            this.chkToppingTruffles.UseVisualStyleBackColor = true;
            this.chkToppingTruffles.CheckedChanged += new System.EventHandler(this.chkToppingAlmonds_CheckedChanged);
            // 
            // chkToppingEggs
            // 
            this.chkToppingEggs.AutoSize = true;
            this.chkToppingEggs.Location = new System.Drawing.Point(278, 197);
            this.chkToppingEggs.Name = "chkToppingEggs";
            this.chkToppingEggs.Size = new System.Drawing.Size(50, 17);
            this.chkToppingEggs.TabIndex = 19;
            this.chkToppingEggs.Text = "Eggs";
            this.chkToppingEggs.UseVisualStyleBackColor = true;
            this.chkToppingEggs.CheckedChanged += new System.EventHandler(this.chkToppingAlmonds_CheckedChanged);
            // 
            // chkToppingSushi
            // 
            this.chkToppingSushi.AutoSize = true;
            this.chkToppingSushi.Location = new System.Drawing.Point(409, 197);
            this.chkToppingSushi.Name = "chkToppingSushi";
            this.chkToppingSushi.Size = new System.Drawing.Size(52, 17);
            this.chkToppingSushi.TabIndex = 20;
            this.chkToppingSushi.Text = "Sushi";
            this.chkToppingSushi.UseVisualStyleBackColor = true;
            this.chkToppingSushi.CheckedChanged += new System.EventHandler(this.chkToppingAlmonds_CheckedChanged);
            // 
            // chkToppingMorePineapples
            // 
            this.chkToppingMorePineapples.AutoSize = true;
            this.chkToppingMorePineapples.Location = new System.Drawing.Point(152, 197);
            this.chkToppingMorePineapples.Name = "chkToppingMorePineapples";
            this.chkToppingMorePineapples.Size = new System.Drawing.Size(104, 17);
            this.chkToppingMorePineapples.TabIndex = 18;
            this.chkToppingMorePineapples.Text = "More pineapples";
            this.chkToppingMorePineapples.UseVisualStyleBackColor = true;
            this.chkToppingMorePineapples.CheckedChanged += new System.EventHandler(this.chkToppingAlmonds_CheckedChanged);
            // 
            // chkToppingPineapples
            // 
            this.chkToppingPineapples.AutoSize = true;
            this.chkToppingPineapples.Location = new System.Drawing.Point(31, 197);
            this.chkToppingPineapples.Name = "chkToppingPineapples";
            this.chkToppingPineapples.Size = new System.Drawing.Size(78, 17);
            this.chkToppingPineapples.TabIndex = 17;
            this.chkToppingPineapples.Text = "Pineapples";
            this.chkToppingPineapples.UseVisualStyleBackColor = true;
            this.chkToppingPineapples.CheckedChanged += new System.EventHandler(this.chkToppingAlmonds_CheckedChanged);
            // 
            // chkToppingQUTSS
            // 
            this.chkToppingQUTSS.AutoSize = true;
            this.chkToppingQUTSS.Location = new System.Drawing.Point(541, 117);
            this.chkToppingQUTSS.Name = "chkToppingQUTSS";
            this.chkToppingQUTSS.Size = new System.Drawing.Size(81, 17);
            this.chkToppingQUTSS.TabIndex = 16;
            this.chkToppingQUTSS.Text = "QUT SS2.0";
            this.chkToppingQUTSS.UseVisualStyleBackColor = true;
            this.chkToppingQUTSS.CheckedChanged += new System.EventHandler(this.chkToppingAlmonds_CheckedChanged);
            // 
            // chkToppingChickenFeet
            // 
            this.chkToppingChickenFeet.AutoSize = true;
            this.chkToppingChickenFeet.Location = new System.Drawing.Point(278, 117);
            this.chkToppingChickenFeet.Name = "chkToppingChickenFeet";
            this.chkToppingChickenFeet.Size = new System.Drawing.Size(86, 17);
            this.chkToppingChickenFeet.TabIndex = 14;
            this.chkToppingChickenFeet.Text = "Chicken feet";
            this.chkToppingChickenFeet.UseVisualStyleBackColor = true;
            this.chkToppingChickenFeet.CheckedChanged += new System.EventHandler(this.chkToppingAlmonds_CheckedChanged);
            // 
            // chkToppingTomatoes
            // 
            this.chkToppingTomatoes.AutoSize = true;
            this.chkToppingTomatoes.Location = new System.Drawing.Point(409, 117);
            this.chkToppingTomatoes.Name = "chkToppingTomatoes";
            this.chkToppingTomatoes.Size = new System.Drawing.Size(73, 17);
            this.chkToppingTomatoes.TabIndex = 15;
            this.chkToppingTomatoes.Text = "Tomatoes";
            this.chkToppingTomatoes.UseVisualStyleBackColor = true;
            this.chkToppingTomatoes.CheckedChanged += new System.EventHandler(this.chkToppingAlmonds_CheckedChanged);
            // 
            // chkToppingPanadol
            // 
            this.chkToppingPanadol.AutoSize = true;
            this.chkToppingPanadol.Location = new System.Drawing.Point(152, 117);
            this.chkToppingPanadol.Name = "chkToppingPanadol";
            this.chkToppingPanadol.Size = new System.Drawing.Size(65, 17);
            this.chkToppingPanadol.TabIndex = 13;
            this.chkToppingPanadol.Text = "Panadol";
            this.chkToppingPanadol.UseVisualStyleBackColor = true;
            this.chkToppingPanadol.CheckedChanged += new System.EventHandler(this.chkToppingAlmonds_CheckedChanged);
            // 
            // chkToppingFeta
            // 
            this.chkToppingFeta.AutoSize = true;
            this.chkToppingFeta.Location = new System.Drawing.Point(31, 117);
            this.chkToppingFeta.Name = "chkToppingFeta";
            this.chkToppingFeta.Size = new System.Drawing.Size(47, 17);
            this.chkToppingFeta.TabIndex = 12;
            this.chkToppingFeta.Text = "Feta";
            this.chkToppingFeta.UseVisualStyleBackColor = true;
            this.chkToppingFeta.CheckedChanged += new System.EventHandler(this.chkToppingAlmonds_CheckedChanged);
            // 
            // chkToppingSteamedChicken
            // 
            this.chkToppingSteamedChicken.AutoSize = true;
            this.chkToppingSteamedChicken.Location = new System.Drawing.Point(541, 40);
            this.chkToppingSteamedChicken.Name = "chkToppingSteamedChicken";
            this.chkToppingSteamedChicken.Size = new System.Drawing.Size(110, 17);
            this.chkToppingSteamedChicken.TabIndex = 11;
            this.chkToppingSteamedChicken.Text = "Steamed Chicken";
            this.chkToppingSteamedChicken.UseVisualStyleBackColor = true;
            this.chkToppingSteamedChicken.CheckedChanged += new System.EventHandler(this.chkToppingAlmonds_CheckedChanged);
            // 
            // chkToppingFriedSquid
            // 
            this.chkToppingFriedSquid.AutoSize = true;
            this.chkToppingFriedSquid.Location = new System.Drawing.Point(278, 40);
            this.chkToppingFriedSquid.Name = "chkToppingFriedSquid";
            this.chkToppingFriedSquid.Size = new System.Drawing.Size(77, 17);
            this.chkToppingFriedSquid.TabIndex = 9;
            this.chkToppingFriedSquid.Text = "Fried squid";
            this.chkToppingFriedSquid.UseVisualStyleBackColor = true;
            this.chkToppingFriedSquid.CheckedChanged += new System.EventHandler(this.chkToppingAlmonds_CheckedChanged);
            // 
            // chkToppingWater
            // 
            this.chkToppingWater.AutoSize = true;
            this.chkToppingWater.Location = new System.Drawing.Point(409, 40);
            this.chkToppingWater.Name = "chkToppingWater";
            this.chkToppingWater.Size = new System.Drawing.Size(55, 17);
            this.chkToppingWater.TabIndex = 10;
            this.chkToppingWater.Text = "Water";
            this.chkToppingWater.UseVisualStyleBackColor = true;
            this.chkToppingWater.CheckedChanged += new System.EventHandler(this.chkToppingAlmonds_CheckedChanged);
            // 
            // chkToppingBananas
            // 
            this.chkToppingBananas.AutoSize = true;
            this.chkToppingBananas.Location = new System.Drawing.Point(152, 40);
            this.chkToppingBananas.Name = "chkToppingBananas";
            this.chkToppingBananas.Size = new System.Drawing.Size(68, 17);
            this.chkToppingBananas.TabIndex = 8;
            this.chkToppingBananas.Text = "Bananas";
            this.chkToppingBananas.UseVisualStyleBackColor = true;
            this.chkToppingBananas.CheckedChanged += new System.EventHandler(this.chkToppingAlmonds_CheckedChanged);
            // 
            // chkToppingAlmonds
            // 
            this.chkToppingAlmonds.AutoSize = true;
            this.chkToppingAlmonds.Location = new System.Drawing.Point(31, 40);
            this.chkToppingAlmonds.Name = "chkToppingAlmonds";
            this.chkToppingAlmonds.Size = new System.Drawing.Size(66, 17);
            this.chkToppingAlmonds.TabIndex = 7;
            this.chkToppingAlmonds.Text = "Almonds";
            this.chkToppingAlmonds.UseVisualStyleBackColor = true;
            this.chkToppingAlmonds.CheckedChanged += new System.EventHandler(this.chkToppingAlmonds_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(1104, 601);
            this.Controls.Add(this.grpTopping);
            this.Controls.Add(this.btnOrder);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.grpCrust);
            this.Controls.Add(this.cmbSauce);
            this.Controls.Add(this.txtOrderName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Moto moto\'s Pizza";
            this.grpCrust.ResumeLayout(false);
            this.grpCrust.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.grpTopping.ResumeLayout(false);
            this.grpTopping.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

            }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtOrderName;
        private System.Windows.Forms.ComboBox cmbSauce;
        private System.Windows.Forms.GroupBox grpCrust;
        private System.Windows.Forms.RadioButton rdoCrustGlutenFree;
        private System.Windows.Forms.RadioButton rdoCrustThick;
        private System.Windows.Forms.RadioButton rdoCrustThin;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnOrder;
        private System.Windows.Forms.GroupBox grpTopping;
        private System.Windows.Forms.CheckBox chkToppingi7;
        private System.Windows.Forms.CheckBox chkToppingTruffles;
        private System.Windows.Forms.CheckBox chkToppingEggs;
        private System.Windows.Forms.CheckBox chkToppingSushi;
        private System.Windows.Forms.CheckBox chkToppingMorePineapples;
        private System.Windows.Forms.CheckBox chkToppingPineapples;
        private System.Windows.Forms.CheckBox chkToppingQUTSS;
        private System.Windows.Forms.CheckBox chkToppingChickenFeet;
        private System.Windows.Forms.CheckBox chkToppingTomatoes;
        private System.Windows.Forms.CheckBox chkToppingPanadol;
        private System.Windows.Forms.CheckBox chkToppingFeta;
        private System.Windows.Forms.CheckBox chkToppingSteamedChicken;
        private System.Windows.Forms.CheckBox chkToppingFriedSquid;
        private System.Windows.Forms.CheckBox chkToppingWater;
        private System.Windows.Forms.CheckBox chkToppingBananas;
        private System.Windows.Forms.CheckBox chkToppingAlmonds;
        }
    }

