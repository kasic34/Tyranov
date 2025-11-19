namespace HotelProject2
{
    partial class FormAdmin
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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxTables = new System.Windows.Forms.ComboBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonUp = new System.Windows.Forms.Button();
            this.buttonDelit = new System.Windows.Forms.Button();
            this.buttonExitAdmin = new System.Windows.Forms.Button();
            this.dataGridViewRelated = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRelated)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 77);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(960, 416);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(418, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "База данных";
            // 
            // comboBoxTables
            // 
            this.comboBoxTables.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxTables.FormattingEnabled = true;
            this.comboBoxTables.Location = new System.Drawing.Point(806, 39);
            this.comboBoxTables.Name = "comboBoxTables";
            this.comboBoxTables.Size = new System.Drawing.Size(166, 32);
            this.comboBoxTables.TabIndex = 2;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAdd.Location = new System.Drawing.Point(12, 518);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(120, 36);
            this.buttonAdd.TabIndex = 3;
            this.buttonAdd.Text = "Добавить\r\n";
            this.buttonAdd.UseVisualStyleBackColor = true;
            // 
            // buttonUp
            // 
            this.buttonUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonUp.Location = new System.Drawing.Point(138, 518);
            this.buttonUp.Name = "buttonUp";
            this.buttonUp.Size = new System.Drawing.Size(120, 36);
            this.buttonUp.TabIndex = 4;
            this.buttonUp.Text = "Изменить";
            this.buttonUp.UseVisualStyleBackColor = true;
            // 
            // buttonDelit
            // 
            this.buttonDelit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDelit.Location = new System.Drawing.Point(264, 518);
            this.buttonDelit.Name = "buttonDelit";
            this.buttonDelit.Size = new System.Drawing.Size(120, 36);
            this.buttonDelit.TabIndex = 5;
            this.buttonDelit.Text = "Удалить";
            this.buttonDelit.UseVisualStyleBackColor = true;
            // 
            // buttonExitAdmin
            // 
            this.buttonExitAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonExitAdmin.Location = new System.Drawing.Point(852, 518);
            this.buttonExitAdmin.Name = "buttonExitAdmin";
            this.buttonExitAdmin.Size = new System.Drawing.Size(120, 36);
            this.buttonExitAdmin.TabIndex = 6;
            this.buttonExitAdmin.Text = "Выход";
            this.buttonExitAdmin.UseVisualStyleBackColor = true;
            // 
            // dataGridViewRelated
            // 
            this.dataGridViewRelated.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRelated.Location = new System.Drawing.Point(634, 77);
            this.dataGridViewRelated.Name = "dataGridViewRelated";
            this.dataGridViewRelated.Size = new System.Drawing.Size(338, 416);
            this.dataGridViewRelated.TabIndex = 7;
            // 
            // FormAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.dataGridViewRelated);
            this.Controls.Add(this.buttonExitAdmin);
            this.Controls.Add(this.buttonDelit);
            this.Controls.Add(this.buttonUp);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.comboBoxTables);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView);
            this.Name = "FormAdmin";
            this.Text = "Hotel";
            this.Load += new System.EventHandler(this.FormAdmin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRelated)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxTables;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonUp;
        private System.Windows.Forms.Button buttonDelit;
        private System.Windows.Forms.Button buttonExitAdmin;
        private System.Windows.Forms.DataGridView dataGridViewRelated;
    }
}