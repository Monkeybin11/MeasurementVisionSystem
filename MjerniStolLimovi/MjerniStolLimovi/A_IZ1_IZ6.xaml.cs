﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Expression.Shapes;

namespace MjerniStolLimovi
{
	/// <summary>
	/// Interaction logic for A_IZ1_IZ6.xaml
	/// </summary>
	public partial class A_IZ1_IZ6 : UserControl , ILimKontrola
	{
        List<Arc> colorPointList = new List<Arc>();
        List<object> pointList = new List<object>();
        List<Point> pointListTranslatedAndRotated = new List<Point>();

        public Grid Circles
        {
            get { return circles; }
            set { circles = value; }
        }

        public Grid MainLines
        {
            get { return mainLines; }
            set { mainLines = value; }
        }

        public Grid PointArcs
        {
            get { return pointArcs; }
            set { pointArcs = value; }
        }

        public Grid CircleArcs
        {
            get { return circleArcs; }
            set { circleArcs = value; }
        }

        public Grid Centerlines
        {
            get { return centerlines; }
            set { centerlines = value; }
        }

        public String SheetName
        {
            get { return TextBlockAIZ6.Text; }
        }

        public List<string> MeasuresList
        {
            get
            {
                List<string> measTemp = new List<string>();
                foreach (string s in measuresArray.Items)
                {
                    measTemp.Add(s);
                }
                return measTemp;
            }
        }

        int purpose = 0;
        public int Purpose
        {
            get { return purpose; }
            set
            {
                purpose = value;
                LimoviCommon.purposeLookRefresh(purpose, pointArcs, lines, lineArrows, dimensionNames, lineEnumeration, circleEnumeration, angleEnumeration, circleArcs, centerlines);
            }
        }
        public List<object> PointList
        {
            get { return pointList; }
            set
            {
                pointList = value;
                LimoviCommon.pointColoring(PointList, colorPointList, Purpose);
                if (PointList.Count >= colorPointList.Count)
                {
                    pointListTranslatedAndRotated = LimoviCommon.translateAndRotate(PointList, (Point)PointList[6], (Point)PointList[1]);
                    var tempList = GetAll();
                }

            }
        }            
                
        //constructor
		public A_IZ1_IZ6()
		{
            this.InitializeComponent();
            colorPointList.Add(Point1);
            colorPointList.Add(Point2);
            colorPointList.Add(Point3);
            colorPointList.Add(Point4);
            colorPointList.Add(Point5);
            colorPointList.Add(Point6);
            colorPointList.Add(Point7);
            LimoviCommon.pointColoring(PointList, colorPointList, Purpose);
		}

        double GetOne(int measureNumber)
        {
            double B, L1;
            double centerline2X;
            switch (measureNumber)
            {
                case 0: // B
                    return (Math.Abs(pointListTranslatedAndRotated[5].Y) + Math.Abs(pointListTranslatedAndRotated[2].Y)) / 2;
                case 1: // L3
                    centerline2X = Math.Abs(pointListTranslatedAndRotated[6].X + pointListTranslatedAndRotated[5].X) / 2;
                    return Math.Abs(pointListTranslatedAndRotated[4].X - centerline2X);
                case 2: // L2
                    return Math.Abs(pointListTranslatedAndRotated[3].X - pointListTranslatedAndRotated[4].X);
                case 3: // L1
                    B = (Math.Abs(pointListTranslatedAndRotated[5].Y) + Math.Abs(pointListTranslatedAndRotated[2].Y)) / 2;
                    return Math.Abs(pointListTranslatedAndRotated[2].X - pointListTranslatedAndRotated[3].X) + B / 2;
                case 4: // L4
                    B = (Math.Abs(pointListTranslatedAndRotated[5].Y) + Math.Abs(pointListTranslatedAndRotated[2].Y)) / 2;
                    L1 = Math.Abs(pointListTranslatedAndRotated[2].X - pointListTranslatedAndRotated[3].X) + B / 2;
                    return Math.Abs(pointListTranslatedAndRotated[0].X - pointListTranslatedAndRotated[3].X) - L1;
                case 5:
                    return (GetOne(1) + GetOne(2) + GetOne(3) + GetOne(4));
                default:
                    return 0;
            }
        }

        public List<double> GetAll()
        {
            var tempList = new List<double>();
            for (int i = 0; i < measuresArray.Items.Count; i++)
            {
                tempList.Add(GetOne(i));
            }
            return tempList;
        }

        //events
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (PointList.Count < 8)
            {

            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (PointList.Count < 7)
            {
                PointList.Add(null);
                PointList = PointList;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
           PointList=new List<object>();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            pointListTranslatedAndRotated = LimoviCommon.translateAndRotate(PointList, (Point)PointList[6], (Point)PointList[1]);
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
      
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            PointList.Add(new Point(90, 37));
            PointList.Add(new Point(84, 40));
            PointList.Add(new Point(81.2, 20));
            PointList.Add(new Point(22.4, 1.3));
            PointList.Add(new Point(0, 13));
            PointList.Add(new Point(71.5, 26.7));
            PointList.Add(new Point(26.5, 12.5));
            PointList = PointList;
        }

	}
}