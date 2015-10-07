using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace DatasourceViewer
{
  [ToolStripItemDesignerAvailability(ToolStripItemDesignerAvailability.ToolStrip)]
  public class ToolStripNumberControl : ToolStripControlHost
  {
    public ToolStripNumberControl()
      : base(new NumericUpDown())
    {
      NumericUpDown nud = (NumericUpDown)this.NumericUpDownControl;
      nud.Maximum = 100000000000;
      nud.Minimum = -1;
      nud.Value = 100;
    }

    public override Size GetPreferredSize(Size constrainingSize)
    {
      return new Size(60, this.Height);
    }

    protected override void OnSubscribeControlEvents(Control control)
    {
      base.OnSubscribeControlEvents(control);
      ((NumericUpDown)control).ValueChanged += new EventHandler(OnValueChanged);
    }

    protected override void OnUnsubscribeControlEvents(Control control)
    {
      base.OnUnsubscribeControlEvents(control);
      ((NumericUpDown)control).ValueChanged -= new EventHandler(OnValueChanged);
    }

    public event EventHandler ValueChanged;

    public Control NumericUpDownControl
    {
      get { return Control as NumericUpDown; }
    }

    public void OnValueChanged(object sender, EventArgs e)
    {
      if (ValueChanged != null)
      {
        ValueChanged(this, e);
      }
    }
  }
}
