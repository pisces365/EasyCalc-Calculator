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
using Windows.ApplicationModel.Core;
using Windows.ApplicationModel.Store;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace 简单计算
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private string FirstFont { get; set; }
        private string LastFont { get; set; }

        private string OperatorString { get; set; }

        public MainPage()
        {
            this.InitializeComponent();
        }

        Calculate CalcX = new Calculate();
        private void Seven_Click(object sender, RoutedEventArgs e)
        {
            CanButtonClick();
            CalcX.SetNum(7);
            ShowTextInTextBlock();
        }

        private void Eight_Click(object sender, RoutedEventArgs e)
        {
            CanButtonClick();
            CalcX.SetNum(8);
            ShowTextInTextBlock();
        }

        private void Night_Click(object sender, RoutedEventArgs e)
        {
            CanButtonClick();
            CalcX.SetNum(9);
            ShowTextInTextBlock();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            ShowTextInTextBlockForOPR();
            CalcX.SetOperator_Calc('+');
            if (this.ShowText.Text != "Error")
                ShowTextInTextBlockForOPR();
        }

        private void Four_Click(object sender, RoutedEventArgs e)
        {
            CanButtonClick();
            CalcX.SetNum(4);
            ShowTextInTextBlock();
        }

        private void Five_Click(object sender, RoutedEventArgs e)
        {
            CanButtonClick();
            CalcX.SetNum(5);
            ShowTextInTextBlock();
        }

        private void Six_Click(object sender, RoutedEventArgs e)
        {
            CanButtonClick();
            CalcX.SetNum(6);
            ShowTextInTextBlock();
        }

        private void Min_Click(object sender, RoutedEventArgs e)
        {
            ShowTextInTextBlockForOPR();
            CalcX.SetOperator_Calc('-');
            if (this.ShowText.Text != "Error")
                ShowTextInTextBlockForOPR();
        }

        private void One_Click(object sender, RoutedEventArgs e)
        {
            CanButtonClick();
            CalcX.SetNum(1);
            ShowTextInTextBlock();
        }

        private void Two_Click(object sender, RoutedEventArgs e)
        {
            CanButtonClick();
            CalcX.SetNum(2);
            ShowTextInTextBlock();
        }

        private void Three_Click(object sender, RoutedEventArgs e)
        {
            CanButtonClick();
            CalcX.SetNum(3);
            ShowTextInTextBlock();
        }

        private void mul_Click(object sender, RoutedEventArgs e)
        {
            ShowTextInTextBlockForOPR();
            CalcX.SetOperator_Calc('×');
            if (this.ShowText.Text != "Error")
                ShowTextInTextBlockForOPR();
        }

        private void Zero_Click(object sender, RoutedEventArgs e)
        {
            CanButtonClick();
            CalcX.SetNum(0);
            ShowTextInTextBlock();
        }

        private void Div_Click(object sender, RoutedEventArgs e)
        {
            ShowTextInTextBlockForOPR();
            CalcX.SetOperator_Calc('÷');
            if (this.ShowText.Text != "Error")
                ShowTextInTextBlockForOPR();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            CanButtonClick();
            CalcX.Delete();
            ShowTextInTextBlock();
        }

        private void Echo_Click(object sender, RoutedEventArgs e)
        {
            ShowTextInTextBlockForOPR();
            CalcX.Echo();
            if(this.ShowText.Text != "Error")
            ShowTextInTextBlockForOPR();
        }

        private void Dot_Click(object sender, RoutedEventArgs e)
        {
            CalcX.FirstDot = '.';
            if (CalcX.FirstDot == '.' && CalcX.CalcOperator !='0')
                CalcX.SecondDot = '.';
            this.ShowText.Text += '.';
        }

        private void ShowTextInTextBlock()
        {
            FirstFont = CalcX.FrontNum.ToString();
            if (CalcX.LastNum != null)
                LastFont = CalcX.LastNum.ToString();
            else
                LastFont = null;
            OperatorString = CalcX.CalcOperator.ToString();

            if (CalcX.CalcOperator == '0' && LastFont == null)
                this.ShowText.Text = FirstFont;
            else if(CalcX.CalcOperator != '0' && LastFont == null)
                this.ShowText.Text = FirstFont + OperatorString;
            else if (CalcX.CalcOperator != '0' && LastFont != null)
            {
                 this.ShowText.Text = FirstFont + OperatorString + LastFont;
            }

        }

        private void ShowTextInTextBlockForOPR()
        {
            FirstFont = CalcX.FrontNum.ToString();
            if (CalcX.LastNum != null)
                LastFont = CalcX.LastNum.ToString();
            else
                LastFont = null;
            OperatorString = CalcX.CalcOperator.ToString();

            if (CalcX.CalcOperator == '0' && LastFont == null)
                this.ShowText.Text = FirstFont;
            else if (CalcX.CalcOperator != '0' && LastFont == null)
                this.ShowText.Text = FirstFont + OperatorString;
            else if (CalcX.CalcOperator != '0' && LastFont != null)
            {
                if (CalcX.CalcOperator == '÷' && LastFont == "0")
                {
                    this.ShowText.Text = "Error";
                    this.Add.IsEnabled = false;
                    this.mul.IsEnabled = false;
                    this.Div.IsEnabled = false;
                    this.Min.IsEnabled = false;
                    this.Echo.IsEnabled = false;
                    this.Dot.IsEnabled = false;
                }
                else this.ShowText.Text = FirstFont + OperatorString + LastFont;
            }

        }


        private void CanButtonClick()
        {
            this.Add.IsEnabled = true;
            this.mul.IsEnabled = true;
            this.Div.IsEnabled = true;
            this.Min.IsEnabled = true;
            this.Echo.IsEnabled = true;
            this.Dot.IsEnabled = true;
        }

        private async void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            await Windows.System.Launcher.LaunchUriAsync(new Uri("ms-windows-store://review/?productid=9N88FCKCQQ3M"));
        }

        private async void Pisces365_Click(object sender, RoutedEventArgs e)
        {
            await Windows.System.Launcher.LaunchUriAsync(new Uri("ms-windows-store://publisher/?Name=Pisces365"));
        }


    }
}
