﻿using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VesteBem_Admin.Class;


namespace VesteBem_Admin
{
	public partial class FrmCliEFun : Form
	{
		List<Cliente> lst = new List<Cliente>();
		public FrmCliEFun()
		{
			InitializeComponent();
		}

		private void FrmCliEFun_Load(object sender, EventArgs e)
		{
			if (!backgroundWorker1.IsBusy)
				backgroundWorker1.RunWorkerAsync();
		}

		private void ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ToolStripMenuItem dss = sender as ToolStripMenuItem;

			if (dss.Text == "Cliente")
				CreateObjectsCli();
			else


		}
		private void CreateObjectsCli()
		{

			panel1.Visible = true;
			panel1.Controls.Clear();
			MemoryStream stream = new MemoryStream();
			int ds = 0;

			lst.ToList().ForEach(item =>
			{
				if (item.Funcionario != 1)
				{
					Panel pnl = new Panel();
					pnl.Location = new Point(0, 82 * ds);
					pnl.Size = new Size(800, 82); pnl.BorderStyle = BorderStyle.None; pnl.BackColor = Color.AntiqueWhite; pnl.Margin = new Padding(0, 0, 0, 0); pnl.BackColor = Color.FromArgb((15 * ds), (20 * ds), 213);
					pnl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
					pnl.AutoScroll = true;
					panel1.Controls.Add(pnl);

					Label lblUser = new Label();
					lblUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
					lblUser.BackColor = System.Drawing.SystemColors.ActiveCaption;
					lblUser.Location = new System.Drawing.Point(73, 21);
					lblUser.Name = "lblUser";
					lblUser.Size = new System.Drawing.Size(209, 27);
					lblUser.TabIndex = 1;
					lblUser.Text = item.Nome;
					pnl.Controls.Add(lblUser);

					PictureBox pctEdit = new PictureBox();
					pctEdit.Anchor = System.Windows.Forms.AnchorStyles.Right;
					pctEdit.BackColor = System.Drawing.SystemColors.ActiveCaption;
					pctEdit.Image = Properties.Resources.Pencil;
					pctEdit.SizeMode = PictureBoxSizeMode.Zoom;
					pctEdit.Location = new System.Drawing.Point(700, 21);
					pctEdit.Name = @"pctEdit\" + ds;
					pctEdit.Size = new System.Drawing.Size(33, 35);
					pctEdit.TabIndex = 2;
					pctEdit.TabStop = false;
					pctEdit.Click += new System.EventHandler(pctEdit_Click);
					pctEdit.Image = Properties.Resources.Pencil;
					pctEdit.Tag = "" + item.Id_Login;
					pnl.Controls.Add(pctEdit);

					PictureBox pctRemove = new PictureBox();
					pctRemove.Anchor = System.Windows.Forms.AnchorStyles.Right;
					pctRemove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
					pctRemove.Location = new System.Drawing.Point(755, 21);
					pctRemove.Name = "pctRemove";
					pctRemove.Image = Properties.Resources.Close_trash;
					pctRemove.SizeMode = PictureBoxSizeMode.Zoom;
					pctRemove.Size = new System.Drawing.Size(33, 35);
					pctRemove.TabIndex = 3;
					pctRemove.TabStop = false;
					pctRemove.MouseEnter += new System.EventHandler(pctRemove_MouseEnter);
					pctRemove.MouseLeave += new System.EventHandler(pctRemove_MouseLeave);
					pnl.Controls.Add(pctRemove);

					PictureBox pctUser = new PictureBox();
					pctUser.Anchor = System.Windows.Forms.AnchorStyles.Left;
					pctUser.BackColor = System.Drawing.SystemColors.ButtonShadow;
					pctUser.Image = item.Icon;
					pctUser.Location = new System.Drawing.Point(12, 13);
					pctUser.Name = "pctUser";
					pctUser.SizeMode = PictureBoxSizeMode.Zoom;
					pctUser.Size = new System.Drawing.Size(44, 45);
					pctUser.TabIndex = 0;
					pctUser.TabStop = false;
					pnl.Controls.Add(pctUser);
				}
				ds++;
			});


		}


		private void pctEdit_Click(object sender, EventArgs e)
		{
			Cliente cli = new Cliente();
			PictureBox pct = sender as PictureBox;

			cli.Nome = lst[int.Parse(pct.Name.Substring(8, (pct.Name.Length - 8)))].Nome;
			cli.Sexo = lst[int.Parse(pct.Name.Substring(8, (pct.Name.Length - 8)))].Sexo;
			cli.Telefone = lst[int.Parse(pct.Name.Substring(8, (pct.Name.Length - 8)))].Telefone;
			cli.Nif = lst[int.Parse(pct.Name.Substring(8, (pct.Name.Length - 8)))].Nif;
			cli.Morada = lst[int.Parse(pct.Name.Substring(8, (pct.Name.Length - 8)))].Morada;
			cli.CodPostal = lst[int.Parse(pct.Name.Substring(8, (pct.Name.Length - 8)))].CodPostal;
			cli.DataNasc = lst[int.Parse(pct.Name.Substring(8, (pct.Name.Length - 8)))].DataNasc;
			cli.Email = lst[int.Parse(pct.Name.Substring(8, (pct.Name.Length - 8)))].Morada;
			cli.Localidade = lst[int.Parse(pct.Name.Substring(8, (pct.Name.Length - 8)))].Localidade;
			cli.Id_Login = int.Parse(pct.Tag.ToString());
			cli.Id_Cliente = lst[int.Parse(pct.Name.Substring(8, (pct.Name.Length - 8)))].Id_Cliente;
			cli.Funcionario = lst[int.Parse(pct.Name.Substring(8, (pct.Name.Length - 8)))].Funcionario;



			FrmModificarCliFun frm = new FrmModificarCliFun(cli);
			frm.ShowDialog();
			lst.Clear();
			lst = ConsultaClientes.ConsultaCliente();
			CreateObjects();

		}

		private void pctRemove_MouseLeave(object sender, EventArgs e)
		{
			PictureBox pct = sender as PictureBox;

			pct.Image = Properties.Resources.Close_trash;
		}

		private void pctRemove_MouseEnter(object sender, EventArgs e)
		{
			PictureBox pct = sender as PictureBox;

			pct.Image = Properties.Resources.Open_trash;
		}

		private void FrmCliEFun_SizeChanged(object sender, EventArgs e)
		{

		}

		private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
		{
			lst = ConsultaClientes.ConsultaCliente();
			backgroundWorker1.DoWork += ToolStripMenuItem_Click;
		}

		private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{

		}
	}
}
