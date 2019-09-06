using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ARGUSnet.RasperryPi2.LedDesigner
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private string val00;
        private string val01;
        private string val02;
        private string val03;
        private string val04;
        private string val05;
        private string val06;
        private string val07;
        private string val10;
        private string val11;
        private string val12;
        private string val13;
        private string val14;
        private string val15;
        private string val16;
        private string val17;
        private string val20;
        private string val21;
        private string val22;
        private string val23;
        private string val24;
        private string val25;
        private string val26;
        private string val27;
        private string val30;
        private string val31;
        private string val32;
        private string val33;
        private string val34;
        private string val35;
        private string val36;
        private string val37;
        private string val40;
        private string val41;
        private string val42;
        private string val43;
        private string val44;
        private string val45;
        private string val46;
        private string val47;
        private string val50;
        private string val51;
        private string val52;
        private string val53;
        private string val54;
        private string val55;
        private string val56;
        private string val57;
        private string val60;
        private string val61;
        private string val62;
        private string val63;
        private string val64;
        private string val65;
        private string val66;
        private string val67;
        private string val70;
        private string val71;
        private string val72;
        private string val73;
        private string val74;
        private string val75;
        private string val76;
        private string val77;
        private string resultBegin;
        private string resultEnd;

        public delegate void UpdateTextBoxDelegate(int value);

        public MainPage()
        {
            InitializeComponent();
            //Thread thread = new Thread(new ThreadStart(UpdateTextBoxThread));
            //thread.Start();

            resultBegin = "var result = new List<VisualLedPoint>\n{\n";
            resultEnd = "\n};";
        }

        private void btnUpdate_OnClick(object sender, RoutedEventArgs e)
        {
            txtOutput.Text = resultBegin + val00 + val01 + val02 + val03 + val04 + val05 + val06 + val07 + val10 + val11 + val12 + val13 + val14 + val15 + val16 + val17 + val20 + val21 + val22 + val23 + val24 + val25 + val26 + val27 + val30 + val31 + val32 + val33 + val34 + val35 + val36 + val37 + val40 + val41 + val42 + val43 + val44 + val45 + val46 + val47 + val50 + val51 + val52 + val53 + val54 + val55 + val56 + val57 + val60 + val61 + val62 + val63 + val64 + val65 + val66 + val67 + val70 + val71 + val72 + val73 + val74 + val75 + val76 + val77 + resultEnd;
        }

        private void Cb00_OnChecked(object sender, RoutedEventArgs e)
        {
            val00 = "new VisualLedPoint(" + cb00.Content + ")";
        }

        private void Cb00_OnUnchecked(object sender, RoutedEventArgs e)
        {
            val00 = null;
        }

        private void Cb01_OnChecked(object sender, RoutedEventArgs e)
        {
            val01 = ",\nnew VisualLedPoint(" + cb01.Content + ")";
        }

        private void Cb01_OnUnchecked(object sender, RoutedEventArgs e)
        {
            val01 = null;
        }

        private void Cb02_OnChecked(object sender, RoutedEventArgs e)
        {
            val02 = ",\nnew VisualLedPoint(" + cb02.Content + ")";
        }

        private void Cb02_OnUnchecked(object sender, RoutedEventArgs e)
        {
            val02 = null;
        }

        private void Cb03_OnChecked(object sender, RoutedEventArgs e)
        {
            val03 = ",\nnew VisualLedPoint(" + cb03.Content + ")";
        }

        private void Cb03_OnUnchecked(object sender, RoutedEventArgs e)
        {
            val03 = null;
        }
        private void Cb04_OnChecked(object sender, RoutedEventArgs e)
        {
            val04 = ",\nnew VisualLedPoint(" + cb04.Content + ")";
        }

        private void Cb04_OnUnchecked(object sender, RoutedEventArgs e)
        {
            val04 = null;
        }

        private void Cb05_OnChecked(object sender, RoutedEventArgs e)
        {
            val05 = ",\nnew VisualLedPoint(" + cb05.Content + ")";
        }

        private void Cb05_OnUnchecked(object sender, RoutedEventArgs e)
        {
            val05 = null;
        }

        private void Cb06_OnChecked(object sender, RoutedEventArgs e)
        {
            val06 = ",\nnew VisualLedPoint(" + cb06.Content + ")";
        }

        private void Cb06_OnUnchecked(object sender, RoutedEventArgs e)
        {
            val06 = null;
        }
        private void Cb07_OnChecked(object sender, RoutedEventArgs e)
        {
            val07 = ",\nnew VisualLedPoint(" + cb07.Content + ")";
        }

        private void Cb07_OnUnchecked(object sender, RoutedEventArgs e)
        {
            val07 = null;
        }

        private void Cb10_OnChecked(object sender, RoutedEventArgs e)
        {
            val10 = ",\nnew VisualLedPoint(" + cb10.Content + ")";
        }

        private void Cb10_OnUnchecked(object sender, RoutedEventArgs e)
        {
            val10 = null;
        }

        private void Cb11_OnChecked(object sender, RoutedEventArgs e)
        {
            val11 = ",\nnew VisualLedPoint(" + cb11.Content + ")";
        }

        private void Cb11_OnUnchecked(object sender, RoutedEventArgs e)
        {
            val11 = null;
        }

        private void Cb12_OnChecked(object sender, RoutedEventArgs e)
        {
            val12 = ",\nnew VisualLedPoint(" + cb12.Content + ")";
        }

        private void Cb12_OnUnchecked(object sender, RoutedEventArgs e)
        {
            val12 = null;
        }

        private void Cb13_OnChecked(object sender, RoutedEventArgs e)
        {
            val13 = ",\nnew VisualLedPoint(" + cb13.Content + ")";
        }

        private void Cb13_OnUnchecked(object sender, RoutedEventArgs e)
        {
            val13 = null;
        }
        private void Cb14_OnChecked(object sender, RoutedEventArgs e)
        {
            val14 = ",\nnew VisualLedPoint(" + cb14.Content + ")";
        }

        private void Cb14_OnUnchecked(object sender, RoutedEventArgs e)
        {
            val14 = null;
        }

        private void Cb15_OnChecked(object sender, RoutedEventArgs e)
        {
            val15 = ",\nnew VisualLedPoint(" + cb15.Content + ")";
        }

        private void Cb15_OnUnchecked(object sender, RoutedEventArgs e)
        {
            val15 = null;
        }

        private void Cb16_OnChecked(object sender, RoutedEventArgs e)
        {
            val16 = ",\nnew VisualLedPoint(" + cb16.Content + ")";
        }

        private void Cb16_OnUnchecked(object sender, RoutedEventArgs e)
        {
            val16 = null;
        }
        private void Cb17_OnChecked(object sender, RoutedEventArgs e)
        {
            val17 = ",\nnew VisualLedPoint(" + cb17.Content + ")";
        }

        private void Cb17_OnUnchecked(object sender, RoutedEventArgs e)
        {
            val17 = null;
        }

        private void Cb20_OnChecked(object sender, RoutedEventArgs e)
        {
            val20 = ",\nnew VisualLedPoint(" + cb20.Content + ")";
        }

        private void Cb20_OnUnchecked(object sender, RoutedEventArgs e)
        {
            val00 = null;
        }

        private void Cb21_OnChecked(object sender, RoutedEventArgs e)
        {
            val21 = ",\nnew VisualLedPoint(" + cb21.Content + ")";
        }

        private void Cb21_OnUnchecked(object sender, RoutedEventArgs e)
        {
            val21 = null;
        }

        private void Cb22_OnChecked(object sender, RoutedEventArgs e)
        {
            val22 = ",\nnew VisualLedPoint(" + cb22.Content + ")";
        }

        private void Cb22_OnUnchecked(object sender, RoutedEventArgs e)
        {
            val22 = null;
        }

        private void Cb23_OnChecked(object sender, RoutedEventArgs e)
        {
            val23 = ",\nnew VisualLedPoint(" + cb23.Content + ")";
        }

        private void Cb23_OnUnchecked(object sender, RoutedEventArgs e)
        {
            val23 = null;
        }
        private void Cb24_OnChecked(object sender, RoutedEventArgs e)
        {
            val24 = ",\nnew VisualLedPoint(" + cb24.Content + ")";
        }

        private void Cb24_OnUnchecked(object sender, RoutedEventArgs e)
        {
            val24 = null;
        }

        private void Cb25_OnChecked(object sender, RoutedEventArgs e)
        {
            val25 = ",\nnew VisualLedPoint(" + cb25.Content + ")";
        }

        private void Cb25_OnUnchecked(object sender, RoutedEventArgs e)
        {
            val25 = null;
        }

        private void Cb26_OnChecked(object sender, RoutedEventArgs e)
        {
            val26 = ",\nnew VisualLedPoint(" + cb26.Content + ")";
        }

        private void Cb26_OnUnchecked(object sender, RoutedEventArgs e)
        {
            val26 = null;
        }
        private void Cb27_OnChecked(object sender, RoutedEventArgs e)
        {
            val27 = ",\nnew VisualLedPoint(" + cb27.Content + ")";
        }

        private void Cb27_OnUnchecked(object sender, RoutedEventArgs e)
        {
            val27 = null;
        }

        private void Cb30_OnChecked(object sender, RoutedEventArgs e)
        {
            val30 = ",\nnew VisualLedPoint(" + cb30.Content + ")";
        }

        private void Cb30_OnUnchecked(object sender, RoutedEventArgs e)
        {
            val30 = null;
        }

        private void Cb31_OnChecked(object sender, RoutedEventArgs e)
        {
            val31 = ",\nnew VisualLedPoint(" + cb31.Content + ")";
        }

        private void Cb31_OnUnchecked(object sender, RoutedEventArgs e)
        {
            val31 = null;
        }

        private void Cb32_OnChecked(object sender, RoutedEventArgs e)
        {
            val32 = ",\nnew VisualLedPoint(" + cb32.Content + ")";
        }

        private void Cb32_OnUnchecked(object sender, RoutedEventArgs e)
        {
            val32 = null;
        }

        private void Cb33_OnChecked(object sender, RoutedEventArgs e)
        {
            val33 = ",\nnew VisualLedPoint(" + cb33.Content + ")";
        }

        private void Cb33_OnUnchecked(object sender, RoutedEventArgs e)
        {
            val33 = null;
        }
        private void Cb34_OnChecked(object sender, RoutedEventArgs e)
        {
            val34 = ",\nnew VisualLedPoint(" + cb34.Content + ")";
        }

        private void Cb34_OnUnchecked(object sender, RoutedEventArgs e)
        {
            val34 = null;
        }

        private void Cb35_OnChecked(object sender, RoutedEventArgs e)
        {
            val35 = ",\nnew VisualLedPoint(" + cb35.Content + ")";
        }

        private void Cb35_OnUnchecked(object sender, RoutedEventArgs e)
        {
            val35 = null;
        }

        private void Cb36_OnChecked(object sender, RoutedEventArgs e)
        {
            val36 = ",\nnew VisualLedPoint(" + cb36.Content + ")";
        }

        private void Cb36_OnUnchecked(object sender, RoutedEventArgs e)
        {
            val36 = null;
        }
        private void Cb37_OnChecked(object sender, RoutedEventArgs e)
        {
            val37 = ",\nnew VisualLedPoint(" + cb37.Content + ")";
        }

        private void Cb37_OnUnchecked(object sender, RoutedEventArgs e)
        {
            val37 = null;
        }

        private void Cb40_OnChecked(object sender, RoutedEventArgs e)
        {
            val40 = ",\nnew VisualLedPoint(" + cb40.Content + ")";
        }

        private void Cb40_OnUnchecked(object sender, RoutedEventArgs e)
        {
            val40 = null;
        }

        private void Cb41_OnChecked(object sender, RoutedEventArgs e)
        {
            val41 = ",\nnew VisualLedPoint(" + cb41.Content + ")";
        }

        private void Cb41_OnUnchecked(object sender, RoutedEventArgs e)
        {
            val41 = null;
        }

        private void Cb42_OnChecked(object sender, RoutedEventArgs e)
        {
            val42 = ",\nnew VisualLedPoint(" + cb42.Content + ")";
        }

        private void Cb42_OnUnchecked(object sender, RoutedEventArgs e)
        {
            val42 = null;
        }

        private void Cb43_OnChecked(object sender, RoutedEventArgs e)
        {
            val43 = ",\nnew VisualLedPoint(" + cb43.Content + ")";
        }

        private void Cb43_OnUnchecked(object sender, RoutedEventArgs e)
        {
            val43 = null;
        }
        private void Cb44_OnChecked(object sender, RoutedEventArgs e)
        {
            val44 = ",\nnew VisualLedPoint(" + cb44.Content + ")";
        }

        private void Cb44_OnUnchecked(object sender, RoutedEventArgs e)
        {
            val44 = null;
        }

        private void Cb45_OnChecked(object sender, RoutedEventArgs e)
        {
            val45 = ",\nnew VisualLedPoint(" + cb45.Content + ")";
        }

        private void Cb45_OnUnchecked(object sender, RoutedEventArgs e)
        {
            val45 = null;
        }

        private void Cb46_OnChecked(object sender, RoutedEventArgs e)
        {
            val46 = ",\nnew VisualLedPoint(" + cb46.Content + ")";
        }

        private void Cb46_OnUnchecked(object sender, RoutedEventArgs e)
        {
            val46 = null;
        }
        private void Cb47_OnChecked(object sender, RoutedEventArgs e)
        {
            val47 = ",\nnew VisualLedPoint(" + cb47.Content + ")";
        }

        private void Cb47_OnUnchecked(object sender, RoutedEventArgs e)
        {
            val47 = null;
        }

        private void Cb50_OnChecked(object sender, RoutedEventArgs e)
        {
            val50 = ",\nnew VisualLedPoint(" + cb50.Content + ")";
        }

        private void Cb50_OnUnchecked(object sender, RoutedEventArgs e)
        {
            val50 = null;
        }

        private void Cb51_OnChecked(object sender, RoutedEventArgs e)
        {
            val51 = ",\nnew VisualLedPoint(" + cb51.Content + ")";
        }

        private void Cb51_OnUnchecked(object sender, RoutedEventArgs e)
        {
            val51 = null;
        }

        private void Cb52_OnChecked(object sender, RoutedEventArgs e)
        {
            val52 = ",\nnew VisualLedPoint(" + cb52.Content + ")";
        }

        private void Cb52_OnUnchecked(object sender, RoutedEventArgs e)
        {
            val52 = null;
        }

        private void Cb53_OnChecked(object sender, RoutedEventArgs e)
        {
            val53 = ",\nnew VisualLedPoint(" + cb53.Content + ")";
        }

        private void Cb53_OnUnchecked(object sender, RoutedEventArgs e)
        {
            val53 = null;
        }
        private void Cb54_OnChecked(object sender, RoutedEventArgs e)
        {
            val54 = ",\nnew VisualLedPoint(" + cb54.Content + ")";
        }

        private void Cb54_OnUnchecked(object sender, RoutedEventArgs e)
        {
            val54 = null;
        }

        private void Cb55_OnChecked(object sender, RoutedEventArgs e)
        {
            val55 = ",\nnew VisualLedPoint(" + cb55.Content + ")";
        }

        private void Cb55_OnUnchecked(object sender, RoutedEventArgs e)
        {
            val55 = null;
        }

        private void Cb56_OnChecked(object sender, RoutedEventArgs e)
        {
            val56 = ",\nnew VisualLedPoint(" + cb56.Content + ")";
        }

        private void Cb56_OnUnchecked(object sender, RoutedEventArgs e)
        {
            val56 = null;
        }
        private void Cb57_OnChecked(object sender, RoutedEventArgs e)
        {
            val57 = ",\nnew VisualLedPoint(" + cb57.Content + ")";
        }

        private void Cb57_OnUnchecked(object sender, RoutedEventArgs e)
        {
            val57 = null;
        }

        private void Cb60_OnChecked(object sender, RoutedEventArgs e)
        {
            val60 = ",\nnew VisualLedPoint(" + cb60.Content + ")";
        }

        private void Cb60_OnUnchecked(object sender, RoutedEventArgs e)
        {
            val60 = null;
        }

        private void Cb61_OnChecked(object sender, RoutedEventArgs e)
        {
            val61 = ",\nnew VisualLedPoint(" + cb61.Content + ")";
        }

        private void Cb61_OnUnchecked(object sender, RoutedEventArgs e)
        {
            val61 = null;
        }

        private void Cb62_OnChecked(object sender, RoutedEventArgs e)
        {
            val62 = ",\nnew VisualLedPoint(" + cb62.Content + ")";
        }

        private void Cb62_OnUnchecked(object sender, RoutedEventArgs e)
        {
            val62 = null;
        }

        private void Cb63_OnChecked(object sender, RoutedEventArgs e)
        {
            val63 = ",\nnew VisualLedPoint(" + cb63.Content + ")";
        }

        private void Cb63_OnUnchecked(object sender, RoutedEventArgs e)
        {
            val63 = null;
        }
        private void Cb64_OnChecked(object sender, RoutedEventArgs e)
        {
            val64 = ",\nnew VisualLedPoint(" + cb64.Content + ")";
        }

        private void Cb64_OnUnchecked(object sender, RoutedEventArgs e)
        {
            val64 = null;
        }

        private void Cb65_OnChecked(object sender, RoutedEventArgs e)
        {
            val65 = ",\nnew VisualLedPoint(" + cb65.Content + ")";
        }

        private void Cb65_OnUnchecked(object sender, RoutedEventArgs e)
        {
            val65 = null;
        }

        private void Cb66_OnChecked(object sender, RoutedEventArgs e)
        {
            val66 = ",\nnew VisualLedPoint(" + cb66.Content + ")";
        }

        private void Cb66_OnUnchecked(object sender, RoutedEventArgs e)
        {
            val66 = null;
        }
        private void Cb67_OnChecked(object sender, RoutedEventArgs e)
        {
            val67 = ",\nnew VisualLedPoint(" + cb67.Content + ")";
        }

        private void Cb67_OnUnchecked(object sender, RoutedEventArgs e)
        {
            val67 = null;
        }

        private void Cb70_OnChecked(object sender, RoutedEventArgs e)
        {
            val70 = ",\nnew VisualLedPoint(" + cb70.Content + ")";
        }

        private void Cb70_OnUnchecked(object sender, RoutedEventArgs e)
        {
            val70 = null;
        }

        private void Cb71_OnChecked(object sender, RoutedEventArgs e)
        {
            val71 = ",\nnew VisualLedPoint(" + cb71.Content + ")";
        }

        private void Cb71_OnUnchecked(object sender, RoutedEventArgs e)
        {
            val71 = null;
        }

        private void Cb72_OnChecked(object sender, RoutedEventArgs e)
        {
            val72 = ",\nnew VisualLedPoint(" + cb72.Content + ")";
        }

        private void Cb72_OnUnchecked(object sender, RoutedEventArgs e)
        {
            val72 = null;
        }

        private void Cb73_OnChecked(object sender, RoutedEventArgs e)
        {
            val73 = ",\nnew VisualLedPoint(" + cb73.Content + ")";
        }

        private void Cb73_OnUnchecked(object sender, RoutedEventArgs e)
        {
            val73 = null;
        }
        private void Cb74_OnChecked(object sender, RoutedEventArgs e)
        {
            val74 = ",\nnew VisualLedPoint(" + cb74.Content + ")";
        }

        private void Cb74_OnUnchecked(object sender, RoutedEventArgs e)
        {
            val74 = null;
        }

        private void Cb75_OnChecked(object sender, RoutedEventArgs e)
        {
            val75 = ",\nnew VisualLedPoint(" + cb75.Content + ")";
        }

        private void Cb75_OnUnchecked(object sender, RoutedEventArgs e)
        {
            val75 = null;
        }

        private void Cb76_OnChecked(object sender, RoutedEventArgs e)
        {
            val76 = ",\nnew VisualLedPoint(" + cb76.Content + ")";
        }

        private void Cb76_OnUnchecked(object sender, RoutedEventArgs e)
        {
            val76 = null;
        }
        private void Cb77_OnChecked(object sender, RoutedEventArgs e)
        {
            val77 = ",\nnew VisualLedPoint(" + cb77.Content + ")";
        }

        private void Cb77_OnUnchecked(object sender, RoutedEventArgs e)
        {
            val77 = null;
        }
    }
}
