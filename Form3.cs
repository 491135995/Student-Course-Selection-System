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
    public partial class Form3 : Form
    {
        string 职工号;
        public Form3(string TNO)
        {
            职工号 = TNO;
            InitializeComponent();
            toolStripStatusLabel3.Text = DateTime.Now.ToString("yyyy - MM - dd HH: mm:ss");
            timer1.Start();
            Table();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel3.Text = DateTime.Now.ToString("yyyy - MM - dd HH: mm:ss");
        }

        private void toolStripStatusLabel3_Click(object sender, EventArgs e)
        {

        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();//结束整个程序
        }

        private void 修改信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form32 form32 = new Form32(职工号);
            form32.Show();
            this.Hide();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
        //从临时表中查询登陆教师已发送的课程。
        private void Table()
        {
            dataGridView1.Rows.Clear();
            string 教师姓名;
            string sql1 = "select * from 教师信息 where 职工号='" + 职工号 + "'";
            DAO dao = new DAO();
            IDataReader dr = dao.read(sql1);
            dr.Read();
            教师姓名 = dr["教师姓名"].ToString();
            dr.Close();
            string sql = "select* from 临时表 where 教师姓名='"+教师姓名+"'";
            IDataReader dr2 = dao.read(sql);
            while (dr2.Read())
            {
                string a, b, c, d;
                a = dr2["课程号"].ToString();
                b = dr2["课程名称"].ToString();
                c = dr2["学分"].ToString();
                d = dr2["教师姓名"].ToString();
                string[] str = { a, b, c, d };
                dataGridView1.Rows.Add(str);
            }
            dr2.Close();//关闭连接
        }
        //发布课程，即将自己的课程添加至临时表，由管理员审核通过
        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            string 课程号 = dataGridView1.SelectedCells[0].Value.ToString();//获取选中的课程号。
            string sql1 = "select* from 临时表 where 课程号='" + 课程号 + "'";
            DAO dao = new DAO();
            IDataReader dc = dao.read(sql1);
            if (!dc.Read())
            {
                DialogResult r = MessageBox.Show("是否发送该课程？", "提示", MessageBoxButtons.OKCancel);
                if (r == DialogResult.OK)
                {
                    string  课程名称, 学分, 任课教师;
                    课程号 = dataGridView1.SelectedCells[0].Value.ToString();
                    课程名称 = dataGridView1.SelectedCells[1].Value.ToString();
                    学分 = dataGridView1.SelectedCells[2].Value.ToString();
                    任课教师 = dataGridView1.SelectedCells[3].Value.ToString();
                    string sql = "Insert into 临时表 values('" + 课程号 + "', '" + 课程名称 + "','" + 学分 + "','" + 任课教师 + "')";
                    int i=dao.Execute(sql);
                    if(i>0)
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

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Table();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("是否删除该课程？", "提示", MessageBoxButtons.OKCancel);
            if (r == DialogResult.OK)
            {
                string id, name;
                id = dataGridView1.SelectedCells[0].Value.ToString();
                name = dataGridView1.SelectedCells[3].Value.ToString();
                string sql = "delete from 临时表 where 课程号='" + id + "'and 教师姓名='" + name + "'";
                DAO dao = new DAO();
                dao.Execute(sql);
                Table();
            }
        }
    }
}
