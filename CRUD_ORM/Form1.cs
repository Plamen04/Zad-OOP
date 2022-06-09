using CRUD_ORM.Business;
using CRUD_ORM.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD_ORM
{
    public partial class ProductForm : Form
    {
        private ProductBusiness productBusiness = new ProductBusiness();
        public ProductForm()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            Product product = new Product();
            product.Name = txtName.Text;
            product.Price = decimal.Parse(txtPrice.Text);
            product.Stock = int.Parse(txtStock.Text);
            productBusiness.Add(product);
            dataGridView1.Update();
            dataGridView1.Refresh();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtID.Text);
            Product product = productBusiness.Get(id);
            if (product != null)
            {
                product.Name = txtName.Text;
                product.Price = decimal.Parse(txtPrice.Text);
                product.Stock = int.Parse(txtStock.Text);
                productBusiness.Update(product);
            }
            else MessageBox.Show("Product not found!");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtID.Text);
            productBusiness.Delete(id);
        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            var products = productBusiness.GetAll();
            dataGridView1.DataSource = products;
        }
    }
}


