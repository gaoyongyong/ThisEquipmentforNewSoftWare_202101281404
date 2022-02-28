using MotorsControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace PropertyGridEx
{
    public class CategoryModalEditor : System.Drawing.Design.UITypeEditor
    {
        public CategoryModalEditor()
        {
        }
        public override System.Drawing.Design.UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }
        public override object EditValue(System.ComponentModel.ITypeDescriptorContext context,
            System.IServiceProvider provider, object value)
        {
            IWindowsFormsEditorService service =
                (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
            if (service == null)
            {
                return null;
            }
           
            service.ShowDialog(Form_cCombox.Instance);
            Form_cCombox.Instance.StartPosition = FormStartPosition.Manual;//必须要设置这一步
            
            return Form_cCombox.input;
          
            return value;
        }
    }

   
}
