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
    public partial class Form44 : Form
    {
        string[] str = new string[5];
        public Form44()
        {
            InitializeComponent();
            toolStripStatusLabel3.Text = DateTime.Now.ToString("yyyy - MM - dd HH: mm:ss");
            timer1.Start();
            button3.Visible = false;//添加时隐藏修改按钮
            button4.Visible = false;
        }
        public Form44(string[] a)
        {
            InitializeComponent();
            toolStripStatusLabel3.Text = DateTime.Now.ToString("yyyy - MM - dd HH: mm:ss");
            timer1.Start();
            for (int i = 0; i < 5; i++)
            {
                str[i] = a[i];
            }
            textBox1.Text = str[0];
            textBox2.Text = str[1];
            textBox3.Text = str[2];
            textBox4.Text = str[3];
            textBox5.Text = str[4];
            button1.Visible = false;//修改时隐藏保存按钮
            button2.Visible = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel3.Text = DateTime.Now.ToString("yyyy - MM - dd HH: mm:ss");
        }
        //添加教师信息
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("输入错误，请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string sql = "Insert into 教师信息 values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')";
                DAO dao = new DAO();
                int i = dao.Execute(sql);
                if (i > 0)
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
        }

        private void 返回ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form42 form42 = new Form42();
            form42.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        //修改教师信息
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" )
            {
                MessageBox.Show("输入错误，请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (textBox1.Text != str[0])
                {
                    string sql = "update 教师信息 set 职工号='" + textBox1.Text + "' where 职工号='" + str[0] + "' and 教师姓名='" + str[1] + "'";
                    DAO dao = new DAO();
                    dao.Execute(sql);
                    str[0] = textBox1.Text;
                }
                if (textBox2.Text != str[1])
                {
                    string sql = "update 教师信息 set 教师姓名='" + textBox2.Text + "' where 职工号='" + str[0] + "' and 教师姓名='" + str[1] + "'";
                    DAO dao = new DAO();
                    dao.Execute(sql);
                    str[1] = textBox2.Text;
                }
                if (textBox3.Text != str[2])
                {
                    string sql = "update 教师信息 set 性别='" + textBox3.Text + "' where 职工号='" + str[0] + "' and 教师姓名='" + str[1] + "'";
                    DAO dao = new DAO();
                    dao.Execute(sql);
                    str[2] = textBox3.Text;
                }
                if (textBox4.Text != str[3])
                {
                    string sql = "update 教师信息 set 登陆密码='" + textBox4.Text + "' where 职工号='" + str[0] + "' and 教师姓名='" + str[1] + "'";
                    DAO dao = new DAO();
                    dao.Execute(sql);
                    str[3] = textBox4.Text;
                }
                if (textBox5.Text != str[4])
                {
                    string sql = "update 教师信息 set 出生日期='" + textBox5.Text + "' where 职工号='" + str[0] + "' and 教师姓名='" + str[1] + "'";
                    DAO dao = new DAO();
                    dao.Execute(sql);
                    str[4] = textBox5.Text;
                }
             
            }
                MessageBox.Show("修改成功！");
            }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = str[0];
            textBox2.Text = str[1];
            textBox3.Text = str[2];
            textBox4.Text = str[3];
            textBox5.Text = str[4];
        }
    }
}
