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
    public partial class Form42 : Form
    {
        public Form42()
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

        private void Form42_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();//结束整个程序
        }

        private void 返回ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
            this.Hide();
        }

        private void Form42_Load(object sender, EventArgs e)
        {

        }
        private void Table()
        {
            dataGridView1.Rows.Clear();
            string sql = "select* from 教师信息";
            DAO dao = new DAO();
            IDataReader dr = dao.read(sql);
            while (dr.Read())
            {
                string a, b, c, e, f;
                a = dr["职工号"].ToString();
                b = dr["教师姓名"].ToString();
                c = dr["性别"].ToString();
                e = dr["登陆密码"].ToString();
                f = dr["出生日期"].ToString();
                string[] str = { a, b, c, e, f };
                dataGridView1.Rows.Add(str);
            }
            dr.Close();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Form44 form44 = new Form44();
            form44.Show();
            this.Hide();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("是否删除该教师信息？", "提示", MessageBoxButtons.OKCancel);
            if (r == DialogResult.OK)
            {
                string id, name;
                id = dataGridView1.SelectedCells[0].Value.ToString();
                name = dataGridView1.SelectedCells[1].Value.ToString();
                string sql = "delete from 教师信息 where 职工号='" + id + "'and 教师姓名='" + name + "'";
                DAO dao = new DAO();
                dao.Execute(sql);
                Table();
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Table();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            string[] str = { dataGridView1.SelectedCells[0].Value.ToString(), dataGridView1.SelectedCells[1].Value.ToString(), dataGridView1.SelectedCells[2].Value.ToString(), dataGridView1.SelectedCells[3].Value.ToString(), dataGridView1.SelectedCells[4].Value.ToString() };
            Form44 form44 = new Form44(str);
            form44.Show();
            this.Hide();
        }
    }
}