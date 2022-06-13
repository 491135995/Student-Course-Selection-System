using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 学生选课系统
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            toolStripStatusLabel3.Text = DateTime.Now.ToString("yyyy - MM - dd HH: mm:ss");
            timer1.Start();
            Table();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel3.Text = DateTime.Now.ToString("yyyy - MM - dd HH: mm:ss");
        }

        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();//结束整个程序
        }
        //获取教师发送来的课程信息
        private void Table()
        {
            dataGridView1.Rows.Clear();
            string sql = "select* from 临时表";
            DAO dao = new DAO();
            IDataReader dr = dao.read(sql);
            while (dr.Read())
            {
                string a, b, c, d;
                a = dr["课程号"].ToString();
                b = dr["课程名称"].ToString();
                c = dr["学分"].ToString();
                d = dr["教师姓名"].ToString();
                string[] str = { a, b, c, d };
                dataGridView1.Rows.Add(str);
            }
            dr.Close();//关闭连接
        }
        private void 学生信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form41 form41 = new Form41();
            form41.Show();
            this.Hide();
        }

        private void 教师信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form42 form42 = new Form42();
            form42.Show();
            this.Hide();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            string 课程号 = dataGridView1.SelectedCells[0].Value.ToString();//获取选中的课程号。
            string sql1 = "select* from 课程表 where 课程号='" + 课程号 + "'";
            DAO dao = new DAO();
            IDataReader dc = dao.read(sql1);
            if (!dc.Read())
            {
                DialogResult r = MessageBox.Show("是否发布该课程？", "提示", MessageBoxButtons.OKCancel);
                if (r == DialogResult.OK)
                {
                    string 课程名称, 学分, 任课教师;
                    课程号 = dataGridView1.SelectedCells[0].Value.ToString();
                    课程名称 = dataGridView1.SelectedCells[1].Value.ToString();
                    学分 = dataGridView1.SelectedCells[2].Value.ToString();
                    任课教师 = dataGridView1.SelectedCells[3].Value.ToString();
                    string sql = "Insert into 课程表 values('" + 课程号 + "', '" + 课程名称 + "','" + 学分 + "','" + 任课教师 + "')";
                    int i = dao.Execute(sql);
                    if (i > 0)
                    {
                        MessageBox.Show("发送成功！");
                    }
                    Table();
                }
            }
            else
            {
                MessageBox.Show("不允许重复发送课程!");
            }
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            Form45 form45 = new Form45();
            form45.Show();
            this.Hide();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Form46 form46 = new Form46();
            form46.Show();
            this.Hide();
        }
    }
}
