using Db4objects.Db4o;
using MidTerm2016;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4201104085_DB4O
{
    public partial class Form1 : Form
    {
        public static string DbFileName { get; set; }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DbFileName = "4201104085_EmployeeManager.yap";
        }
        public static List<T> GetList<T>()
        {
            List<T> results = new List<T>();

            Employee template = new Employee(0, null, null, null, null, 0);
            IObjectContainer db = Db4oEmbedded.OpenFile(DbFileName);
            IObjectSet resultList = db.QueryByExample(template);
            foreach (T obj in resultList)
            {
                results.Add(obj);
            }
            db.Close();
            return results;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            IObjectContainer db = Db4oEmbedded.OpenFile(DbFileName);
            Company comp = new Company(txtCompanyName.Text, txtHouseNumber.Text, txtStreet.Text, txtCity.Text);
            Employee emp = new Employee(int.Parse(txtID.Text), txtFullName.Text, txtSkill.Text, comp,null, double.Parse(txtSalary.Text));
            db.Store(comp);
            db.Store(emp);
            db.Close();
            loadDSNV();
        }

        public void loadDSNV()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = GetList<Employee>();
        }


        private void btnDSNhanVien_Click(object sender, EventArgs e)
        {
            loadDSNV();
        }
    }
}
