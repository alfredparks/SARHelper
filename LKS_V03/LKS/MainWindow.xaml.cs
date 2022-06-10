/// Authors: Alister Hardy, Gabriel Ross-Carrier
/// Date: May 9, 2022
/// Last Edit: May 11, 2022

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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

namespace LKS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // The track the program is working on. Having just one might be cumbersome later, but should be fine for now.
        private Track curTrack;
        private SCartographer silent = new SCartographer(); 
        public MainWindow()
        {
            InitializeComponent();
            // Makes new track.
            curTrack = new Track("16711680", 10);
            // Adds the points for the track. Will be handled via function later, as we need to calcualate a series of points to make a circle.
            ArrayList points = silent.workOrder(0, 64, 48, 5);
            //points.Add(new TrackPoint(63.962218, -94.311558, 1));
            //points.Add(new TrackPoint(58.192711, -101.658291, 0));
            //points.Add(new TrackPoint(50.763070, -83.376884, 0));
            //points.Add(new TrackPoint(64.408781, -94.824121, 0));
            // Add the points to the track.
            curTrack.setPoints(points);
            // Make the file by calling this.
            createPLT();
            // Exit the app, since the interface isn't in yet.
            System.Environment.Exit(0);
        }

        /// <summary>
        /// Probably a garbage fuction that calls up track to make the string for the PLT file.
        /// </summary>
        public void createPLT()
        {
            string fileData = curTrack.makeFileString();
            writeToFile(fileData);
        }

        /// <summary>
        /// Writes data to a file. Expects only a single string.
        /// </summary>
        /// <param name="data">The data to write from the file. Should come from Track's makeFileString()</param>
        public void writeToFile(string data)
        {
            // create path and file name for writing to. This step will need to go to a higher scope later,
            // so that other identifiers can be added (like track type, which statisitic it represents, or other things)
            string currDir = Environment.CurrentDirectory;
            string fileName = "MissingPerson_" + DateTime.Now.ToString("yyyy-MM-dd") + ".plt";
            Console.WriteLine(fileName);
            File.WriteAllText(System.IO.Path.Combine(currDir, fileName), data);
        }
    }
}
