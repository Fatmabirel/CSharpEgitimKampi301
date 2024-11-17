using System;
using System.Linq;
using System.Windows.Forms;

namespace CSharpEgitimKampi301.EFProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        DbEgitimKampıEfTravelEntities db = new DbEgitimKampıEfTravelEntities();
        private void btnList_Click(object sender, EventArgs e)
        {
            var values = db.Guides.ToList();
            dataGridView1.DataSource = values;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Guides guides = new Guides();
            guides.Name = txtName.Text;
            guides.Surname = txtSurname.Text;
            db.Guides.Add(guides);
            db.SaveChanges();
            MessageBox.Show("Rehber başarıyla eklendi");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var deletedValue = db.Guides.Find(id);
            db.Guides.Remove(deletedValue);
            db.SaveChanges();
            MessageBox.Show("Rehber başarıyla silindi");

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var updatedValue = db.Guides.Find(id);
            updatedValue.Name = txtName.Text;
            updatedValue.Surname = txtSurname.Text;
            db.SaveChanges();
            MessageBox.Show("Rehber başarıyla güncellendi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnGetById_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var values = db.Guides.Where(g => g.Id == id).ToList();
            dataGridView1.DataSource = values;
        }
    }
}
