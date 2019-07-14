using Microcharts;
using SkiaSharp;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FormHabit.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DetailView : Page
    {
        Models.Event singleEvent = new Models.Event();

        public DetailView()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (e.Parameter is Models.Event)
            {
                singleEvent = e.Parameter as Models.Event;
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var entries = new[]
                {
                    new Entry(200)
                    {
                        Label = "January",
                        ValueLabel = "200",
                    Color = SKColor.Parse("#266489")
                    },
                    new Entry(400)
                    {
                    Label = "February",
                    ValueLabel = "400",
                    Color = SKColor.Parse("#68B9C0")
                    },
                    new Entry(-100)
                    {
                    Label = "March",
                    ValueLabel = "-100",
                    Color = SKColor.Parse("#90D585")
                    },
                    new Entry(220)
                    {
                    Label = "April",
                    ValueLabel = "220",
                    Color = SKColor.Parse("#68B9C0")
                    },
                     new Entry(330)
                    {
                        Label = "May",
                        ValueLabel = "330",
                        Color = SKColor.Parse("#266489")
                    },
                };

            var chart = new LineChart() { Entries = entries };
            this.chartView.Chart = chart;

        }
    }
}
