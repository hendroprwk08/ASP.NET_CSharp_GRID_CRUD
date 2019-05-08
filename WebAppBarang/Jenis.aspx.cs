using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppBarang
{
    public partial class Jenis : System.Web.UI.Page
    {
        DataTable dt;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadGrid();
            }
        }

        private void loadGrid()
        {
            DatabaseClass d = new DatabaseClass();

            try
            {
                d.openDb();
                var s = "select * from jenis";
                dt = new DataTable();
                dt = d.read(s);

                Console.WriteLine(dt.Rows.Count.ToString());

                gv.DataSource = dt;
                gv.DataBind();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                d.closeDB();
            }
        }

        protected void gv_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gv.EditIndex = e.NewEditIndex;
            loadGrid();
        }

        protected void gv_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            DatabaseClass d = new DatabaseClass();

            try
            {
                string id = (gv.Rows[e.RowIndex].FindControl("lbl_id") as Label).Text.ToString().Trim();
                string jenis = (gv.Rows[e.RowIndex].FindControl("tb_jenis") as TextBox).Text.ToString().Trim();

                d.openDb();

                var s = "update jenis set jenis = '" + jenis + "' where id_jenis = '" + id + "'";
                Console.WriteLine(s);
                d.execute(s);

                gv_RowCancelingEdit(null, null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                d.closeDB();
            }
        }

        protected void gv_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gv.EditIndex = -1;
            loadGrid();
        }


        protected void gv_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DatabaseClass d = new DatabaseClass();

            try
            {
                string id = (gv.Rows[e.RowIndex].FindControl("lbl_id") as Label).Text.ToString().Trim();
               
                d.openDb();

                var s = "delete jenis where id_jenis = '" + id + "'";
                Console.WriteLine(s);
                d.execute(s);

                gv_RowCancelingEdit(null, null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                d.closeDB();
            }
        }

        protected void gv_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Console.WriteLine(e.CommandName);
            if (e.CommandName.Equals("Select")) {                
                string id = gv.DataKeys[gv.SelectedRow.RowIndex].Value.ToString(); //gv.SelectedRow.Cells[1].ToString(); //(gv.SelectedRow.FindControl("lbl_id") as Label).Text.ToString().Trim();
                string jenis = gv.SelectedRow.Cells[2].Text.ToString(); //(gv.SelectedRow.FindControl("tb_jenis") as TextBox).Text.ToString().Trim();

                lbl_status.InnerText = id + " - " + jenis;
            }
        }
    }
}