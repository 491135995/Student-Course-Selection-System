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
    public partial class Form43 : Form
    {
        string[] str = new string[6];
        public Form43()
        {
            InitializeComponent();
            toolStripStatusLabel3.Text = DateTime.Now.ToString("yyyy - MM - dd HH: mm:ss");
            timer1.Start();
            button3.Visible = false;//添加时隐藏修改按钮
            button4.Visible = false;
        }
        public Form43(string[] a)
        {
            InitializeComponent();
            toolStripStatusLabel3.Text = DateTime.Now.ToString("yyyy - MM - dd HH: mm:ss");
            timer1.Start();
            for (int i = 0; i < 6; i++)
            {
                str[i] = a[i];
            }
            textBox1.Text = str[0];
            textBox2.Text = str[1];
            textBox3.Text = str[2];
            textBox4.Text = str[3];
            textBox5.Text = str[4];
            textBox6.Text = str[5];
            button1.Visible = false;//修改时隐藏保存按钮
            button2.Visible = false;
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel3.Text = DateTime.Now.ToString("yyyy - MM - dd HH: mm:ss");
        }

        private void Form43_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();//结束整个程序
        }

        private void 返回ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form41 form41 = new Form41();
            form41.Show();
            this.Hide();
        }
        //添加学生信息
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
            {
                MessageBox.Show("输入错误，请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string sql = "Insert into 学生信息 values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "')";
                DAO dao = new DAO();
                int i = dao.Execute(sql);
                if(i>0)
                {
                    MessageBox.Show("保存成功");
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            textBox5.Text = null;
            textBox6.Text = null;
        }
        //修改学生信息
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
            {
                MessageBox.Show("输入错误，请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if(textBox1.Text!=str[0])
                {
                    string sql = "update 学生信息 set 学号='" + textBox1.Text + "' where 学号='" + str[0] + "' and 学生姓名='" + str[1] + "'";
                    DAO dao = new DAO();
                    dao.Execute(sql);
                    str[0] = textBox1.Text;
                }
                if (textBox2.Text != str[1])
                {
                    string sql = "update 学生信息 set 学生姓名='" + textBox2.Text + "' where 学号='" + str[0] + "' and 学生姓名='" + str[1] + "'";
                    DAO dao = new DAO();
                    dao.Execute(sql);
                    str[1] = textBox2.Text;
                }
                if (textBox3.Text != str[2])
                {
                    string sql = "update 学生信息 set 性别='" + textBox3.Text + "' where 学号='" + str[0] + "' and 学生姓名='" + str[1] + "'";
                    DAO dao = new DAO();
                    dao.Execute(sql);
                    str[2] = textBox3.Text;
                }
                if (textBox4.Text != str[3])
                {
                    string sql = "update 学生信息 set 专业='" + textBox4.Text + "' where 学号='" + str[0] + "' and 学生姓名='" + str[1] + "'";
                    DAO dao = new DAO();
                    dao.Execute(sql);
                    str[3] = textBox4.Text;
                }
                if (textBox5.Text != str[4])
                {
                    string sql = "update 学生信息 set 登陆密码='" + textBox5.Text + "' where 学号='" + str[0] + "' and 学生姓名='" + str[1] + "'";
                    DAO dao = new DAO();
                    dao.Execute(sql);
                    str[4] = textBox5.Text;
                }
                if (textBox6.Text != str[5])
                {
                    string sql = "update 学生信息 set 出生日期='" + textBox6.Text + "' where 学号='" + str[0] + "' and 学生姓名='" + str[1] + "'";
                    DAO dao = new DAO();
                    dao.Execute(sql);
                    str[5] = textBox6.Text;
                }
                MessageBox.Show("修改成功！");
            }
        }
        
        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = str[0];
            textBox2.Text = str[1];
            textBox3.Text = str[2];
            textBox4.Text = str[3];
            textBox5.Text = str[4];
            textBox6.Text = str[5];
        }
    }
}
