using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MyApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void appBarButton_Click(object sender, RoutedEventArgs e)
        {
        }

        private async System.Threading.Tasks.Task button_ClickAsync(object sender, RoutedEventArgs e)
        {
            StorageFolder folder = ApplicationData.Current.LocalFolder;
            try
            {
                StorageFile readfFile = await folder.GetFileAsync(NameBox.Text);
                await FileIO.AppendTextAsync(readfFile, ContentBox.Text);

            }
            catch (Exception)
            {
                StorageFile file = await folder.CreateFileAsync(ContentBox.Text, CreationCollisionOption.ReplaceExisting);
                await FileIO.WriteTextAsync(file, ContentBox.Text);
            }
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
        }
    }
}
