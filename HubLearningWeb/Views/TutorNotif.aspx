<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TutorNotif.aspx.cs" Inherits="HubLearningWeb.Views.TutorNotif" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <title></title>
    <link href="../Css/Notif.css" rel="stylesheet" />
    <link href="../Css/Dashboard.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="Dashboard">
            <div class="IconNavigation">
                <div class="Icon">
                    <img src="../Medias/Images/PF_placeholder.png" class="IconImage" />
                </div>
                <div class="Navigation">
                    <div class="dropdown">
                        <button class="dropbtn">Bulletin</button>
                        <div class="dropdown-content">
                            <a href="BulletinTutor.aspx">Tutor Bulletin</a>
                            <a href="BulletinTutee.aspx">Tutee Bulletin</a>
                        </div>
                    </div>
                    <div class="dropdown">
                        <button class="dropbtn">Notifications</button>
                        <div class="dropdown-content">
                            <a href="TutorNotif.aspx">Tutor Notification</a>
                            <a href="TuteeNotif.aspx">Tutee Notification</a>
                        </div>
                    </div>
                    <div class="dropdown">
                        <button class="dropbtn">Request</button>
                        <div class="dropdown-content">
                            <a href="MakeRequest.aspx">Make a Request</a>
                        </div>
                    </div>
                    <div class="dropdown">
                        <button class="dropbtn">Account</button>
                        <div class="dropdown-content">
                            <a href="Account.aspx">Account</a>
                            <a href="Progress.aspx">Progress Tracking</a>
                        </div>
                    </div>
                </div>
            </div>
            <div class="Content">
                <div class="TitleOnly">
                    <p>TUTOR NOTIFICATION</p>
                </div>
                    <div class="MainHolderNotif">
                    <table class="NotifTable">
                        <tr class="NotifRow">
                            <td class="NotifCell">
                                <div class="DivInCell">
                                    <div class="LabelHolder">
                                    <asp:Label ID="NotifLabelName" runat="server" Text="Name: Ian Quiming"></asp:Label>&nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="NotifLabelMath" runat="server" Text="Subject: Math"></asp:Label>
                                    </div>
                                    <asp:Button ID="NotifViewButton" runat="server" Text="View" />
                                </div>
                            </td>
                        </tr>
                           <tr class="NotifRow">
                            <td class="NotifCell">
                                <div class="DivInCell">
                                    <div class="LabelHolder">
                                    <asp:Label ID="Label1" runat="server" Text="Name: Ian Quiming"></asp:Label>&nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="Label2" runat="server" Text="Subject: Math"></asp:Label>
                                    </div>
                                    <asp:Button ID="Button1" runat="server" Text="View" />
                                </div>
                            </td>
                        </tr>
                         <tr class="NotifRow">
                            <td class="NotifCell">
                                <div class="DivInCell">
                                    <div class="LabelHolder">
                                    <asp:Label ID="Label3" runat="server" Text="Name: Ian Quiming"></asp:Label>&nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="Label4" runat="server" Text="Subject: Math"></asp:Label>
                                    </div>
                                    <asp:Button ID="Button2" runat="server" Text="View" />
                                </div>
                            </td>
                        </tr>
                         <tr class="NotifRow">
                            <td class="NotifCell">
                                <div class="DivInCell">
                                    <div class="LabelHolder">
                                    <asp:Label ID="Label5" runat="server" Text="Name: Ian Quiming"></asp:Label>&nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="Label6" runat="server" Text="Subject: Math"></asp:Label>
                                    </div>
                                    <asp:Button ID="Button3" runat="server" Text="View" />
                                </div>
                            </td>
                             </tr>
                              <tr class="NotifRow">
                            <td class="NotifCell">
                                <div class="DivInCell">
                                    <div class="LabelHolder">
                                    <asp:Label ID="Label7" runat="server" Text="Name: Ian Quiming"></asp:Label>&nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="Label8" runat="server" Text="Subject: Math"></asp:Label>
                                    </div>
                                    <asp:Button ID="Button4" runat="server" Text="View" />
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </form>
</body>
</html>