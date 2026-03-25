using global::System;
using global::System.Collections.Generic;
using global::System.Drawing;
using global::System.IO;
using global::System.Linq;
using global::System.Net.Http;
using global::System.Threading;
using global::System.Threading.Tasks;
using global::System.Windows.Forms;


namespace ReservationApiUygulamasi.UI
{
	internal class Program
	{
		static void Main(string[] args)
		{
            Application.Run(new ProductList());
        }
	}
}
