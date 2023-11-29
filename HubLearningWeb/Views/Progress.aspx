<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Progress.aspx.cs" Inherits="HubLearningWeb.Views.Progress" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <title></title>
    <link href="../Css/Dashboard.css" rel="stylesheet" />
    <link href="../Css/ProgressTracker.css" rel ="stylesheet" />
       <link rel="icon" type="image/x-icon" href="../favicon-32x32.png" />

    <style>
        #additionalContent {
            width: 50%;
            height: 80%;
        }
            .progress-table {
        text-align: center;
        margin: 0 auto; /* Center the table */
        color: black;
    }

    .additional-content {
        width: 80%; /* Combined width of both tables */
    }
    </style>
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
                          <asp:TemplateField HeaderText="Progress">
                            <ItemTemplate>
                                <asp:Button ID="btnComplete" runat="server" Text="Complete" CommandName="CompleteCommand"
                                    OnClientClick='<%# "return showConfirmationModal(this, " + Container.DataItemIndex + ");" %>' />
                                <asp:Button ID="btnMore" runat="server" Text="More" CssClass="more-button" CommandName="MoreCommand" />
                                <asp:HiddenField ID="hfRowIndex" runat="server" Value='<%# Container.DataItemIndex %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <div id="additionalContent" class="additional-content" runat="server" style="display: none; position: fixed; top: 50%; left: 50%; transform: translate(-50%, -50%); background-color: white; padding: 20px; border: 1px solid #ccc;">
    <table class="progress-table" style="width: 40%; float: left;">
        <tr>
            <th colspan="2">First Half</th>
        </tr>
        <tr>
            <td>Day 1</td>
            <td><asp:Button ID="btnDetails1" runat="server" Text="Details" CssClass="details-button" OnClick="Details_Click" /></td>
        </tr>
        <tr>
            <td>Day 2</td>
            <td><asp:Button ID="btnDetails2" runat="server" Text="Details" CssClass="details-button" OnClick="Details_Click" /></td>
        </tr>
        <tr>
            <td>Day 3</td>
            <td><asp:Button ID="btnDetails3" runat="server" Text="Details" CssClass="details-button" OnClick="Details_Click" /></td>
        </tr>
        <tr>
            <td>Day 4</td>
            <td><asp:Button ID="btnDetails4" runat="server" Text="Details" CssClass="details-button" OnClick="Details_Click" /></td>
        </tr>
        <tr>
            <td>Day 5</td>
            <td><asp:Button ID="btnDetails5" runat="server" Text="Details" CssClass="details-button" OnClick="Details_Click" /></td>
        </tr>
        <tr>
            <td>Day 6</td>
            <td><asp:Button ID="btnDetails6" runat="server" Text="Details" CssClass="details-button" OnClick="Details_Click" /></td>
        </tr>
        <tr>
            <td>Day 7</td>
            <td><asp:Button ID="btnDetails7" runat="server" Text="Details" CssClass="details-button" OnClick="Details_Click" /></td>
        </tr>
    </table>

    <table class="progress-table" style="width: 40%; float: right;">
        <tr>
            <th colspan="2">Second Half</th>
        </tr>
        <tr>
            <td>Day 8</td>
            <td><asp:Button ID="btnDetails8" runat="server" Text="Details" CssClass="details-button" OnClick="Details_Click" /></td>
        </tr>
        <tr>
            <td>Day 9</td>
            <td><asp:Button ID="btnDetails9" runat="server" Text="Details" CssClass="details-button" OnClick="Details_Click" /></td>
        </tr>
        <tr>
            <td>Day 10</td>
            <td><asp:Button ID="btnDetails10" runat="server" Text="Details" CssClass="details-button" OnClick="Details_Click" /></td>
        </tr>
        <tr>
            <td>Day 11</td>
            <td><asp:Button ID="btnDetails11" runat="server" Text="Details" CssClass="details-button" OnClick="Details_Click" /></td>
        </tr>
        <tr>
            <td>Day 12</td>
            <td><asp:Button ID="btnDetails12" runat="server" Text="Details" CssClass="details-button" OnClick="Details_Click" /></td>
        </tr>
        <tr>
            <td>Day 13</td>
            <td><asp:Button ID="btnDetails13" runat="server" Text="Details" CssClass="details-button" OnClick="Details_Click" /></td>
        </tr>
        <tr>
            <td>Day 14</td>
            <td><asp:Button ID="btnDetails14" runat="server" Text="Details" CssClass="details-button" OnClick="Details_Click" /></td>
        </tr>
    </table>
</div>
            </div>
        </div>
        <div class="modal fade" id="confirmationModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
    <div class="modal-dialog" role="document">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title" id="exampleModalLabel">Confirmation</h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>
            <div class="modal-body">
                Are you sure you want to complete this? (Irreversible)
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-secondary" data-dismiss="modal">No</button>
                <button type="button" class="btn btn-primary" id="btnConfirm">Yes</button>
            </div>
        </div>
    </div>
</div>
    </form>
    <script>



        function showConfirmationModal(button, rowIndex) {
            return confirm('Are you sure you want to complete this? (Irreversible)');
        }

        function showMoreContent() {
            var additionalContent = document.getElementById("additionalContent");
            additionalContent.style.display = (additionalContent.style.display === "none") ? "block" : "none";
            return false; // Prevent postback
        }

    </script>
</body>
</html>