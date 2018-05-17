namespace View
{
    partial class FormMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonDishes = new System.Windows.Forms.Button();
            this.buttonProducts = new System.Windows.Forms.Button();
            this.buttonReports = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonRequests = new System.Windows.Forms.Button();
            this.buttonBackup = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonDishes
            // 
            this.buttonDishes.Location = new System.Drawing.Point(71, 89);
            this.buttonDishes.Name = "buttonDishes";
            this.buttonDishes.Size = new System.Drawing.Size(119, 32);
            this.buttonDishes.TabIndex = 0;
            this.buttonDishes.Text = "Блюда";
            this.buttonDishes.UseVisualStyleBackColor = true;
            this.buttonDishes.Click += new System.EventHandler(this.buttonDishes_Click);
            // 
            // buttonProducts
            // 
            this.buttonProducts.Location = new System.Drawing.Point(71, 31);
            this.buttonProducts.Name = "buttonProducts";
            this.buttonProducts.Size = new System.Drawing.Size(119, 32);
            this.buttonProducts.TabIndex = 1;
            this.buttonProducts.Text = "Продукты";
            this.buttonProducts.UseVisualStyleBackColor = true;
            this.buttonProducts.Click += new System.EventHandler(this.buttonProducts_Click);
            // 
            // buttonReports
            // 
            this.buttonReports.Location = new System.Drawing.Point(71, 198);
            this.buttonReports.Name = "buttonReports";
            this.buttonReports.Size = new System.Drawing.Size(119, 32);
            this.buttonReports.TabIndex = 2;
            this.buttonReports.Text = "Отчеты";
            this.buttonReports.UseVisualStyleBackColor = true;
            this.buttonReports.Click += new System.EventHandler(this.buttonReports_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(71, 304);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(119, 32);
            this.buttonExit.TabIndex = 3;
            this.buttonExit.Text = "Выход";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonRequests
            // 
            this.buttonRequests.Location = new System.Drawing.Point(71, 143);
            this.buttonRequests.Name = "buttonRequests";
            this.buttonRequests.Size = new System.Drawing.Size(119, 32);
            this.buttonRequests.TabIndex = 4;
            this.buttonRequests.Text = "Заявки";
            this.buttonRequests.UseVisualStyleBackColor = true;
            this.buttonRequests.Click += new System.EventHandler(this.buttonRequests_Click);
            // 
            // buttonBackup
            // 
            this.buttonBackup.Location = new System.Drawing.Point(71, 249);
            this.buttonBackup.Name = "buttonBackup";
            this.buttonBackup.Size = new System.Drawing.Size(119, 32);
            this.buttonBackup.TabIndex = 5;
            this.buttonBackup.Text = "Бэкап";
            this.buttonBackup.UseVisualStyleBackColor = true;
            this.buttonBackup.Click += new System.EventHandler(this.buttonBackup_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 362);
            this.Controls.Add(this.buttonBackup);
            this.Controls.Add(this.buttonRequests);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonReports);
            this.Controls.Add(this.buttonProducts);
            this.Controls.Add(this.buttonDishes);
            this.Name = "FormMain";
            this.Text = "Главное меню";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonDishes;
        private System.Windows.Forms.Button buttonProducts;
        private System.Windows.Forms.Button buttonReports;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonRequests;
        private System.Windows.Forms.Button buttonBackup;
    }
}

