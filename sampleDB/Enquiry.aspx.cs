using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sampleDB
{
    public partial class Enquiry : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataSource = PersonDAO.getAllPerson();
            GridView1.DataBind();
        }


        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Goto")
            {
                int index = Convert.ToInt32(e.CommandArgument.ToString());
                string id = GridView1.Rows[index].Cells[1].Text;
                Response.Redirect("PersonDetail.aspx?PersonID="+id);
            }
        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("PersonDetail.aspx");

        }
    }
}