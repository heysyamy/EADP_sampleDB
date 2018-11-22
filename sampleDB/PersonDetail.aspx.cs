using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sampleDB
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) // this is first time coming to this page
            {
                string id = Request.QueryString["PersonID"];

                if (id == null) // this is add mode
                {
                    btnAddUpdate.Text = "Add New";
                    btnDelete.Visible = false;
                }
                else
                {
                    btnAddUpdate.Text = "Update";
                    Person p = PersonDAO.getPersonById(Convert.ToInt32(id));

                    lblPersonID.Text = p.PersonID.ToString();
                    tbFullName.Text = p.FullName;
                    ddlGender.SelectedValue = p.Gender;

                    tbPersonRole.Text = p.PersonRole;

                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Enquiry.aspx");
        }

        protected void btnAddUpdate_Click(object sender, EventArgs e)
        {
            if (btnAddUpdate.Text == "Update") // update mode
            {
                PersonDAO.updateById(Convert.ToInt32(lblPersonID.Text), tbFullName.Text, ddlGender.SelectedValue, tbPersonRole.Text);
                Response.Redirect("Enquiry.aspx");
            }
            else // this is add new record
            {
                PersonDAO.insert(tbFullName.Text, ddlGender.SelectedValue, tbPersonRole.Text);
                Response.Redirect("Enquiry.aspx");
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            PersonDAO.deleteById(Convert.ToInt32(lblPersonID.Text));
            Response.Redirect("Enquiry.aspx");

        }
    }
}