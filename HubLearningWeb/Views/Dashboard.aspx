<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="HubLearningWeb.Views.Dashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <title></title>
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
                            <a href="DashBoardNotifTutor.aspx">Tutor Bulletin</a>
                            <a href="DashBoardNotifTutee.aspx">Tutee Bulletin</a>
                        </div>
                    </div>
                    <div class="dropdown">
                        <button class="dropbtn">Notifications</button>
                        <div class="dropdown-content">
                            <a href="DashBoardNotifTutor.aspx">Tutor Notification</a>
                            <a href="DashBoardNotifTutee.aspx">Tutee Notification</a>
                        </div>
                    </div>
                    <div class="dropdown">
                        <button class="dropbtn">Request</button>
                        <div class="dropdown-content">
                            <a href="DashBoardNotifTutor.aspx">Make a Request</a>
                        </div>
                    </div>
                    <div class="dropdown">
                        <button class="dropbtn">Account</button>
                        <div class="dropdown-content">
                            <a href="DashBoardNotifTutor.aspx">Account</a>
                            <a href="DashBoardNotifTutee.aspx">Progress Tracking</a>
                        </div>
                    </div>
                </div>
            </div>
            <div class="Content">

            </div>
        </div>
    </form>
</body>
</html>
