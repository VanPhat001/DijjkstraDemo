
namespace Dijkstra_Find_Shortest_Path
{
    partial class Form1
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
            this.pnlMap = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radioTrapPoint = new System.Windows.Forms.RadioButton();
            this.radioEndPoint = new System.Windows.Forms.RadioButton();
            this.radioStartPoint = new System.Windows.Forms.RadioButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnClearPath = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMap
            // 
            this.pnlMap.Location = new System.Drawing.Point(12, 12);
            this.pnlMap.Name = "pnlMap";
            this.pnlMap.Size = new System.Drawing.Size(763, 426);
            this.pnlMap.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.radioTrapPoint);
            this.panel2.Controls.Add(this.radioEndPoint);
            this.panel2.Controls.Add(this.radioStartPoint);
            this.panel2.Location = new System.Drawing.Point(781, 13);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(129, 147);
            this.panel2.TabIndex = 1;
            // 
            // radioTrapPoint
            // 
            this.radioTrapPoint.AutoSize = true;
            this.radioTrapPoint.Checked = true;
            this.radioTrapPoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioTrapPoint.Location = new System.Drawing.Point(3, 83);
            this.radioTrapPoint.Name = "radioTrapPoint";
            this.radioTrapPoint.Size = new System.Drawing.Size(102, 21);
            this.radioTrapPoint.TabIndex = 2;
            this.radioTrapPoint.TabStop = true;
            this.radioTrapPoint.Text = "Đặt/hủy bẫy";
            this.radioTrapPoint.UseVisualStyleBackColor = true;
            this.radioTrapPoint.Click += new System.EventHandler(this.radioEndPoint_Click);
            // 
            // radioEndPoint
            // 
            this.radioEndPoint.AutoSize = true;
            this.radioEndPoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioEndPoint.Location = new System.Drawing.Point(3, 57);
            this.radioEndPoint.Name = "radioEndPoint";
            this.radioEndPoint.Size = new System.Drawing.Size(112, 21);
            this.radioEndPoint.TabIndex = 1;
            this.radioEndPoint.Text = "Điểm kết thúc";
            this.radioEndPoint.UseVisualStyleBackColor = true;
            this.radioEndPoint.Click += new System.EventHandler(this.radioEndPoint_Click);
            // 
            // radioStartPoint
            // 
            this.radioStartPoint.AutoSize = true;
            this.radioStartPoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioStartPoint.Location = new System.Drawing.Point(3, 30);
            this.radioStartPoint.Name = "radioStartPoint";
            this.radioStartPoint.Size = new System.Drawing.Size(110, 21);
            this.radioStartPoint.TabIndex = 0;
            this.radioStartPoint.Text = "Điểm bắt đầu";
            this.radioStartPoint.UseVisualStyleBackColor = true;
            this.radioStartPoint.Click += new System.EventHandler(this.radioEndPoint_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnClearPath);
            this.panel3.Controls.Add(this.btnExit);
            this.panel3.Controls.Add(this.btnStart);
            this.panel3.Controls.Add(this.btnReset);
            this.panel3.Location = new System.Drawing.Point(781, 166);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(129, 273);
            this.panel3.TabIndex = 2;
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(3, 209);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(119, 46);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(3, 53);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(119, 46);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(3, 157);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(119, 46);
            this.btnReset.TabIndex = 3;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnClearPath
            // 
            this.btnClearPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearPath.Location = new System.Drawing.Point(3, 105);
            this.btnClearPath.Name = "btnClearPath";
            this.btnClearPath.Size = new System.Drawing.Size(119, 46);
            this.btnClearPath.TabIndex = 6;
            this.btnClearPath.Text = "Clear Path";
            this.btnClearPath.UseVisualStyleBackColor = true;
            this.btnClearPath.Click += new System.EventHandler(this.btnClearPath_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 450);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnlMap);
            this.Name = "Form1";
            this.Text = "Find Shortest Path Using Dijkstra";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMap;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.RadioButton radioTrapPoint;
        private System.Windows.Forms.RadioButton radioEndPoint;
        private System.Windows.Forms.RadioButton radioStartPoint;
        private System.Windows.Forms.Button btnClearPath;
    }
}

