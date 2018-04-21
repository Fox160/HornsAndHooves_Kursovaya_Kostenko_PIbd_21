namespace View
{
    partial class FormAddRequest
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
            this.components = new System.ComponentModel.Container();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxTotalSum = new System.Windows.Forms.TextBox();
            this.buttonAddRequest = new System.Windows.Forms.Button();
            this.buttonAddProductToRequest = new System.Windows.Forms.Button();
            this.buttonDeleteProductFromRequest = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.dataGridViewRequestProducts = new System.Windows.Forms.DataGridView();
            this.requestProductViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.requestViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Цена = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RequestId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRequestProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.requestProductViewModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.requestViewModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(410, 267);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Итог:";
            // 
            // textBoxTotalSum
            // 
            this.textBoxTotalSum.Enabled = false;
            this.textBoxTotalSum.Location = new System.Drawing.Point(473, 264);
            this.textBoxTotalSum.Name = "textBoxTotalSum";
            this.textBoxTotalSum.ReadOnly = true;
            this.textBoxTotalSum.Size = new System.Drawing.Size(67, 20);
            this.textBoxTotalSum.TabIndex = 4;
            // 
            // buttonAddRequest
            // 
            this.buttonAddRequest.Location = new System.Drawing.Point(417, 314);
            this.buttonAddRequest.Name = "buttonAddRequest";
            this.buttonAddRequest.Size = new System.Drawing.Size(123, 30);
            this.buttonAddRequest.TabIndex = 5;
            this.buttonAddRequest.Text = "Добавить заявку";
            this.buttonAddRequest.UseVisualStyleBackColor = true;
            this.buttonAddRequest.Click += new System.EventHandler(this.buttonAddRequest_Click);
            // 
            // buttonAddProductToRequest
            // 
            this.buttonAddProductToRequest.Location = new System.Drawing.Point(546, 92);
            this.buttonAddProductToRequest.Name = "buttonAddProductToRequest";
            this.buttonAddProductToRequest.Size = new System.Drawing.Size(124, 53);
            this.buttonAddProductToRequest.TabIndex = 6;
            this.buttonAddProductToRequest.Text = "Добавить заявку на продукт";
            this.buttonAddProductToRequest.UseVisualStyleBackColor = true;
            this.buttonAddProductToRequest.Click += new System.EventHandler(this.buttonAddProductToRequest_Click);
            // 
            // buttonDeleteProductFromRequest
            // 
            this.buttonDeleteProductFromRequest.Location = new System.Drawing.Point(546, 165);
            this.buttonDeleteProductFromRequest.Name = "buttonDeleteProductFromRequest";
            this.buttonDeleteProductFromRequest.Size = new System.Drawing.Size(124, 51);
            this.buttonDeleteProductFromRequest.TabIndex = 7;
            this.buttonDeleteProductFromRequest.Text = "Удалить продукт из заявки";
            this.buttonDeleteProductFromRequest.UseVisualStyleBackColor = true;
            this.buttonDeleteProductFromRequest.Click += new System.EventHandler(this.buttonDeleteProductFromRequest_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(557, 314);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(113, 30);
            this.buttonCancel.TabIndex = 8;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // dataGridViewRequestProducts
            // 
            this.dataGridViewRequestProducts.AllowUserToAddRows = false;
            this.dataGridViewRequestProducts.AllowUserToDeleteRows = false;
            this.dataGridViewRequestProducts.AutoGenerateColumns = false;
            this.dataGridViewRequestProducts.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridViewRequestProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRequestProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.ColumnProductName,
            this.ColumnCount,
            this.ProductId,
            this.Цена,
            this.RequestId});
            this.dataGridViewRequestProducts.DataSource = this.requestProductViewModelBindingSource;
            this.dataGridViewRequestProducts.Location = new System.Drawing.Point(12, 22);
            this.dataGridViewRequestProducts.MultiSelect = false;
            this.dataGridViewRequestProducts.Name = "dataGridViewRequestProducts";
            this.dataGridViewRequestProducts.ReadOnly = true;
            this.dataGridViewRequestProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewRequestProducts.Size = new System.Drawing.Size(528, 236);
            this.dataGridViewRequestProducts.TabIndex = 0;
            // 
            // requestProductViewModelBindingSource
            // 
            this.requestProductViewModelBindingSource.DataSource = typeof(Service.ViewModels.RequestProductViewModel);
            // 
            // requestViewModelBindingSource
            // 
            this.requestViewModelBindingSource.DataSource = typeof(Service.ViewModels.RequestViewModel);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Id";
            this.dataGridViewTextBoxColumn1.HeaderText = "Id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // ColumnProductName
            // 
            this.ColumnProductName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnProductName.DataPropertyName = "ProductName";
            this.ColumnProductName.HeaderText = "Продукт";
            this.ColumnProductName.Name = "ColumnProductName";
            this.ColumnProductName.ReadOnly = true;
            // 
            // ColumnCount
            // 
            this.ColumnCount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnCount.DataPropertyName = "Count";
            this.ColumnCount.HeaderText = "Количество";
            this.ColumnCount.Name = "ColumnCount";
            this.ColumnCount.ReadOnly = true;
            // 
            // ProductId
            // 
            this.ProductId.DataPropertyName = "ProductId";
            this.ProductId.HeaderText = "ProductId";
            this.ProductId.Name = "ProductId";
            this.ProductId.ReadOnly = true;
            this.ProductId.Visible = false;
            // 
            // Цена
            // 
            this.Цена.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Цена.DataPropertyName = "ProductPrice";
            this.Цена.HeaderText = "Цена";
            this.Цена.Name = "Цена";
            this.Цена.ReadOnly = true;
            // 
            // RequestId
            // 
            this.RequestId.DataPropertyName = "RequestId";
            this.RequestId.HeaderText = "RequestId";
            this.RequestId.Name = "RequestId";
            this.RequestId.ReadOnly = true;
            this.RequestId.Visible = false;
            // 
            // FormAddRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 356);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonDeleteProductFromRequest);
            this.Controls.Add(this.buttonAddProductToRequest);
            this.Controls.Add(this.buttonAddRequest);
            this.Controls.Add(this.textBoxTotalSum);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridViewRequestProducts);
            this.Name = "FormAddRequest";
            this.Text = "Формирование заявки";
            this.Load += new System.EventHandler(this.FormAddRequest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRequestProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.requestProductViewModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.requestViewModelBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxTotalSum;
        private System.Windows.Forms.Button buttonAddRequest;
        private System.Windows.Forms.Button buttonAddProductToRequest;
        private System.Windows.Forms.Button buttonDeleteProductFromRequest;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.DataGridView dataGridViewRequestProducts;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn countDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dishIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource requestViewModelBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Цена;
        private System.Windows.Forms.DataGridViewTextBoxColumn RequestId;
        public System.Windows.Forms.BindingSource requestProductViewModelBindingSource;
    }
}