using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Drawing;
using QRCoder;

namespace DVD.Pages
{
    /// <summary>
    /// Логика взаимодействия для QRPage.xaml
    /// </summary>
    public partial class QRPage : Page
    {
        public QRPage()
        {
            InitializeComponent();
        }

        private void QrCode_Click(object sender, RoutedEventArgs e)
        {
            string soucer_x1 = "https://yandex.ru/images/search?from=tabbar&img_url=https%3A%2F%2Fget.pxhere.com%2Fphoto%2Fnature-grass-outdoor-meadow-animal-pasture-sheep-mammal-fauna-lamb-vertebrate-sheeps-domestic-green-grass-cow-goat-family-823594.jpg&lr=43&pos=13&rpt=simage&text=%D0%BE%D0%B2%D1%86%D0%B0";
            QRCoder.QRCodeGenerator qr = new QRCoder.QRCodeGenerator();
            QRCoder.QRCodeData data = qr.CreateQrCode(soucer_x1, QRCoder.QRCodeGenerator.ECCLevel.L);
            QRCoder.QRCode code = new QRCoder.QRCode(data);
            Bitmap bitmap = code.GetGraphic(100);

            using (MemoryStream memory = new MemoryStream())
            {
                bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                memory.Position = 0;
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                Qr.Source = bitmapImage;
            } 
        } 
    }
}
