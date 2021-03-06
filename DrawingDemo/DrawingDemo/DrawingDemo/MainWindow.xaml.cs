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
        private bool isMouseDown = false;

        // variables to hold mouse location
        private Point prevMouseLoc = new Point();
        private Point currMouseLoc = new Point();

        public MainWindow()
        {
            InitializeComponent();
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
                Line myLine = new Line();
                myLine.Stroke = Brushes.Red;

                currMouseLoc = e.GetPosition(this);

                // line's x coord
                myLine.X1 = prevMouseLoc.X;
                myLine.X2 = currMouseLoc.X;

                // line's y coord
                myLine.Y1 = prevMouseLoc.Y;
                myLine.Y2 = currMouseLoc.Y;

                // store current mouse Location in prev mouse Location
                prevMouseLoc = currMouseLoc;

                // line's alignment
                myLine.HorizontalAlignment = HorizontalAlignment.Left;
                myLine.VerticalAlignment = VerticalAlignment.Center;

                // thickness
                myLine.StrokeThickness = 2;

                // add line to the canvas
                myCanvas.Children.Add(myLine);
            }
        }

        private void myCanvas_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            isMouseDown = true;
            prevMouseLoc = e.GetPosition(this);
        }

        private void myCanvas_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                // Create a new line and define color
                Line myLine = new Line();
                myLine.Stroke = Brushes.Red;

                currMouseLoc = e.GetPosition(this);

                // line's x coord
                myLine.X1 = prevMouseLoc.X;
                myLine.X2 = currMouseLoc.X;

                // line's y coord
                myLine.Y1 = prevMouseLoc.Y;
                myLine.Y2 = currMouseLoc.Y;

                // store current mouse Location in prev mouse Location
                prevMouseLoc = currMouseLoc;

                // line's alignment
                myLine.HorizontalAlignment = HorizontalAlignment.Left;
                myLine.VerticalAlignment = VerticalAlignment.Center;

                // thickness
                myLine.StrokeThickness = 2;

                // add line to the canvas
                myCanvas.Children.Add(myLine);
            }
        }

        private void myCanvas_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            isMouseDown = false;
        }
    }
}
