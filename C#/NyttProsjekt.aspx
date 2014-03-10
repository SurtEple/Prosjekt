<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NyttProsjekt.aspx.cs" Inherits="Timeregistreringssystem.NyttProsjekt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 387px;
        }
        #Text2 {
            height: 29px;
            width: 163px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 328px">

        <asp:TextBox ID="resultBox" runat="server" Height="81px" Width="281px"></asp:TextBox>


      
        <table style="width: 100%; height: 139px;">
            <tr>
                <td class="auto-style1">Navn:</td>
                <td>
                    <asp:TextBox ID="textBoxNavn" runat="server"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">Oppsummering:</td>
                <td>
                    <asp:TextBox ID="textBoxOppsummering" runat="server" Height="44px"  TextMode="MultiLine" Width="177px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style1">Neste Fase:</td>
                <td>
                    <asp:TextBox ID="textBoxNesteFase" runat="server" Height="44px" TextMode="MultiLine" Width="177px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <asp:Button ID="btnLagre" runat="server" Height="34px" OnClick="btnLagre_Click" Text="Lagre" Width="159px" />


      
    </div>
    </form>
</body>
</html>
