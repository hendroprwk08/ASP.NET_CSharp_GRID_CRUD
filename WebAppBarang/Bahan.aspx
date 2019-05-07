<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Bahan.aspx.cs" Inherits="WebAppBarang.Barang" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
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
            OnRowUpdating="gv_RowUpdating">
            
            <Columns>
                <asp:TemplateField HeaderText="#" ItemStyle-Width="20">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%# Eval("ID_BAHAN") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Label ID="lbl_id" runat="server" Text='<%# Eval("ID_BAHAN") %>'></asp:Label>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="tb_id_footer" runat="server"></asp:TextBox>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="BAHAN" ItemStyle-Width="50">
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
                <asp:TemplateField HeaderText="DESKRIPSI" ItemStyle-Width="50">
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
                <asp:TemplateField HeaderText="" ItemStyle-Width="110">
                    <ItemTemplate>
                        <asp:Button  ID="bt_ubah" runat="server" CommandName="cn_ubah" Text="Ubah" /></Button>
                        <asp:Button  ID="bt_hapus" runat="server" CommandName="cn_hapus" Text="Hapus" /></Button>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Button  ID="bt_perbarui" runat="server" CommandName="cn_perbarui" Text="Perbarui" /></Button>
                        <asp:Button  ID="bt_batal" runat="server" CommandName="cn_batal" Text="Batal" /></Button>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:Button  ID="bt_tambah" runat="server" CommandName="cn_tambah" Text="Tambah" /></Button>                    
                    </FooterTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        </form>
</body>
</html>
