﻿using System;
using System.Collections.Generic;
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

namespace DrawingDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // testing bool
        private bool mouseTest = false;


        private bool isMouseDown = false;

        // variables to hold mouse location
        private Point prevMouseLoc = new Point();
        private Point currMouseLoc = new Point();

        // Lists for touch collections
        //private TouchPoint tpCurr;
        //private TouchPoint tpPrev;

        private Dictionary<int, Point> prevTouches = new Dictionary<int,Point>();
        private Dictionary<int, Point> currTouches = new Dictionary<int,Point>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void draw(Brush color, Point prevLoc, Point currLoc, int thick)
        {
            // Create a new line and define color
            Line myLine = new Line();
            myLine.Stroke = color;

            // line's x coord
            myLine.X1 = prevLoc.X;
            myLine.X2 = currLoc.X;

            // line's y coord
            myLine.Y1 = prevLoc.Y;
            myLine.Y2 = currLoc.Y;

            // line's alignment
            myLine.HorizontalAlignment = HorizontalAlignment.Left;
            myLine.VerticalAlignment = VerticalAlignment.Center;

            // thickness
            myLine.StrokeThickness = thick;

            // add line to the canvas
            myCanvas.Children.Add(myLine);
        }

        private void myCanvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            isMouseDown = true;
            prevMouseLoc = e.GetPosition(this);
        }

        private void myCanvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            isMouseDown = false;
        }

        private void myCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                // Create a new line and define color
                //Line myLine = new Line();
                //myLine.Stroke = Brushes.Red;

                //currMouseLoc = e.GetPosition(this);

                //// line's x coord
                //myLine.X1 = prevMouseLoc.X;
                //myLine.X2 = currMouseLoc.X;

                //// line's y coord
                //myLine.Y1 = prevMouseLoc.Y;
                //myLine.Y2 = currMouseLoc.Y;

                currMouseLoc = e.GetPosition(this);

                // use draw method
                if(mouseTest)  
                draw(Brushes.Red, prevMouseLoc, currMouseLoc, 3);

                // store current mouse Location in prev mouse Location
                prevMouseLoc = currMouseLoc;

                //// line's alignment
                //myLine.HorizontalAlignment = HorizontalAlignment.Left;
                //myLine.VerticalAlignment = VerticalAlignment.Center;

                //// thickness
                //myLine.StrokeThickness = 2;

                //// add line to the canvas
                //myCanvas.Children.Add(myLine);
            }
        }

        private void myCanvas_TouchMove(object sender, TouchEventArgs e)
        {
            //tpCurr = e.GetTouchPoint(this);

            int tempId = e.TouchDevice.Id;
            Point tempPoint = e.GetTouchPoint(this).Position;

            currTouches.Add(tempId, tempPoint);

            draw(Brushes.Black, prevTouches[tempId], currTouches[tempId], 3);

            prevTouches[tempId] = currTouches[tempId];

            // set prev touch collect to current
            //tpPrev = tpCurr;
        }        

        private void myCanvas_TouchDown(object sender, TouchEventArgs e)
        {
            //tpPrev = e.GetTouchPoint(this);

            // Store the touch id and the touch location
            int tempId = e.TouchDevice.Id;
            Point tempPoint = e.GetTouchPoint(this).Position;

            prevTouches.Add(tempId, tempPoint);
        }

        private void myCanvas_TouchUp(object sender, TouchEventArgs e)
        {
            prevTouches.Remove(e.TouchDevice.Id);
            currTouches.Remove(e.TouchDevice.Id);
        }
    }
}
