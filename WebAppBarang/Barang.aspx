<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Barang.aspx.cs" Inherits="WebAppBarang.Barang1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <p>Buka: <a href="Jenis.aspx">Jenis</a> | <a href="Bahan.aspx">Bahan</a></p>
    <form id="form1" runat="server">
        <asp:GridView ID="gv" runat="server" AutoGenerateColumns="false">
        </asp:GridView>
    <div>
    
    </div>
    </form>
</body>
</html>
