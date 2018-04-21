namespace View
{
    partial class FormReports
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
            this.buttonMakeReports = new System.Windows.Forms.Button();
            this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSaveToPdf = new System.Windows.Forms.Button();
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // buttonMakeReports
            // 
            this.buttonMakeReports.Location = new System.Drawing.Point(640, 25);
            this.buttonMakeReports.Name = "buttonMakeReports";
            this.buttonMakeReports.Size = new System.Drawing.Size(143, 24);
            this.buttonMakeReports.TabIndex = 0;
            this.buttonMakeReports.Text = "Показать отчеты";
            this.buttonMakeReports.UseVisualStyleBackColor = true;
            this.buttonMakeReports.Click += new System.EventHandler(this.buttonMake_Click);
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.Location = new System.Drawing.Point(39, 29);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(144, 20);
            this.dateTimePickerFrom.TabIndex = 1;
            // 
            // dateTimePickerTo
            // 
            this.dateTimePickerTo.Location = new System.Drawing.Point(231, 29);
            this.dateTimePickerTo.Name = "dateTimePickerTo";
            this.dateTimePickerTo.Size = new System.Drawing.Size(144, 20);
            this.dateTimePickerTo.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(200, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "—";
            // 
            // buttonSaveToPdf
            // 
            this.buttonSaveToPdf.Location = new System.Drawing.Point(664, 509);
            this.buttonSaveToPdf.Name = "buttonSaveToPdf";
            this.buttonSaveToPdf.Size = new System.Drawing.Size(119, 37);
            this.buttonSaveToPdf.TabIndex = 4;
            this.buttonSaveToPdf.Text = "Сохранить отчет в pdf";
            this.buttonSaveToPdf.UseVisualStyleBackColor = true;
            this.buttonSaveToPdf.Click += new System.EventHandler(this.buttonToPdf_Click);
            // 
            // reportViewer
            // 
            this.reportViewer.LocalReport.ReportEmbeddedResource = "View.ReportDishesProducts.rdlc";
            this.reportViewer.Location = new System.Drawing.Point(12, 70);
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.ServerReport.BearerToken = null;
            this.reportViewer.Size = new System.Drawing.Size(771, 423);
            this.reportViewer.TabIndex = 5;
            // 
            // FormReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 558);
            this.Controls.Add(this.reportViewer);
            this.Controls.Add(this.buttonSaveToPdf);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePickerTo);
            this.Controls.Add(this.dateTimePickerFrom);
            this.Controls.Add(this.buttonMakeReports);
            this.Name = "FormReports";
            this.Text = "Отчёты";
            this.Load += new System.EventHandler(this.FormReports_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonMakeReports;
        private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
        private System.Windows.Forms.DateTimePicker dateTimePickerTo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSaveToPdf;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
    }
}