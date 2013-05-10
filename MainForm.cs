/*
 * Creado por SharpDevelop.
 * Usuario: ivancf
 * Fecha: 10/05/2013
 * Hora: 14:32
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CalculoHipoteca
{
	

	public partial class MainForm : Form{
		public abstract class DatosEvento{}
		public class DatosPagoCuota{}
		public class DatosAportacion{
			double CapitalAportado;
		}
		public class DatosCambioInteres{
			double NuevoInteresAnual;
		}
		public enum TipoEvento {PagoCuota,Aportacion,CambioInteres};
		public class Evento{
			DateTime Fecha;
			TipoEvento Tipo;
			DatosEvento Datos;
		}
		*** ibas por generar la lista de eventos
		public MainForm(){
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			
		}
		void  Mensaje(string cad){
			this.textBox1.Text += cad + Environment.NewLine;
		}
		protected double CalculaInteres(double CapitalPendiente,double InteresAnual){
			return Math.Round((CapitalPendiente*InteresAnual/12)/100,2);
		}
			
		protected void CalculaCuota(double CapitalPendiente,double InteresAnual,double MesesRestantes,out double Cuota, out double InteresesPagados,out double CapitalAportado){
			Cuota = Math.Round((CapitalPendiente * (InteresAnual/12)) / (100 *(1-(System.Math.Pow((1+((InteresAnual/12)/100)),-MesesRestantes)))),2);
			InteresesPagados = CalculaInteres(CapitalPendiente,InteresAnual);
    		CapitalAportado = Math.Round((Cuota - InteresesPagados),2);
		}
		
		void MainFormLoad(object sender, EventArgs e)
		{
			double CapitalPendiente = 330000;
			double InteresAnual = 4.6;
			double Anos = 40;
			double MesesRestantes = Anos * 12;
			double Cuota,InteresesPagados,CapitalAportado;
			CalculaCuota(CapitalPendiente,InteresAnual,MesesRestantes,out Cuota,out InteresesPagados,out CapitalAportado);
			this.Mensaje(String.Format("Cuota:{0:###,##0.00}, Intereses: {1:###,##0.00} Capital Aportado:{2:###,##0.00}",Cuota,InteresesPagados,CapitalAportado));
			this.Mensaje(String.Format("Cuota:{0}, Intereses: {1} Capital Aportado:{2}",Cuota,InteresesPagados,CapitalAportado));
		}
	}
}
