using System;
using System.Data;
using System.Windows.Forms;

namespace 学生选课系统
{
    public partial class Form41 : Form
    {
        public Form41()
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

        private void Form41_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();//结束整个程序
        }

        private void Form41_Load(object sender, EventArgs e)
        {
        }
        private void Table()
        {
            dataGridView1.Rows.Clear();
            string sql = "select* from 学生信息";
            DAO dao = new DAO();
            IDataReader dr = dao.read(sql);
            while (dr.Read())
            {
                string a, b, c, d, e, f;
                a = dr["学号"].ToString();
                b = dr["学生姓名"].ToString();
                c = dr["性别"].ToString();
                d = dr["专业"].ToString();
                e = dr["登陆密码"].ToString();
                f = dr["出生日期"].ToString();
                string[] str = { a, b, c, d, e, f };
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

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Form43 form43 = new Form43();
            form43.Show();
            this.Hide();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("是否删除该学生信息？", "提示", MessageBoxButtons.OKCancel);
            if(r==DialogResult.OK)
            {
                string id, name;
                id = dataGridView1.SelectedCells[0].Value.ToString();//获取选中学生学号
                name = dataGridView1.SelectedCells[1].Value.ToString();//获取选中学生姓名
                string sql = "delete from 学生信息 where 学号='" + id + "'and 学生姓名='" + name + "'";
                DAO dao = new DAO();
                dao.Execute(sql);
                Table();
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Table();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            string[] str = { dataGridView1.SelectedCells[0].Value.ToString(), dataGridView1.SelectedCells[1].Value.ToString(), dataGridView1.SelectedCells[2].Value.ToString(), dataGridView1.SelectedCells[3].Value.ToString(), dataGridView1.SelectedCells[4].Value.ToString(), dataGridView1.SelectedCells[5].Value.ToString() };
            Form43 form43 = new Form43(str);
            form43.Show();
            this.Hide();
        }
    }
}
