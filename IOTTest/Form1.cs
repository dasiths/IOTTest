using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Azure.Devices;
using Microsoft.Azure.Devices.Client;
using Microsoft.Azure.Devices.Common.Exceptions;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;
using Newtonsoft.Json;
using Message = Microsoft.Azure.Devices.Client.Message;
using TransportType = Microsoft.Azure.Devices.Client.TransportType;

namespace IOTTest
{
    public partial class Form1 : Form
    {
        static RegistryManager registryManager;
        static string connectionString = "HostName=DasithIOTHub.azure-devices.net;SharedAccessKeyName=iothubowner;SharedAccessKey=ShSXR0KjrGZL98aSiTWh/IrJTxBYo6AIfbXJQvnVGwU=";

        string iotHubD2cEndpoint = "messages/events";
        static EventHubClient eventHubClient;

        static DeviceClient deviceClient;
        static string iotHubUri = "DasithIOTHub.azure-devices.net";
        static string deviceKey = "ChOZOP8GkluY2KkjeCEOXnIqugGlpW4yNbj/i9N65HI=";

        public Form1()
        {
            InitializeComponent();

            registryManager = RegistryManager.CreateFromConnectionString(connectionString);
        }

        private void WriteToOutput(string s)
        {
            txtOutput.Text = txtOutput.Text + Environment.NewLine + s;
            txtOutput.SelectionStart = txtOutput.Text.Length - 1;
            txtOutput.ScrollToCaret();
        }

        private async void btnAddDevice_Click(object sender, EventArgs e)
        {

            string deviceId = "myFirstDevice";
            Device device;
            try
            {
                device = await registryManager.AddDeviceAsync(new Device(deviceId));
            }
            catch (DeviceAlreadyExistsException)
            {
                device = await registryManager.GetDeviceAsync(deviceId);
            }

            WriteToOutput("Generated device key: " + device.Authentication.SymmetricKey.PrimaryKey);
        }

        #region "Receive"

        private async void btnListen_Click(object sender, EventArgs e)
        {
            btnListen.Enabled = false;

            ServiceBusEnvironment.SystemConnectivity.Mode = ConnectivityMode.Http;

            WriteToOutput("Receive messages.");
            eventHubClient = EventHubClient.CreateFromConnectionString(connectionString, iotHubD2cEndpoint);

            var d2cPartitions = eventHubClient.GetRuntimeInformation().PartitionIds;

            CancellationTokenSource cts = new CancellationTokenSource();

            btnCancelListening.Click += (s, a) =>
            {
                cts.Cancel();
                WriteToOutput("Exiting...");
            };

            var tasks = new List<Task>();
            foreach (string partition in d2cPartitions)
            {
                tasks.Add(ReceiveMessagesFromDeviceAsync(partition, cts.Token));
            }
            await Task.WhenAll(tasks);
        }

        private async Task ReceiveMessagesFromDeviceAsync(string partition, CancellationToken ct)
        {
            var eventHubReceiver = eventHubClient.GetDefaultConsumerGroup().CreateReceiver(partition, DateTime.UtcNow);
            while (true)
            {
                if (ct.IsCancellationRequested) break;
                EventData eventData = await eventHubReceiver.ReceiveAsync();
                if (eventData == null) continue;

                string data = Encoding.UTF8.GetString(eventData.GetBytes());
                WriteToOutput($"Message received. Partition: {partition} Data: '{data}'");
            }
        }

        #endregion

        #region "Send"

        private async void btnSend_Click(object sender, EventArgs e)
        {
            WriteToOutput("Simulated device\n");
            deviceClient = DeviceClient.Create(iotHubUri, new DeviceAuthenticationWithRegistrySymmetricKey("myFirstDevice", deviceKey), TransportType.Http1);

            await SendDeviceToCloudMessagesAsync();
        }

        private async Task SendDeviceToCloudMessagesAsync()
        {
            double avgWindSpeed = 10; // m/s
            Random rand = new Random();

            while (true)
            {
                double currentWindSpeed = avgWindSpeed + rand.NextDouble() * 4 - 2;

                var telemetryDataPoint = new
                {
                    deviceId = "myFirstDevice",
                    windSpeed = currentWindSpeed
                };
                var messageString = JsonConvert.SerializeObject(telemetryDataPoint);
                var message = new Message(Encoding.ASCII.GetBytes(messageString));

                await deviceClient.SendEventAsync(message);
                WriteToOutput($"{DateTime.Now} > Sending message: {messageString}");

                Task.Delay(1000).Wait();
            }
        }

        #endregion
    }
}
