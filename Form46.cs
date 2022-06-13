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
    public partial class Form46 : Form
    {
        public Form46()
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

        private void Table()
        {
            dataGridView1.Rows.Clear();
            string sql = "select* from 学生选课表";
            DAO dao = new DAO();
            IDataReader dr = dao.read(sql);
            while (dr.Read())
            {
                string 学号 = dr["学号"].ToString();
                string sql1= "select* from 学生信息 where 学号='" + 学号 + "'";
                IDataReader dr1 = dao.read(sql1);
                dr1.Read();
                string f, g;
                f = dr1["学号"].ToString();
                g = dr1["学生姓名"].ToString();
                string 课程号 = dr["课程号"].ToString();
                string sql2 = "select* from 课程表 where 课程号='" + 课程号 + "'";
                IDataReader dr2 = dao.read(sql2);
                dr2.Read();
                string a, b, c, d;
                a = dr2["课程号"].ToString();
                b = dr2["课程名称"].ToString();
                c = dr2["学分"].ToString();
                d = dr2["教师姓名"].ToString();
                string[] str = {f,g, a, b, c, d };
                dataGridView1.Rows.Add(str);
                dr2.Close();
            }
            dr.Close();//关闭连接
        }
        private void 返回ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
            this.Hide();
        }
    }
}
