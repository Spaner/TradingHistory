using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
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
using TradingHistory.Controllers;
using TradingHistory.Models;

namespace TradingHistory
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool canFetchData = false;
        public MainWindow()
        {
            InitializeComponent();
            SetStartState();
        }

        /// <summary>
        /// Initializes the UI
        /// </summary>
        private void SetStartState()
        {
            ToggleTextFirst.Text = Constants.PRESS_TEXT;
            ToggleTextSecond.Text = Constants.START_MESSAGE;
            ToggleButton.Content = Constants.START;
        }

        /// <summary>
        /// Displays text in the MainContent ScrollViewer, ordered by most recent entry
        /// </summary>
        /// <param name="text">Text to display</param>
        /// <param name="isWarning">Changes the text style if true</param>
        private void SetMainContent(string text, bool isWarning = false)
        {
            TextBlock textBlock = new TextBlock();
            textBlock.Text = text;
            textBlock.TextWrapping = TextWrapping.Wrap;
            textBlock.FontSize = 14;
            if (isWarning)
            {
                textBlock.Foreground = Brushes.Red;
                textBlock.FontWeight = FontWeights.Bold;
            }
            //removes lines past the maximum number of lines allowed
            if(MainContentPanel.Children.Count >= Settings.MaxLinesDisplay)
            {
                MainContentPanel.Children.RemoveAt(MainContentPanel.Children.Count - 1);
            }
            MainContentPanel.Children.Insert(0, textBlock);
            MainContent.Content = MainContentPanel;
        }

        #region Event Handlers

        /// <summary>
        /// Handler for the click event of ToggleButton. Toggles fetching data on or off.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnToggleHandler(object sender, EventArgs e)
        {
            SetRunningState();
            FetchData();
        }

        /// <summary>
        /// Toggles fetching data on or off and sets the value for UI elements based on it.
        /// </summary>
        private void SetRunningState()
        {
            canFetchData = !canFetchData;
            ToggleButton.Content = canFetchData ? Constants.STOP : Constants.START;
            ToggleTextSecond.Text = canFetchData ? Constants.STOP_MESSAGE : Constants.START_MESSAGE;
            if (!canFetchData)
            {
                TimeText.Text = string.Empty;
            }
            var timeMessage = canFetchData ? Constants.START_TIME_MESSAGE : Constants.STOP_TIME_MESSAGE;
            var operationText = string.Format(timeMessage, DateTimeOffset.Now.LocalDateTime);
            SetMainContent(operationText, true);
        }
        

        /// <summary>
        /// Fetches Fetches a specified number of records of BTC/EUR trades starting from a set date (last hour)
        /// and displays the minimum, maximum and average prices every 10 seconds
        /// </summary>
        private async void FetchData()
        {
            var controller = new BitcoinEuroTradeController();
            try
            {
                while (canFetchData)
                {
                    var now = DateTimeOffset.Now;
                    var maxTime = now.AddHours(-Settings.StartInterval);
                    var maxTimeMilliseconds = maxTime.ToUnixTimeMilliseconds();
                    TimeText.Text = string.Format(Constants.TIME_TEXT, maxTime.LocalDateTime);

                    var tradeList = await controller.BitcoinEuroTradeHistory(Settings.RecordLimit, maxTimeMilliseconds);
                    var minPrice = tradeList.Min(o => o.Price);
                    var maxPrice = tradeList.Max(o => o.Price);
                    var averagePrice = tradeList.Average(o => o.Price);
                    var displayText = string.Format(Constants.BTC_EUR_DISPLAY_TEXT, now.LocalDateTime, minPrice, maxPrice, averagePrice);
                    SetMainContent(displayText);

                    await Task.Delay(Settings.RefreshInterval);
                }
            }
            catch (Exception ex)
            {
                var errorText = string.Format(Constants.ERROR_TIME_MESSAGE, DateTimeOffset.Now.LocalDateTime, ex.Message);
                SetMainContent(errorText, true);
                SetRunningState();
            }
        }
        #endregion
    }
}
