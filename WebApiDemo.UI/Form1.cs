using WebApiDemo.Entities;
using WebApiDemo.UI.Repositories;
using System.Linq;

namespace WebApiDemo.UI
{
    public partial class Form1 : Form
    {

        WebApiDemoRepo repo = new WebApiDemoRepo();
        Product product = new Product();
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var list = await repo.Getlist();
            dataGridView1.DataSource = list;
        }


        private void btnEkle_Click(object sender, EventArgs e)
        {
            product.ProductName = txtProduct.Text;
            product.CategoryID = Convert.ToInt32(txtCategory.Text);
            product.UnitPrice = Convert.ToDecimal(txtUnitPrice.Text);
            product.UnitsInStock = Convert.ToInt16(txtUnitInStock.Text);
            repo.Add(product);

            MessageBox.Show("The product Added");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtProduct.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtCategory.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtUnitPrice.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtUnitInStock.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);


            product.ProductName = txtProduct.Text != default ? txtProduct.Text : product.ProductName;
            product.CategoryID = Convert.ToInt32(txtCategory.Text != default ? txtCategory.Text : product.CategoryID);
            product.UnitPrice = Convert.ToDecimal(txtUnitPrice.Text!=default ? txtUnitPrice.Text : product.UnitPrice);
            product.UnitsInStock = Convert.ToInt16(txtUnitInStock.Text!=default ? txtUnitInStock.Text : product.UnitsInStock);

            repo.Update(product, id);

            MessageBox.Show($"{id} ID product updated");
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int productId =Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            repo.Delete(productId);

            MessageBox.Show($"{productId} ID product deleted");
        }

       


        private async void txtBul_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if(!string.IsNullOrEmpty(txtBul.Text))
                {
                    int id = Convert.ToInt32(txtBul.Text);
                    var result = await repo.Get(id);
                    dataGridView1.DataSource = result;
                }
                else
                {
                    var list = await repo.Getlist();
                    dataGridView1.DataSource = list;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}