using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

class Class_Form
{
    public static void PanelShow(Panel panel, Form Winform,bool isfill=true)
    {
        panel.Controls.Clear();
        Winform.TopLevel = false;
        Winform.FormBorderStyle = FormBorderStyle.None;
        if (isfill == true)
        {
            Winform.Dock = System.Windows.Forms.DockStyle.Fill;//填充
        }
        else 
        {
            Winform.Dock = System.Windows.Forms.DockStyle.None;//不填充
        }
        panel.Controls.Add(Winform);
        Winform.Show();
    }



    public static void PanelShowObject(Panel panel, Form Winform)
    {

        panel.Controls.Clear();
        //((Control)Winform).TopLevel = false;
        //Winform.FormBorderStyle = FormBorderStyle.None;
        //Winform.Dock = System.Windows.Forms.DockStyle.Fill;//填充
        panel.Controls.Add((Control)Winform);
        ((Control)Winform).Show();
    }
}

