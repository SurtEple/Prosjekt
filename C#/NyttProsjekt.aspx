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
        .auto-style2 {
            width: 315px;
        }
        .auto-style4 {
            width: 119px;
        }
        .auto-style5 {
            width: 398px;
        }
        .auto-style6 {
            width: 178px;
        }
        .auto-style7 {
            width: 180px;
        }
    </style>
</head>
<body style="height: 2243px">
    <form id="form1" runat="server">
    <div>


      <h1>Nytt Prosjekt</h1>
        <table>
            <tr>
                <td class="auto-style4">Navn:</td>
                <td class="auto-style5">
                    <asp:TextBox ID="textBoxNavn" runat="server" Height="22px" Width="203px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">Oppsummering:</td>
                <td class="auto-style5">
                    <asp:TextBox ID="textBoxOppsummering" runat="server" Height="59px"  TextMode="MultiLine" Width="212px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style4">Neste Fase:</td>
                <td class="auto-style5">
                    <asp:TextBox ID="textBoxNesteFase" runat="server" Height="68px" TextMode="MultiLine" Width="210px"></asp:TextBox>
                </td>
            </tr>

        </table>

        <asp:Button ID="btnLagre" runat="server" Height="34px" OnClick="btnLagre_Click" Text="Lagre Nytt Prosjekt" Width="159px" />


      
        <br />
        <br />
        <br />
        <h3>Resultat</h3>

        <asp:TextBox ID="resultBox" runat="server" Height="81px" Width="281px" ReadOnly="True"></asp:TextBox>


      
    </div>
        <br />
    <div>
        <h1>Slett Prosjekt</h1>

        <table>
            <tr>
                <td class="auto-style1">ProsjektID:</td>
                <td class="auto-style2">
                    <asp:TextBox ID="textBoxProsjektID" runat="server" Height="22px" Width="160px"></asp:TextBox>
                </td>
                <td>
                 <asp:Button ID="btnSlett" runat="server" Height="34px" OnClick="btnSlett_Click" Text="Slett" Width="159px" />
                </td>
            </tr>

        </table>

        <h3>ProsjektInfo: </h3>

             <p>

        <asp:TextBox ID="prosjektInfoBox" runat="server" Height="81px" Width="281px" ReadOnly="True" TextMode="MultiLine"></asp:TextBox>

        </p>

    </div>
        <br />
        <div>
            <h1>Redigere Prosjekt</h1>
            <table>
            <tr>
                <td class="auto-style6">ProsjektID: </td>
                <td class="auto-style5">
                    <asp:TextBox ID="textBoxProjectIDForEdit" runat="server"></asp:TextBox>
                </td>
            </tr>

             <tr>
                <td class="auto-style6">Nytt navn:  </td>
                <td class="auto-style5">
                    <asp:TextBox ID="textBoxNewNavn" runat="server"></asp:TextBox>
                </td>
            </tr>

                 <tr>
                <td class="auto-style6">Ny oppsummering: </td>
                <td class="auto-style5">
                    <asp:TextBox ID="textBoxNewOppsummering" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td class="auto-style6">Ny neste fase: </td>
                <td class="auto-style5">
                    <asp:TextBox ID="textBoxNewNesteFase" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>

            </table>

            <br />
            <asp:Button ID="btnLagreNewProject" runat="server" OnClick="btnLagreNewProject_Click" Text="Lagre" Width="103px" />
            <br />

            <h2>Nye Detaljer: </h2>

        </div>

             <asp:TextBox ID="textBoxNewDetails" runat="server" Height="100px" Width="220px" ReadOnly="True" TextMode="MultiLine"></asp:TextBox>

        <br />

        <div>
            <h1>Koble Team til Prosjekt</h1>
            <table>
                <tr>
                <td class="auto-style7">ProsjektID:</td>
                <td class="auto-style2">
                    <asp:TextBox ID="textBoxConnectProjectID" runat="server"></asp:TextBox>
                </td>
            </tr>
                <tr>
                <td class="auto-style7">TeamID: </td>
                <td class="auto-style2">
                    <asp:TextBox ID="textBoxConnectTeamID" runat="server"></asp:TextBox>
                </td>

                </tr>

            </table>

            <br />
            <br />
             <asp:Button ID="btnConnectTeamProject" runat="server" Text="Lagre Kobling" Width="128px" OnClick="btnConnectTeamProject_Click" />

        </div>
   
        <h3>Resultat: </h3>
        <p>
             <asp:TextBox ID="textBoxConnectResult" runat="server" Height="46px" Width="220px" ReadOnly="True" TextMode="MultiLine"></asp:TextBox>

        </p>
   

       
   

    </form>
</body>
</html>
