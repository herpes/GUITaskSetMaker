using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace GUITaskSetMaker
{
    class TaskExecusion : System.Windows.Forms.Label
    {
        private int begintime;
        private int extime;
        private bool nonPreemptive;
        static int ExecutionID = 0;
        DAndDSizeChanger sizeChanger;

        private int startX;
        private int startY;

        public TaskExecusion()
        {
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Location = new System.Drawing.Point(309, 222);
            this.Name = "TaskExecution" + ++ExecutionID;
            this.Text = this.Name;
            this.Size = new System.Drawing.Size(480, 24);
            this.TabIndex = 0;
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TaskExecution_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TaskExecution_MouseMove);

            sizeChanger = new DAndDSizeChanger(this.Parent, this, DAndDArea.All, 8);
        }

        private void TaskExecution_MouseDown(object sender, MouseEventArgs e)
        {
            startX = e.X;
            startY = e.Y;
        }

        private void TaskExecution_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int moveX = Left + e.X - startX;
                int moveY = Top + e.Y - startY;

                Location = new Point(moveX, moveY);
            }
        }

    }
}
