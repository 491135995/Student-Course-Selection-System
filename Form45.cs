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
    public partial class Form45 : Form
    {
        public Form45()
        {
            InitializeComponent();
            toolStripStatusLabel3.Text = DateTime.Now.ToString("yyyy - MM - dd HH: mm:ss");
            timer1.Start();
            Table();
        }

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
        private void 返回ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
            this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel3.Text = DateTime.Now.ToString("yyyy - MM - dd HH: mm:ss");
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("是否取消该课程？", "提示", MessageBoxButtons.OKCancel);
            if (r == DialogResult.OK)
            {
                string id, name;
                id = dataGridView1.SelectedCells[0].Value.ToString();
                name = dataGridView1.SelectedCells[3].Value.ToString();
                string sql = "delete from 课程表 where 课程号='" + id + "'and 教师姓名='" + name + "'";
                DAO dao = new DAO();
                dao.Execute(sql);
                Table();
            }
        }
    }
}
