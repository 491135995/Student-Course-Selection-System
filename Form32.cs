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
    public partial class Form32 : Form
    {
        string 职工号;
        string a, b, c, d, f;
        public Form32(string TNO)
        {
            职工号 = TNO;
            InitializeComponent();
            toolStripStatusLabel3.Text = DateTime.Now.ToString("yyyy - MM - dd HH: mm:ss");
            timer1.Start();
            //根据登录账号读取教师信息。
            string sql = "select* from 教师信息 where 职工号='"+职工号+"'";
            DAO dao = new DAO();
            IDataReader dr = dao.read(sql);
            dr.Read();
            a = dr["职工号"].ToString();
            b = dr["教师姓名"].ToString();
            c = dr["性别"].ToString();
            d = dr["登陆密码"].ToString();
            f = dr["出生日期"].ToString();
            textBox1.Text = b;
            textBox2.Text = c;
            textBox3.Text = a;
            textBox4.Text = f;
            textBox5.Text = d;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = b;
            textBox2.Text = c;
            textBox3.Text = a;
            textBox4.Text = f;
            textBox5.Text = d;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel3.Text = DateTime.Now.ToString("yyyy - MM - dd HH: mm:ss");
        }

        private void Form32_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();//结束整个程序
        }

        private void 返回ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3(职工号);
            form3.Show();
            this.Hide();
        }
        //修改教师信息
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" )
            {
                MessageBox.Show("输入错误，请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (textBox1.Text != b)
                {
                    string sql = "update 教师信息 set 教师姓名='" + textBox1.Text + "' where 职工号='" + a + "' and 教师姓名='" + b + "'";
                    DAO dao = new DAO();
                    dao.Execute(sql);
                    b = textBox1.Text;
                }
                if (textBox2.Text != c)
                {
                    string sql = "update 教师信息 set 性别='" + textBox2.Text + "' where 职工号='" + a + "' and 教师姓名='" + b + "'";
                    DAO dao = new DAO();
                    dao.Execute(sql);
                    c = textBox2.Text;
                }
                if (textBox3.Text != a)
                {
                    string sql = "update 教师信息 set 职工号='" + textBox3.Text + "' where 职工号='" + a + "' and 教师姓名='" + b + "'";
                    DAO dao = new DAO();
                    dao.Execute(sql);
                    a = textBox3.Text;
                }
                if (textBox5.Text != d)
                {
                    string sql = "update 教师信息 set 登陆密码='" + textBox5.Text + "' where 职工号='" + a + "' and 教师姓名='" + b + "'";
                    DAO dao = new DAO();
                    dao.Execute(sql);
                    d = textBox5.Text;
                }
                if (textBox4.Text != f)
                {
                    string sql = "update 教师信息 set 出生日期='" + textBox4.Text + "' where 职工号='" + a + "' and 教师姓名='" + b + "'";
                    DAO dao = new DAO();
                    dao.Execute(sql);
                    f = textBox4.Text;
                }
                MessageBox.Show("修改成功！");
            }
        }
    }
}
