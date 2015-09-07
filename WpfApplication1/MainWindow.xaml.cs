using System;
using System.Collections.Generic;
using System.Linq;
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
using Microsoft.SharePoint.Client;

namespace WpfApplication1
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

			// Starting with ClientContext, the constructor requires a URL to the 
			// server running SharePoint. 
			ClientContext ctx = new ClientContext("http://galaxis.axis.com/suppliers/Manufacturing/Experimental/");

			// The SharePoint web at the URL.
			Web web = ctx.Web;
			var POLib = ctx.Web.Lists.GetByTitle("Part Overview Library");

			// Retrieve all lists from the server. 
			ctx.Load(web.Lists,
						 lists => lists.Include(list => list.Title, // For each list, retrieve Title and Id. 
												list => list.Id));

			

			// Execute query. 
			ctx.ExecuteQuery();

			// Enumerate the web.Lists. 
			foreach (Microsoft.SharePoint.Client.List list in web.Lists)
			{
				textBlock.Text = textBlock.Text + ", " + list.Title + ", ID:" + list.Id +;
			}

		}
	}
}
