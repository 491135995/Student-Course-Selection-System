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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (pictureBox1.Location.X < 150)
            {
                pictureBox1.Location = new Point(pictureBox1.Location.X + 1, pictureBox1.Location.Y);
            }
                else
            {
                timer1.Stop();
                if (comboBox1.Text == "学生")
                {
                    string sql = "select* from 学生信息 where 学号='" + textBox1.Text + "' and 登陆密码='" + textBox2.Text + "'";
                    DAO dao = new DAO();
                    IDataReader dr = dao.read(sql);
                    dr.Read();
                    string SNO = dr["学号"].ToString();
                    Form2 form2 = new Form2(SNO);
                    form2.Show();
                    this.Hide();
                }
                else
                {
                    if (comboBox1.Text == "老师")
                    {
                        string sql = "select* from 教师信息 where 职工号='" + textBox1.Text + "' and 登陆密码='" + textBox2.Text + "'";
                        DAO dao = new DAO();
                        IDataReader dr = dao.read(sql);
                        dr.Read();
                        string TNO = dr["职工号"].ToString();
                        Form3 form3 = new Form3(TNO);
                        form3.Show();
                        this.Hide();
                    }
                    else
                    {
                        if (comboBox1.Text == "管理员")
                        {
                            Form4 form4 = new Form4();
                            form4.Show();
                            this.Hide();
                        }
                    }
                }
            }
        }
        //登录事件

        private void button1_Click(object sender, EventArgs e)
        {
            if(login())
            {
                timer1.Start();
                textBox1.Visible = false;
                textBox2.Visible = false;
                comboBox1.Visible = false;
                button1.Visible = false;
                button2.Visible = false;
                label1.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
               
                    }
        }
        private bool login()
        {
            if(textBox1.Text==""||textBox2.Text==""||comboBox1.Text=="")
            {
                MessageBox.Show("输入错误，请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if(comboBox1.Text=="学生")
            {
                string sql = "select* from 学生信息 where 学号='" + textBox1.Text + "' and 登陆密码='" + textBox2.Text + "'";
                DAO dao = new DAO();
                IDataReader dr = dao.read(sql);
                if(dr.Read())
                {
                    MessageBox.Show("登录成功！", "提示", MessageBoxButtons.OK);
                    return true;
                }
                else
                {
                    MessageBox.Show("输入错误，请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            if(comboBox1.Text=="老师")
            {
                string sql = "select* from 教师信息 where 职工号='" + textBox1.Text + "' and 登陆密码='" + textBox2.Text + "'";
                DAO dao = new DAO();
                IDataReader dr = dao.read(sql);
                if (dr.Read())
                    {
                    MessageBox.Show("登录成功！", "提示", MessageBoxButtons.OK);
                    return true;
                    }
                    else
                    {
                    MessageBox.Show("输入错误，请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                    }
            }
            if(comboBox1.Text=="管理员")
            {
                string sql = "select* from 管理员 where 账号='" + textBox1.Text + "' and 密码='" +textBox2.Text+ "'";
                DAO dao = new DAO();
                IDataReader dr = dao.read(sql);
                if (dr.Read())
                    {
                    MessageBox.Show("登录成功！", "提示", MessageBoxButtons.OK);
                    return true;
                    }
                    else
                    {
                    MessageBox.Show("输入错误，请重新输入！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                    }

            }
            return false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
            textBox2.Text = null;
            comboBox1.Text = null;
        }
    }
}
