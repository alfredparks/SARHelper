using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LKS
{
    /// <summary>
    /// Holds most of the data for the track we create for importing to Ozi.
    /// </summary>
    public class Track
    {
        private readonly int width = 2;
        // Since Ozi can't be nice, and use hex codes for colour, refer here for colour numbers: https://infocenter.sybase.com/help/index.jsp?topic=/com.sybase.stf.wad_dw.doc/html/wad_dw/CAIBJHCI.htm
        private string colour;
        private readonly string dis = DateTime.Now.ToString();
        // For track type, 0 is just a line (for max distance, or a median), 10 is a polygon (for donuts)
        private int trkType;
        private string fillColour;
        // Count of how many points are in the track. Ozi needs it in the file.
        private int trkPoints;
        // The points that will make up the track.
        private ArrayList points;

        public Track(string c, int t)
        {
            colour = c;
            fillColour = c;
            trkType = t;
        }

        /// <summary>
        /// Sets the track points. If changing the track points through other means, be sure to update the count too.
        /// </summary>
        /// <param name="p">An arraylist of TrackPoint objects.</param>
        public void setPoints(ArrayList p)
        {
            points = p;
            trkPoints = p.Count;
        }

        /// <summary>
        /// Makes a string that can be written to a .plt file that Ozi can read to load the track. Data that is not going to change has been hardcoded.
        /// </summary>
        /// <returns>A string that is properly formated for making a .plt file for OziExplorer</returns>
        public String makeFileString()
        {
            string fileString = "OziExplorer Track Point File Version 2.1\n WGS 84\n Altitude is in Feet \n Reserved 3 \n 0," + width + "," + colour + "," + dis + ",1," + trkType +
                ",3," + fillColour + "-1,5 \n" + trkPoints;
            // appendSelf() puts a new line character before its data, so we don't need to worry about that.
            foreach (TrackPoint p in points)
            {
                fileString = p.appendSelf(fileString);
            }
            return fileString;
        }
    }
}
