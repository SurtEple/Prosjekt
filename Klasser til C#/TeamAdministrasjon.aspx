﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeamAdministrasjon.aspx.cs" Inherits="Timeregistreringssystem.TeamAdministrasjon" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Team administrasjon</h1>
        <br />
        <asp:GridView ID="gridViewTeam" runat="server" OnSelectedIndexChanged="gridViewTeam_SelectedIndexChanged"
             autogenerateselectbutton="True" selectedindex="0" AutoGenerateDeleteButton="True" AutoGenerateEditButton="True"
             BackColor="white" BorderColor="Black" BorderStyle="Solid" CellPadding="5" OnRowDeleting="gridViewTeam_RowDeleting" OnRowEditing="gridViewTeam_RowEditing">
         <HeaderStyle BackColor="#CCCCFF" ForeColor="Black" />
         <selectedrowstyle backcolor="White"
         forecolor="Black"
         font-bold="True" BorderColor="Black"/> 
        </asp:GridView>
    
        <br />
        <asp:Button ID="btnAvbryt" runat="server" Text="Avbryt" Width="80px" />
&nbsp;
        <asp:Button ID="btnNyttTeam" runat="server" Text="Nytt team" OnClick="btnNyttTeam_Click" />
    
    </div>
    </form>
</body>
</html>
