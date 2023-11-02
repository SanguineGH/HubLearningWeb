<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MakeRequest.aspx.cs" Inherits="HubLearningWeb.Views.MakeRequest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
     <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <link href="../Css/Dashboard.css" rel="stylesheet" />
    <link href="../Css/MakeRequest.css" rel="stylesheet" />
    <title></title>
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
                <br />
                <div class="PostRequestHolder">
                    <div class="TopPart">
                        <div class="ImageContainer">
                        <img src="../Medias/Images/PF_placeholder.png" class="RequestImage"/>
                        </div>
                        <div class="HoldInfos">
                            <asp:Label ID="Name" runat="server" Text="Name: Ian Quimming" ></asp:Label>
                            <asp:Label ID="SID" runat="server" Text="Student ID: 19-2020" class="InfoLabel"></asp:Label>
                            <asp:Label ID="Email" runat="server" Text="Email: Ianquimming@gmail.com" class="InfoLabel"></asp:Label>
                            <asp:Label ID="Contact" runat="server" Text="Contact No.: 09123456789" class="InfoLabel"></asp:Label>
                        </div>
                    </div>
                   <%--Bottom part na dito--%>
                    <div class="BottomPart">
                          <div class="Looking">
                            <p>Looking for</p>
                            
                                <asp:RadioButton ID="ReqTutee" runat="server" Text="Tutee" GroupName="LookingFor" value="Tutee" />
                                <asp:RadioButton ID="ReqTutor" runat="server" Text="Tutor" GroupName="LookingFor" value="Tutor" />
                           
                        </div>
                        <div class="Strand" runat="server" id="StrandRadios">
                            <p>Strand</p>
                       
                                <asp:RadioButton ID="ReqStem" runat="server" Text="STEM" GroupName="Strand" value="STEM" />
                                <asp:RadioButton ID="ReqABM" runat="server" Text="ABM" GroupName="Strand" value="ABM" />
                                <asp:RadioButton ID="ReqHUMSS" runat="server" Text="HUMSS" GroupName="Strand" value="HUMSS" />
                                <asp:RadioButton ID="ReqGAS" runat="server" Text="GAS" GroupName="Strand" value="GAS" />
                                <asp:RadioButton ID="ReqTV" runat="server" Text="TechVoc" GroupName="Strand" value="TechVoc" />
               
                        </div>
                        <div class="Subject" runat="server" id="SubjectRadios">
                            <p>Subject</p>
                      
                                <asp:RadioButton ID="ReqS1" runat="server" Text="Subject 1" GroupName="Subject" value="Subject 1" />
                                <asp:RadioButton ID="ReqS2" runat="server" Text="Subject 2" GroupName="Subject" value="Subject 2" />
                                <asp:RadioButton ID="ReqS3" runat="server" Text="Subject 3" GroupName="Subject" value="Subject 3" />
                                <asp:RadioButton ID="ReqS4" runat="server" Text="Subject 4" GroupName="Subject" value="Subject 4" />
                      
                        </div>

                        <div class="Avail">
                            <p>Availability</p>
                            <asp:CheckBox ID="ReqSun" runat="server" Text="Sunday" value="Sunday" />
                            <asp:CheckBox ID="ReqMon" runat="server" Text="Monday" value="Monday" />
                            <asp:CheckBox ID="ReqTues" runat="server" Text="Tuesday" value="Tuesday" />
                            <asp:CheckBox ID="ReqWed" runat="server" Text="Wednesday" value="Wednesday" />
                            <asp:CheckBox ID="ReqThur" runat="server" Text="Thursday" value="Thursday" />
                            <asp:CheckBox ID="ReqFri" runat="server" Text="Friday" value="Friday" />
                            <asp:CheckBox ID="ReqSat" runat="server" Text="Saturday" value="Saturday" />
                        </div>
                        <div class="Location">
                            <p>Location</p>
                            <asp:CheckBox ID="ReqHome" runat="server" Text="Home" value="Home" />
                            <asp:CheckBox ID="ReqSchool" runat="server" Text="School" value="School" />
                            <asp:CheckBox ID="ReqPublic" runat="server" Text="Public Place" value="Public Place" />
                        </div>

                        <asp:Button ID="ReqSubmit" runat="server" OnClick="ReqSubmit_Click" Text="Submit" />
                    </div>
                    <%--Here end--%>
                </div>
    

            </div>
        </div>
    </form>
</body>
</html>
