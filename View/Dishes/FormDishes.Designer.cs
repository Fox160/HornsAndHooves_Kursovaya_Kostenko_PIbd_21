namespace View
{
    partial class FormDishes
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
            this.buttonAddDish = new System.Windows.Forms.Button();
            this.buttonChangeDish = new System.Windows.Forms.Button();
            this.buttonDeleteDish = new System.Windows.Forms.Button();
            this.dataGridViewDishes = new System.Windows.Forms.DataGridView();
            this.dishViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDishes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dishViewModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonAddDish
            // 
            this.buttonAddDish.Location = new System.Drawing.Point(500, 128);
            this.buttonAddDish.Name = "buttonAddDish";
            this.buttonAddDish.Size = new System.Drawing.Size(139, 32);
            this.buttonAddDish.TabIndex = 0;
            this.buttonAddDish.Text = "Добавить блюдо";
            this.buttonAddDish.UseVisualStyleBackColor = true;
            this.buttonAddDish.Click += new System.EventHandler(this.buttonAddDish_Click);
            // 
            // buttonChangeDish
            // 
            this.buttonChangeDish.Location = new System.Drawing.Point(500, 170);
            this.buttonChangeDish.Name = "buttonChangeDish";
            this.buttonChangeDish.Size = new System.Drawing.Size(139, 32);
            this.buttonChangeDish.TabIndex = 1;
            this.buttonChangeDish.Text = "Изменить блюдо";
            this.buttonChangeDish.UseVisualStyleBackColor = true;
            this.buttonChangeDish.Click += new System.EventHandler(this.buttonChangeDish_Click);
            // 
            // buttonDeleteDish
            // 
            this.buttonDeleteDish.Location = new System.Drawing.Point(500, 211);
            this.buttonDeleteDish.Name = "buttonDeleteDish";
            this.buttonDeleteDish.Size = new System.Drawing.Size(139, 32);
            this.buttonDeleteDish.TabIndex = 2;
            this.buttonDeleteDish.Text = "Удалить блюдо";
            this.buttonDeleteDish.UseVisualStyleBackColor = true;
            this.buttonDeleteDish.Click += new System.EventHandler(this.buttonDeleteDish_Click);
            // 
            // dataGridViewDishes
            // 
            this.dataGridViewDishes.AllowUserToAddRows = false;
            this.dataGridViewDishes.AllowUserToDeleteRows = false;
            this.dataGridViewDishes.AutoGenerateColumns = false;
            this.dataGridViewDishes.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridViewDishes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDishes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.priceDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn});
            this.dataGridViewDishes.DataSource = this.dishViewModelBindingSource;
            this.dataGridViewDishes.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewDishes.Name = "dataGridViewDishes";
            this.dataGridViewDishes.ReadOnly = true;
            this.dataGridViewDishes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewDishes.Size = new System.Drawing.Size(469, 388);
            this.dataGridViewDishes.TabIndex = 3;
            // 
            // dishViewModelBindingSource
            // 
            this.dishViewModelBindingSource.DataSource = typeof(Service.ViewModels.DishViewModel);
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
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Описание";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            this.descriptionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // FormDishes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 412);
            this.Controls.Add(this.dataGridViewDishes);
            this.Controls.Add(this.buttonDeleteDish);
            this.Controls.Add(this.buttonChangeDish);
            this.Controls.Add(this.buttonAddDish);
            this.Name = "FormDishes";
            this.Text = "Список блюд";
            this.Load += new System.EventHandler(this.FormDishes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDishes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dishViewModelBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonAddDish;
        private System.Windows.Forms.Button buttonChangeDish;
        private System.Windows.Forms.Button buttonDeleteDish;
        private System.Windows.Forms.DataGridView dataGridViewDishes;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource dishViewModelBindingSource;
    }
}