using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StockTracking.BLL;
using StockTracking.DAL.DTO;

namespace StockTracking
{
    public partial class FrmSalesList : Form
    {
        public FrmSalesList()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = General.isNumber(e);
        }

        private void txtSalesAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = General.isNumber(e);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmSales frm = new FrmSales();
            frm.dto = dto;
            //Hide the current page
            this.Hide();
            //Show the other page
            frm.ShowDialog();
            this.Visible = true;

            dto = bll.Select();
            dataGridView1.DataSource = dto.Sales;
            CleanFilters();
        }
        SalesBLL bll = new SalesBLL();
        SalesDTO dto = new SalesDTO();
        private void FrmSalesList_Load(object sender, EventArgs e)
        {
            dto = bll.Select();
            dataGridView1.DataSource = dto.Sales;
            dataGridView1.Columns[0].HeaderText = "Customer Name";
            dataGridView1.Columns[1].HeaderText = "Product Name";
            dataGridView1.Columns[2].HeaderText = "Category Name";
            dataGridView1.Columns[6].HeaderText = "Sales Amount";
            dataGridView1.Columns[7].HeaderText = "Price";
            dataGridView1.Columns[8].HeaderText = "Sales Date";
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[9].Visible = false;
            dataGridView1.Columns[10].Visible = false;


            cmbCategory.DataSource = dto.Categories;
            cmbCategory.DisplayMember = "CategoryName";
            cmbCategory.ValueMember = "ID";
            cmbCategory.SelectedIndex = -1;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<SalesDetailDTO> list = dto.Sales;
            if(txtProductName.Text.Trim()!="")
                list = list.Where(x => x.ProductName.Contains(txtProductName.Text)).ToList();
            if (txtCustomerName.Text.Trim() != "")
                list = list.Where(x => x.CustomerName.Contains(txtCustomerName.Text)).ToList();
            if (cmbCategory.SelectedIndex!=-1)
                list = list.Where(x => x.CategoryID==Convert.ToInt32(cmbCategory.SelectedValue)).ToList();
            if (txtPrice.Text.Trim() != "")
            {
                if (rbPriceEquals.Checked)
                    list = list.Where(x => x.Price == Convert.ToInt32(txtPrice.Text)).ToList();
                else if (rbPriceMore.Checked)
                    list = list.Where(x => x.Price > Convert.ToInt32(txtPrice.Text)).ToList();
                else if (rbPriceLess.Checked)
                    list = list.Where(x => x.Price < Convert.ToInt32(txtPrice.Text)).ToList();
                else
                    MessageBox.Show("Please select a criterin from price group");
            }

            if (txtSalesAmount.Text.Trim() != "")
            {
                if (rbSalesEqual.Checked)
                    list = list.Where(x => x.SalesAmount == Convert.ToInt32(txtSalesAmount.Text)).ToList();
                else if (rbSalesMore.Checked)
                    list = list.Where(x => x.SalesAmount > Convert.ToInt32(txtSalesAmount.Text)).ToList();
                else if (rbSalesLess.Checked)
                    list = list.Where(x => x.SalesAmount < Convert.ToInt32(txtSalesAmount.Text)).ToList();
                else
                    MessageBox.Show("Please select a criterin sale amount group");
            }
            if (chDate.Checked)
                list = list.Where(x => x.SalesDate > dpStart.Value && x.SalesDate < dpEnd.Value).ToList();
            dataGridView1.DataSource = list;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            CleanFilters();
        }

        private void CleanFilters()
        {
            txtPrice.Clear();
            txtCustomerName.Clear();
            txtProductName.Clear();
            txtSalesAmount.Clear();
            rbPriceEquals.Checked = false;
            rbPriceLess.Checked = false;
            rbPriceMore.Checked = false;
            rbSalesEqual.Checked = false;
            rbSalesLess.Checked = false;
            rbSalesMore.Checked = false;
            dpStart.Value = DateTime.Today;
            dpEnd.Value = DateTime.Today;
            chDate.Checked = false;
            cmbCategory.SelectedIndex = -1;
            dataGridView1.DataSource = dto.Sales;
        }
    }
}
