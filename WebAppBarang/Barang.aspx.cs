using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppBarang
{
    public partial class Barang1 : System.Web.UI.Page
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
                var s = "select * from barang";
                dt = new DataTable();
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
                lbl_message.Text = "";
            }
        }

        protected void gv_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv.PageIndex = e.NewPageIndex;
            loadGrid();
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
                string nama = (gv.Rows[e.RowIndex].FindControl("tb_nama") as TextBox).Text.ToString().Trim();
                string jenis = (gv.Rows[e.RowIndex].FindControl("ddl_jenis") as DropDownList).SelectedValue.ToString();
                string bahan = (gv.Rows[e.RowIndex].FindControl("ddl_bahan") as DropDownList).SelectedValue.ToString();
                string harga = (gv.Rows[e.RowIndex].FindControl("tb_harga") as TextBox).Text.ToString().Trim();
                harga = harga.Remove(harga.Length - 5);

                d.openDb();

                var s = "update barang set nama = '" + nama + "', id_jenis = '" + jenis + "', " +
                        "id_bahan = '" + bahan + "', harga = "+ harga +"  where id_barang = '" + id + "'";
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

        protected void gv_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DatabaseClass d = new DatabaseClass();

            try
            {
                string id = (gv.Rows[e.RowIndex].FindControl("lbl_id") as Label).Text.ToString().Trim();

                d.openDb();

                var s = "delete barang where id_barang = " + id;
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
            if (e.CommandName.Equals("Insert"))
            {
                
                DatabaseClass d = new DatabaseClass();

                string nama = (gv.FooterRow.FindControl("tb_nama_footer") as TextBox).Text.ToString().Trim();
                string jenis = (gv.FooterRow.FindControl("ddl_jenis_footer") as DropDownList).SelectedValue.ToString();
                string bahan = (gv.FooterRow.FindControl("ddl_bahan_footer") as DropDownList).SelectedValue.ToString();
                string harga = (gv.FooterRow.FindControl("tb_harga_footer") as TextBox).Text.ToString().Trim();

                if (nama.Length == 0 || jenis.Length == 0 || bahan.Length == 0 || harga.Length == 0)
                {
                    lbl_message.Text = "Lengkapi datamu";
                    return;
                }

                try
                {  
                    d.openDb();
                    
                    var s = "insert into barang ([nama], [id_jenis], [id_bahan], [harga]) values ('" + nama + "', '" + jenis + "', '" + bahan + "', " + harga + ")";

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

        protected void gv_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gv.EditIndex = -1;
            loadGrid();
        }

        protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //bind ke dropdownlist
            if(e.Row.RowType == DataControlRowType.DataRow){
                DatabaseClass d = new DatabaseClass();

                try
                {
                    d.openDb();
                    var s = "select id_jenis, jenis from jenis";
                    dt = new DataTable();
                    dt = d.read(s);

                    //definisi objek dropdownlist
                    DropDownList ddl_jenis = e.Row.FindControl("ddl_jenis") as DropDownList;

                    //set ddl jenis
                    ddl_jenis.DataSource = dt;
                    ddl_jenis.DataTextField = "jenis";
                    ddl_jenis.DataValueField = "id_jenis";
                    ddl_jenis.DataBind();
                    ddl_jenis.Items.Insert(0, new ListItem( "-- Pilih Jenis --", "0"));
                    
                    //-------------- BAHAN -----------
                    s = "select id_bahan, bahan from bahan";
                    dt = new DataTable();
                    dt = d.read(s);

                    //definisi objek dropdownlist
                    DropDownList ddl_bahan = e.Row.FindControl("ddl_bahan") as DropDownList;
                    
                    //set ddl bahan
                    ddl_bahan.DataSource = dt;
                    ddl_bahan.DataTextField = "bahan";
                    ddl_bahan.DataValueField = "id_bahan";
                    ddl_bahan.DataBind();
                    ddl_bahan.Items.Insert(0, new ListItem("-- Pilih Bahan --", "0"));
                   
                    //set selected value
                    DataRowView drv = e.Row.DataItem as DataRowView; //baca baris grid
                    ddl_jenis.SelectedValue = drv["ID_JENIS"].ToString();
                    ddl_bahan.SelectedValue = drv["ID_BAHAN"].ToString();
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

            //bind dropdownlist pada FOOTER
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                DatabaseClass d = new DatabaseClass();

                try
                {
                    d.openDb();
                    var s = "select id_jenis, jenis from jenis";
                    dt = new DataTable();
                    dt = d.read(s);

                    //definisi objek dropdownlist
                    DropDownList ddl_jenis_footer = e.Row.FindControl("ddl_jenis_footer") as DropDownList;

                    //set ddl jenis_footer
                    ddl_jenis_footer.DataSource = dt;
                    ddl_jenis_footer.DataTextField = "jenis";
                    ddl_jenis_footer.DataValueField = "id_jenis";
                    ddl_jenis_footer.DataBind();
                    ddl_jenis_footer.Items.Insert(0, new ListItem("-- Pilih Jenis --", "0"));

                    //-------------- BAHAN -----------
                    s = "select id_bahan, bahan from bahan";
                    dt = new DataTable();
                    dt = d.read(s);

                    //definisi objek dropdownlist
                    DropDownList ddl_bahan_footer = e.Row.FindControl("ddl_bahan_footer") as DropDownList;

                    //set ddl bahan_footer
                    ddl_bahan_footer.DataSource = dt;
                    ddl_bahan_footer.DataTextField = "bahan";
                    ddl_bahan_footer.DataValueField = "id_bahan";
                    ddl_bahan_footer.DataBind();
                    ddl_bahan_footer.Items.Insert(0, new ListItem("-- Pilih Bahan --", "0"));
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
}