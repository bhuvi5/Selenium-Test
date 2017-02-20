namespace Pro_Tester_UI
{
    partial class ApplicationTest
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
            this.btn_execute = new System.Windows.Forms.Button();
            this.lbl_testCaseID = new System.Windows.Forms.Label();
            this.txt_testCaseID = new System.Windows.Forms.TextBox();
            this.btn_stop = new System.Windows.Forms.Button();
            this.chk_Priority = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btn_execute
            // 
            this.btn_execute.Location = new System.Drawing.Point(15, 104);
            this.btn_execute.Name = "btn_execute";
            this.btn_execute.Size = new System.Drawing.Size(75, 23);
            this.btn_execute.TabIndex = 0;
            this.btn_execute.Text = "Execute";
            this.btn_execute.UseVisualStyleBackColor = true;
            this.btn_execute.Click += new System.EventHandler(this.btn_execute_Click);
            // 
            // lbl_testCaseID
            // 
            this.lbl_testCaseID.AutoSize = true;
            this.lbl_testCaseID.Location = new System.Drawing.Point(12, 35);
            this.lbl_testCaseID.Name = "lbl_testCaseID";
            this.lbl_testCaseID.Size = new System.Drawing.Size(63, 13);
            this.lbl_testCaseID.TabIndex = 1;
            this.lbl_testCaseID.Text = "TestCaseID";
            // 
            // txt_testCaseID
            // 
            this.txt_testCaseID.Location = new System.Drawing.Point(97, 35);
            this.txt_testCaseID.Name = "txt_testCaseID";
            this.txt_testCaseID.Size = new System.Drawing.Size(100, 20);
            this.txt_testCaseID.TabIndex = 2;
            // 
            // btn_stop
            // 
            this.btn_stop.Location = new System.Drawing.Point(134, 104);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Size = new System.Drawing.Size(75, 23);
            this.btn_stop.TabIndex = 3;
            this.btn_stop.Text = "Stop";
            this.btn_stop.UseVisualStyleBackColor = true;
            this.btn_stop.Click += new System.EventHandler(this.btn_stop_Click);
            // 
            // chk_Priority
            // 
            this.chk_Priority.AutoSize = true;
            this.chk_Priority.Checked = true;
            this.chk_Priority.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_Priority.Location = new System.Drawing.Point(236, 38);
            this.chk_Priority.Name = "chk_Priority";
            this.chk_Priority.Size = new System.Drawing.Size(57, 17);
            this.chk_Priority.TabIndex = 4;
            this.chk_Priority.Text = "Priority";
            this.chk_Priority.UseVisualStyleBackColor = true;
            // 
            // ApplicationTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 264);
            this.Controls.Add(this.chk_Priority);
            this.Controls.Add(this.btn_stop);
            this.Controls.Add(this.txt_testCaseID);
            this.Controls.Add(this.lbl_testCaseID);
            this.Controls.Add(this.btn_execute);
            this.Name = "ApplicationTest";
            this.Text = "Automation Test";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_execute;
        private System.Windows.Forms.Label lbl_testCaseID;
        private System.Windows.Forms.TextBox txt_testCaseID;
        private System.Windows.Forms.Button btn_stop;
        private System.Windows.Forms.CheckBox chk_Priority;
    }
}

