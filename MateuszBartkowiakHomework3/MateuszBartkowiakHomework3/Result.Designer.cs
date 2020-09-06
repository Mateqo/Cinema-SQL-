namespace MateuszBartkowiakHomework3
{
    partial class Result
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Result));
            this.labelOrders = new System.Windows.Forms.Label();
            this.dataGridViewOrder = new System.Windows.Forms.DataGridView();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.labelYourId = new System.Windows.Forms.Label();
            this.labelActiveId = new System.Windows.Forms.Label();
            this.buttonFiltr = new System.Windows.Forms.Button();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.pictureBoxInfo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // labelOrders
            // 
            this.labelOrders.AutoSize = true;
            this.labelOrders.BackColor = System.Drawing.Color.Transparent;
            this.labelOrders.Font = new System.Drawing.Font("Modern No. 20", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOrders.ForeColor = System.Drawing.Color.GreenYellow;
            this.labelOrders.Location = new System.Drawing.Point(324, 9);
            this.labelOrders.Name = "labelOrders";
            this.labelOrders.Size = new System.Drawing.Size(194, 62);
            this.labelOrders.TabIndex = 0;
            this.labelOrders.Text = "Orders";
            this.labelOrders.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dataGridViewOrder
            // 
            this.dataGridViewOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOrder.Location = new System.Drawing.Point(12, 89);
            this.dataGridViewOrder.Name = "dataGridViewOrder";
            this.dataGridViewOrder.ReadOnly = true;
            this.dataGridViewOrder.RowTemplate.Height = 24;
            this.dataGridViewOrder.Size = new System.Drawing.Size(428, 246);
            this.dataGridViewOrder.TabIndex = 1;
            // 
            // buttonDelete
            // 
            this.buttonDelete.AutoSize = true;
            this.buttonDelete.BackColor = System.Drawing.Color.Bisque;
            this.buttonDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonDelete.Font = new System.Drawing.Font("Modern No. 20", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDelete.Location = new System.Drawing.Point(232, 341);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(208, 59);
            this.buttonDelete.TabIndex = 3;
            this.buttonDelete.Text = "Delete my order";
            this.buttonDelete.UseVisualStyleBackColor = false;
            this.buttonDelete.Click += new System.EventHandler(this.ButtonDelete_Click);
            // 
            // labelYourId
            // 
            this.labelYourId.AutoSize = true;
            this.labelYourId.BackColor = System.Drawing.Color.Transparent;
            this.labelYourId.Font = new System.Drawing.Font("Modern No. 20", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelYourId.ForeColor = System.Drawing.Color.GreenYellow;
            this.labelYourId.Location = new System.Drawing.Point(539, 153);
            this.labelYourId.Name = "labelYourId";
            this.labelYourId.Size = new System.Drawing.Size(260, 40);
            this.labelYourId.TabIndex = 6;
            this.labelYourId.Text = "OrderTicketId ";
            this.labelYourId.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelActiveId
            // 
            this.labelActiveId.AutoSize = true;
            this.labelActiveId.BackColor = System.Drawing.Color.Transparent;
            this.labelActiveId.Font = new System.Drawing.Font("Modern No. 20", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelActiveId.ForeColor = System.Drawing.Color.GreenYellow;
            this.labelActiveId.Location = new System.Drawing.Point(652, 193);
            this.labelActiveId.Name = "labelActiveId";
            this.labelActiveId.Size = new System.Drawing.Size(35, 40);
            this.labelActiveId.TabIndex = 7;
            this.labelActiveId.Text = "1";
            this.labelActiveId.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // buttonFiltr
            // 
            this.buttonFiltr.AutoSize = true;
            this.buttonFiltr.BackColor = System.Drawing.Color.Bisque;
            this.buttonFiltr.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonFiltr.Font = new System.Drawing.Font("Modern No. 20", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFiltr.Location = new System.Drawing.Point(12, 341);
            this.buttonFiltr.Name = "buttonFiltr";
            this.buttonFiltr.Size = new System.Drawing.Size(205, 59);
            this.buttonFiltr.TabIndex = 8;
            this.buttonFiltr.Text = "Show my order";
            this.buttonFiltr.UseVisualStyleBackColor = false;
            this.buttonFiltr.Click += new System.EventHandler(this.ButtonFiltr_Click);
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.AutoSize = true;
            this.buttonConfirm.BackColor = System.Drawing.Color.Bisque;
            this.buttonConfirm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonConfirm.Font = new System.Drawing.Font("Modern No. 20", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonConfirm.Location = new System.Drawing.Point(681, 379);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(109, 59);
            this.buttonConfirm.TabIndex = 9;
            this.buttonConfirm.Text = "Confirm";
            this.buttonConfirm.UseVisualStyleBackColor = false;
            this.buttonConfirm.Click += new System.EventHandler(this.ButtonConfirm_Click);
            // 
            // pictureBoxInfo
            // 
            this.pictureBoxInfo.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxInfo.BackgroundImage = global::MateuszBartkowiakHomework3.Properties.Resources.user;
            this.pictureBoxInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxInfo.Location = new System.Drawing.Point(721, 12);
            this.pictureBoxInfo.Name = "pictureBoxInfo";
            this.pictureBoxInfo.Size = new System.Drawing.Size(67, 62);
            this.pictureBoxInfo.TabIndex = 58;
            this.pictureBoxInfo.TabStop = false;
            this.pictureBoxInfo.Click += new System.EventHandler(this.PictureBoxInfo_Click);
            // 
            // Result
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBoxInfo);
            this.Controls.Add(this.buttonConfirm);
            this.Controls.Add(this.buttonFiltr);
            this.Controls.Add(this.labelActiveId);
            this.Controls.Add(this.labelYourId);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.dataGridViewOrder);
            this.Controls.Add(this.labelOrders);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Result";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Result";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelOrders;
        private System.Windows.Forms.DataGridView dataGridViewOrder;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Label labelYourId;
        private System.Windows.Forms.Label labelActiveId;
        private System.Windows.Forms.Button buttonFiltr;
        private System.Windows.Forms.Button buttonConfirm;
        private System.Windows.Forms.PictureBox pictureBoxInfo;
    }
}