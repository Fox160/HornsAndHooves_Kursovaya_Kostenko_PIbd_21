namespace View
{
    partial class FormProducts
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
            this.dataGridViewProducts = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.buttonDeleteProduct = new System.Windows.Forms.Button();
            this.buttonChangeProduct = new System.Windows.Forms.Button();
            this.buttonAddProduct = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productViewModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewProducts
            // 
            this.dataGridViewProducts.AllowUserToAddRows = false;
            this.dataGridViewProducts.AllowUserToDeleteRows = false;
            this.dataGridViewProducts.AutoGenerateColumns = false;
            this.dataGridViewProducts.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridViewProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.priceDataGridViewTextBoxColumn});
            this.dataGridViewProducts.DataSource = this.productViewModelBindingSource;
            this.dataGridViewProducts.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewProducts.Name = "dataGridViewProducts";
            this.dataGridViewProducts.ReadOnly = true;
            this.dataGridViewProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewProducts.Size = new System.Drawing.Size(415, 382);
            this.dataGridViewProducts.TabIndex = 7;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Visible = false;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Название";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // priceDataGridViewTextBoxColumn
            // 
            this.priceDataGridViewTextBoxColumn.DataPropertyName = "Price";
            this.priceDataGridViewTextBoxColumn.HeaderText = "Цена";
            this.priceDataGridViewTextBoxColumn.Name = "priceDataGridViewTextBoxColumn";
            this.priceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // productViewModelBindingSource
            // 
            this.productViewModelBindingSource.DataSource = typeof(Service.ViewModels.ProductViewModel);
            // 
            // buttonDeleteProduct
            // 
            this.buttonDeleteProduct.Location = new System.Drawing.Point(448, 223);
            this.buttonDeleteProduct.Name = "buttonDeleteProduct";
            this.buttonDeleteProduct.Size = new System.Drawing.Size(139, 35);
            this.buttonDeleteProduct.TabIndex = 6;
            this.buttonDeleteProduct.Text = "Удалить продукт";
            this.buttonDeleteProduct.UseVisualStyleBackColor = true;
            this.buttonDeleteProduct.Click += new System.EventHandler(this.buttonDeleteProduct_Click);
            // 
            // buttonChangeProduct
            // 
            this.buttonChangeProduct.Location = new System.Drawing.Point(448, 182);
            this.buttonChangeProduct.Name = "buttonChangeProduct";
            this.buttonChangeProduct.Size = new System.Drawing.Size(139, 35);
            this.buttonChangeProduct.TabIndex = 5;
            this.buttonChangeProduct.Text = "Изменить продукт";
            this.buttonChangeProduct.UseVisualStyleBackColor = true;
            this.buttonChangeProduct.Click += new System.EventHandler(this.buttonChangeProduct_Click);
            // 
            // buttonAddProduct
            // 
            this.buttonAddProduct.Location = new System.Drawing.Point(448, 140);
            this.buttonAddProduct.Name = "buttonAddProduct";
            this.buttonAddProduct.Size = new System.Drawing.Size(139, 35);
            this.buttonAddProduct.TabIndex = 4;
            this.buttonAddProduct.Text = "Добавить продукт";
            this.buttonAddProduct.UseVisualStyleBackColor = true;
            this.buttonAddProduct.Click += new System.EventHandler(this.buttonAddProduct_Click);
            // 
            // FormProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 406);
            this.Controls.Add(this.dataGridViewProducts);
            this.Controls.Add(this.buttonDeleteProduct);
            this.Controls.Add(this.buttonChangeProduct);
            this.Controls.Add(this.buttonAddProduct);
            this.Name = "FormProducts";
            this.Text = "Список продуктов";
            this.Load += new System.EventHandler(this.FormProducts_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productViewModelBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewProducts;
        private System.Windows.Forms.Button buttonDeleteProduct;
        private System.Windows.Forms.Button buttonChangeProduct;
        private System.Windows.Forms.Button buttonAddProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource productViewModelBindingSource;
    }
}