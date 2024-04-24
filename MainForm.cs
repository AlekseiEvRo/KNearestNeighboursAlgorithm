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
                var cricles = _controller.GetObjectsByType(Model.Type.Cricle);
                if (cricles.Count != 0)
                {
                    var cricle = cricles.First();
                    Draw—ircle(new Point((int)cricle.X, (int)cricle.Y), _backgroundColor, _backgroundColor);
                }

                _controller.RemoveObjectsByType(Model.Type.Cricle);

                _controller.AddObject(new Model.Object(
                    id,
                    (float)e.X,
                    (float)e.Y,
                    Model.Type.Cricle
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
            _controller.CalculateDistances();

            Model.Type type = _controller.CalculateCricleType((int)NeighbourCounter.Value);
            var cricle = _controller.GetObjectsByType(Model.Type.Cricle).First();
            switch (type)
            {
                case Model.Type.Rectangle:
                    Draw—ircle(new Point((int)cricle.X, (int)cricle.Y), Color.Red, Color.Black);
                    break;
                case Model.Type.Triangle:
                    Draw—ircle(new Point((int)cricle.X, (int)cricle.Y), Color.Blue, Color.Black);
                    break;
                case Model.Type.Cricle:
                    Draw—ircle(new Point((int)cricle.X, (int)cricle.Y), Color.Green, Color.Black);
                    break;
            }
        }
    }
}