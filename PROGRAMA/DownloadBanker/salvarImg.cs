using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace DownloadBanker
{
    class salvarImg
    {
        public static void salvarImgCapturada(System.Drawing.Image image)
        {
            acessoQR qr = new acessoQR();
            SaveFileDialog salvar = new SaveFileDialog();
            salvar.FileName = acessoDadosQR.Codigo + "-" + acessoDadosQR.Valor;
            salvar.DefaultExt = ".Jpg";
            salvar.Filter = "Image (.jpg)|*.jpg";

            if (salvar.ShowDialog() == DialogResult.OK)
            {
                string filename = salvar.FileName;
                FileStream fstream = new FileStream(filename, FileMode.Create);
                image.Save(fstream, System.Drawing.Imaging.ImageFormat.Jpeg);
                fstream.Close();
            }

        }

    }
}
