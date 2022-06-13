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
    public partial class Form2 : Form
    {
        string 学号;
        public Form2(string SNO)
        {
            学号 = SNO;
            InitializeComponent();
            toolStripStatusLabel3.Text = DateTime.Now.ToString("yyyy - MM - dd HH: mm:ss");
            timer1.Start();
            Table();
        }
        //获取选课表。
        private void Table()
        {
            dataGridView1.Rows.Clear();
            string sql = "select* from 课程表";
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
        private void toolStripContainer1_TopToolStripPanel_Click(object sender, EventArgs e)
        {

        }

        private void 修改学生信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form21 form21 = new Form21(学号);
            form21.Show();
            this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel3.Text = DateTime.Now.ToString("yyyy - MM - dd HH: mm:ss");
        }

        private void 选修课程ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();//结束整个程序
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void 已选课程ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form22 form22 = new Form22(学号);
            form22.Show();
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
            string 课程号=dataGridView1.SelectedCells[0].Value.ToString();//获取选中的课程号。
            string sql1 = "select* from 学生选课表 where 学号='" + 学号 + "' and 课程号='" + 课程号 + "'";
            DAO dao = new DAO();
            IDataReader dc = dao.read(sql1);
            if(!dc.Read())
            {
                string sql = "insert into 学生选课表 values('" + 学号 + "','" + 课程号 + "')";
                int i = dao.Execute(sql);
                if (i > 0)
                {
                    MessageBox.Show("选课成功！");
                }
            }
            else 
            {
                MessageBox.Show("不允许重复选课！");
            }
            
        }
    }
}
