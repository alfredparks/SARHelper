using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LKS
{
    public class SCartographer
    {
        public SCartographer() { 
        }

        public ArrayList workOrder(int type, double lon, double lat, double dis)
        {
            if (type == 0)
            {
                ArrayList rlist = drawCircle(lon, lat, dis);
                return rlist;
            } else
            {
                ArrayList rlist = drawCircles(lon, lat, dis);
                return rlist;
            }
        }

        public ArrayList drawCircle(double lon, double lat, double dis)
        {
            ArrayList points = new ArrayList();
            double l, x, y;
            TrackPoint point = new TrackPoint(lon, lat, 1);
            points.Add(point);
            l = (int)(dis * Math.Cos(Math.PI / 4));
            //l = 4.99953072516704;
            for (x = -l; x < l; x++)
            {
                y = Math.Sqrt((dis * dis) - (x * x));
                lon = lon + x;
                lat = lat + y;
                point = new TrackPoint(lon, lat, 0);
                points.Add(point);
            }
            for (x = -l; x < l; x++)
            {
                y = Math.Sqrt((dis * dis) - (x * x));
                lon = lon + -x;
                lat = lat + y;
                point = new TrackPoint(lon, lat, 0);
                points.Add(point);
            }
            for (x = -l; x < l; x++)
            {
                y = Math.Sqrt((dis * dis) - (x * x));
                lon = lon + -x;
                lat = lat + -y;
                point = new TrackPoint(lon, lat, 0);
                points.Add(point);
            }
            for (x = -l; x < l; x++)
            {
                y = Math.Sqrt((dis * dis) - (x * x));
                lon = lon + x;
                lat = lat + -y;
                point = new TrackPoint(lon, lat, 0);
                points.Add(point);
            }

            return points;
        }

        public ArrayList drawCircles(double lon, double lat, double dis)
        {
            ArrayList points = new ArrayList();
            double l;
            TrackPoint point = new TrackPoint(lon, lat, 1);
            points.Add(point);
            //l = (int)(dis * Math.Cos(Math.PI / 4));
            l = 4.99953072516704;
            for (lon = -l; lon < l; lon++)
            {
                lat = Math.Sqrt((dis * dis) - (lon * lon));
                point = new TrackPoint(lon, lat, 0);
                points.Add(point);
            }
            for (lon = -l; lon < l; lon++)
            {
                lat = Math.Sqrt((dis * dis) - (lon * lon));
                point = new TrackPoint(-lon, lat, 0);
                points.Add(point);
            }
            for (lon = -l; lon < l; lon++)
            {
                lat = Math.Sqrt((dis * dis) - (lon * lon));
                point = new TrackPoint(-lon, -lat, 0);
                points.Add(point);
            }
            for (lon = -l; lon < l; lon++)
            {
                lat = Math.Sqrt((dis * dis) - (lon * lon));
                point = new TrackPoint(lon, -lat, 0);
                points.Add(point);
            }

            return points;
        }
    }
}
