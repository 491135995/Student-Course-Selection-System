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
    public partial class Form22 : Form
    {
        string 学号;
        public Form22(string SNO)
        {
            学号 = SNO;
            InitializeComponent();
            toolStripStatusLabel3.Text = DateTime.Now.ToString("yyyy - MM - dd HH: mm:ss");
            timer1.Start();
            Table();
        }
        //查询已选课程
        private void Table()
        {
            dataGridView1.Rows.Clear();
            string sql = "select* from 学生选课表 where 学号='"+学号+"'";
            DAO dao = new DAO();
            IDataReader dr = dao.read(sql);
            while (dr.Read())
            {
                string 课程号 = dr["课程号"].ToString();
                string sql2= "select* from 课程表 where 课程号='" + 课程号 + "'";
                IDataReader dr2 = dao.read(sql2);
                dr2.Read();
                string a, b, c, d;
                a = dr2["课程号"].ToString();
                b = dr2["课程名称"].ToString();
                c = dr2["学分"].ToString();
                d = dr2["教师姓名"].ToString();
                string[] str = { a, b, c, d };
                dataGridView1.Rows.Add(str);
                dr2.Close();
            }
            dr.Close();//关闭连接
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel3.Text = DateTime.Now.ToString("yyyy - MM - dd HH: mm:ss");
        }

        private void Form22_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();//结束整个程序
        }

        private void 退出ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(学号);
            form2.Show();
            this.Hide();
        }
        //退选课程
        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            string 课程号 = dataGridView1.SelectedCells[0].Value.ToString();
            string sql = "delete from 学生选课表 where 学号='" + 学号 + "' and 课程号='" + 课程号 + "'";
            DAO dao = new DAO();
            int i=dao.Execute(sql);
            if(i>0)
            {
                MessageBox.Show("退选成功！");
            }
            Table();
        }
    }
}
