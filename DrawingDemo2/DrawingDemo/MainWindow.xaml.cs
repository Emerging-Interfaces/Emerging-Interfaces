using System;
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

        // Lists for touch collections
        private TouchPointCollection tpcCurr = new TouchPointCollection();
        private TouchPointCollection tpcPrev = new TouchPointCollection();

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
            tpcCurr = e.GetIntermediateTouchPoints(this);

            for (int i = 0; i < tpcCurr.Count; i++)
            {
                draw(Brushes.Black, tpcPrev[i].Position, tpcCurr[i].Position, 3);
            }

            // set prev touch collect to current
            tpcPrev = tpcCurr;
        }        

        private void myCanvas_TouchDown(object sender, TouchEventArgs e)
        {
            tpcPrev = e.GetIntermediateTouchPoints(this);
        }
    }
}
