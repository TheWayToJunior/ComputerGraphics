using System.Drawing;
using System.Windows.Forms;

namespace PracticalWork6
{
    public partial class MainView : Form
    {
        public MainView(Bitmap bitmap)
        {
            InitializeComponent();

            pbMain.Image = bitmap;
        }
    }
}
