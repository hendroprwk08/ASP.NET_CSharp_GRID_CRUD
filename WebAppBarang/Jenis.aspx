<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Jenis.aspx.cs" Inherits="WebAppBarang.Jenis" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <p>Buka: <a href="Bahan.aspx">Bahan</a> | <a href="Barang.aspx">Barang</a></p>
    <form id="form1" runat="server">
        <asp:GridView ID="gv" runat="server" 
            AutoGenerateColumns="False" 
            AllowPaging="True" 
            PageSize="2" 
            AllowSorting="True" 
            OnPageIndexChanging="gv_PageIndexChanging"          
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
                <asp:TemplateField ShowHeader="False">
                    <EditItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update" Text="Update"></asp:LinkButton>
                        &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit"></asp:LinkButton>
                        &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Select" Text="Select" CommandArgument='<%# (Container.DataItemIndex + 1) + "-" + Eval("ID_JENIS") + "-" + Eval("JENIS") %>'></asp:LinkButton>
                        &nbsp;<asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <p id="lbl_status" runat="server"></p>
    </form>
</body>
</html>
