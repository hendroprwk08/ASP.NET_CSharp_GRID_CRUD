<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Barang.aspx.cs" Inherits="WebAppBarang.Barang1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <p>Buka: <a href="Jenis.aspx">Jenis</a> | <a href="Bahan.aspx">Bahan</a></p>
    <form id="form1" runat="server">
        <asp:GridView ID="gv" runat="server" 
            AutoGenerateColumns="false" 
            EmptyDataText="Tak ada data." 
            ShowFooter="true" 
            AllowPaging="true" 
            OnPageIndexChanging="gv_PageIndexChanging"
            PageSize="2" 
            OnRowDataBound="gv_RowDataBound"
            OnRowCommand="gv_RowCommand"
            OnRowEditing="gv_RowEditing" 
            OnRowCancelingEdit="gv_RowCancelingEdit" 
            OnRowDeleting="gv_RowDeleting" 
            OnRowUpdating="gv_RowUpdating">
            <Columns>
                <asp:TemplateField HeaderText="#">
                    <ItemTemplate>
                        <asp:Label ID="lbl_id" runat="server" Text='<%# Eval("ID_BARANG") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Label ID="lbl_id" runat="server" Text='<%# Eval("ID_BARANG") %>'></asp:Label>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <!-- kosong, karena ID-nya otomatis -->
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="NAMA">
                    <ItemTemplate>
                        <asp:Label ID="lbl_nama" runat="server" Text='<%# Eval("NAMA") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="tb_nama" runat="server" Text='<%# Eval("NAMA") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="tb_nama_footer" runat="server"></asp:TextBox>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="JENIS">
                    <ItemTemplate>
                        <asp:DropDownList ID="ddl_jenis" runat="server"></asp:DropDownList>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:DropDownList ID="ddl_jenis" runat="server"></asp:DropDownList>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:DropDownList ID="ddl_jenis_footer" runat="server"></asp:DropDownList>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="BAHAN">
                    <ItemTemplate>
                        <asp:DropDownList ID="ddl_bahan" runat="server"></asp:DropDownList>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:DropDownList ID="ddl_bahan" runat="server"></asp:DropDownList>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:DropDownList ID="ddl_bahan_footer" runat="server"></asp:DropDownList>
                    </FooterTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="HARGA">
                    <ItemTemplate>
                        <asp:Label ID="lbl_harga" runat="server" Text='<%# Eval("HARGA") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="tb_harga" runat="server" Text='<%# Eval("HARGA") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="tb_harga_footer" runat="server"></asp:TextBox>
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
    <div>
    <p> <asp:Label runat="server" ID="lbl_message"></asp:Label></p>
    </div>
    </form>
</body>
</html>
