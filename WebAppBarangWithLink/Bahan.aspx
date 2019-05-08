<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Bahan.aspx.cs" Inherits="WebAppBarangWithLink.Bahan" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:GridView ID="GridView1" runat="server" AllowPaging="true"  PageSize="5" AllowSorting="true" AutoGenerateColumns="false">
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
                 <asp:CommandField ShowEditButton="true" ShowDeleteButton="true" ShowInsertButton="true" ShowCancelButton="true" ShowSelectButton="true" />
            </Columns>
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
