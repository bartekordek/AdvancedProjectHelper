using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ultimate_Management_Tool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.FillTree();
        }

        private void FillTree()
        {
            using (var db = new UMTEntities())
            {
                var query = from a in db.Activities
                            select a;

                foreach (var act in query)
                {
                    var node = new TreeNode()
                    {
                        Name=act.Id.ToString(),
                        Text=act.activityName
                    };

                    if (act.parentActivityId.HasValue)
                    {
                        var parentNode = treeView1.Nodes.Find(act.parentActivityId.ToString(), true)[0];

                        parentNode.Nodes.Add(node);
                    }
                    else
                    {
                        treeView1.Nodes.Add(node);
                    }
                }
            }
        }
    }
}
