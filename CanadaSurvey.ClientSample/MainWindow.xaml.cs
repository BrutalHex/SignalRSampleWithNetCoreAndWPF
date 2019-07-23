using CanadaSurvey.CommunicationComponent;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Threading;
using System.Windows;

namespace CanadaSurvey.ClientSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Communicator communicator;
        public MainWindow()
        {
            InitializeComponent();

        }
        private void ReInitMessage()
        {
            try
            {
                communicator = new Communicator(UrlBox.Text);

                communicator.OnMessageReceived += Message_Received;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void UrlBox_LostFocus(object sender, RoutedEventArgs e)
        {
            ReInitMessage();
        }

        private void Grid_Initialized(object sender, EventArgs e)
        {
            ReInitMessage();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            CloseConnection();
        }

        private async void SendBtn_Click(object sender, RoutedEventArgs e)
        {
            if (communicator == null)
            {
                ReInitMessage();
            }
            await communicator.SendAsync(MessageTxT.Text);


        }







        private void CloseConnection()
        {
            communicator.CloseChannel();
        }

        private void Message_Received(object sender, MessageReceivedEventArgs e)
        {


            VisualizeMsssage(e.Message);


        }

        private void VisualizeMsssage(string message)
        {
            Dispatcher.BeginInvoke(new ThreadStart(() => { ReceiveBox.Text += Environment.NewLine + message; }));

        }



    }
}
