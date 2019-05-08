<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Jenis.aspx.cs" Inherits="WebAppBarang.Jenis" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:GridView ID="gv" runat="server" 
            AutoGenerateColumns="false" 
            AllowPaging="true" 
            PageSize="5" 
            AllowSorting="true"
            OnRowEditing="gv_RowEditing" 
            OnRowUpdating="gv_RowUpdating" 
            OnRowCancelingEdit="gv_RowCancelingEdit" 
            OnRowDeleting="gv_RowDeleting" OnRowCommand="gv_RowCommand">
            
            <Columns>
                <asp:TemplateField HeaderText="#">
                    <ItemTemplate>
                        <asp:Label ID="lbl_id" runat="server" Text='<%# Eval("ID_JENIS") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Label ID="lbl_id" runat="server" Text='<%# Eval("ID_JENIS") %>'></asp:Label>
                    </EditItemTemplate>
                    <footerTemplate>
                        <asp:TextBox ID="tb_id_footer" runat="server"></asp:TextBox>
                    </footerTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="JENIS">
                    <ItemTemplate>
                        <asp:Label ID="lbl_jenis" runat="server" Text='<%# Eval("JENIS") %>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="tb_jenis" runat="server" Text='<%# Eval("JENIS") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <footerTemplate>
                        <asp:TextBox ID="tb_jenis_footer" runat="server"></asp:TextBox>
                    </footerTemplate>
                </asp:TemplateField>
                <asp:CommandField ShowEditButton="true" ShowCancelButton="true" ShowDeleteButton="true" ShowSelectButton="true"/>
            </Columns>
        </asp:GridView>
        <p id="lbl_status" runat="server"></p>
    </form>
</body>
</html>
