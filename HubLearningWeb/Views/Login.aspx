<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="HubLearningWeb.Views.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link href="../Css/Login.css" rel="stylesheet" />
    <link rel="icon" type="image/x-icon" href="../favicon-32x32.png" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>Login</h2>
            <table>
                <caption class="c1">Insert Data</caption>
                <tr>
                    <td class="c1">Student ID</td>
                    <td>
                        <input id="Name" type="text" name="Username" />
                    </td>
                </tr>
                <tr>
                    <td class="c1">Password</td>
                    <td>
                        <input id="Pass" type="password" name="Password" />
                    </td>
                </tr>
                <tr>
                    <td class="c2" colspan="2">
                        <asp:Button ID="submit" runat="server" Text="Submit" OnClick="submit_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
    
</body>
</html>


