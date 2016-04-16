using DeviationManager.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DeviationManager.GUI
{
    public partial class ShowDiagramms : Form
    {

        private UploadFile uploadFile ;

        public ShowDiagramms(String hostName)
        {
            InitializeComponent();
            uploadFile = new UploadFile("u288026726", "alter6+");
            
        }


        //add diagramms
        public void addDiagramms(String hostName)
        {
            Stream stream = this.uploadFile.getImageStream(hostName);
            Image img = Image.FromStream(stream);
            PictureBox pic = new PictureBox();
            pic.Image = img;
            pic.Size = img.Size;
            pic.Anchor = AnchorStyles.None;

            this.imagePanel.Controls.Add(pic);
        }
        
    }
}
