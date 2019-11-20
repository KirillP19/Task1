using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuickGraph;
using QuickGraph.Algorithms;

namespace BusSimulator
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        Simulation sim = new Simulation();

        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            if (cBxStart.Items.Count > 0) //При загрузке нового файла
            {
                cBxTime.Items.Clear();
                cBxStart.Items.Clear();
                cBxFinish.Items.Clear();
                lblResult.Text = "Результат:\n-";
            }

            //Чтение файла
            var lines = File.ReadAllLines(tBxFileAddress.Text);
            int busCount = Convert.ToInt32(lines[0]);
            int busStops = Convert.ToInt32(lines[1]);

            //Основной объект
            sim = new Simulation
            {
                StopCount = busStops
            };

            string[] startTimes = lines[2].Split(' ');
            string[] ticketCosts = lines[3].Split(' ');

            for (int i = 1; i <= busStops; i++)
            {
                cBxStart.Items.Add(i.ToString());
                cBxFinish.Items.Add(i.ToString());
            }

            //Заполнение массива автобусов
            for (int i = 0; i < busCount; i++)
            {
                Bus bus = new Bus
                {
                    StartTime = startTimes.ElementAt(i),
                    TicketCost = Convert.ToInt32(ticketCosts.ElementAt(i)),
                    ID = i + 1
                };

                sim.Buses.Add(bus);
            }

            //Составление и заполнение расписаний автобусов
            for (int i = 4; i < lines.Length; i++)
            {
                string tempo = lines[i];
                int count = Convert.ToInt32(tempo.Substring(0, tempo.IndexOf(' ')));
                tempo = tempo.Substring(tempo.IndexOf(' ') + 1);
                List<int> stopData = tempo.Split(' ').Select(Int32.Parse).ToList();

                //DateTime startTime = Convert.ToDateTime(sim.Buses[i - 4].StartTime);
                for (int j = 0; j < count; j++)
                {
                    BusStop busStop = new BusStop
                    {
                        Number = stopData[j],
                        TravelTime = stopData[j + count]
                    };

                    //DateTime timing = startTime;

                    //startTime = startTime.AddMinutes(busStop.TravelTime);

                    sim.Buses[i - 4].BaseSchedule.BusStops.Add(busStop);
                    //sim.Buses[i - 4].BaseSchedule.TimeStamps.Add(timing); //последний TimeStamp - время возвращения (для зацикливания)
                }
                //sim.Buses[i - 4].ReturnTime = stopData[stopData.Count() - 1];

                int minutes = Convert.ToInt32(TimeSpan.Parse(sim.Buses[i - 4].StartTime).TotalMinutes);
                int currentStation = 0;
                int stationTotal = sim.Buses[i - 4].BaseSchedule.BusStops.Count();
                //MessageBox.Show("total:" + stationTotal.ToString());

                DateTime currentTime = Convert.ToDateTime(sim.Buses[i - 4].StartTime);
                int totalTime = minutes;
                while (totalTime < 1440)
                {
                    BusStop busStop = new BusStop
                    {
                        Number = sim.Buses[i - 4].BaseSchedule.BusStops[currentStation].Number,
                        TravelTime = sim.Buses[i - 4].BaseSchedule.BusStops[currentStation].TravelTime
                    };

                    DateTime timing = currentTime;

                    sim.Buses[i - 4].FullSchedule.BusStops.Add(busStop);

                    currentTime = currentTime.AddMinutes(busStop.TravelTime);
                    totalTime += busStop.TravelTime;

                    currentStation += 1;
                    if (currentStation == stationTotal)
                    {
                        currentStation = 0;
                    }

                    sim.Buses[i - 4].FullSchedule.TimeStamps.Add(timing); //последний TimeStamp - время возвращения (для зацикливания)
                }
            }

            //foreach (Bus bus in sim.Buses)
            //{
            //    string full = "";
            //    for (int i = 0; i < bus.FullSchedule.BusStops.Count; i++)
            //    {
            //        full += bus.FullSchedule.BusStops[i].Number + " " + bus.FullSchedule.TimeStamps[i].ToString("HH:mm") + "   ";
            //    }

            //    //foreach (DateTime dt in bus.FullSchedule.TimeStamps)
            //    //{
            //    //    full += dt.TimeOfDay + " ";
            //    //}
            //    MessageBox.Show(full);
            //}
            MessageBox.Show("Файл загружен успешно!", "BusSimulator");

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, "BusSimulator");
            //}
        }

        AdjacencyGraph<string, Edge<string>> shortestPathGraph;
        Dictionary<Edge<string>, double> shortestPathCosts;
        Dictionary<Edge<string>, int> shortestPathBusIDs;

        AdjacencyGraph<string, Edge<string>> cheapestPathGraph;
        Dictionary<Edge<string>, double> cheapestPathCosts;
        Dictionary<Edge<string>, int> cheapestPathBusIDs;

        public void SetUpEdgesAndCosts()
        {
            shortestPathGraph = new AdjacencyGraph<string, Edge<string>>();
            shortestPathCosts = new Dictionary<Edge<string>, double>();
            shortestPathBusIDs = new Dictionary<Edge<string>, int>();

            cheapestPathGraph = new AdjacencyGraph<string, Edge<string>>();
            cheapestPathCosts = new Dictionary<Edge<string>, double>();
            cheapestPathBusIDs = new Dictionary<Edge<string>, int>();

            //TimeSpan currentTime = TimeSpan.Parse(cBxTime.Text);
            foreach (Bus bus in sim.Buses)
            {
                int count = (bus.BaseSchedule.BusStops.Count * 2) - 1;

                for (int i = 0; i < count; i++)
                {
                    // Граф для самого короткого пути
                    //if (i == 0 || currentTime == bus.FullSchedule.TimeStamps[i].TimeOfDay) //Добавить следующую остановку если автобус на самой первой или если автобус будет на следующей остановке в нужное время
                    //{
                    AddEdgeWithCosts(bus.FullSchedule.BusStops[i].Number.ToString(), bus.FullSchedule.BusStops[i + 1].Number.ToString(), bus.FullSchedule.BusStops[i].TravelTime, shortestPathGraph, shortestPathCosts, shortestPathBusIDs, bus.ID);
                    //    currentTime = currentTime.Add(bus.FullSchedule.TimeStamps[i].TimeOfDay);
                    //}

                    for (int j = 0; j < bus.BaseSchedule.BusStops.Count; j++)
                    {
                        //if (i == 0 || currentTime == bus.FullSchedule.TimeStamps[i].TimeOfDay)
                        //{
                        AddEdgeWithCosts(bus.FullSchedule.BusStops[i].Number.ToString(), bus.FullSchedule.BusStops[j].Number.ToString(), bus.TicketCost, cheapestPathGraph, cheapestPathCosts, cheapestPathBusIDs, bus.ID);
                        //    currentTime = currentTime.Add(bus.FullSchedule.TimeStamps[i].TimeOfDay);
                        //}
                    }
                }
            }


            //foreach (Edge<string> edge in shortestPathGraph.Edges)
            //{
            //    MessageBox.Show(edge.Source.);
            //}

            //AddEdgeWithCosts("A", "D", 4.0);
            //AddEdgeWithCosts("C", "B", 1.0);
        }

        private void AddEdgeWithCosts(string source, string target, double cost, AdjacencyGraph<string, Edge<string>> graph, Dictionary<Edge<string>, double> costs, Dictionary<Edge<string>, int> busIDs, int busID)
        {
            var edge = new Edge<string>(source, target);
            graph.AddVerticesAndEdge(edge);
            costs.Add(edge, cost);
            busIDs.Add(edge, busID);
        }

        private string PrintShortestPath(string @from, string to, AdjacencyGraph<string, Edge<string>> graph, Dictionary<Edge<string>, double> costs, Dictionary<Edge<string>, int> busIDs, int mode)
        {
            var edgeCost = AlgorithmExtensions.GetIndexer(costs);
            var tryGetPath = graph.ShortestPathsDijkstra(edgeCost, @from);

            string type = "";
            if (mode == 1)
            {
                type = "короткий";
            }
            else if (mode == 2)
            {
                type = "дешёвый";
            }

            IEnumerable<Edge<string>> path;
            StringBuilder builder = new StringBuilder();

            if (tryGetPath(to, out path))
            {
                builder.Append("Самый " + type + " путь от остановки ");
                builder.Append(from);
                builder.Append(" до остановки ");
                builder.Append(to);
                builder.Append(":\n");
                builder.Append("{" + from + "}");

                //MessageBox.Show("Path found from {" + from  + "} to {" + to + "}: {" + from + "}");
                foreach (var e in path)
                {
                    builder.Append(" > {" + e.Target + "}");
                }
            }
            else
            {
                builder.Append("Путь не найден.");
            }

            builder.Append(" на автобусе(ах): ");
            foreach (Edge<string> edge in path)
            {
                foreach (var item in busIDs)
                {
                    if (item.Key == edge)
                    {
                        //MessageBox.Show(item.Value.ToString());
                        builder.Append(item.Value.ToString() + " ");
                    }
                }
            }


            return builder.ToString();
        }

        private void btnFindRoutes_Click(object sender, EventArgs e)
        {
            //if (cheapestBusID == 0 || fastestBusID == 0)
            //{
            //    if (cBxTime.Text.Length < 1)
            //    {
            //        lblResult.Text = "Укажите время отправления.";
            //    }
            //}
            //else
            //{
            //    if (shortestTime > 0)
            //    {
            //        lblResult.Text = "Результат:\nСамый дешёвый автобус: Номер " + cheapestBusID + ", стоимость: " + lowestCost.ToString()
            //            + "\nСамый быстрый автобус: Номер " + fastestBusID + ", время в пути: " + shortestTime.ToString();
            //    }
            //}

            shortestPathGraph = new AdjacencyGraph<string, Edge<string>>();
            shortestPathCosts = new Dictionary<Edge<string>, double>();

            SetUpEdgesAndCosts();

            lblResult.Text = "Результат:\n" + PrintShortestPath(cBxStart.Text, cBxFinish.Text, shortestPathGraph, shortestPathCosts, shortestPathBusIDs, 1)
                + "\n" + PrintShortestPath(cBxStart.Text, cBxFinish.Text, cheapestPathGraph, cheapestPathCosts, cheapestPathBusIDs, 2);
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            tBxFileAddress.Text = @"F:\Test.txt";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void cBxStart_SelectedIndexChanged(object sender, EventArgs e)
        {
            cBxTime.Items.Clear();
            cBxTime.Text = "";

            //Заполнение comboBox'a с временами отправлений
            for (int i = 0; i < sim.Buses.Count; i++)
            {
                if (sim.Buses[i].FullSchedule.BusStops.Any(x => x.Number == Convert.ToInt32(cBxStart.SelectedItem)) == true)
                {
                    //int index = 0;
                    for (int j = 0; j < sim.Buses[i].FullSchedule.BusStops.Count; j++)
                    {
                        if (sim.Buses[i].FullSchedule.BusStops[j].Number == Convert.ToInt32(cBxStart.SelectedItem))
                        {
                            //index = j;
                            //}
                            //else if (sim.Buses[i].FullSchedule.BusStops[j].Number == Convert.ToInt32(cBxFinish.SelectedItem) && index != -2)
                            //{
                            string s = sim.Buses[i].FullSchedule.TimeStamps[j].ToString("HH:mm");
                            cBxTime.Items.Add(s);

                            //    index = -2;
                        }
                    }
                }
            }

            cBxFinish.Items.Clear();
            cBxFinish.Text = "";

            for (int i = 1; i <= sim.StopCount; i++)
            {
                cBxFinish.Items.Add(i.ToString());
            }

            cBxFinish.Items.Remove(Convert.ToInt32(cBxStart.SelectedItem));
        }

        private void cBxFinish_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }


    //Добавить в отдельный класс в случае дальнейшей доработки, добавить ID где требуется если присоединять базу данных
    public class Simulation
    {
        private List<Bus> _buses = new List<Bus>();

        public IList<Bus> Buses { get { return _buses; } }

        public int StopCount { get; set; }
    }

    public class Bus
    {
        public int ID { get; set; }
        public string StartTime { get; set; }
        public int TicketCost { get; set; }
        public Schedule FullSchedule = new Schedule();
        public Schedule BaseSchedule = new Schedule();
    }

    public class BusStop
    {
        public int Number { get; set; }// ID
        public int TravelTime { get; set; }
    }

    public class Schedule
    {
        public List<BusStop> BusStops = new List<BusStop>();
        public List<DateTime> TimeStamps = new List<DateTime>();

        // private List<BusStop> _busStops = new List<BusStop>();
        // public IList<BusStop> BusStops { get { return _busStops; } }    
        // private List<DateTime> _timeStamps = new List<DateTime>();
        // public IList<DateTime> TimeStamps { get { return _timeStamps; } }


    }

}
