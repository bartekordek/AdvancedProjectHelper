using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace UltimateManagementTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
			dbManager = new DBManager.CDbManager();
        }

		private void btnLoadDb_Click( object sender, EventArgs e )
		{
			
		}

		private void btnCreateNewDb_Click( object sender, EventArgs e )
		{
			DbBuilder.CDbBuilder.CreateEmptyDb( dbManager );
		}

		private DBManager.CDbManager dbManager;
	}
}
