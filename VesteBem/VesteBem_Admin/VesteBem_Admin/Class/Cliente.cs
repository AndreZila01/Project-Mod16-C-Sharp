﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VesteBem_Admin.Class
{
	public class ConsultaClientes
	{
		public static List<Cliente> ConsultaCliente()
		{
			List<Cliente> lstdoutors = new List<Cliente>();
			//SqlConnection liga = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB; DataBase=Work; Integrated Security=True");

			//SqlConnection liga = new SqlConnection(@"Server=tcp:srv-epbjc.database.windows.net,1433;Initial Catalog=bd;Persist Security Info=False;User ID=epbjc;Password=Teste123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
			//SqlCommand command = new SqlCommand();
			List<Cliente> lst = new List<Cliente>();
			//SqlDataReader dr; Bitmap bitmap;
			//try
			//{
				//Image images = Properties.Resources.add;
				//using (var ms = new MemoryStream())
				//{
				//	images.Save(ms, images.RawFormat);
				//	Debug.Print(""+ms.ToArray());
				//}
				//if (liga.State == System.Data.ConnectionState.Open) throw new ArgumentException("Problemas a ligar ao servidor!!");
				//liga.Open();
				//command.Connection = liga;

				//command.CommandText = "select * From tbl_Cliente, tbl_login where tbl_Cliente.Id_Login=tbl_login.IdLogin and tbl_login.Funcionario=0";
				//dr = command.ExecuteReader();
				//if (dr.Read())
				//{
				//	lst.Clear();
				//	MemoryStream MS = new MemoryStream();

				//	while (dr.Read())
				//	{
				//		Cliente cli = new Cliente();
				//		cli.Id_Cliente = int.Parse(dr["IdCliente"].ToString());
				//		cli.CodPostal = (dr["CodPostal"]).ToString();
				//		cli.DataNasc = (dr["DataNasc"]).ToString();
				//		cli.Email = (dr["Email"]).ToString();
				//		cli.Id_Login = int.Parse(dr["Id_Login"].ToString());
				//		//Image.FromStream((new MemoryStream( ... ), true, true))
				//		cli.Icon = Properties.Resources.user;//cli.Icon = Image.FromStream(new MemoryStream(Convert.FromBase64String(dr["Icon"].ToString())), true, true);
				//		cli.Localidade = (dr["Localidade"]).ToString();
				//		cli.Morada = (dr["Morada"]).ToString();
				//		cli.Nif = (dr["Nif"]).ToString();
				//		cli.Nome = (dr["Nome"]).ToString();
				//		cli.Sexo = (dr["Sexo"]).ToString();
				//		cli.Telefone = (dr["Telefone"]).ToString();

				//		lst.Add(cli);

				//		/*MemoryStream stream = new MemoryStream();
				//	 byte[] image = (byte[])comando.ExecuteScalar();
				//        stream.Write(image, 0, image.Length);
				//        Bitmap bitmap = new Bitmap(stream);
				//        Response.ContentType = "image/Jpeg";
				//        bitmap.Save(Response.OutputStream, ImageFormat.Jpeg);*/
				//	}
				//}
				//ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });
				//string str = string.Empty;
				//	using (SqlConnection conn = new SqlConnection(@"Server=tcp:srv-epbjc.database.windows.net,1433;Initial Catalog=bd;Persist Security Info=False;User ID=epbjc;Password=Teste123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
				//	//using (SqlConnection conn = new SqlConnection(@"Server=(localdb)\MSSQLLocalDB; DataBase=Work; Integrated Security=True"))
				//	{
				//		ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });
				//		using (SqlCommand command = new SqlCommand("select * From tbl_Cliente, tbl_login where tbl_Cliente.Id_Login=tbl_login.IdLogin"))//select * From tbl_Cliente, tbl_login where tbl_Cliente.Id_Login=tbl_login.IdLogin and tbl_login.Funcionario=0
				//		{
				//			using (SqlDataAdapter adapter = new SqlDataAdapter())
				//			{
				//				command.Connection = conn;
				//				adapter.SelectCommand = command;
				//				conn.Open(); ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(delegate { return true; });
				//				//using (SqlDataReader oReader = command.ExecuteReader())
				//				{
				//					DataSet dataSet = new DataSet();
				//					adapter.Fill(dataSet);



				//					int ds = 0;
				//					//while (oReader.Read())
				//					{
				//						Cliente cli = new Cliente();
				//						//cli.Id_Cliente = int.Parse(oReader["IdCliente"].ToString());
				//						//cli.Nome = oReader["Nome"].ToString();
				//						//cli.Sexo = oReader["Sexo"].ToString();
				//						//cli.Id_Login = int.Parse(oReader["Id_Login"].ToString());
				//						//cli.Morada = oReader["Morada"].ToString();
				//						//cli.CodPostal = oReader["CodPostal"].ToString();
				//						//cli.Localidade = oReader["Localidade"].ToString();
				//						//cli.DataNasc = oReader["DataNasc"].ToString();
				//						//cli.Email = oReader["Email"].ToString();
				//						//cli.Telefone = oReader["Telefone"].ToString();
				//						//cli.Nif = oReader["Nif"].ToString();
				//						//cli.Funcionario = int.Parse(oReader["Funcionario"].ToString());
				//						Byte[] data = new Byte[0];
				//						data = (Byte[])(dataSet.Tables[0].Rows[ds]["Icon"]);
				//						MemoryStream mem = new MemoryStream(data);
				//						cli.Icon = Image.FromStream(mem);
				//						//cli.Icon = Image.FromStream(new MemoryStream((Byte[])oReader["Icon"].ToString()));
				//						ds++;
				//						lstdoutors.Add(cli);
				//					}
				//					conn.Close();
				//				}

				//			}
				//		}
				//	}

				//}
				//catch (Exception ex)
				//{

				//}
				System.Windows.Forms.DataGridView grdLogin = new System.Windows.Forms.DataGridView();
				SqlConnection liga = new SqlConnection(@"Server=tcp:srv-epbjc.database.windows.net,1433;Initial Catalog=bd;Persist Security Info=False;User ID=epbjc;Password=Teste123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
					
				SqlDataAdapter dataAdapter = new SqlDataAdapter(new SqlCommand("SELECT * FROM tbl_Cliente", liga));
				DataSet dataSet = new DataSet();
				dataAdapter.Fill(dataSet);

				if (dataSet.Tables[0].Rows.Count > 1)
				{
					Byte[] data = new Byte[0];
					data = (Byte[])(dataSet.Tables[0].Rows[0]["Icon"]);
					MemoryStream mem = new MemoryStream(data);
					System.Windows.Forms.PictureBox pictureBox2=new System.Windows.Forms.PictureBox();
					pictureBox2.Image	= Image.FromStream(mem);
					pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
				}

				return lstdoutors;
		}
	}
}
