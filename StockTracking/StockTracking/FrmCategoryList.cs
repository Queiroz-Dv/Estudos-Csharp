﻿using System;
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
    public partial class FrmCategoryList : Form
    {
        public FrmCategoryList()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmCategory frm = new FrmCategory();
            //Hide the current page
            this.Hide();
            //Show the other page
            frm.ShowDialog();
            this.Visible = true;
            dto = bll.Select();
            dataGridView1.DataSource = dto.Categories;
        }

        CategoryDTO dto= new CategoryDTO();
        CategoryBLL bll = new CategoryBLL();
        private void FrmCategoryList_Load(object sender, EventArgs e)
        {
            dto = bll.Select();
            dataGridView1.DataSource = dto.Categories;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Category Name";
        }

        private void txtCategoryName_TextChanged(object sender, EventArgs e)
        {
            List<CategoryDetailDTO> list = dto.Categories;
            list = list.Where(x => x.CategoryName.Contains(txtCategoryName.Text)).ToList();
            dataGridView1.DataSource = list;

        }
    }
}
