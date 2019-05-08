using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppBarang
{
    public partial class Barang : System.Web.UI.Page
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
                var s = "select * from bahan";
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

        //PINDAH HALAMAN
        protected void gv_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv.PageIndex = e.NewPageIndex;
            loadGrid();
        }

        //TAMBAH DATA PADA FOOTER
        protected void gv_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Insert"))
            {
                DatabaseClass d = new DatabaseClass();

                try
                {
                    string id = (gv.FooterRow.FindControl("tb_id_footer") as TextBox).Text.ToString().Trim();
                    string bahan = (gv.FooterRow.FindControl("tb_bahan_footer") as TextBox).Text.ToString().Trim();
                    string deskripsi = (gv.FooterRow.FindControl("tb_deskripsi_footer") as TextBox).Text.ToString().Trim();

                    d.openDb();
                    
                    var s = "insert into bahan (id_bahan, bahan, deskripsi) values ('" + id + "', '" + bahan + "', '" + deskripsi + "')";
                    Console.WriteLine(s);
                    d.execute(s);

                    loadGrid();
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
        }

        //EDIT DAN MENAMPILKAN TEMPLATE EDIT
        protected void gv_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gv.EditIndex = e.NewEditIndex;
            loadGrid();
        }

        //batalkan edit
        protected void gv_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gv.EditIndex = -1;
            loadGrid();
        }

        //update data
        protected void gv_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            DatabaseClass d = new DatabaseClass();

            try
            {
                string id = (gv.Rows[e.RowIndex].FindControl("lbl_id") as Label).Text.ToString().Trim();
                string bahan = (gv.Rows[e.RowIndex].FindControl("tb_bahan") as TextBox).Text.ToString().Trim();
                string deskripsi = (gv.Rows[e.RowIndex].FindControl("tb_deskripsi") as TextBox).Text.ToString().Trim();

                d.openDb();

                var s = "update bahan set bahan = '" + bahan + "', deskripsi =  '" + deskripsi + "' where id_bahan = '" + id + "'"; 
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

        //eksekusi penghapusan data
        protected void gv_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DatabaseClass d = new DatabaseClass();

            try
            {
                string id = (gv.Rows[e.RowIndex].FindControl("lbl_id") as Label).Text.ToString().Trim();
             
                d.openDb();

                var s = "delete from bahan where id_bahan = '" + id + "'";
                Console.WriteLine(s);
                d.execute(s);

                loadGrid();
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
    }
}