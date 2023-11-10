<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TuteeNotif.aspx.cs" Inherits="HubLearningWeb.Views.TuteeNotif" %>

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
            </div>
            <div class="Content">
                <div class="TitleOnly">
                    <p>TUTEE NOTIFICATION</p>
                </div>
                <div class="MainHolderNotif">
             <asp:Repeater ID="transactionRepeater" runat="server">
    <ItemTemplate>
        <div class="NotificationCard">
            <asp:Label ID="tutorLabel" runat="server" Text="Tutor: "></asp:Label>
            <asp:Label ID="tutorNameLabel" runat="server" Text='<%# Eval("TutorName") %>'></asp:Label>
            <br />
            <asp:Label ID="tuteeLabel" runat="server" Text="Tutee: "></asp:Label>
            <asp:Label ID="tuteeNameLabel" runat="server" Text='<%# Eval("TuteeName") %>'></asp:Label>
            <br />
            <asp:Label ID="subjectLabel" runat="server" Text="Subject: "></asp:Label>
            <asp:Label ID="subjectNameLabel" runat="server" Text='<%# Eval("Subject") %>'></asp:Label>
            <br />
            <asp:Button ID="viewMoreButton" runat="server" Text="View More" OnClick="ViewMore_Click" CommandArgument='<%# Eval("TransactionID") %>' />
        </div>
    </ItemTemplate>
</asp:Repeater>
          </div>
        </div>
    </form>
</body>
</html>