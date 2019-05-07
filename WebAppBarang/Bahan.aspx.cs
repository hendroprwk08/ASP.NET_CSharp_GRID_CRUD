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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadGrid();
            }
        }

        protected void bt_simpan_Click(object sender, EventArgs e)
        {
            //DatabaseClass d = new DatabaseClass();

            //try
            //{
            //    d.openDb();
            //    var s = "insert into bahan (id_bahan, bahan, deskripsi) values ('" + tb_id.Text + "', '" + tb_bahan.Text + "', '" + tb_deskripsi.Text + "')";
            //    Console.WriteLine(s);
            //    d.execute(s);

            //    loadGrid();
            //    kosong();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            //finally 
            //{
            //    d.closeDB();
            //}
        }

        //protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        //{
        //    gv.EditIndex = e.NewEditIndex;
        //    loadGrid();
        //}

        private void loadGrid()
        {
            DatabaseClass d = new DatabaseClass();

            try
            {
                DataTable dt = new DataTable();

                d.openDb();
                var s = "select * from bahan";
                dt = d.read(s);

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

        void kosong() {
            //tb_id.Text = "";
            //tb_bahan.Text = "";
            //tb_deskripsi.Text = "";
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
            if (e.CommandName.Equals("cn_tambah")) {
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
                    kosong();
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

        protected void gv_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gv.EditIndex = -1;
            loadGrid();
        }

        protected void gv_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            DatabaseClass d = new DatabaseClass();

            try
            {
                string id = (gv.Rows[e.RowIndex].FindControl("lbl_id") as TextBox).Text.ToString().Trim();
                string bahan = (gv.Rows[e.RowIndex].FindControl("tb_bahan") as TextBox).Text.ToString().Trim();
                string deskripsi = (gv.Rows[e.RowIndex].FindControl("tb_deskripsi") as TextBox).Text.ToString().Trim();

                d.openDb();

                var s = "update bahan set bahan = '" + bahan + "', deskripsi =  '" + deskripsi + "' where id_bahan = '" + id + "'"; 
                Console.WriteLine(s);
                d.execute(s);

                loadGrid();
                kosong();
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

        //protected void OnRowCancelingEdit(object sender, EventArgs e)
        //{
        //    gv.EditIndex = -1;
        //    loadGrid();
        //}

        //protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        //{
        //    GridViewRow row = gv.Rows[e.RowIndex];
        //    string id =gv.DataKeys[e.RowIndex].Values.ToString();
        //    string name = (row.FindControl("tb_bahan") as TextBox).Text;
        //    string country = (row.FindControl("tb_deskripsi") as TextBox).Text;

        //    DatabaseClass d = new DatabaseClass();

        //    try
        //    {
        //        DataTable dt = new DataTable();

        //        d.openDb();
        //        var s = "select * from bahan";
        //        dt = d.read(s);

        //        gv.DataSource = dt;
        //        gv.DataBind();
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //    finally
        //    {
        //        d.closeDB();
        //    }

        //    gv.EditIndex = -1;
        //    loadGrid();
        //}

        //protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        //{

        //}

        //protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        //{

        //}
    }
}