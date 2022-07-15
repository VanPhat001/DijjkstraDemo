using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dijkstra_Find_Shortest_Path
{
    public class Dijkstra
    {
        private int[,] Graph = new int[Constant.Instance.Rows, Constant.Instance.Cols];
        private Point StartPoint = new Point(-1, -1);
        private Point EndPoint = new Point(-1, -1);
        private const int oo = 999999999;
        private List<Point> Move = new List<Point>  {
            new Point(-1, -1), new Point(0, -1), new Point(1, -1),
            new Point(-1, 0),                    new Point(1, 0),
            new Point(-1, 1),  new Point(0, 1),  new Point(1, 1),
            };

        private Dijkstra() { }

        private static Dijkstra instance = null;
        public static Dijkstra Instance
        {
            get
            {
                if (instance == null) instance = new Dijkstra();
                return instance;
            }
            set { }
        }

        public bool InitGraph(Button[,] BanDo)
        {
            /* Đặt điểm đầu và cuối = -1 do chưa xác định được vị trí */
            StartPoint.X = EndPoint.X = -1;

            /* Khởi tạo Graph dựa trên BanDo */
            for (int i = 0; i < Constant.Instance.Rows; i++)
            {
                for (int j = 0; j < Constant.Instance.Cols; j++)
                {
                    Graph[i, j] = (int)BanDo[i, j].Tag;
                    if (Graph[i, j] == (int)Constant.Status.Start)
                    {
                        /* Tồn tại nhiều hơn 1 điểm bắt đầu */
                        if (StartPoint.X != -1) return false;
                        StartPoint.Y = i;
                        StartPoint.X = j;
                    }
                    else if (Graph[i, j] == (int)Constant.Status.End)
                    {
                        /* Tồn tại nhiều hơn 1 điểm kết thúc */
                        if (EndPoint.X != -1) return false;
                        EndPoint.Y = i;
                        EndPoint.X = j;
                    }
                }
            }

            return true;
        }

        public bool CheckRange(int X, int Y)
        {
            return 0 <= X && X < Constant.Instance.Cols && 0 <= Y && Y < Constant.Instance.Rows;
        }

        private Point[,] findShortestPath()
        {
            int[,] ChiPhi = new int[Constant.Instance.Rows, Constant.Instance.Cols];
            Point[,] Parent = new Point[Constant.Instance.Rows, Constant.Instance.Cols];

            //Khởi tạo ChiPhi mỗi đỉnh là vô cùng, Parent chưa xác định
            for (int i = 0; i < Constant.Instance.Rows; i++)
            {
                for (int j = 0; j < Constant.Instance.Cols; j++)
                {
                    ChiPhi[i, j] = oo;
                    Parent[i, j] = new Point(-1, -1);
                }
            }

            ChiPhi[StartPoint.Y, StartPoint.X] = 0;
            int FreeStatus = (int)Constant.Status.Free;
            int StartStatus = (int)Constant.Status.Start;
            int EndStatus = (int)Constant.Status.End;

            //Tìm đường đi ngắn nhất
            for (int k = 1; k < Constant.Instance.Rows * Constant.Instance.Cols; k++)
            {
                int UX = -1;
                int UY = -1;
                int MinU = oo;

                /* Chọn đỉnh U có chi phí nhỏ nhất */
                for (int hang = 0; hang < Constant.Instance.Rows; hang++)
                {
                    for (int cot = 0; cot < Constant.Instance.Cols; cot++)
                    {
                        if (Graph[hang, cot] == FreeStatus || Graph[hang, cot] == StartStatus || Graph[hang, cot] == EndStatus)
                        {
                            if (MinU > ChiPhi[hang, cot])
                            {
                                MinU = ChiPhi[hang, cot];
                                UX = cot;
                                UY = hang;
                            }
                        }
                    }
                }

                /* Quá trình tìm đường đi ngắn nhất kế thúc khi không còn đỉnh để duyệt hoặc là đã tìm được đường đi đến EndPoint */
                if (UX == -1 || (UX == EndPoint.X && UY == EndPoint.Y)) break;

                //Đánh dấu u được duyệt
                Graph[UY, UX] = (int)Constant.Status.Mark;

                /* Cập nhật chi phí cho láng giềng của U */
                foreach (var item in Move)
                {
                    int VX = UX + item.X;
                    int VY = UY + item.Y;

                    if (CheckRange(VX, VY) && (Graph[VY, VX] == FreeStatus || Graph[VY, VX] == StartStatus || Graph[VY, VX] == EndStatus))
                    {
                        if (ChiPhi[UY, UX] + 1 < ChiPhi[VY, VX])
                        {
                            ChiPhi[VY, VX] = ChiPhi[UY, UX] + 1;
                            Parent[VY, VX].Y = UY;
                            Parent[VY, VX].X = UX;
                        }
                    }
                }

            }

            return Parent;
        }

        public bool FindShortPath(Button[,] BanDo)
        {
            /* Khởi tạo đồ thị Graph */
            if (!InitGraph(BanDo))
            {
                MessageBox.Show("Bản đồ không hợp lệ!\nYêu cầu xem lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            /* Kiểm tra tính hợp lệ của điểm đầu và cuối */
            if (StartPoint.X == -1 || EndPoint.X == -1)
            {
                MessageBox.Show("Bản đồ không hợp lệ!\nYêu cầu xem lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            /* Tìm đường đi ngắn nhất bằng Dijkstra, trả về danh sách Parent */
            Point[,] Parent = findShortestPath();

            /* Kiểm tra xem có tồn tại đường đi từ StartPoint đến EndPoint */
            if (Parent[EndPoint.Y, EndPoint.X].X == -1)
            {
                MessageBox.Show("Không tồn tại đường đi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            /* Truy vết đường đi */
            Stack<Point> Duyet = new Stack<Point>();
            Duyet.Clear();
            Point Current = EndPoint;

            while (true)
            {
                Current = Parent[Current.Y, Current.X];
                if (Current == StartPoint) break;
                Duyet.Push(Current);
            }

            /* Show đường đi */
            while (Duyet.Count > 0)
            {
                Current = Duyet.Pop();

                BanDo[Current.Y, Current.X].Tag = Constant.Status.Mark;
                BanDo[Current.Y, Current.X].BackColor = Constant.Instance.ConvertColor(Constant.Status.Mark);
            }

            return true;
        }
    }
}
