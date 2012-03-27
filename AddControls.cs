using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;



namespace RobotControlPanel
{
    class AddControls
    {

        //protected override void LoadViewState(object savedState)
        //{
        //    base.LoadViewState(savedState);
        //    if (ViewState["controsladded"] == null)
        //    AddControls();
        //}
        public FlowLayoutPanel AddButton()
        {
            Button dynamicbutton = new Button();
            Button dynamicbutton1 = new Button();
            Button dynamicbutton2 = new Button();
            Button dynamicbutton3 = new Button();
            Button dynamicbutton4 = new Button();
            Button dynamicbutton5 = new Button();
            Button dynamicbutton6 = new Button();
            Button dynamicbutton7 = new Button();
            Button dynamicbutton8 = new Button();
            Button dynamicbutton9 = new Button();
            Button dynamicbutton10 = new Button();
            FlowLayoutPanel groupBox1=new FlowLayoutPanel();
            int y = 20;
            dynamicbutton.Location = new System.Drawing.Point(10, y);
            dynamicbutton.Size = new System.Drawing.Size(100, 20);
            dynamicbutton.Visible = true;
            dynamicbutton1.Location = new System.Drawing.Point(10, y=y+20);
            dynamicbutton1.Size = new System.Drawing.Size(100, 20);
            dynamicbutton1.Visible = true;
            dynamicbutton2.Location = new System.Drawing.Point(10, y = y + 20);
            dynamicbutton2.Size = new System.Drawing.Size(100, 20);
            dynamicbutton2.Visible = true;
            dynamicbutton3.Location = new System.Drawing.Point(10, y = y + 20);
            dynamicbutton3.Size = new System.Drawing.Size(100, 20);
            dynamicbutton3.Visible = true;
            dynamicbutton4.Location = new System.Drawing.Point(10, y = y + 20);
            dynamicbutton4.Size = new System.Drawing.Size(100, 20);
            dynamicbutton4.Visible = true;
            dynamicbutton5.Location = new System.Drawing.Point(10, y = y + 20);
            dynamicbutton5.Size = new System.Drawing.Size(100, 20);
            dynamicbutton5.Visible = true;
            dynamicbutton6.Location = new System.Drawing.Point(10, y = y + 20);
            dynamicbutton6.Size = new System.Drawing.Size(100, 20);
            dynamicbutton6.Visible = true;
            dynamicbutton7.Location = new System.Drawing.Point(10, y = y + 20);
            dynamicbutton7.Size = new System.Drawing.Size(100, 20);
            dynamicbutton7.Visible = true;
            dynamicbutton8.Location = new System.Drawing.Point(10, y = y + 20);
            dynamicbutton8.Size = new System.Drawing.Size(100, 20);
            dynamicbutton8.Visible = true;
            dynamicbutton9.Location = new System.Drawing.Point(10, y = y + 20);
            dynamicbutton9.Size = new System.Drawing.Size(100, 20);
            dynamicbutton9.Visible = true;
            dynamicbutton10.Location = new System.Drawing.Point(10, y = y + 20);
            dynamicbutton10.Size = new System.Drawing.Size(100, 20);
            dynamicbutton10.Visible = true;
            dynamicbutton.Text = "Dynamic Button";
            dynamicbutton1.Text = "Dynamic Button1";
            dynamicbutton2.Text = "Dynamic Button2";
            dynamicbutton3.Text = "Dynamic Button3";
            dynamicbutton4.Text = "Dynamic Button4";
            dynamicbutton5.Text = "Dynamic Button5";
            dynamicbutton6.Text = "Dynamic Button6";
            dynamicbutton7.Text = "Dynamic Button7";
            dynamicbutton8.Text = "Dynamic Button8";
            dynamicbutton9.Text = "Dynamic Button9";
            dynamicbutton10.Text = "Dynamic Button10";

            groupBox1.Location = new System.Drawing.Point(10, 20);
            groupBox1.Size = new System.Drawing.Size(180, 20);
            groupBox1.Dock = DockStyle.Fill;
            groupBox1.Visible = true;
            groupBox1.FlowDirection = FlowDirection.TopDown;
            dynamicbutton.Click += new System.EventHandler(dynamicbutton_Click);
            
            groupBox1.Controls.Add(dynamicbutton);
            groupBox1.Controls.Add(dynamicbutton1);
            groupBox1.Controls.Add(dynamicbutton2);
            groupBox1.Controls.Add(dynamicbutton3);
            groupBox1.Controls.Add(dynamicbutton4);
            groupBox1.Controls.Add(dynamicbutton5);
            groupBox1.Controls.Add(dynamicbutton6);
            groupBox1.Controls.Add(dynamicbutton7);
            groupBox1.Controls.Add(dynamicbutton8);
            groupBox1.Controls.Add(dynamicbutton9);
            groupBox1.Controls.Add(dynamicbutton10);
            return groupBox1;
            //ViewState["controlsadded"] = true;            
        }
        private void dynamicbutton_Click(Object sender, System.EventArgs e)
        {
            MessageBox.Show("Gom megnyomva", "Gombnyomás");
        }
    }
}
