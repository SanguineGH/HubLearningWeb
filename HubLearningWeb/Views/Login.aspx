<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="HubLearningWeb.Views.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Css/Login.css" rel="stylesheet" />
    <style>
        body {
            padding-top: 150px;
        }
        table {
           border: solid;
            margin: auto;
        }
        td {
           width: 50%;
           text-align: center;
           
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
          <table style="width: 30%;">
            <caption class="c1">Insert Data </caption>
            <tr>
                <td  class="c1">&nbsp;Student ID</td>
                <td>&nbsp;
                    <input id="Name" type="text"  name="Username" />
                </td>
            </tr>
            <tr>
               <td  class="c1">&nbsp;Password</td>
                <td>&nbsp;  <input id="Pass" type="password"  name="Password"/>

                </td>
            </tr>
            <tr>
                <td class="c2" colspan="2">&nbsp;<asp:Button ID="submit" runat="server" Text="Submit" OnClick="submit_Click"/>

                </td>
            </tr>
        </table>
        </div>
    </form>
</body>
</html>

