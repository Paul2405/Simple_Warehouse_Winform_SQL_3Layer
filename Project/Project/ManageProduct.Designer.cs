namespace Project
{
    partial class ManageProduct
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
            this.dgvView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPricePack = new System.Windows.Forms.TextBox();
            this.txtPriceSub = new System.Windows.Forms.TextBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.ProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PackageID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubPackage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuantityPackage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuantitySub = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PricePackage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PriceSubPackage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PricePackageExport = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PriceSubExport = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubResidual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbInfor = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvView)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvView
            // 
            this.dgvView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProductID,
            this.ProductName,
            this.Description,
            this.PackageID,
            this.SubPackage,
            this.QuantityPackage,
            this.QuantitySub,
            this.PricePackage,
            this.PriceSubPackage,
            this.PricePackageExport,
            this.PriceSubExport,
            this.SubResidual});
            this.dgvView.Location = new System.Drawing.Point(12, 50);
            this.dgvView.Name = "dgvView";
            this.dgvView.Size = new System.Drawing.Size(1313, 261);
            this.dgvView.TabIndex = 0;
            this.dgvView.Click += new System.EventHandler(this.DgvView_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Algerian", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(521, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(215, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "List Product";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(135, 358);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Price package export:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(668, 354);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Price sub package export:";
            // 
            // txtPricePack
            // 
            this.txtPricePack.Location = new System.Drawing.Point(321, 351);
            this.txtPricePack.Name = "txtPricePack";
            this.txtPricePack.Size = new System.Drawing.Size(263, 20);
            this.txtPricePack.TabIndex = 4;
            // 
            // txtPriceSub
            // 
            this.txtPriceSub.Location = new System.Drawing.Point(859, 352);
            this.txtPriceSub.Name = "txtPriceSub";
            this.txtPriceSub.Size = new System.Drawing.Size(270, 20);
            this.txtPriceSub.TabIndex = 5;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(432, 404);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 6;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(601, 404);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 7;
            this.btnUpdate.Text = "Udpate";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(784, 404);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 8;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.BtnRemove_Click);
            // 
            // ProductID
            // 
            this.ProductID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ProductID.DataPropertyName = "ProductID";
            this.ProductID.HeaderText = "ProductID";
            this.ProductID.Name = "ProductID";
            // 
            // ProductName
            // 
            this.ProductName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ProductName.DataPropertyName = "ProductName";
            this.ProductName.HeaderText = "Name";
            this.ProductName.Name = "ProductName";
            // 
            // Description
            // 
            this.Description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Description.DataPropertyName = "Description";
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            // 
            // PackageID
            // 
            this.PackageID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PackageID.DataPropertyName = "Package";
            this.PackageID.HeaderText = "Package";
            this.PackageID.Name = "PackageID";
            // 
            // SubPackage
            // 
            this.SubPackage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SubPackage.DataPropertyName = "Subpackage";
            this.SubPackage.HeaderText = "SubPackage";
            this.SubPackage.Name = "SubPackage";
            // 
            // QuantityPackage
            // 
            this.QuantityPackage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.QuantityPackage.DataPropertyName = "NumPackage";
            this.QuantityPackage.HeaderText = "QuantityPackage";
            this.QuantityPackage.Name = "QuantityPackage";
            // 
            // QuantitySub
            // 
            this.QuantitySub.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.QuantitySub.DataPropertyName = "NumSub";
            this.QuantitySub.HeaderText = "QuantitySub";
            this.QuantitySub.Name = "QuantitySub";
            // 
            // PricePackage
            // 
            this.PricePackage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PricePackage.DataPropertyName = "PricePackage";
            this.PricePackage.HeaderText = "PricePackage";
            this.PricePackage.Name = "PricePackage";
            // 
            // PriceSubPackage
            // 
            this.PriceSubPackage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PriceSubPackage.DataPropertyName = "PriceSub";
            this.PriceSubPackage.HeaderText = "PriceSub";
            this.PriceSubPackage.Name = "PriceSubPackage";
            // 
            // PricePackageExport
            // 
            this.PricePackageExport.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PricePackageExport.DataPropertyName = "PricePackExport";
            this.PricePackageExport.HeaderText = "PricePackageExport";
            this.PricePackageExport.Name = "PricePackageExport";
            // 
            // PriceSubExport
            // 
            this.PriceSubExport.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PriceSubExport.DataPropertyName = "PriceSubExport";
            this.PriceSubExport.HeaderText = "PriceSubExport";
            this.PriceSubExport.Name = "PriceSubExport";
            // 
            // SubResidual
            // 
            this.SubResidual.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SubResidual.DataPropertyName = "SubRe";
            this.SubResidual.HeaderText = "SubResidual";
            this.SubResidual.Name = "SubResidual";
            // 
            // lbInfor
            // 
            this.lbInfor.AutoSize = true;
            this.lbInfor.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbInfor.Location = new System.Drawing.Point(138, 328);
            this.lbInfor.Name = "lbInfor";
            this.lbInfor.Size = new System.Drawing.Size(0, 15);
            this.lbInfor.TabIndex = 9;
            // 
            // ManageProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1337, 450);
            this.Controls.Add(this.lbInfor);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.txtPriceSub);
            this.Controls.Add(this.txtPricePack);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvView);
            this.Name = "ManageProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ManageProduct";
            this.Load += new System.EventHandler(this.ManageProduct_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPricePack;
        private System.Windows.Forms.TextBox txtPriceSub;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn PackageID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubPackage;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuantityPackage;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuantitySub;
        private System.Windows.Forms.DataGridViewTextBoxColumn PricePackage;
        private System.Windows.Forms.DataGridViewTextBoxColumn PriceSubPackage;
        private System.Windows.Forms.DataGridViewTextBoxColumn PricePackageExport;
        private System.Windows.Forms.DataGridViewTextBoxColumn PriceSubExport;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubResidual;
        private System.Windows.Forms.Label lbInfor;
    }
}