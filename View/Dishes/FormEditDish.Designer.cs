namespace View
{
    partial class FormAddDish
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxDishName = new System.Windows.Forms.TextBox();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.textBoxDishPrice = new System.Windows.Forms.TextBox();
            this.groupBoxProducts = new System.Windows.Forms.GroupBox();
            this.buttonDeleteProduct = new System.Windows.Forms.Button();
            this.buttonChangeProduct = new System.Windows.Forms.Button();
            this.buttonAddProduct = new System.Windows.Forms.Button();
            this.dataGridViewProducts = new System.Windows.Forms.DataGridView();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSaveDish = new System.Windows.Forms.Button();
            this.requestViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dishProductViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DishId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBoxProducts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.requestViewModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dishProductViewModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Название:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Цена:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Описание:";
            // 
            // textBoxDishName
            // 
            this.textBoxDishName.Location = new System.Drawing.Point(118, 19);
            this.textBoxDishName.Name = "textBoxDishName";
            this.textBoxDishName.Size = new System.Drawing.Size(372, 20);
            this.textBoxDishName.TabIndex = 3;
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Location = new System.Drawing.Point(118, 73);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(372, 70);
            this.textBoxDescription.TabIndex = 4;
            // 
            // textBoxDishPrice
            // 
            this.textBoxDishPrice.Location = new System.Drawing.Point(118, 47);
            this.textBoxDishPrice.Name = "textBoxDishPrice";
            this.textBoxDishPrice.Size = new System.Drawing.Size(372, 20);
            this.textBoxDishPrice.TabIndex = 5;
            // 
            // groupBoxProducts
            // 
            this.groupBoxProducts.Controls.Add(this.buttonDeleteProduct);
            this.groupBoxProducts.Controls.Add(this.buttonChangeProduct);
            this.groupBoxProducts.Controls.Add(this.buttonAddProduct);
            this.groupBoxProducts.Controls.Add(this.dataGridViewProducts);
            this.groupBoxProducts.Location = new System.Drawing.Point(12, 162);
            this.groupBoxProducts.Name = "groupBoxProducts";
            this.groupBoxProducts.Size = new System.Drawing.Size(478, 250);
            this.groupBoxProducts.TabIndex = 7;
            this.groupBoxProducts.TabStop = false;
            this.groupBoxProducts.Text = "Продукты для блюда";
            // 
            // buttonDeleteProduct
            // 
            this.buttonDeleteProduct.Location = new System.Drawing.Point(378, 107);
            this.buttonDeleteProduct.Name = "buttonDeleteProduct";
            this.buttonDeleteProduct.Size = new System.Drawing.Size(75, 23);
            this.buttonDeleteProduct.TabIndex = 3;
            this.buttonDeleteProduct.Text = "Удалить";
            this.buttonDeleteProduct.UseVisualStyleBackColor = true;
            this.buttonDeleteProduct.Click += new System.EventHandler(this.buttonDeleteProduct_Click);
            // 
            // buttonChangeProduct
            // 
            this.buttonChangeProduct.Location = new System.Drawing.Point(378, 66);
            this.buttonChangeProduct.Name = "buttonChangeProduct";
            this.buttonChangeProduct.Size = new System.Drawing.Size(75, 23);
            this.buttonChangeProduct.TabIndex = 2;
            this.buttonChangeProduct.Text = "Изменить";
            this.buttonChangeProduct.UseVisualStyleBackColor = true;
            this.buttonChangeProduct.Click += new System.EventHandler(this.buttonChangeProduct_Click);
            // 
            // buttonAddProduct
            // 
            this.buttonAddProduct.Location = new System.Drawing.Point(378, 28);
            this.buttonAddProduct.Name = "buttonAddProduct";
            this.buttonAddProduct.Size = new System.Drawing.Size(75, 23);
            this.buttonAddProduct.TabIndex = 1;
            this.buttonAddProduct.Text = "Добавить";
            this.buttonAddProduct.UseVisualStyleBackColor = true;
            this.buttonAddProduct.Click += new System.EventHandler(this.buttonAddProduct_Click);
            // 
            // dataGridViewProducts
            // 
            this.dataGridViewProducts.AllowUserToAddRows = false;
            this.dataGridViewProducts.AllowUserToDeleteRows = false;
            this.dataGridViewProducts.AutoGenerateColumns = false;
            this.dataGridViewProducts.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridViewProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.DishId,
            this.ProductId,
            this.ProductName,
            this.Count});
            this.dataGridViewProducts.DataSource = this.dishProductViewModelBindingSource;
            this.dataGridViewProducts.Dock = System.Windows.Forms.DockStyle.Left;
            this.dataGridViewProducts.Location = new System.Drawing.Point(3, 16);
            this.dataGridViewProducts.Name = "dataGridViewProducts";
            this.dataGridViewProducts.ReadOnly = true;
            this.dataGridViewProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewProducts.Size = new System.Drawing.Size(350, 231);
            this.dataGridViewProducts.TabIndex = 0;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(415, 431);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 9;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonSaveDish
            // 
            this.buttonSaveDish.Location = new System.Drawing.Point(312, 431);
            this.buttonSaveDish.Name = "buttonSaveDish";
            this.buttonSaveDish.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveDish.TabIndex = 8;
            this.buttonSaveDish.Text = "Сохранить";
            this.buttonSaveDish.UseVisualStyleBackColor = true;
            this.buttonSaveDish.Click += new System.EventHandler(this.buttonSaveDish_Click);
            // 
            // requestViewModelBindingSource
            // 
            this.requestViewModelBindingSource.DataSource = typeof(Service.ViewModels.RequestViewModel);
            // 
            // dishProductViewModelBindingSource
            // 
            this.dishProductViewModelBindingSource.DataSource = typeof(Service.ViewModels.DishProductViewModel);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Visible = false;
            // 
            // DishId
            // 
            this.DishId.DataPropertyName = "DishId";
            this.DishId.HeaderText = "DishId";
            this.DishId.Name = "DishId";
            this.DishId.ReadOnly = true;
            this.DishId.Visible = false;
            // 
            // ProductId
            // 
            this.ProductId.DataPropertyName = "ProductId";
            this.ProductId.HeaderText = "ProductId";
            this.ProductId.Name = "ProductId";
            this.ProductId.ReadOnly = true;
            this.ProductId.Visible = false;
            // 
            // ProductName
            // 
            this.ProductName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ProductName.DataPropertyName = "ProductName";
            this.ProductName.HeaderText = "Название";
            this.ProductName.Name = "ProductName";
            this.ProductName.ReadOnly = true;
            // 
            // Count
            // 
            this.Count.DataPropertyName = "Count";
            this.Count.HeaderText = "Количество";
            this.Count.Name = "Count";
            this.Count.ReadOnly = true;
            // 
            // FormAddDish
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 477);
            this.Controls.Add(this.groupBoxProducts);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSaveDish);
            this.Controls.Add(this.textBoxDishPrice);
            this.Controls.Add(this.textBoxDescription);
            this.Controls.Add(this.textBoxDishName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormAddDish";
            this.Text = "Добавление блюда";
            this.Load += new System.EventHandler(this.FormAddDish_Load);
            this.groupBoxProducts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.requestViewModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dishProductViewModelBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxDishName;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.TextBox textBoxDishPrice;
        private System.Windows.Forms.GroupBox groupBoxProducts;
        private System.Windows.Forms.Button buttonDeleteProduct;
        private System.Windows.Forms.Button buttonChangeProduct;
        private System.Windows.Forms.Button buttonAddProduct;
        private System.Windows.Forms.DataGridView dataGridViewProducts;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSaveDish;
        private System.Windows.Forms.BindingSource dishProductViewModelBindingSource;
        private System.Windows.Forms.BindingSource requestViewModelBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DishId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Count;
    }
}