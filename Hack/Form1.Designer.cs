namespace Hack
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ClickButton = new Button();
            SuspendLayout();
            // 
            // ClickButton
            // 
            ClickButton.Font = new Font("Segoe UI", 30F);
            ClickButton.Location = new Point(162, 126);
            ClickButton.Name = "ClickButton";
            ClickButton.Size = new Size(407, 171);
            ClickButton.TabIndex = 0;
            ClickButton.Text = "Don't Click";
            ClickButton.UseVisualStyleBackColor = true;
            ClickButton.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(766, 451);
            Controls.Add(ClickButton);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button ClickButton;
    }
}
