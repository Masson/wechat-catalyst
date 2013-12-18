using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using IMasson.WechatCatalyst.BaseLib;
using IMasson.WechatCatalyst.Genymotion;

namespace IMasson.WechatCatalyst.UI
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        AbstractCatalystControl _control = new GenymotionControl();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_prepare_Click(object sender, RoutedEventArgs e)
        {
            _control.Prepare();
            string message = _control.GetStatusDescription();
            tbk_output.Text = message;
        }

        private void btn_launch_Click(object sender, RoutedEventArgs e)
        {
            _control.Launch();
            string message = _control.GetStatusDescription();
            tbk_output.Text = message;
        }
    }
}
