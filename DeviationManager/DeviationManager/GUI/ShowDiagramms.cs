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
        private String hostName;

        public ShowDiagramms(DataGridView dataGridView)
        {
            InitializeComponent();
            this.hostName = "ftp://31.170.165.123/";
            uploadFile = new UploadFile("u288026726", "alter6+");

            this.showDiagramms(dataGridView);
            //imagePanel.FlowDirection = FlowDirection.TopDown;
            //imagePanel.WrapContents = false;
            //this.addDiagramms(hostName);
            
        }


        //add diagramms
        public void addDiagramms(String hostName)
        {
            Stream stream = this.uploadFile.getImageStream(hostName);
            Image img = Image.FromStream(stream);
            PictureBox pic = new PictureBox();
            pic.Image = img;
            pic.Size = img.Size;
            pic.Anchor = AnchorStyles.Left;
            pic.Anchor = AnchorStyles.Right;
          

            this.imagePanel.Controls.Add(pic);
        }

        //add diagramms
        private void showDiagramms(DataGridView dataGridView)
        {
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                //verify the extention file 
                String fileExtention = Path.GetExtension(row.Cells[0].Value.ToString());
                if (fileExtention.Equals(".png", StringComparison.InvariantCultureIgnoreCase) || fileExtention.Equals(".png", StringComparison.InvariantCultureIgnoreCase))
                {
                    //Get Image Stream
                    Stream stream = this.uploadFile.getImageStream(this.hostName + row.Cells[1].Value.ToString());
                    if (stream != null)
                    {
                        Image img = Image.FromStream(stream);
                        PictureBox pic = new PictureBox();
                        pic.Image = img;
                        pic.Size = img.Size;
                        pic.Anchor = AnchorStyles.Left;
                        pic.Anchor = AnchorStyles.Right;

                        Label imageLegend = new Label();
                        imageLegend.Text = row.Cells[3].Value.ToString();
                        imageLegend.Margin = new Padding(0,0,70,70);

                        this.imagePanel.Controls.Add(pic);
                        this.imagePanel.Controls.Add(imageLegend);
                        

                    }
                }
                

            }
        }


        /****____classs ****/
        
    }
}
