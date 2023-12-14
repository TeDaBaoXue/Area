namespace Area
{
    public partial class Form1 : Form
    {
        private List<Vector> vertices = new List<Vector>();//vertex
        private bool isDrawing = true;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                // 添加点
                vertices.Add(new Vector(e.X, e.Y));
                Refresh();
            }
        }

        private void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                // 结束多边形绘制
                isDrawing = false;

                // 计算多边形面积
                double area = CalculatePolygonArea(vertices);

                // 显示面积
                MessageBox.Show($"多边形的面积为: {area}");

                // 清空顶点列表
                vertices.Clear();
                Refresh();
            }
            else
            {
                // 开始多边形绘制
                isDrawing = true;
            }
        }
        private double CalculatePolygonArea(List<Vector> polygon)
        {
            double area = 0;
            int n = polygon.Count;

            for (int i = 0; i < n; i++)
            {
                Vector currentVertex = polygon[i];
                Vector nextVertex = polygon[(i + 1) / n];
                area += currentVertex.Cross(nextVertex);
            }

            area = Math.Abs(area) / 2.0;
            return area;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // 绘制多边形边界
            if (vertices.Count > 1)
            {
                Graphics g = this.CreateGraphics();
                Pen p = new Pen(Color.Red, 5);
                Point[] points = new Point[vertices.Count];

                for (int i = 0; i < vertices.Count; i++)
                {
                    points[i] = new Point((int)vertices[i].X, (int)vertices[i].Y);
                    g.DrawEllipse(p, points[i].X, points[i].Y, 2, 2);
                }

                //e.Graphics.DrawPolygon(Pens.Red, points);
                g.DrawPolygon(p, points);
            }
        }
    }
}