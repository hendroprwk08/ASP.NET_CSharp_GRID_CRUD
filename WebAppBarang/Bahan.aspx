<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Bahan.aspx.cs" Inherits="WebAppBarang.Barang" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <p>Buka: <a href="Jenis.aspx">Jenis</a> | <a href="Barang.aspx">Barang</a></p>
    <form id="form1" runat="server">
        <asp:GridView 
            ID="gv"
            runat="server" 
            AutoGenerateColumns="False" 
            DataKeyNames="id_bahan" 
            EmptyDataText="Tak ada data." 
            ShowFooter="true" 
            AllowPaging="true" 
            OnPageIndexChanging="gv_PageIndexChanging"
            PageSize="5"
            OnRowCommand="gv_RowCommand"
            OnRowEditing="gv_RowEditing" 
            OnRowCancelingEdit="gv_RowCancelingEdit" 
            OnRowDeleting="gv_RowDeleting" 
            OnRowUpdating="gv_RowUpdating">
            
            <Columns>
                <asp:TemplateField HeaderText="#" ItemStyle-Width="70">
                    <ItemTemplate>
                        <asp:Label ID="lbl_id" runat="server" Text='<%# Eval("ID_BAHAN") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Label ID="lbl_id" runat="server" Text='<%# Eval("ID_BAHAN") %>'></asp:Label>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="tb_id_footer" runat="server"></asp:TextBox>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="BAHAN">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%# Eval("BAHAN") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="tb_bahan" runat="server" Text='<%# Eval("BAHAN") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="tb_bahan_footer" runat="server"></asp:TextBox>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="DESKRIPSI">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%# Eval("DESKRIPSI") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="tb_deskripsi" runat="server" Text='<%# Eval("DESKRIPSI") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="tb_deskripsi_footer" runat="server"></asp:TextBox>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="" ItemStyle-Width="120">
                    <ItemTemplate>
                        <asp:Button  ID="bt_ubah" runat="server" CommandName="Edit" Text="Ubah" /></Button>
                        <asp:Button  ID="bt_hapus" runat="server" CommandName="Delete" Text="Hapus" /></Button>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Button  ID="bt_perbarui" runat="server" CommandName="Update" Text="Perbarui" /></Button>
                        <asp:Button  ID="bt_batal" runat="server" CommandName="Cancel" Text="Batal" /></Button>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:Button  ID="bt_tambah" runat="server" CommandName="Insert" Text="Tambah" /></Button>                    
                    </FooterTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        </form>
</body>
</html>
