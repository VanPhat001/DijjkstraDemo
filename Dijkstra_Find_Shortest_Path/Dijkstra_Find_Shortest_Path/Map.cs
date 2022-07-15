using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dijkstra_Find_Shortest_Path
{
    public class Map
    {
        private Button[,] BanDo = null;
        private RadioButton selectRadio = null;
        private static Map instance = null;
        public static Map Instance
        {
            get
            {
                if (instance == null) instance = new Map();
                return instance;
            }
            set { }
        }

        public RadioButton SelectRadio { get => selectRadio; set => selectRadio = value; }

        private Map() {
            InitMap();
        }

        public void InitMap()
        {
            BanDo = new Button[Constant.Instance.Rows, Constant.Instance.Cols];

            Button btn;
            for (int hang = 0; hang < Constant.Instance.Rows; hang++)
            {
                for (int cot = 0; cot < Constant.Instance.Cols; cot++)
                {
                    btn = new Button()
                    {
                        Text = "",
                        Width = Constant.Instance.BtnWidth,
                        Height = Constant.Instance.BtnHeight,
                        Location = new Point(cot * Constant.Instance.BtnWidth, hang * Constant.Instance.BtnHeight),
                        Tag = Constant.Status.Free,
                        BackColor = Constant.Instance.ConvertColor(Constant.Status.Free)
                    };
                    btn.Click += Btn_Click;

                    BanDo[hang, cot] = btn;
                }
            }
        }

        public void ResetMap()
        {
            /* 
             * Nếu chưa có bản đồ thì khỏi tạo bản đồ
             * Nếu bản đồ đã có, thì chỉ cần thay đổi vài thông số cần thiết
             */
            if (BanDo == null)
            {
                InitMap();
            }
            else
            {
                Button btn;
                for (int hang = 0; hang < Constant.Instance.Rows; hang++)
                {
                    for (int cot = 0; cot < Constant.Instance.Cols; cot++)
                    {
                        //btn = new Button()
                        //{
                        //    Text = "",
                        //    Width = Constant.Instance.BtnWidth,
                        //    Height = Constant.Instance.BtnHeight,
                        //    Location = new Point(cot * Constant.Instance.BtnWidth, hang * Constant.Instance.BtnHeight),
                        //    Tag = Constant.Status.Free,
                        //    BackColor = Constant.Instance.ConvertColor(Constant.Status.Free)
                        //};
                        //btn.Click += Btn_Click;
                        //BanDo[hang, cot] = btn;

                        btn = BanDo[hang, cot];
                        btn.Tag = Constant.Status.Free;
                        btn.BackColor = Constant.Instance.ConvertColor(Constant.Status.Free);
                        //btn.Click += Btn_Click;
                    }
                }
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            /* Chỉ tô màu cho nút khi đã chọn được trạng thái để tô */
            if (selectRadio != null)
            {
                Button btn = sender as Button;
                Constant.Status status = (Constant.Status)selectRadio.Tag;
                Color color = Constant.Instance.ConvertColor(status);

                /* Nếu màu nút khác với màu mong muốn ghi đè thì ghi đè bình thường */
                /* Ngược lại kiểm tra xem có phải ghi đè đặt/hủy bẫy không */
                if (color != btn.BackColor)
                {
                    btn.BackColor = color;
                    btn.Tag = status;
                }
                else if (color == btn.BackColor && status == Constant.Status.Trap)
                {
                    btn.BackColor = Constant.Instance.ConvertColor(Constant.Status.Free);
                    btn.Tag = Constant.Status.Free;
                }
            }
        }

        public void ShowMap(Panel pnlMap)
        {
            if (BanDo == null)
            {
                InitMap();
            }

            for (int i = 0; i < Constant.Instance.Rows; i++)
            {
                for (int j = 0; j < Constant.Instance.Cols; j++)
                {
                    pnlMap.Controls.Add(BanDo[i, j]);
                }
            }
        }

        public bool Solve()
        {
            ClearPath();
            return Dijkstra.Instance.FindShortPath(BanDo);
        }

        public void ClearPath()
        {
            for (int i = 0; i < Constant.Instance.Rows; i++)
            {
                for (int j = 0; j < Constant.Instance.Cols; j++)
                {
                    if ((Constant.Status)BanDo[i, j].Tag == Constant.Status.Mark)
                    {
                        BanDo[i, j].Tag = Constant.Status.Free;
                        BanDo[i, j].BackColor = Constant.Instance.ConvertColor(Constant.Status.Free);
                    }
                }
            }
        }
    }
}
