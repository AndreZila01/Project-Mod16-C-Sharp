﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VesteBem_Admin
{
	public partial class FrmAdmin : Form
	{
		private string Username, Password; 
		public FrmAdmin(string user, string pass)
		{
			InitializeComponent();
			Username = user;
			Password = pass;
		}

		private void button_Click(object sender, EventArgs e)
		{
			Button btn = sender as Button;

			switch (btn.Text)
			{
				case "Adicionar Produtos":
					FrmAddProdutos frm = new FrmAddProdutos();
					frm.Show();
				break;
			}
		}

		private void FrmAdmin_Load(object sender, EventArgs e)
		{

		}
	}
}