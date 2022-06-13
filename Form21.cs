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
    public partial class Form21 : Form
    {
        string 学号;
        string a, b, c, d, g, f;
        public Form21(string SNO)
        {
            学号 = SNO;
            InitializeComponent();
            toolStripStatusLabel2.Text = DateTime.Now.ToString("yyyy - MM - dd HH: mm:ss");
            timer1.Start();
            //根据登录账号读取学生信息。
            string sql = "select* from 学生信息 where 学号='"+学号+"'";
            DAO dao = new DAO();
            IDataReader dr = dao.read(sql);
            dr.Read();
            a = dr["学号"].ToString();
            b = dr["学生姓名"].ToString();
            c = dr["性别"].ToString();
            d = dr["专业"].ToString();
            g = dr["登陆密码"].ToString();
            f = dr["出生日期"].ToString();
            textBox1.Text = b;
            textBox2.Text = c;
            textBox3.Text = a;
            textBox4.Text = d;
            textBox5.Text = f;
            textBox6.Text = g;
        }

            private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = b;
            textBox2.Text = c;
            textBox3.Text = a;
            textBox4.Text = d;
            textBox5.Text = f;
            textBox6.Text = g;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel2.Text = DateTime.Now.ToString("yyyy - MM - dd HH: mm:ss");
        }

        private void Form21_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();//结束整个程序
        }

        private void 返回ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(学号);
            form2.Show();
            this.Hide();
        }
        //修改个人信息
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
            {
                MessageBox.Show("输入错误，请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (textBox1.Text != b)
                {
                    string sql = "update 学生信息 set 学生姓名='" + textBox1.Text + "' where 学号='" + a + "' and 学生姓名='" + b + "'";
                    DAO dao = new DAO();
                    dao.Execute(sql);
                    b = textBox1.Text;
                }
                if (textBox2.Text != c)
                {
                    string sql = "update 学生信息 set 性别='" + textBox2.Text + "' where 学号='" + a + "' and 学生姓名='" + b + "'";
                    DAO dao = new DAO();
                    dao.Execute(sql);
                    c = textBox2.Text;
                }
                if (textBox3.Text != a)
                {
                    string sql = "update 学生信息 set 学号='" + textBox3.Text + "' where 学号='" + a + "' and 学生姓名='" + b + "'";
                    DAO dao = new DAO();
                    dao.Execute(sql);
                    a = textBox3.Text;
                }
                if (textBox4.Text != d)
                {
                    string sql = "update 学生信息 set 专业='" + textBox4.Text + "' where 学号='" + a + "' and 学生姓名='" + b + "'";
                    DAO dao = new DAO();
                    dao.Execute(sql);
                    d = textBox4.Text;
                }
                if (textBox6.Text != g)
                {
                    string sql = "update 学生信息 set 登陆密码='" + textBox6.Text + "' where 学号='" + a + "' and 学生姓名='" + b + "'";
                    DAO dao = new DAO();
                    dao.Execute(sql);
                    g = textBox6.Text;
                }
                if (textBox5.Text != f)
                {
                    string sql = "update 学生信息 set 出生日期='" + textBox5.Text + "' where 学号='" + a + "' and 学生姓名='" + b + "'";
                    DAO dao = new DAO();
                    dao.Execute(sql);
                    f = textBox5.Text;
                }
                MessageBox.Show("修改成功！");
            }
        }
    }
}
