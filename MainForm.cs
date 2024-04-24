using KNN.Controller;
using System.ComponentModel.DataAnnotations;
using System.Windows.Forms;

namespace KNN
{
    public partial class MainForm : Form
    {
        private int _width = 10;
        private int _height = 10;
        private Color _backgroundColor = Color.Gray;
        private KNNController _controller;

        public MainForm()
        {
            InitializeComponent();
            _controller = new KNNController();

            if (pictureBox.Image == null)
            {
                Bitmap bmp = new Bitmap(pictureBox.Width, pictureBox.Height);
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.Clear(_backgroundColor);
                }
                pictureBox.Image = bmp;
            }
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            var id = _controller.GetNextObjectId();
            ClearLines();
            if (e.Button == MouseButtons.Left)
            {
                _controller.AddObject(new Model.Object(
                    id,
                    (float)e.X,
                    (float)e.Y,
                    Model.Type.Rectangle
                    ));

                DrawRectangle(e.Location, Color.Red, Color.Black);
            }
            if (e.Button == MouseButtons.Right)
            {
                _controller.AddObject(new Model.Object(
                    id,
                    (float)e.X,
                    (float)e.Y,
                    Model.Type.Triangle
                    ));

                DrawTriangle(e.Location, Color.Blue, Color.Black);
            }
            if (e.Button == MouseButtons.Middle)
            {
                var circles = _controller.GetObjectsByType(Model.Type.Circle);
                if (circles.Count != 0)
                {
                    var circle = circles.First();
                    Draw—ircle(new Point((int)circle.X, (int)circle.Y), _backgroundColor, _backgroundColor);
                }

                _controller.RemoveObjectsByType(Model.Type.Circle);

                _controller.AddObject(new Model.Object(
                    id,
                    (float)e.X,
                    (float)e.Y,
                    Model.Type.Circle
                    ));

                Draw—ircle(e.Location, Color.Green, Color.Black);
            }
        }

        private void Draw—ircle(Point location, Color Brushcolor, Color penColor)
        {
            using (Graphics g = Graphics.FromImage(pictureBox.Image))
            {
                var brush = new SolidBrush(Brushcolor);
                var pen = new Pen(penColor);

                g.FillEllipse(brush, location.X - _width / 2, location.Y - _height / 2, _width, _height);
                g.DrawEllipse(pen, location.X - _width / 2, location.Y - _height / 2, _width, _height);

                brush.Dispose();
                pen.Dispose();
                pictureBox.Invalidate();
            }
        }

        private void DrawRectangle(Point location, Color Brushcolor, Color penColor)
        {
            using (Graphics g = Graphics.FromImage(pictureBox.Image))
            {
                var brush = new SolidBrush(Brushcolor);
                var pen = new Pen(penColor);

                g.FillRectangle(brush, location.X - _width / 2, location.Y - _height / 2, _width, _height);
                g.DrawRectangle(pen, location.X - _width / 2, location.Y - _height / 2, _width, _height);

                brush.Dispose();
                pen.Dispose();
                pictureBox.Invalidate();
            }
        }

        private void DrawTriangle(Point location, Color Brushcolor, Color penColor)
        {
            using (Graphics g = Graphics.FromImage(pictureBox.Image))
            {
                var brush = new SolidBrush(Brushcolor);
                var pen = new Pen(penColor);

                Point top = new Point(location.X, location.Y - _height / 2);
                Point bottomLeft = new Point(location.X - _width / 2, location.Y + _height / 2);
                Point bottomRight = new Point(location.X + _width / 2, location.Y + _height / 2);

                Point[] trianglePoints =
                {
                    top,
                    bottomLeft,
                    bottomRight
                };


                g.DrawPolygon(pen, trianglePoints);
                g.FillPolygon(brush, trianglePoints);

                brush.Dispose();
                pen.Dispose();
                pictureBox.Invalidate();
            }
        }

        private void RemoveAllRectanglesButton_Click(object sender, EventArgs e)
        {
            var rectangles = _controller.GetObjectsByType(Model.Type.Rectangle);

            foreach (var rectangle in rectangles)
            {
                DrawRectangle(new Point((int)rectangle.X, (int)rectangle.Y), _backgroundColor, _backgroundColor);
            }

            _controller.RemoveObjectsByType(Model.Type.Rectangle);
        }

        private void RemoveAllTrianglesButton_Click(object sender, EventArgs e)
        {
            var triangles = _controller.GetObjectsByType(Model.Type.Triangle);

            foreach (var triangle in triangles)
            {
                DrawTriangle(new Point((int)triangle.X, (int)triangle.Y), _backgroundColor, _backgroundColor);
            }

            _controller.RemoveObjectsByType(Model.Type.Triangle);
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            ClearLines();

            _controller.CalculateDistances();

            Model.Type type = _controller.CalculatecircleType((int)NeighbourCounter.Value);
            var circle = _controller.GetObjectsByType(Model.Type.Circle).First();

            switch (type)
            {
                case Model.Type.Rectangle:
                    Draw—ircle(new Point((int)circle.X, (int)circle.Y), Color.Red, Color.Black);
                    break;
                case Model.Type.Triangle:
                    Draw—ircle(new Point((int)circle.X, (int)circle.Y), Color.Blue, Color.Black);
                    break;
                case Model.Type.Circle:
                    Draw—ircle(new Point((int)circle.X, (int)circle.Y), Color.Green, Color.Black);
                    break;
            }

            DrawLinesToNeighbours();
        }

        private void DrawLine(Point start, Point end, Color color)
        {
            using (Graphics g = Graphics.FromImage(pictureBox.Image))
            {
                var pen = new Pen(color);

                g.DrawLine(pen, start, end);
                
                pen.Dispose();
                pictureBox.Invalidate();
            }
        }

        private void DrawLinesToNeighbours()
        {
            var nearestObjects = _controller.GetNearObjects();
            var circle = _controller.GetObjectsByType(Model.Type.Circle).First();

            var circlePos = new Point((int)circle.X, (int)circle.Y);

            foreach (var obj in nearestObjects)
            {
                var objectPos = new Point((int)obj.X, (int)obj.Y);
                DrawLine(circlePos, objectPos, Color.Black);
            }
        }

        private void ClearLines()
        {
            var nearestObjects = _controller.GetNearObjects();
            var circlesList = _controller.GetObjectsByType(Model.Type.Circle).ToList();
            if (circlesList.Count == 0)
                return;

            var circle = circlesList.First();
            var circlePos = new Point((int)circle.X, (int)circle.Y);

            foreach (var obj in nearestObjects)
            {
                var objectPos = new Point((int)obj.X, (int)obj.Y);
                DrawLine(circlePos, objectPos, _backgroundColor);
            }
            DrawAllObjects();
        }

        private void DrawAllObjects()
        {
            var rectangles = _controller.GetObjectsByType(Model.Type.Rectangle);
            var triangles = _controller.GetObjectsByType(Model.Type.Triangle);
            var circles = _controller.GetObjectsByType(Model.Type.Circle);

            foreach (var triangle in triangles)
            {
                DrawTriangle(new Point((int)triangle.X, (int)triangle.Y), Color.Blue, Color.Black);
            }

            foreach (var rectangle in rectangles)
            {
                DrawRectangle(new Point((int)rectangle.X, (int)rectangle.Y), Color.Red, Color.Black);
            }

            foreach (var circle in circles)
            {
                Draw—ircle(new Point((int)circle.X, (int)circle.Y), Color.Green, Color.Black);
            }
        }
    }
}