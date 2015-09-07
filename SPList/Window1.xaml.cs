using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace SPList
{

	public partial class Window1 : Window
	{
		public Window1()
		{
			InitializeComponent();


			var listTitle = "Part Overview Library";
			ClientContext ctx = new ClientContext("http://galaxis.axis.com/suppliers/Manufacturing/Experimental/");

			var list = ctx.Web.Lists.GetByTitle(listTitle);

			ctx.Credentials = CredentialCache.DefaultCredentials;
			FieldCollection coll = list.Fields;

			ctx.Load(list.Fields);
			//ctx.Load(web);
			ctx.ExecuteQuery();

			string fill = "";
			foreach (var item in coll)
			{
				fill += item.Title + " | ";
			}
			textBlock.Text = fill.ToString();

		}
	}
}
