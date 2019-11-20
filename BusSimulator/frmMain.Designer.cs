namespace BusSimulator
{
    partial class frmMain
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
            this.btnExit = new System.Windows.Forms.Button();
            this.btnLoadFile = new System.Windows.Forms.Button();
            this.tBxFileAddress = new System.Windows.Forms.TextBox();
            this.gpBxData = new System.Windows.Forms.GroupBox();
            this.gpBxAction = new System.Windows.Forms.GroupBox();
            this.lblResult = new System.Windows.Forms.Label();
            this.lbl3 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.cBxFinish = new System.Windows.Forms.ComboBox();
            this.cBxTime = new System.Windows.Forms.ComboBox();
            this.cBxStart = new System.Windows.Forms.ComboBox();
            this.btnFindRoutes = new System.Windows.Forms.Button();
            this.gpBxData.SuspendLayout();
            this.gpBxAction.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(417, 415);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 0;
            this.btnExit.Text = "Выход";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnLoadFile
            // 
            this.btnLoadFile.Location = new System.Drawing.Point(357, 45);
            this.btnLoadFile.Name = "btnLoadFile";
            this.btnLoadFile.Size = new System.Drawing.Size(123, 23);
            this.btnLoadFile.TabIndex = 1;
            this.btnLoadFile.Text = "Загрузить файл";
            this.btnLoadFile.UseVisualStyleBackColor = true;
            this.btnLoadFile.Click += new System.EventHandler(this.btnLoadFile_Click);
            // 
            // tBxFileAddress
            // 
            this.tBxFileAddress.Location = new System.Drawing.Point(6, 19);
            this.tBxFileAddress.Name = "tBxFileAddress";
            this.tBxFileAddress.Size = new System.Drawing.Size(474, 20);
            this.tBxFileAddress.TabIndex = 2;
            // 
            // gpBxData
            // 
            this.gpBxData.Controls.Add(this.btnLoadFile);
            this.gpBxData.Controls.Add(this.tBxFileAddress);
            this.gpBxData.Location = new System.Drawing.Point(12, 12);
            this.gpBxData.Name = "gpBxData";
            this.gpBxData.Size = new System.Drawing.Size(486, 81);
            this.gpBxData.TabIndex = 4;
            this.gpBxData.TabStop = false;
            this.gpBxData.Text = "Путь к файлу:";
            // 
            // gpBxAction
            // 
            this.gpBxAction.Controls.Add(this.lblResult);
            this.gpBxAction.Controls.Add(this.lbl3);
            this.gpBxAction.Controls.Add(this.lbl2);
            this.gpBxAction.Controls.Add(this.lbl1);
            this.gpBxAction.Controls.Add(this.cBxFinish);
            this.gpBxAction.Controls.Add(this.cBxTime);
            this.gpBxAction.Controls.Add(this.cBxStart);
            this.gpBxAction.Controls.Add(this.btnFindRoutes);
            this.gpBxAction.Location = new System.Drawing.Point(12, 99);
            this.gpBxAction.Name = "gpBxAction";
            this.gpBxAction.Size = new System.Drawing.Size(486, 310);
            this.gpBxAction.TabIndex = 5;
            this.gpBxAction.TabStop = false;
            this.gpBxAction.Text = "Поиск путей:";
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblResult.Location = new System.Drawing.Point(16, 138);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(94, 36);
            this.lblResult.TabIndex = 10;
            this.lblResult.Text = "Результат:\r\n-\r\n";
            // 
            // lbl3
            // 
            this.lbl3.AutoSize = true;
            this.lbl3.Location = new System.Drawing.Point(241, 25);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(108, 13);
            this.lbl3.TabIndex = 9;
            this.lbl3.Text = "Время отправления";
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Location = new System.Drawing.Point(135, 25);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(86, 13);
            this.lbl2.TabIndex = 8;
            this.lbl2.Text = "Конечная точка";
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Location = new System.Drawing.Point(16, 25);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(93, 13);
            this.lbl1.TabIndex = 7;
            this.lbl1.Text = "Начальная точка";
            // 
            // cBxFinish
            // 
            this.cBxFinish.FormattingEnabled = true;
            this.cBxFinish.Location = new System.Drawing.Point(132, 41);
            this.cBxFinish.Name = "cBxFinish";
            this.cBxFinish.Size = new System.Drawing.Size(98, 21);
            this.cBxFinish.TabIndex = 6;
            this.cBxFinish.SelectedIndexChanged += new System.EventHandler(this.cBxFinish_SelectedIndexChanged);
            // 
            // cBxTime
            // 
            this.cBxTime.FormattingEnabled = true;
            this.cBxTime.Location = new System.Drawing.Point(244, 41);
            this.cBxTime.Name = "cBxTime";
            this.cBxTime.Size = new System.Drawing.Size(98, 21);
            this.cBxTime.TabIndex = 5;
            // 
            // cBxStart
            // 
            this.cBxStart.FormattingEnabled = true;
            this.cBxStart.Location = new System.Drawing.Point(16, 41);
            this.cBxStart.Name = "cBxStart";
            this.cBxStart.Size = new System.Drawing.Size(98, 21);
            this.cBxStart.TabIndex = 4;
            this.cBxStart.SelectedIndexChanged += new System.EventHandler(this.cBxStart_SelectedIndexChanged);
            // 
            // btnFindRoutes
            // 
            this.btnFindRoutes.Location = new System.Drawing.Point(405, 281);
            this.btnFindRoutes.Name = "btnFindRoutes";
            this.btnFindRoutes.Size = new System.Drawing.Size(75, 23);
            this.btnFindRoutes.TabIndex = 3;
            this.btnFindRoutes.Text = "Поиск";
            this.btnFindRoutes.UseVisualStyleBackColor = true;
            this.btnFindRoutes.Click += new System.EventHandler(this.btnFindRoutes_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 450);
            this.Controls.Add(this.gpBxAction);
            this.Controls.Add(this.gpBxData);
            this.Controls.Add(this.btnExit);
            this.Name = "frmMain";
            this.Text = "BusSimulator";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.gpBxData.ResumeLayout(false);
            this.gpBxData.PerformLayout();
            this.gpBxAction.ResumeLayout(false);
            this.gpBxAction.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnLoadFile;
        private System.Windows.Forms.TextBox tBxFileAddress;
        private System.Windows.Forms.GroupBox gpBxData;
        private System.Windows.Forms.GroupBox gpBxAction;
        private System.Windows.Forms.Button btnFindRoutes;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label lbl3;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.ComboBox cBxFinish;
        private System.Windows.Forms.ComboBox cBxTime;
        private System.Windows.Forms.ComboBox cBxStart;
    }
}

