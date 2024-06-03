using NetworkService.Model;
using NetworkService.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace NetworkService.ViewModel
{
    public class MainWindowViewModel : BindableBase
    {
        private NetworkEntitiesViewModel EntitiyView = new NetworkEntitiesViewModel();
        private MeasurmentGraphViewModel GraphView = new MeasurmentGraphViewModel();
        private NetworkDisplayViewModel DisplayView = new NetworkDisplayViewModel();
        private BindableBase currentViewModel;
        Help hlp;
        public MyICommand<string> NavCommand { get;private set; }
        public MyICommand HelpCommand { get;private set; }

        public BindableBase CurrentViewModel
        {
            get
            {
                return currentViewModel;
            }

            set
            {
                SetProperty(ref currentViewModel, value);
            }
        }
        public MainWindowViewModel()
        {
            createListener(); //Povezivanje sa serverskom aplikacijom
            NavCommand = new MyICommand<string>(OnNav);
            HelpCommand = new MyICommand(onHelp);
            CurrentViewModel = EntitiyView;
            LoadData();
        }
        private void OnNav(string destination)
        {
            switch (destination)
            {
                case "entity":
                    CurrentViewModel = EntitiyView;
                    break;
                case "display":
                    CurrentViewModel = DisplayView;
                    break;
                case "graph":
                    CurrentViewModel = GraphView;
                    break;
            }
        }

        private void onHelp()
        {
            if (hlp == null)
            {
                // Create a new instance of the help window if it's not already open
                hlp = new Help();

                // Subscribe to the Closed event of the help window
                hlp.Closed += (sender, e) =>
                {
                    // Reset the reference to null when the window is closed
                    hlp = null;
                };

                hlp.Show();
            }
            else
            {
                // If the help window is already open, bring it to the front
                hlp.Activate();
            }
        }

        private void createListener()
        {
            var tcp = new TcpListener(IPAddress.Any, 25675);
            tcp.Start();

            var listeningThread = new Thread(() =>
            {
                while (true)
                {
                    var tcpClient = tcp.AcceptTcpClient();
                    ThreadPool.QueueUserWorkItem(param =>
                    {
                        //Prijem poruke
                        NetworkStream stream = tcpClient.GetStream();
                        string incomming;
                        byte[] bytes = new byte[1024];
                        int i = stream.Read(bytes, 0, bytes.Length);
                        //Primljena poruka je sacuvana u incomming stringu
                        incomming = System.Text.Encoding.ASCII.GetString(bytes, 0, i);

                        //Ukoliko je primljena poruka pitanje koliko objekata ima u sistemu -> odgovor
                        if (incomming.Equals("Need object count"))
                        {
                            //Response
                            /* Umesto sto se ovde salje count.ToString(), potrebno je poslati 
                             * duzinu liste koja sadrzi sve objekte pod monitoringom, odnosno
                             * njihov ukupan broj (NE BROJATI OD NULE, VEC POSLATI UKUPAN BROJ)
                             * */
                            Byte[] data = System.Text.Encoding.ASCII.GetBytes(GetEntitiesCount().ToString());
                            stream.Write(data, 0, data.Length);
                        }
                        else
                        {
                            //U suprotnom, server je poslao promenu stanja nekog objekta u sistemu
                            Console.WriteLine(incomming); //Na primer: "Entitet_1:272"

                            //################ IMPLEMENTACIJA ####################
                            // Obraditi poruku kako bi se dobile informacije o izmeni
                            // Azuriranje potrebnih stvari u aplikaciji

                            string[] input = incomming.Split('_');

                            var parts = input[1].Split(':');
                            if (parts.Length == 2)
                            {
                                string entityName = parts[0];
                                string value = parts[1];

                                 // Upis u Log datoteku
                                WriteToLogFile(entityName, value);

                                // Ažuriranje potrebnih stvari u aplikaciji
                                UpdateEntityValue(Int32.Parse(entityName), Double.Parse(value), incomming.Split(':')[0]);
                            }
                        }
                    }, null);
                }
            });

            listeningThread.IsBackground = true;
            listeningThread.Start();
        }

        private void WriteToLogFile(string entityName, string value)
        {
            string logFilePath = @"../../Log.txt";
            string logEntry = $"{DateTime.Now}: Entity {entityName} - Value: {value}";
            File.AppendAllText(logFilePath, logEntry + Environment.NewLine);
        }
        private int GetEntitiesCount()
        {
            // Metoda koja vraća broj entiteta pod monitoringom
            return ReactorCollection.Entities.Count;
        }
        private void UpdateEntityValue(int id, double value, string name)
        {
            // Metoda koja ažurira vrednost entiteta u aplikaciji
            foreach(ReactorTemp entity in ReactorCollection.Entities)
            {
                if (entity.Id == id)
                {
                    try
                    {
                        entity.Value = value;
                        
                    }
                    catch (Exception) {
                    }
                }
            }
            
        }

        private void LoadData()
        {

            ReactorCollection.Entities.Add(new ReactorTemp(0,"Entity_0",305,ReactorCollection.ThermoTypes["RTD"]));
            ReactorCollection.Entities.Add(new ReactorTemp(1, "Entity_1", 345, ReactorCollection.ThermoTypes["TC"]));
            ReactorCollection.Entities.Add(new ReactorTemp(2, "Entity_2", 275, ReactorCollection.ThermoTypes["RTD"]));
            ReactorCollection.Entities.Add(new ReactorTemp(3, "Entity_3", 251, ReactorCollection.ThermoTypes["TC"]));
            ReactorCollection.Entities.Add(new ReactorTemp(4, "Entity_4", 275, ReactorCollection.ThermoTypes["RTD"]));
            ReactorCollection.Entities.Add(new ReactorTemp(5, "Entity_5", 300, ReactorCollection.ThermoTypes["TC"]));
            ReactorCollection.Entities.Add(new ReactorTemp(6, "Entity_6", 349, ReactorCollection.ThermoTypes["RTD"]));
        }
    }
}
