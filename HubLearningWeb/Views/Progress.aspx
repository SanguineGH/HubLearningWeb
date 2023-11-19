<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Progress.aspx.cs" Inherits="HubLearningWeb.Views.Progress" %>

<!-- Your HTML file -->

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <title></title>
    <link href="../Css/Dashboard.css" rel="stylesheet" />
    <link href="../Css/ProgressTracker.css" rel="stylesheet" />
</head>
<!-- ... rest of your HTML ... -->

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
                <asp:GridView ID="progressGridView" runat="server" AutoGenerateColumns="False" OnRowCommand="progressGridView_RowCommand" DataKeyNames="TransactionID">
                    <Columns>
                        <asp:BoundField DataField="TuteeName" HeaderText="Tutee Name" SortExpression="TuteeName" />
                        <asp:BoundField DataField="TuteeStudentID" HeaderText="Tutee Student ID" SortExpression="TuteeStudentID" />
                        <asp:BoundField DataField="TutorName" HeaderText="Tutor Name" SortExpression="TutorName" />
                        <asp:BoundField DataField="TutorStudentID" HeaderText="Tutor Student ID" SortExpression="TutorStudentID" />
                        <asp:BoundField DataField="TuteeYearLevel" HeaderText="Year Level" SortExpression="TuteeYearLevel" />
                        <asp:BoundField DataField="TuteeStrand" HeaderText="Strand" SortExpression="TuteeStrand" />
                        <asp:BoundField DataField="TutorAvailability" HeaderText="Availability" SortExpression="TutorAvailability" />
                        <asp:BoundField DataField="TutorLocation" HeaderText="Location" SortExpression="TutorLocation" />
                        <asp:BoundField DataField="progress" HeaderText="Progress" SortExpression="progress" />
                        <asp:ButtonField ButtonType="Button" Text="Complete" CommandName="CompleteCommand" HeaderText="" ShowHeader="True" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </form>
</body>
</html>