using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace eftaskk
{
    public partial class Form1 : Form
    {
        private MarketDbContext context;
        private BindingSource bindingSource;

        public Form1()
        {
            InitializeComponent();
            context = new MarketDbContext();
            bindingSource = new BindingSource();
            dataGridView1.AutoGenerateColumns = false; // Manually define columns
            dataGridView1.DataSource = bindingSource;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Form yüklendi?inde tüm ürünleri göster
            LoadProducts();
        }

        private void LoadProducts()
        {
            try
            {
                // Tüm ürünleri veritaban?ndan al
                var products = context.Product.ToList();

                // Veri ba?lamay? güncelle
                bindingSource.DataSource = products;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ürünler yüklenirken hata olu?tu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Tüm ürünleri veritaban?ndan al
                var products = context.Product.ToList();

                // Veri ba?lamay? güncelle
                bindingSource.DataSource = products;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ürünler yüklenirken hata olu?tu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
